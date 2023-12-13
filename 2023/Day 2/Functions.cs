﻿using System.Text.RegularExpressions;

namespace Day_2;

public static class Functions {
    public static int PartOne(string[] lines) {
        const string pattern = @"(\d+) (\w+)";

        int gameCounter = 0;
        
        foreach (var line in lines) {
            Match gameIdMatch = Regex.Match(line, @"Game (\d+)");
            int gameId = int.Parse(gameIdMatch.Groups[1].Value);
            gameCounter += gameId;
            
            Dictionary<string, int> rgbValuesDic = new Dictionary<string, int> {
                ["red"] = 0,
                ["green"] = 0,
                ["blue"] = 0
            };
            
            string[] gameSets = line.Split(';');

            foreach (var set in gameSets) {
                MatchCollection matchColl = Regex.Matches(set, pattern);

                foreach (Match match in matchColl) {
                    string colorName = match.Groups[2].Value;
                    int rgbValue = int.Parse(match.Groups[1].Value);
                    rgbValuesDic[colorName] = rgbValue;
                }

                if (IsGamePossible(rgbValuesDic, 12, 13, 14)) continue;
                
                gameCounter -= int.Parse(gameIdMatch.Groups[1].Value);
                rgbValuesDic["red"] = 0;
                rgbValuesDic["green"] = 0;
                rgbValuesDic["blue"] = 0;
                break;
            }
        }
        
        return gameCounter;
    }

    static bool IsGamePossible(Dictionary<string, int> rgbValues, int redLimit, int greenLimit, int blueLimit) {
        return rgbValues["red"] <= redLimit && rgbValues["green"] <= greenLimit && rgbValues["blue"] <= blueLimit;
    }

    public static int PartTwo(IEnumerable<string> lines) {
        const string pattern = @"(\d+) (\w+)";

        int gameCounter = 0;
        
        foreach (var line in lines) {
            Dictionary<string, int> rgbValuesDic = new Dictionary<string, int> {
                ["red"] = 0,
                ["green"] = 0,
                ["blue"] = 0
            };
            
            string[] gameSets = line.Split(';');

            foreach (string set in gameSets) {
                MatchCollection matchColl = Regex.Matches(set, pattern);

                foreach (Match match in matchColl) {
                    string colorName = match.Groups[2].Value;
                    int rgbValue = int.Parse(match.Groups[1].Value);
                    
                    if (rgbValue > rgbValuesDic[colorName]) {
                        rgbValuesDic[colorName] = rgbValue;
                    }
                }
            }

            int gamePower = rgbValuesDic.Aggregate(1, (current, colorValuePair) => current * colorValuePair.Value);
            gameCounter += gamePower;
        }
        return gameCounter;
    }
}