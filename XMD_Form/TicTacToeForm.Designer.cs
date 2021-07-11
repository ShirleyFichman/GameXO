namespace XMD_Form
{
     public partial class TicTacToeForm
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }

               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.m_Player1Label = new System.Windows.Forms.Label();
               this.m_Player2Label = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // m_Player1Label
               // 
               this.m_Player1Label.AutoSize = true;
               this.m_Player1Label.Location = new System.Drawing.Point(236, 424);
               this.m_Player1Label.Name = "m_Player1Label";
               this.m_Player1Label.Size = new System.Drawing.Size(64, 17);
               this.m_Player1Label.TabIndex = 0;
               this.m_Player1Label.Text = "Player: 0";
               // 
               // m_Player2Label
               // 
               this.m_Player2Label.AutoSize = true;
               this.m_Player2Label.Location = new System.Drawing.Point(480, 424);
               this.m_Player2Label.Name = "m_Player2Label";
               this.m_Player2Label.Size = new System.Drawing.Size(46, 17);
               this.m_Player2Label.TabIndex = 1;
               this.m_Player2Label.Text = "label1";
               // 
               // TicTacToeForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(800, 450);
               this.Controls.Add(this.m_Player2Label);
               this.Controls.Add(this.m_Player1Label);
               this.Name = "TicTacToeForm";
               this.Text = "TicTacToeMisere";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label m_Player1Label;
          private System.Windows.Forms.Label m_Player2Label;
          private System.Windows.Forms.Button[,] m_ButtonsMatrix;
     }
}