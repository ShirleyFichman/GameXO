using System;
using System.Drawing;
using System.Windows.Forms;

namespace XMD_Form
{
    /// <summary>
    /// This is the form of the matrix and game itself
    /// </summary>
     public partial class TicTacToeForm : Form
     {
          private readonly int r_MatrixSize;
          private readonly int r_ButtonSize = 50;
          private readonly string r_Player1Name;
          private readonly string r_Player2Name;
          private GameManager m_GameManager;

          /// <summary>
          /// The constructor of the TicTacToeForm
          /// </summary>
          public TicTacToeForm(string i_Player1Name, string i_Player2Name, bool i_IsSingleGame, int i_MatrixSize)
          {
               InitializeComponent();
               r_MatrixSize = i_MatrixSize;
               r_Player1Name = i_Player1Name;
               r_Player2Name = i_Player2Name;
               m_GameManager = new GameManager(i_IsSingleGame, i_MatrixSize);
               m_GameManager.GameOver += gameOver;
               m_GameManager.StartNewGame += startNewGame;
               m_GameManager.ChangeButton += changeButtonText;
               createButtonsMatrix();
               createPlayersLabels();
               m_GameManager.NewGame();
          }

        /// <summary>
        /// This method create the buttons for the matrix
        /// </summary>
          private void createButtonsMatrix()
          {
               int buttonCounter = 1;
               m_ButtonsMatrix = new Button[r_MatrixSize, r_MatrixSize];

               for (int i = 0; i < r_MatrixSize; i++)
               {
                    for (int j = 0; j < r_MatrixSize; j++)
                    {
                         m_ButtonsMatrix[i, j] = new Button()
                         {
                              Width = r_ButtonSize, Height = r_ButtonSize,
                              Location = new Point((r_ButtonSize * i) + 2, (r_ButtonSize * j) + 2),
                              Name = i + "," + j
                         };
                         m_ButtonsMatrix[i, j].Tag = "button" + (buttonCounter++);
                         m_ButtonsMatrix[i, j].Click += matrixButtonClick;
                         Controls.Add(m_ButtonsMatrix[i, j]);
                    }
               }
          }

        /// <summary>
        /// This method creat the Players labels on the lower part of the form
        /// </summary>
          private void createPlayersLabels()
          {
               m_Player1Label.Text = r_Player1Name + ": " + m_GameManager.PlayerPoints1;
               m_Player1Label.Location = new Point(((r_ButtonSize * r_MatrixSize) / 2) - r_ButtonSize, (r_ButtonSize * r_MatrixSize) + (r_ButtonSize / 2));
               m_Player2Label.Text = r_Player2Name + ": " + m_GameManager.PlayerPoints2;
               m_Player2Label.Location = new Point(m_Player1Label.Location.X + m_Player1Label.Size.Width + 10, (r_ButtonSize * r_MatrixSize) + (r_ButtonSize / 2));
               Controls.Add(m_Player1Label);
               Controls.Add(m_Player2Label);
          }

        /// <summary>
        /// This method is what happens when a button is clicked
        /// </summary>
          private void matrixButtonClick(object sender, EventArgs e)
          {
              string buttonName = ((Control)sender).Name;
               int row = int.Parse(buttonName[0] + string.Empty) + 1;
               int col = int.Parse(buttonName[2] + string.Empty) + 1;
               m_GameManager.HumanPlayerTurn(row, col);
          }

        /// <summary>
        /// This method checks the button with the right pawn
        /// </summary>
          private void changeButtonText(int i_Row, int i_Col, string i_Pawn)
          {
               m_ButtonsMatrix[i_Row - 1, i_Col - 1].Text = i_Pawn;
          }

        /// <summary>
        /// This method is what happens when a user starts a new game
        /// </summary>
          private void startNewGame()
          {
               for (int i = 0; i < r_MatrixSize; i++)
               {
                    for (int j = 0; j < r_MatrixSize; j++)
                    {
                         m_ButtonsMatrix[i, j].Text = string.Empty;
                    }
               }

               m_Player1Label.Text = r_Player1Name + ": " + m_GameManager.PlayerPoints1;
               m_Player2Label.Text = r_Player2Name + ": " + m_GameManager.PlayerPoints2;
          }

        /// <summary>
        /// This method happens when the game has ended and then we ask the user if he would like to have another game or exit
        /// </summary>
          private void gameOver(string i_Message)
          {
               DialogResult dialogResult;

               if (i_Message != "Tie!")
               {
                    string winnerName = (m_GameManager.PlayerPoints1 > m_GameManager.PlayerPoints2) ? r_Player1Name : r_Player2Name;
                    i_Message = "The Winner is " + winnerName + "!" + "\nWould you like to play another game?";
                    dialogResult = MessageBox.Show(i_Message, "A Win!", MessageBoxButtons.YesNo);
               }
               else
               {
                    dialogResult = MessageBox.Show(i_Message + "\nWould you like to play another game?", "A Tie!", MessageBoxButtons.YesNo);
               }
               
               if(dialogResult == DialogResult.No)
               {
                    this.Close();
               }
          }
     }
}
