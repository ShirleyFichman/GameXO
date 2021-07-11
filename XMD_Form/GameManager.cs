using System;

namespace XMD_Form
{
     public delegate void GameOver(string i_Message);

     public delegate void StartNewGame();

     public delegate void ChangeButton(int i_Row, int i_Col, string i_Pawn);

     /// <summary>
     /// Contains the logic game flow and relevant objects of the game
     /// </summary>/
     public class GameManager
     {
          private readonly int r_SizeOfMatrix;
          private Matrix m_Matrix;
          private AI m_AI;
          private int m_PlayerPoints1, m_PlayerPoints2; // player_1= 'X', player_2='O'
          private bool m_IsMultiplayer;
          private int m_MovesCounter; // to check when the board if full
          private int m_CurrentPlayerNumber;

          public event GameOver GameOver;

          public event StartNewGame StartNewGame;

          public event ChangeButton ChangeButton;

          /// <summary>
          /// The constructor initiates the game with size of matrix and how many players
          /// </summary>/
          public GameManager(bool i_IsMultiplayer, int i_MatrixSize)
          {
               m_PlayerPoints1 = 0;
               m_PlayerPoints2 = 0;
               m_IsMultiplayer = i_IsMultiplayer;
               r_SizeOfMatrix = i_MatrixSize;
               if (!m_IsMultiplayer)
               {
                    m_AI = new AI();
               }
          }

          /// <summary>
          /// Creates the board and call the game to start
          /// </summary>/
          public void NewGame()
          {
               m_Matrix = new Matrix(r_SizeOfMatrix);
               m_CurrentPlayerNumber = 1;
               m_MovesCounter = 0;
               StartNewGame();
          }

          /// <summary>
          /// The flow of the AI's turn
          /// </summary>/
          public void AITurn()
          {
               int row, column;

               m_AI.AIMove(m_Matrix, m_MovesCounter, out row, out column);
               m_MovesCounter++;
               changeButton(row, column);
               checkIfGameOver(row, column);
               ChangePlayer();
          }

        /// <summary>
        /// This methodupdate the board with the move the player had and then if single game- calls to AI move
        /// </summary>
          public void HumanPlayerTurn(int i_Row, int i_Col)
          {
               if (m_Matrix.AddMove(i_Row, i_Col, m_CurrentPlayerNumber))
               {
                    m_MovesCounter++;
                    changeButton(i_Row, i_Col);
                    checkIfGameOver(i_Row, i_Col);
                    ChangePlayer();
                    if (!m_IsMultiplayer)
                    {
                         AITurn();
                    }
               } 
          }

        /// <summary>
        /// This method calls to update the button
        /// </summary>
          private void changeButton(int i_Row, int i_Col)
          {
               if(m_CurrentPlayerNumber == 1)
               {
                    ChangeButton(i_Row, i_Col, "X");
               }
               else
               {
                    ChangeButton(i_Row, i_Col, "O");
               }
          }

          /// <summary>
          /// Updates current player number
          /// </summary>/
          public void ChangePlayer()
          {
               m_CurrentPlayerNumber = m_CurrentPlayerNumber == 1 ? 2 : 1;
          }

          /// <summary>
          /// This method is what happening when a game is over- and update state of points
          /// </summary>/
          private void gameOver(string i_Message)
          {
               GameOver(i_Message);
               if (i_Message != "Tie!")
               {
                    if (m_CurrentPlayerNumber != 1)
                    {
                         m_PlayerPoints1++;
                    }
                    else
                    {
                         m_PlayerPoints2++;
                    }
               }

               NewGame();
          }

        /// <summary>
        /// This method checks if a game is over
        /// </summary>
          private void checkIfGameOver(int i_Row, int i_Col)
          {
               if (m_Matrix.CheckIfLost(m_CurrentPlayerNumber, i_Row, i_Col))
               {
                    gameOver(string.Empty);
               }
               else if (m_MovesCounter == m_Matrix.Board.Length)
               {
                    gameOver("Tie!");
               }
          }

          public int PlayerPoints1
          {
               get => m_PlayerPoints1;
               set => m_PlayerPoints1 = value;
          }

          public int PlayerPoints2
          {
               get => m_PlayerPoints2;
               set => m_PlayerPoints2 = value;
          }
     }
}
