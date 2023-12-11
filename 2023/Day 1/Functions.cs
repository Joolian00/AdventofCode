﻿using System.Text.RegularExpressions;

namespace Day_1;

public static class Functions {
    public static int PartOne(string[] lines) {
        string pattern = @"\d";
        
        int finalCalibrationValue = 0;
        
        foreach (var line in lines) {
            MatchCollection matches = Regex.Matches(line, pattern);
            string calibrationValueString = matches[0].Value + matches[^1].Value;
            finalCalibrationValue += int.Parse(calibrationValueString);
        }
        
        return finalCalibrationValue;
    }

    public static int PartTwo(IEnumerable<string> lines) {
        int finalCalibrationValue = 0;

        string pattern = @"(?=(one|two|three|four|five|six|seven|eight|nine|\d))";

        Dictionary<string, string> wordToNumberMap = new() {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
        };

        foreach (var line in lines) {
            MatchCollection matches = Regex.Matches(line, pattern);
            
            if (!wordToNumberMap.TryGetValue(matches[0].Groups[1].Value, out string value1)) {
                value1 = matches[0].Groups[1].Value;
            }


            if (!wordToNumberMap.TryGetValue(matches[^1].Groups[1].Value, out string value2)) {
                value2 = matches[^1].Groups[1].Value;
            }
            
            finalCalibrationValue += int.Parse(value1+value2);

        }
        
        return finalCalibrationValue;
    }

}