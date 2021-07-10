using System;

namespace XMDGame
{
     /// <summary>
     /// Contains the logic game flow and relevant objects of the game
     /// </summary>/
     public class GameManager
     {
          private Matrix m_Matrix;
          private AI m_AI;
          private int m_PlayerPoints1, m_PlayerPoints2; // player_1= 'X', player_2='O'
          private bool m_IsSingleGame;
          private int m_MovesCounter; // to check when the board if full
          private bool m_IsGameOver;
          private int m_CurrentPlayerNumber;
          private int m_SizeOfMatrix;

          /// <summary>
          /// The constructor initiates the game with size of matrix and how many players
          /// </summary>/
          public GameManager()
          {
               m_PlayerPoints1 = 0;
               m_PlayerPoints2 = 0;
               m_SizeOfMatrix = UIManager.GetSizeFromUser();
               m_IsSingleGame = UIManager.IsSinglePlayerGame();
               if (m_IsSingleGame)
               {
                    m_AI = new AI();
               }

               NewGame();
          }

          /// <summary>
          /// Creates the board and call the game to start
          /// </summary>/
          public void NewGame()
          {
               m_Matrix = new Matrix(m_SizeOfMatrix);
               m_CurrentPlayerNumber = 1;
               m_IsGameOver = false;
               m_MovesCounter = 0;
               runGame();
          }

          /// <summary>
          /// Have the basic flow of the game- calls to turnes until the end of the game
          /// </summary>/
          private void runGame()
          {
               while (!m_IsGameOver)
               {
                    Ex02.ConsoleUtils.Screen.Clear();
                    UIManager.PrintBoard(m_Matrix);
                    if (m_MovesCounter == m_Matrix.Board.Length)
                    {
                         if (!UIManager.EndGame("It's a tie !", m_PlayerPoints1, m_PlayerPoints2))
                         {
                              NewGame();
                         }
                    }

                    PlayerTurn();
                    ChangePlayer();
               }

               Ex02.ConsoleUtils.Screen.Clear();
               UIManager.PrintBoard(m_Matrix);
               // if the player pressed 1 it means that he wants another game
               if (!endGame()) 
               {
                    NewGame();
               }
               else
               {
                    UIManager.ExitGame();
               }
          }

          /// <summary>
          /// The flow of a player's turn - asks for AI move/ input from player
          /// </summary>/
          public void PlayerTurn()
          {
               int row, column;

               // implement AI - it's the computer's turn
               if (m_IsSingleGame && m_CurrentPlayerNumber == 2) 
               {
                    m_AI.AIMove(m_Matrix, m_MovesCounter, out row, out column);
               }
               // regular player
               else
               {
                    row = UIManager.GetIntFromPlayer(m_Matrix.GetBoardSizeInChar(), "row");
                    column = UIManager.GetIntFromPlayer(m_Matrix.GetBoardSizeInChar(), "column");
                    // here I take into consideration that the computer won't make mistakes
                    while (!m_Matrix.AddMove(row, column, m_CurrentPlayerNumber))
                    {
                         UIManager.PrintMessage("This place is already taken");
                         row = UIManager.GetIntFromPlayer(m_Matrix.GetBoardSizeInChar(), "row");
                         column = UIManager.GetIntFromPlayer(m_Matrix.GetBoardSizeInChar(), "column");
                    }
               }

               m_MovesCounter++;
               m_IsGameOver = m_Matrix.CheckIfLost(m_CurrentPlayerNumber, row, column);
          }

          /// <summary>
          /// Updates current player number
          /// </summary>/
          public void ChangePlayer()
          {
               m_CurrentPlayerNumber = m_CurrentPlayerNumber == 1 ? 2 : 1;
          }

          /// <summary>
          /// Updates points + call EndGame in UI with the right statement
          /// </summary>/
          private bool endGame()
          {
               string resultString;

               if (m_CurrentPlayerNumber == 1)
               {
                    resultString = "X Won, Congratulations!";
                    m_PlayerPoints1++;
               }
               else
               {
                    resultString = "O Won, Congratulations!";
                    m_PlayerPoints2++;
               }

               return UIManager.EndGame(resultString, m_PlayerPoints1, m_PlayerPoints2);
          }
     }
}
