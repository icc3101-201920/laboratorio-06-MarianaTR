using Laboratorio_5_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
    static class Visualizacion
    {
   
        public static void ShowHand(Hand hand)
            {
                Console.WriteLine("Hand:");
                int i = 0;
                foreach (Card card in hand.Cards)
                {
                    if (card.Type==Enums.EnumType.buff || card.Type == Enums.EnumType.bufflongRange|| card.Type == Enums.EnumType.buffmelee|| card.Type == Enums.EnumType.buffrange|| card.Type == Enums.EnumType.weather|| card.Type == Enums.EnumType.captain)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"| {0} {1} ({2}) |", i, card.Name, card.Type);
                        Console.ForegroundColor = ConsoleColor.White;
                        i++;
                    }
                    else
                    {
                        CombatCard combatCard = (CombatCard)card;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"| {0} {1} ({2}) : {3}|", i, card.Name, card.Type,combatCard.AttackPoints);
                        Console.ForegroundColor = ConsoleColor.White;
                        i++;
                    }
                }
            }

        public static void ShowDecks(List<Deck> decks)
        {
            Console.WriteLine("Select one Deck:");
            int i = 0;
            foreach(Deck deck in decks)
            {
                Console.WriteLine($"({0}) Deck {1}",i,i+1);
                i++;
            }

        }

        public static void ShowCaptains(List<SpecialCard> captains)
        {
            int i = 0;
            Console.WriteLine("Select one captain:");
            foreach (SpecialCard specialCard in captains)
            {
                if (specialCard.Type == Enums.EnumType.captain)
                {
                    Console.WriteLine($"({i}) {0} : {1}", specialCard.Name,specialCard.Effect);
                }
            }
        }

        public static void GetUserInput(int maxInput, bool stopper = false)
        {
            string input = Console.ReadLine();
            try
            {
                int d = Convert.ToInt32(input);
            }
            catch
            {
                ConsoleError("Input must be a number, try again");
            }
            if (stopper == true)
            {
                if (Convert.ToInt32(input) <= maxInput && -1 <= Convert.ToInt32(input))
                {
                    Console.WriteLine(input);
                }
                else
                {
                    ConsoleError($"The option ({input}) is not valid, try again");
                }
                
            }
            else
            {
                if (Convert.ToInt32(input) <= maxInput && 0 <= Convert.ToInt32(input))
                {
                    Console.WriteLine(input);
                }
                else
                {
                    ConsoleError($"The option ({input}) is not valid, try again");
                }
            }
            

        }

        public static void ConsoleError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static  void ShowProgramMessage(string message)
        {

            for (int i = 1; i <= 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player {i} select Deck and Captain:");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void ShowListOptions(List<string> options, string message = null)
        {
            Console.WriteLine(message);
            int i = 0;
            foreach(string op in options)
            {
                Console.WriteLine($"({i}) {op}");
            }

        }

        public static void ClearConsole()
        {
                Console.Clear();
        }

        
    }
}
