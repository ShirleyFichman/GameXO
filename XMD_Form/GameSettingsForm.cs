using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMD_Form
{
    /// <summary>
    /// The GameSettingsForm is the first form that appears on screen
    /// </summary>
     public partial class GameSettingsForm : Form
     {
          private string m_Player1Name;
          private string m_Player2Name;

        /// <summary>
        /// The constructor of Game Settings Form- the first form 
        /// </summary>
          public GameSettingsForm()
          {
               InitializeComponent();
               m_Player2TextBox.Enabled = false;
          }

        /// <summary>
        /// This method is what happens after the user click the start button
        /// </summary>
          private void startClick(object sender, EventArgs e)
          {
               try
               {
                    checkPlayerInput();
                    m_Player1Name = m_Player1TextBox.Text;
                    if (!m_Multiplayer.Checked)
                    {
                         m_Player2Name = "Computer";
                    }
                    else
                    {
                         m_Player2Name = m_Player2TextBox.Text;
                    }

                    if(m_ColsNumber.Value == m_RowsNumber.Value)
                    {
                         this.Close();
                    }

                    MessageBox.Show("Rows and Cols number should be the same ! Try again.");
               }
               catch (Exception ex)
               {
                    MessageBox.Show(ex.Message);
               }
          }

        /// <summary>
        /// This method checked if the type of game changed- multiplayer or single game
        /// </summary>
          private void isMultiplayerCheckedChanged(object sender, EventArgs e)
          {
               if (m_Multiplayer.Checked)
               {
                    m_Player2TextBox.Enabled = true;
               }
               else
               {
                    m_Player2TextBox.Enabled = false;
               }
          }

        /// <summary>
        /// This method sends a message to the user if didn't enter a player's name
        /// </summary>
          private void checkPlayerInput()
          {
               if(m_Player1TextBox.Text == string.Empty)
               {
                   throw new Exception("Enter a player 1 name !");
               }
               else if (m_Player2TextBox.Enabled && m_Player2TextBox.Text == string.Empty)
               {
                    throw new Exception("Enter a player 2 name !");
               }
          }

          public string Player1Name
          {
               get => m_Player1Name;
               set => m_Player1Name = value;
          }

          public string Player2Name
          {
               get => m_Player2Name;
               set => m_Player2Name = value;
          }

          public bool IsMultiplayer
          {
               get => m_Multiplayer.Checked;
               set => m_Multiplayer.Checked = value;
          }

          public int RowsNumber
          {
               get => Convert.ToInt32(m_RowsNumber.Value);
               set => m_RowsNumber.Value = value;
          }

          public int ColsNumber
          {
               get => Convert.ToInt32(m_ColsNumber.Value);
               set => m_ColsNumber.Value = value;
          }
     }
}
