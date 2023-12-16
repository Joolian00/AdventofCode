using System.Text.RegularExpressions;

namespace Day_1;

public static class Functions {
    public static int PartOne(string[] lines) {
        foreach (var (line, index) in lines.Select((v, i) => (v, i))) {
            Console.WriteLine($"------------------ Line {index}: {line} ------------------");
            MatchCollection digitMatches = Regex.Matches(line, @"(\d+)");
            MatchCollection symbolMatches = Regex.Matches(line, @"[^.^\d]");

            foreach (Match match in digitMatches) {
                Console.WriteLine($"Digit {match.Value}:\n{FindIndexOfFirstDigit(line, match.Value)}");
            }

            foreach (Match match in symbolMatches) {
                
                Console.WriteLine($"Symbol {match.Value}:\n{FindIndexOfSymbol(line, match.Value[0])}");
            }
        }
        
        return 0;
    }
    
    private static int FindIndexOfSymbol(string input, char targetSymbol) {
        for (int i = 0; i < input.Length; i++) {
            if (input[i] == targetSymbol) return i;
        }

        return -1;
    }

    private static int FindIndexOfFirstDigit(string input, string targetString) {

        for (int i = 0; i < input.Length - targetString.Length + 1; i++) {
            if (input[i] != targetString[0]) continue;

            bool match = true;
            
            for (int j = 1; j < targetString.Length; j++) {
                if (input[i + j] == targetString[j]) continue;
                
                match = false;
                break;
            }

            if (!match) continue;

            return i;
        }
        
        return -1;
    }

    public static int PartTwo(string[] lines) {
    
        
        return 0;
    }

}