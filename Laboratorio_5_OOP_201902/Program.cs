using Laboratorio_5_OOP_201902.Cards;
using System;
using System.Collections.Generic;

namespace Laboratorio_5_OOP_201902
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            Game game = new Game();
            game.AddDecks();
            game.AddCaptains();
            Player player = new Player();
            Board board = new Board();
            player.Board = board;
            player.Deck = game.Decks[0];
            player.Deck.Shuffle();
            player.FirstHand();
            player.ChooseCaptainCard(game.Captains[0]);
            Console.WriteLine($"Player captain card: {player.Captain.Name}\n");
            int counter = 1;
            Console.WriteLine("Player Hand:");
            foreach (Card card in player.Hand.Cards)
            {
                Console.WriteLine($"{counter++}: {card.Name}");
            }
            counter = 1;
            Console.WriteLine("\nPlayer Deck:");
            foreach (Card card in player.Deck.Cards)
            {
                Console.WriteLine($"{counter++}: {card.Name}");
            }
            
            //Test Change Card
            
            //player.ChangeCard(3);
            //counter = 1;
            //Console.WriteLine("\n New Player Hand:");
            //foreach (Card card in player.Hand.Cards)
            //{
            //    Console.WriteLine($"{counter++}: {card.Name}");
            //}
            //counter = 1;
            //Console.WriteLine("\n New Player Deck:");
            //foreach (Card card in player.Deck.Cards)
            //{
            //    Console.WriteLine($"{counter++}: {card.Name}");
            //}
            */
            Game game = new Game();
            game.Play();

            //Test draw card

            //player.DrawCard();
            //counter = 1;
            //Console.WriteLine("\n New Player Hand:");
            //foreach (Card card in player.Hand.Cards)
            //{
            //    Console.WriteLine($"{counter++}: {card.Name}");
            //}
            //counter = 1;
            //Console.WriteLine("\n New Player Deck:");
            //foreach (Card card in player.Deck.Cards)
            //{
            //    Console.WriteLine($"{counter++}: {card.Name}");
            //}


            //Test play card

            //player.PlayCard(6);
            //counter = 1;
            //Console.WriteLine("\n New Player Hand:");
            //foreach (Card card in player.Hand.Cards)
            //{
            //    Console.WriteLine($"{counter++}: {card.Name}");
            //}
            //Console.WriteLine(String.Join(", ", board.GetMeleeAttackPoints()));
            //Console.WriteLine(String.Join(", ", board.GetRangeAttackPoints()));
            //Console.WriteLine(String.Join(", ", board.GetLongRangeAttackPoints()));


        }
    }
}
