using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Day_3;

public static class Functions {
    public static int PartOne(string[] lines) {
        int sum = 0;
        foreach (var (line, lineIndex) in lines.Select((v, i) => (v, i))) {
            MatchCollection digitMatches = Regex.Matches(line, @"(\d+)");
            
            foreach (Match match in digitMatches) {
                if (!CheckForSymbol(lines, lineIndex, match.Value, match.Index)) continue;
                
                sum += int.Parse(match.Value);
            }
            
            
        }
        
        return sum;
    }

    private static bool CheckForSymbol(string[] lines, int lineNumber, string matchValue, int numIndex) {
        for (int i = -1; i < 2; i++) {
            if (lineNumber + i < 0 || lineNumber + i > lines.Length - 1) {
                continue;
            }
            for (int ii = -1; ii < matchValue.Length + 1; ii++) {
                if (numIndex + ii < 0 || numIndex + ii > lines[lineNumber].Length - 1) {
                    continue;
                }

                if (Regex.IsMatch($"{lines[lineNumber + i][numIndex + ii]}", @"[^.^\d]")) {
                    return true;
                }

            }
        }
        
        return false;
    }
    
    private class SymbolInfo
    {
        public int Count { get; set; }
        public List<int> ReferenceNumbers { get; } = new List<int>();
    }

    public static int PartTwo(string[] lines) {
        Dictionary<Tuple<int, int>, SymbolInfo> countOfAsterisksNearDigits = new();
        
        foreach (var (line, lineIndex) in lines.Select((v, i) => (v, i))) {
            MatchCollection digitMatches = Regex.Matches(line, @"(\d+)");
            
            foreach (Match match in digitMatches) {
                (bool found, int referenceLineNumber, int referenceAsteriskIndex) = CheckForAsterisk(lines, lineIndex, match.Value, match.Index);
                if (!found) continue;
                
                IncrementSymbolCount(referenceLineNumber, referenceAsteriskIndex, int.Parse(match.Value));
            }
        }


        int sum = countOfAsterisksNearDigits
            .Where(key => key.Value.Count == 2)
            .Sum(key => countOfAsterisksNearDigits[key.Key].ReferenceNumbers[0] * countOfAsterisksNearDigits[key.Key].ReferenceNumbers[1]);

        
        
        return sum;

        void IncrementSymbolCount(int lineNumber, int indexNumber, int referenceNumber)
        {
            var key = Tuple.Create(lineNumber, indexNumber);

            if (countOfAsterisksNearDigits.TryGetValue(key, out var symbolInfo))
            {
                symbolInfo.Count++;
                symbolInfo.ReferenceNumbers.Add(referenceNumber);
            }
            else
            {
                countOfAsterisksNearDigits[key] = new SymbolInfo { Count = 1, ReferenceNumbers = { referenceNumber } };
            }
        }
    }
    
    private static (bool, int, int) CheckForAsterisk(string[] lines, int lineNumber, string matchValue, int numIndex) {
        for (int i = -1; i < 2; i++) {
            if (lineNumber + i < 0 || lineNumber + i > lines.Length - 1) {
                continue;
            }
            for (int ii = -1; ii < matchValue.Length + 1; ii++) {
                if (numIndex + ii < 0 || numIndex + ii > lines[lineNumber].Length - 1) {
                    continue;
                }

                if (Regex.IsMatch($"{lines[lineNumber + i][numIndex + ii]}", @"[\*]")) {
                    return (true, lineNumber + i, numIndex+ii);
                }
            }
        }
        
        return (false, -1, -1);
    }
}