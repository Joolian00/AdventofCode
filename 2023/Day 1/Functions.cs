﻿using System.Text.RegularExpressions;

namespace Day_1;

public static class Functions {
    public static int PartOne(string[] lines) {
        string pattern = @"\d";

        List<int> calibrationValues = [];
        int finalCalibrationValue = 0;
        
        foreach (var line in lines) {
            MatchCollection matches = Regex.Matches(line, pattern);
            string calibrationValueString = matches[0].Value + matches[^1].Value;
            calibrationValues.Add(int.Parse(calibrationValueString));
        }

        foreach (var value in calibrationValues) {
            finalCalibrationValue += value;
        }
        
        return finalCalibrationValue;
    }

    public static int PartTwo(string[] lines) {
        List<int> calibrationValues = [];
        int finalCalibrationValue = 0;

        string pattern = @"(?=(one|two|three|four|five|six|seven|eight|nine|\d))";

        Dictionary<string, string> wordToNumberMap = new Dictionary<string, string> {
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
            
            calibrationValues.Add(int.Parse(value1+value2));
            
            //string calibrationValueString = matches[0].Value + matches[^1].Value;
            //calibrationValues.Add(int.Parse(calibrationValueString));
        }
        
        foreach (var value in calibrationValues) {
            finalCalibrationValue += value;
        }

        return finalCalibrationValue;
    }

}