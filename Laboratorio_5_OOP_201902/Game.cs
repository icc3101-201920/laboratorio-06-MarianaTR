using Laboratorio_5_OOP_201902.Cards;
using Laboratorio_5_OOP_201902.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Laboratorio_5_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private List<SpecialCard> captains;
        private Board boardGame;
        
        private bool endGame;
        private int turn;

        //Constructor
        public Game()
        {
            Random Random = new Random();
            players = new Player[] { new Player(), new Player() };
            int ramdom = Random.Next(0, 2);
            if (ramdom==0)
            {
                activePlayer = players[ramdom];
            }
            else
            {
                activePlayer = players[ramdom];
            }
            turn = 0;
            boardGame = new Board();
            endGame = false;
            players[0].Board = boardGame;
            players[1].Board = boardGame;
            AddDecks();
            AddCaptains();
            decks = new List<Deck>();
            captains = new List<SpecialCard>();
        }
        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public List<SpecialCard> Captains
        {
            get
            {
                return this.captains;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0 && players[1].LifePoints > 0)
            {
                return 1;
            }
            else if (players[1].LifePoints == 0 && players[0].LifePoints > 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public void Play()
        {
            foreach(Player  player in players)
            {
                List<string> optionCambiar= new List<string>() { "Change Card", "Pass" };
                Visualizacion.ShowProgramMessage($"Player {player.Id} select Deck and Captains");
                Visualizacion.ShowDecks(decks);
                int inputDeck = Visualizacion.GetUserInput(decks.Count-1);
                activePlayer.Deck = decks[inputDeck];
                player.FirstHand();
                Visualizacion.ShowCaptains(captains);
                Console.Write("---------------------------------------------------------------------------------------------------------------");
                int inputCaptain = Visualizacion.GetUserInput(decks.Count-1);
                activePlayer.ChooseCaptainCard(captains[inputCaptain]);
                Console.Write("---------------------------------------------------------------------------------------------------------------");
                Visualizacion.ShowHand(activePlayer.Hand);
                Console.Write("---------------------------------------------------------------------------------------------------------------");
                Visualizacion.ShowListOptions(optionCambiar, "Change 3 cards or ready to play:");
                int inputAnswer = Visualizacion.GetUserInput(optionCambiar.Count-1);
                switch(inputAnswer)
                {
                    case 0:
                        Visualizacion.ShowProgramMessage($"Player {player.Id} change your card");
             
                        for (int i = 0; i < 3; i++)
                        {
                            Visualizacion.ShowHand(activePlayer.Hand);
                            Visualizacion.ShowProgramMessage("Input the number of the cards you want to change (Max 3). Input -1 to stop " + i);
                            int loopAnswer = Visualizacion.GetUserInput(activePlayer.Hand.Cards.Count-1, true);
                            if (loopAnswer == -1)
                            {
                                i = 4;
                            }
                            else
                            {
                                activePlayer.ChangeCard(loopAnswer);
                            }
                        }
                        Visualizacion.ShowProgramMessage("Done those all your changes!");
                        break;

                }
                Visualizacion.ClearConsole();

            }

            throw new NotImplementedException();
        }
        public void AddDecks()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Decks.txt";
            StreamReader reader = new StreamReader(path);
            int deckCounter = 0;
            List<Card> cards = new List<Card>();
            List<Deck> decks = new List<Deck>();


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] cardDetails = line.Split(",");

                if (cardDetails[0] == "END")
                {
                    decks[deckCounter].Cards = new List<Card>(cards);
                    deckCounter += 1;
                }
                else
                {
                    if (cardDetails[0] != "START")
                    {
                        if (cardDetails[0] == nameof(CombatCard))
                        {
                            cards.Add(new CombatCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3], Int32.Parse(cardDetails[4]), bool.Parse(cardDetails[5])));
                        }
                        else
                        {
                            cards.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
                        }
                    }
                    else
                    {
                        decks.Add(new Deck());
                        cards = new List<Card>();
                    }
                }

            }

        }

        
        public void AddCaptains()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + @"\Files\Captains.txt";
            StreamReader reader = new StreamReader(path);
            List<SpecialCard> captains = new List<SpecialCard>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] cardDetails = line.Split(",");
                captains.Add(new SpecialCard(cardDetails[1], (EnumType)Enum.Parse(typeof(EnumType), cardDetails[2]), cardDetails[3]));
            }
        }
    }
}
