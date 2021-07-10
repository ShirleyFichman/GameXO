using System;

namespace XMDGame
{
     /// <summary>
     /// Logic class of the AI - implements minimax algorithm.
     /// Because of the algorithm's time complexity we limit the depth of the search for the perfect move.
     /// To make it seems like human thinking, we use random move if the outcomes are all the same.
     /// Therefore, the computer will never lose unless there is no other choice.
     /// </summary>
     public class AI
     {
          /// <summary>
          /// AIMove uses Minimax algorithm to calculate the optimal move for the AI 
          /// by counting all possible outcomes for the next move. Uses random move if the outcomes are all the same.
          /// </summary>
          /// <param name="i_Matrix"> The matrix to check. </param>
          /// <param name="i_MoveCounter"> Number of moves made in the game this far. </param>
          /// <param name="o_Row"> The row of the cell that is checked currently. </param>
          /// <param name="o_Column"> The column of the cell that is checked currently.</param>
          public void AIMove(Matrix i_Matrix, int i_MoveCounter, out int o_Row, out int o_Column)
          {
               int bestMoveScore = int.MinValue;
               o_Row = int.MinValue;
               o_Column = int.MinValue;
               int minDepth = findMaxDepth(i_Matrix.Board.GetLength(0));
               for (int i = 1; i <= i_Matrix.Board.GetLength(0); i++)
               {
                    for (int j = 1; j <= i_Matrix.Board.GetLength(0); j++)
                    {
                         // Is the spot available?
                         if (i_Matrix.GetSingleCell(i, j) == ' ')
                         {
                              i_Matrix.AddMove(i, j, 2);
                              int moveScore = minimaxRec(i_Matrix, 0, false, i_MoveCounter + 1, minDepth, i, j);
                              i_Matrix.RemoveMove(i, j);
                              if (moveScore > bestMoveScore)
                              {
                                   bestMoveScore = moveScore;
                                   o_Row = i;
                                   o_Column = j;
                              }
                         }
                    }
               }

               if (bestMoveScore == 0)
               {
                    randomMove(ref i_Matrix, out o_Row, out o_Column);
               }

               i_Matrix.AddMove(o_Row, o_Column, 2);
          }

          /// <summary>
          /// Limits the depth of the algorithm's search to avoid long time complexity. depends on board size.
          /// </summary>
          /// <param name="i_BoardSize"> The board size. </param>
          /// <returns> The maximum depth to search. </returns>
          private int findMaxDepth(int i_BoardSize) 
          {
               int minDepth = 2;
               if(i_BoardSize == 3)
               {
                    minDepth = 9;
               }
               else if(i_BoardSize == 4)
               {
                    minDepth = 4;
               }
               else if(i_BoardSize == 5 || i_BoardSize == 6)
               {
                    minDepth = 3;
               }

               return minDepth;
          }

          /// <summary>
          /// The recursive helper function for the minimax main function.
          /// </summary>
          /// <param name="i_Matrix"> The matrix to check. </param>
          /// <param name="i_Depth"> The depth of the "next steps" tree the function is currently in.</param>
          /// <param name="i_IsMaximizing"> True if the function checks for the best move for the AI,
          /// false if checks for worst move for human (max/min options). </param>
          /// <param name="i_MoveCounter"> Number of moves made in the game this far. </param>
          /// <param name="i_MaxDepth"> The maximum depth the algorithm will go. </param>
          /// <param name="i_Row"> The row of the cell that is checked currently. </param>
          /// <param name="i_Column"> The column of the cell that is checked currently.</param>
          /// <returns> The total score calculated for the given move. </returns>
          private int minimaxRec(Matrix i_Matrix, int i_Depth, bool i_IsMaximizing, int i_MoveCounter, int i_MaxDepth, int i_Row, int i_Column)
          {
               if (i_Matrix.CheckIfLost(2, i_Row, i_Column))
               {
                    return -1;
               }
               else if (i_Matrix.CheckIfLost(1, i_Row, i_Column))
               {
                    return 1;
               }

               if (i_Matrix.Board.Length == i_MoveCounter || i_Depth == i_MaxDepth)
               {
                    return 0;
               }

               int bestScore = i_IsMaximizing ? int.MinValue : int.MaxValue;
               int playerNumber = i_IsMaximizing ? 2 : 1;
               for (int i = 1; i <= i_Matrix.Board.GetLength(0); i++)
               {
                    for (int j = 1; j <= i_Matrix.Board.GetLength(0); j++)
                    {
                         // Is the spot available?
                         if (i_Matrix.GetSingleCell(i, j) == ' ')
                         {
                              i_Matrix.AddMove(i, j, playerNumber);
                              int score = minimaxRec(i_Matrix, i_Depth + 1, !i_IsMaximizing, i_MoveCounter + 1, i_MaxDepth, i, j);
                              i_Matrix.RemoveMove(i, j);
                              bestScore = i_IsMaximizing ? Math.Max(score, bestScore) : Math.Min(score, bestScore);
                         }
                    }
               }

               return bestScore;
          }

          /// <summary>
          /// Chooses a random cell and checks if its free.
          /// </summary>
          /// <param name="io_Matrix"> The matrix. </param>
          /// <param name="o_Row"> Out parameter for the chosen row. </param>
          /// <param name="o_Column"> Out parameter for the chosen column. </param>
          private void randomMove(ref Matrix io_Matrix, out int o_Row, out int o_Column)
          {
               do
               {
                    Random rand = new Random();
                    o_Row = rand.Next(1, io_Matrix.Board.GetLength(0) + 1);
                    o_Column = rand.Next(1, io_Matrix.Board.GetLength(0) + 1);
               }
               while (!io_Matrix.AddMove(o_Row, o_Column, 2));
          }
     }
}
