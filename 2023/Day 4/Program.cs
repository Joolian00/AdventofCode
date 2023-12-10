using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
 
namespace Day_4;
internal class Program {
    public static void Main() {
        string[] lines = File.ReadAllLines("input.txt");

        StoreCards(lines, out List<Card> cards);

        Console.WriteLine($"Total Number of cards: {cards.Count}");
        /*foreach (var card in cards) {
            Console.WriteLine($"score of card {card.CardId}: {card.GetScore()}");
        }*/

        //Card cardId3 = cards.FirstOrDefault(card => card.CardId == 3);
        //int index = cards.FindIndex(card => card.CardId == 3);
        List<int> indexes = new List<int>();
        
        for (int i = 2; i < 6; i++) {
            indexes.Add(i);
        }
        
        for (int i = 0; i < cards.Count; i++) {
            short counter = 0;

            int currentIndex = indexes[0];
            
            short score = cards[currentIndex].GetScore();
            Console.WriteLine($"Score of card {cards[currentIndex].CardId}: {score}");
            while (counter < score) {
                int index = cards.FindIndex(card => card.CardId == currentIndex);
                Console.WriteLine($"Creating copy of card {cards[index].CardId} at index {index}");
                //Console.WriteLine("Card not copied, copying card");
                cards.Insert(index, cards[index]);
                cards[index].CopiedCard = true;
                
                counter++;
                currentIndex++;
            }
            
            indexes.RemoveAt(0);

        }
        
        //Console.WriteLine($"Card with Id {cardId3.CardId} has index {index}");



    }

    static void CopyCards(List<Card> cards, out List<Card> newCards) {
        newCards = new List<Card>();

        foreach (var card in cards) {
            short score = card.GetScore();

            while (score > 0) {
                score--;
                
            }

        }
    }
    static void StoreCards(string[] lines, out List<Card> cards) {
        cards = new List<Card>();
        
        foreach (var line in lines) {
            cards.Add(new Card(line));
        }
    }

}
    