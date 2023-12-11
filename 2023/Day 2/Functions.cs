﻿using System.Text.RegularExpressions;

namespace Day_2;

public static class Functions {
    public static int PartOne(string[] lines) {
        string[] patterns = new[]
        {
            @"(\d+) (blue)",  
            @"(\d+) (red)",
            @"(\d+) (green)"
        };

        foreach (var line in lines) {
            Console.WriteLine(line);
            
            foreach (var pattern in patterns) {
                MatchCollection matches = Regex.Matches(line, pattern);
                int totalAmount = 0;
                
                
                
            }
            
        }

        
        
        return 0;
    }

    public static int PartTwo(IEnumerable<string> lines) {
        
        
        return 0;
    }

}