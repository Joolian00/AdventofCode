using System.Text.RegularExpressions;

namespace Day_1;

public static class Functions {
    public static int PartOne(string[] lines) {
        int sum = 0;
        foreach (var (line, lineIndex) in lines.Select((v, i) => (v, i))) {
            Console.WriteLine($"------------------ Line {lineIndex}: {line} ------------------");
            MatchCollection digitMatches = Regex.Matches(line, @"(\d+)");
            

            foreach (Match match in digitMatches) {
                for (int i = 0; i < match.Value.Length; i++) {
                    if (CheckIfSymbolAroundDigit(lines, lineIndex, match.Value, FindIndexOfFirstDigit(line, match.Value) + i)) {
                        sum += int.Parse(match.Value);

                        break;

                    }
                    //Console.WriteLine(CheckIfSymbolAroundDigit(lines, lineIndex, match.Value, FindIndexOfFirstDigit(line, match.Value) + i));

                }
                Console.WriteLine("__________________________");
                //Console.WriteLine($"Symbol around digit: {match.Value} {CheckIfSymbolAroundDigit(lines, lineIndex, match.Value, FindIndexOfFirstDigit(line, match.Value))}");
            }
            
        }
        
        return sum;
    }

    private static bool CheckIfSymbolAroundDigit(string[] lines, int currentLine, string matchValue, int index) {
        for (int i = -1; i < 2; i++) {
            for (int ii = -1; ii < 2; ii++) {
                // Check for valid indices to avoid going out of bounds
                if (currentLine + i >= 0 && currentLine + i < lines.Length && index + ii >= 0 && index + ii < lines[currentLine].Length) {
                    Console.Write(lines[currentLine + i][index + ii]);
                    bool isMatch = Regex.IsMatch($"{lines[currentLine + i][index + ii]}", @"[^.^\d]");
                    if (isMatch) return true;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        
        /*if (currentLine > 0) {
            if (index > 0) {
                Console.Write($"{lines[currentLine - 1][index - 1]}");
            }
            Console.Write($"{lines[currentLine - 1][index]}");
            if (index < lines[currentLine - 1].Length-1) {
                Console.Write($"{lines[currentLine - 1][index + 1]}");
            }
            Console.Write("\n");
        }

        if (index > 0) {
            Console.Write($"{lines[currentLine][index - 1]}");
        }
        Console.Write($"{lines[currentLine][index]}");
        if (index < lines[currentLine].Length-1) {
            Console.Write($"{lines[currentLine][index + 1]}");
        }
        Console.Write("\n");
        if (currentLine < lines.Length - 1) {
            if (index > 0) {
                Console.Write($"{lines[currentLine+ 1][index - 1]}");
            }
            Console.Write($"{lines[currentLine+ 1][index]}");
            if (index < lines[currentLine+ 1].Length-1) {
                Console.Write($"{lines[currentLine+ 1][index + 1]}");
            }
            Console.Write("\n");
        }*/
        
        return false;
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