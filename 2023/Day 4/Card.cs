using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_4;

internal class Card {
    public readonly short CardId;
    public readonly List<short> CardNumbers;
    public readonly List<short> WinningNumbers;

    public bool CopiedCard = false;

    public Card(string line) {
        GetRelevantData(line, out CardId, out CardNumbers, out WinningNumbers);
    }
        
    static void GetRelevantData(string line,out short cardId, out List<short> cardNumbers, out List<short> winningNumbers) {
        cardNumbers = new List<short>();
        winningNumbers = new List<short>();
            
        cardId = short.Parse(Regex.Match(line, @"Card (\d+)").Groups[1].Value);
           
        line = line.Substring(line.IndexOf(':') + 1).Trim();
        string[] rawCardData = line.Split('|');
           
        MatchCollection cardMatches = Regex.Matches(rawCardData[0], @"\d+");
        MatchCollection winningMatches = Regex.Matches(rawCardData[1], @"\d+");

        foreach (var match in cardMatches) {
            short number = short.Parse(match.ToString());
            cardNumbers.Add(number);
        }

        foreach (var match in winningMatches) {
            short number = short.Parse(match.ToString());
            winningNumbers.Add(number);
        }
           
    }

    public short GetScore() {
        short score = 0;

        foreach (var cardNumber in CardNumbers) {
            foreach (var winningNumber in WinningNumbers) {
                if (cardNumber == winningNumber) {
                    score++;
                }
            }
        }
            
        return score;
    }
}