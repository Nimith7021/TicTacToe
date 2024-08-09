using System.Net.Http.Headers;

namespace TicTacToe
{
    internal class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
        static int noOfTurns = 0;
        const int MAX_TURNS = 9;

        
        static void Main(string[] args)
        {
            DrawBoard();
            while (true) {

                Console.WriteLine("PLAYER 1 TURN");
                int playerChoice = Convert.ToInt32(Console.ReadLine());
                if(playerChoice<0 || playerChoice > 9)
                {
                    Console.WriteLine("Invalid Choice Enter Again");
                    continue;
                }
                if (board[playerChoice]!='X' && board[playerChoice] != 'O')
                {
                    board[playerChoice] = 'X';
                    noOfTurns++;
                }
                else
                {
                    Console.WriteLine("Spot already Occupied Enter Again");
                    continue;
                }

                DrawBoard();
                if (CheckIfWin('X'))
                {
                    Console.WriteLine("Player 1 Wins !!!");
                    break;
                }
                else if (noOfTurns == MAX_TURNS)
                {
                    Console.WriteLine("Draw!");
                    break;
                }

                Retry:
                Console.WriteLine("PLAYER 2 TURN");
                playerChoice = Convert.ToInt32(Console.ReadLine());
                if (playerChoice < 0 || playerChoice > 9)
                {
                    Console.WriteLine("Invalid Choice Enter Again");
                    continue;
                }
                if (board[playerChoice] != 'X' && board[playerChoice] != 'O')
                {
                    board[playerChoice] = 'O';
                    noOfTurns++;
                }
                else
                {
                    Console.WriteLine("Spot already Occupied Enter Again");
                    goto Retry;
                }

                DrawBoard();
                if (CheckIfWin('O'))
                {
                    Console.WriteLine("Player 2 Wins !!!");
                    break;
                }


            }
        }

        static void DrawBoard()
        {
            Console.WriteLine(" {0} | {1} | {2}", board[0] , board[1] , board[2]);
            Console.WriteLine(" --|-- |--");
            Console.WriteLine(" {0} | {1} | {2}", board[3], board[4], board[5]);
            Console.WriteLine(" --|-- |--");
            Console.WriteLine(" {0} | {1} | {2}", board[6], board[7], board[8]);
            Console.WriteLine(" --|-- |-- \n");
        }

        static bool CheckIfWin(char ch) {

            if( (board[0]==  ch && board[1] == ch && board[2] == ch) ||
                (board[3] == ch && board[4] == ch && board[5] == ch) ||
                (board[6] == ch && board[7] == ch && board[8] == ch) ||
                (board[0] == ch && board[3] == ch && board[6] == ch) ||
                (board[1] == ch && board[4] == ch && board[7] == ch) ||
                (board[2] == ch && board[5] == ch && board[8] == ch) ||
                (board[0] == ch && board[4] == ch && board[8] == ch) ||
                (board[2] == ch && board[4] == ch && board[6] == ch))
                return true;
            return false;
        }
    }
}
