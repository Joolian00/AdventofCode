using System.Text.RegularExpressions;

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

        string pattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

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
            
            Console.WriteLine(line);
            
            
            if (wordToNumberMap.TryGetValue(matches[0].Value, out string value1)) {
                
            }
            else {
                value1 = matches[0].Value;
            }

            if (wordToNumberMap.TryGetValue(matches[^1].Value, out string value2)) {
                
            }
            else {
                value2 = matches[^1].Value;
            }
            Console.WriteLine(value1 + " and " + value2);
            
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