using System;

namespace MorpionExtra
{
    public class Board
    {
        const string FREE = "■";
        const string X = "X";
        const string O = "O";

        string[,] board = new string[3, 3];

        public Board()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = FREE;

                }

            }
        }

        internal bool IsSquareFree(int x, int y)
        {
            return board[x, y] == FREE;
        }

        internal bool Draw(Player player1, int x, int y)
        {
            string symbol = "Y";
            if (player1.isCross)
                symbol = "X";


            board[x, y] = symbol;


            //Check if won
            bool row=false;
            bool column=false;
            bool diagonal= board[0, 0] == symbol;

            bool result = false;
            //Check row
            for (int i = 0; i < board.GetLength(0);i++)
            {
                row = board[i, 0] == symbol;
                column = board[0, i] == symbol;

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    row = row && board[i, j] == symbol;
                    column = column && board[j, i] == symbol;

                    if (i == j)
                    {
                        diagonal = diagonal && board[i, j] == symbol;
                    }
                }

                result= row || column;
                if (result)
                    return true;
            }
            if (diagonal)
                return true;

            return false;


        }
    }
}