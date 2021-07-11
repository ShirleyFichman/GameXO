using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMD_Form
{
     public static class Program
     {
          /// <summary>
          /// The main entry point for the application.
          /// </summary>
          [STAThread]
          public static void Main()
          {
               Application.EnableVisualStyles();
               Application.SetCompatibleTextRenderingDefault(false);
               GameSettingsForm gameSettingsForm = new GameSettingsForm();
               Application.Run(gameSettingsForm);
               Application.Run(new TicTacToeForm(gameSettingsForm.Player1Name, gameSettingsForm.Player2Name, gameSettingsForm.IsMultiplayer, gameSettingsForm.RowsNumber));
          }
     }
}
