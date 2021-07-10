using System;
using System.Collections.Generic;
using System.Text;

namespace XMDGame
{
     /// <summary>
     /// UIManager handles all related to user's interface and I/O.
     /// </summary>
     public static class UIManager
     {
          /// <summary> Gets a board size from the user. </summary>
          /// <returns> The size from the user. </returns>
          public static int GetSizeFromUser()
          {
               Console.WriteLine("Please Enter board size between 3-9:");
               string usersize = Console.ReadLine();
               while (!checkUserInput(usersize, '3', '9'))
               {
                    Console.WriteLine("Wrong input! Please Enter board size between 3-9:");
                    usersize = Console.ReadLine();
               }

               return int.Parse(usersize);
          }

          /// <summary>
          /// Checks if user's input is an int and that is in the given range. also Checks if the user pressed Q for quitting the game.
          /// </summary>
          /// <param name="i_UserInput"> The user's given Input. </param>
          /// <param name="i_MinValue"> The minimum value for the range. </param>
          /// <param name="i_MaxValue"> The Maximum value for the range. </param>
          /// <returns> True if input is valid, false otherwise. </returns>
          private static bool checkUserInput(string i_UserInput, char i_MinValue, char i_MaxValue)
          {
               char input = char.MinValue;
               if (i_UserInput.Length == 1)
               {
                    input = i_UserInput[0];
                    if (input == 'Q' || input == 'q')
                    {
                         ExitGame();
                    }
               }

               return char.IsDigit(input) && input >= i_MinValue && input <= i_MaxValue;
          }

          /// <summary>
          /// Asks the user if he wants to play vs the computer or vs another player.
          /// </summary>
          /// <returns> True if it's a single game, false otherwise. </returns>
          public static bool IsSinglePlayerGame()
          {
               Console.WriteLine("Please Enter:"); ////FIND ELEGANT WAY NOT TO REPEAT SAME LINES
               Console.WriteLine("1 - One player game.");
               Console.WriteLine("2 - Two players game.");
               string userInput = Console.ReadLine();
               while (!checkUserInput(userInput, '1', '2'))
               {
                    Console.WriteLine("Wrong input! Please Enter:");
                    Console.WriteLine("1 - One player game.");
                    Console.WriteLine("2 - Two players game.");
                    userInput = Console.ReadLine();
               }

               return userInput[0] == '1';
          }

          /// <summary>
          /// Prints a given board.
          /// </summary>
          /// <param name="i_Board"> The board to print. </param>
          public static void PrintBoard(Matrix i_Board)
          {
               Console.Write("  ");
               for (int i = 1; i <= i_Board.Board.GetLength(0); i++)
               {
                    Console.Write("{0}   ", i);
               }

               Console.WriteLine();
               for (int i = 1; i <= i_Board.Board.GetLength(0); i++)
               {
                    Console.Write("{0}|", i);
                    for (int j = 0; j < i_Board.Board.GetLength(0); j++)
                    {
                         Console.Write(" {0} |", i_Board.GetSingleCell(i, j + 1));
                    }

                    Console.WriteLine();
                    Console.Write(" ");
                    for (int j = 0; j < (i_Board.Board.GetLength(0) * 4) + 1; j++)
                    {
                         Console.Write("=");
                    }

                    Console.WriteLine();
               }
          }

          /// <summary>
          /// Gets row/column number from user.
          /// </summary>
          /// <param name="i_MaxSize"> Max size for the input. </param>
          /// <param name="i_RequestedLine"> Should be "row"/"column" for output line. </param>
          /// <returns> Number of row/column - not index. </returns>
          public static int GetIntFromPlayer(char i_MaxSize, string i_RequestedLine)
          {
               Console.WriteLine("Please enter {0} number for your pawn: ", i_RequestedLine);
               string userInput = Console.ReadLine();
               while (!checkUserInput(userInput, '1', i_MaxSize))
               {
                    Console.WriteLine("Wrong input! Please enter {0} number for your pawn: ", i_RequestedLine);
                    userInput = Console.ReadLine();
               }

               return int.Parse(userInput);
          }

          /// <summary>
          /// Prints the overall results for the game and asks if the user wants another game.
          /// </summary>
          /// <param name="i_Statment"> Should be "You lost."/"It's a tie!"/"congratulations! You won" for output line. </param>
          /// <param name="i_PlayerOneScore"> Player's 1 score. </param>
          /// <param name="i_PlayerTwoScore"> Player's 2 score. </param>
          /// <returns> Returns false if the player wants another game, true otherwise. </returns>
          public static bool EndGame(string i_Statment, int i_PlayerOneScore, int i_PlayerTwoScore)
          {
               Console.WriteLine(i_Statment);
               Console.WriteLine("Score: X = {0} O = {1}", i_PlayerOneScore, i_PlayerTwoScore);
               Console.WriteLine("Do you want to play another game? Enter 1 for yes or 0 for no.");
               string userInput = Console.ReadLine();
               while (!checkUserInput(userInput, '0', '1'))
               {
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine("Do you want to play another game? Enter 1 for yes or 0 for no.");
                    userInput = Console.ReadLine();
               }

               return !(int.Parse(userInput) == 1);
          }

          /// <summary> Prints given message. </summary>
          /// <param name="i_Message"> The message to print. </param>
          public static void PrintMessage(string i_Message)
          {
               Console.WriteLine(i_Message);
          }

          /// <summary> Exits from the application. </summary>
          public static void ExitGame()
          {
               PrintMessage("GoodBye!");
               Environment.Exit(0);
          }
     }
}