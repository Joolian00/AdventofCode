using System.Diagnostics;
using Day_1;

List<string> fileSelection = ["testInput.txt", "input.txt"];

string[] lines = File.ReadAllLines(fileSelection[0]);


PrintHorizontalLine('-', 30);
var watch = Stopwatch.StartNew();

Console.WriteLine($"Solution for Part one: {Functions.PartOne(lines)} {ElapsedTime()}");
Console.WriteLine($"Solution for Part two: {Functions.PartTwo(lines)} {ElapsedTime()}");

PrintHorizontalLine('-', 30);
return;

static void PrintHorizontalLine(char character, int length)
{
    string line = new(character, length);
    Console.WriteLine(line);
}

string ElapsedTime() {
    var elapsed = watch.ElapsedMilliseconds;
    watch.Restart();

    return $"{elapsed}ms";
}



