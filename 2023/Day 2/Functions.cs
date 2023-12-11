﻿using System.Text.RegularExpressions;

namespace Day_2;

public static class Functions {
    public static int PartOne(string[] lines) {
        string[] patterns = new[]
        {
            @"(\d+) (red)",  
            @"(\d+) (green)",
            @"(\d+) (blue)"
        };

        Match gameIDMatch;

        int gameCounter = 0;
        
        foreach (var line in lines) {
            int[] rgbValues = new[] { 0, 0, 0 };
            gameIDMatch = Regex.Match(line, @"Game (\d+)");
        
            for (int j = 0; j < patterns.Length; j++) {
                MatchCollection matches = Regex.Matches(line, patterns[j]);
            
                for (int i = 0; i < matches.Count; i++) {
                    rgbValues[j] += int.Parse(matches[i].Groups[1].Value);
                }
            }

            if (!(rgbValues[0] > 12 || rgbValues[1] > 13 || rgbValues[2] > 14)) {
                Console.WriteLine($"Game number {gameIDMatch.Groups[1].Value} is possible");
                
                gameCounter += int.Parse(gameIDMatch.Groups[1].Value);
            }
        }

        
        
        return gameCounter;
    }

    public static int PartTwo(IEnumerable<string> lines) {
        
        
        return 0;
    }

}