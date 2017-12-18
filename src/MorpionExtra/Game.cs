using System;
using System.Collections.Generic;

namespace MorpionExtra
{

    public class Game
    {
        private Form1 ui;
        private List<Player> players;
        private Board board;
        int round;

        public Game()
        {
            players = new List<Player>(2);
            board = new Board();
        }

        public Board Board { get => board; set => board = value; }
        public List<Player> Players { get => players;}

        public void SetUi(Form1 ui)
        {
            this.ui = ui;
        }
        public void Start()
        {

            //GUI
            for (int i = 0; i < 3; i++)
            {
                
                for (int j = 0; j < 3; j++)
                {
                    Console.SetCursorPosition(i,j);
                    Console.Write("■");
                }

            }
            Console.WriteLine();

            while (true)
            {
                round++;

                foreach (Player player in players)
                {
                    int[] xY;

                    //Chercher un mouvement valide
                    do
                    {
                        //GUI
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine();

                        xY = player.NextMove();
                       
                    } while (xY==null || !board.IsSquareFree(xY[0], xY[1]));

                    player.ResetNextMoveFromUI();

                    //GUI
                    Console.SetCursorPosition(xY[1], xY[0]);
                    Console.Write((player.isCross ? "X" : "0"));
                    ui.Draw(player, xY[0], xY[1]);


                    //Jouer et vérifier si mouvement gagnant
                    bool hasWon = board.Draw(player, xY[0], xY[1]);

                    //Informer le mouvement à l'autre joueur
                    //Player otherPlayer = GetOpponent(player);
                    //otherPlayer.NotifyMove(xY);

                    if (hasWon)
                    {
                        Console.WriteLine("{0} a gagné !", player.Name);
                        break;
                    }
                }
            }
        }

        Player GetOpponent(Player player)
        {
            return null;
        }

        internal void AddPlayer(Player human)
        {
            players.Add(human);
        }
    }
}