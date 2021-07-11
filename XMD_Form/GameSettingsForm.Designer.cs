namespace XMD_Form
{
     public partial class GameSettingsForm
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
               this.m_PlayersLabel = new System.Windows.Forms.Label();
               this.m_Player1Label = new System.Windows.Forms.Label();
               this.m_Player1TextBox = new System.Windows.Forms.TextBox();
               this.m_Player2Label = new System.Windows.Forms.Label();
               this.m_Player2TextBox = new System.Windows.Forms.TextBox();
               this.m_Multiplayer = new System.Windows.Forms.CheckBox();
               this.m_BoardSize = new System.Windows.Forms.Label();
               this.m_RowsLabel = new System.Windows.Forms.Label();
               this.m_RowsNumber = new System.Windows.Forms.NumericUpDown();
               this.m_ColsLabel = new System.Windows.Forms.Label();
               this.m_ColsNumber = new System.Windows.Forms.NumericUpDown();
               this.button1 = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.m_RowsNumber)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.m_ColsNumber)).BeginInit();
               this.SuspendLayout();
               // 
               // m_PlayersLabel
               // 
               this.m_PlayersLabel.AutoSize = true;
               this.m_PlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_PlayersLabel.Location = new System.Drawing.Point(12, 9);
               this.m_PlayersLabel.Name = "m_PlayersLabel";
               this.m_PlayersLabel.Size = new System.Drawing.Size(70, 20);
               this.m_PlayersLabel.TabIndex = 0;
               this.m_PlayersLabel.Text = "Players:";
               this.m_PlayersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // m_Player1Label
               // 
               this.m_Player1Label.AutoSize = true;
               this.m_Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_Player1Label.Location = new System.Drawing.Point(54, 46);
               this.m_Player1Label.Name = "m_Player1Label";
               this.m_Player1Label.Size = new System.Drawing.Size(75, 20);
               this.m_Player1Label.TabIndex = 1;
               this.m_Player1Label.Text = "Player 1:";
               // 
               // m_Player1TextBox
               // 
               this.m_Player1TextBox.Location = new System.Drawing.Point(139, 46);
               this.m_Player1TextBox.Name = "m_Player1TextBox";
               this.m_Player1TextBox.Size = new System.Drawing.Size(192, 22);
               this.m_Player1TextBox.TabIndex = 2;
               // 
               // m_Player2Label
               // 
               this.m_Player2Label.AutoSize = true;
               this.m_Player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_Player2Label.Location = new System.Drawing.Point(54, 88);
               this.m_Player2Label.Name = "m_Player2Label";
               this.m_Player2Label.Size = new System.Drawing.Size(75, 20);
               this.m_Player2Label.TabIndex = 3;
               this.m_Player2Label.Text = "Player 2:";
               // 
               // m_Player2TextBox
               // 
               this.m_Player2TextBox.Location = new System.Drawing.Point(139, 88);
               this.m_Player2TextBox.Name = "m_Player2TextBox";
               this.m_Player2TextBox.Size = new System.Drawing.Size(192, 22);
               this.m_Player2TextBox.TabIndex = 4;
               // 
               // m_Multiplayer
               // 
               this.m_Multiplayer.AutoSize = true;
               this.m_Multiplayer.Location = new System.Drawing.Point(25, 90);
               this.m_Multiplayer.Name = "m_IsSingleGame";
               this.m_Multiplayer.Size = new System.Drawing.Size(18, 17);
               this.m_Multiplayer.TabIndex = 5;
               this.m_Multiplayer.UseVisualStyleBackColor = true;
               this.m_Multiplayer.CheckedChanged += new System.EventHandler(this.isMultiplayerCheckedChanged);
               // 
               // m_BoardSize
               // 
               this.m_BoardSize.AutoSize = true;
               this.m_BoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_BoardSize.Location = new System.Drawing.Point(21, 142);
               this.m_BoardSize.Name = "m_BoardSize";
               this.m_BoardSize.Size = new System.Drawing.Size(97, 20);
               this.m_BoardSize.TabIndex = 6;
               this.m_BoardSize.Text = "Board Size:";
               this.m_BoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // m_RowsLabel
               // 
               this.m_RowsLabel.AutoSize = true;
               this.m_RowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_RowsLabel.Location = new System.Drawing.Point(59, 180);
               this.m_RowsLabel.Name = "m_RowsLabel";
               this.m_RowsLabel.Size = new System.Drawing.Size(56, 20);
               this.m_RowsLabel.TabIndex = 7;
               this.m_RowsLabel.Text = "Rows:";
               this.m_RowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // m_RowsNumber
               // 
               this.m_RowsNumber.Location = new System.Drawing.Point(139, 180);
               this.m_RowsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
               this.m_RowsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
               this.m_RowsNumber.Name = "m_RowsNumber";
               this.m_RowsNumber.Size = new System.Drawing.Size(43, 22);
               this.m_RowsNumber.TabIndex = 8;
               this.m_RowsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
               // 
               // m_ColsLabel
               // 
               this.m_ColsLabel.AutoSize = true;
               this.m_ColsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.m_ColsLabel.Location = new System.Drawing.Point(220, 180);
               this.m_ColsLabel.Name = "m_ColsLabel";
               this.m_ColsLabel.Size = new System.Drawing.Size(48, 20);
               this.m_ColsLabel.TabIndex = 9;
               this.m_ColsLabel.Text = "Cols:";
               this.m_ColsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // m_ColsNumber
               // 
               this.m_ColsNumber.Location = new System.Drawing.Point(288, 178);
               this.m_ColsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
               this.m_ColsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
               this.m_ColsNumber.Name = "m_ColsNumber";
               this.m_ColsNumber.Size = new System.Drawing.Size(43, 22);
               this.m_ColsNumber.TabIndex = 10;
               this.m_ColsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
               // 
               // button1
               // 
               this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.button1.Location = new System.Drawing.Point(63, 230);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(268, 36);
               this.button1.TabIndex = 11;
               this.button1.Text = "Start!";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.startClick);
               // 
               // GameSettingsForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(385, 307);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.m_ColsNumber);
               this.Controls.Add(this.m_ColsLabel);
               this.Controls.Add(this.m_RowsNumber);
               this.Controls.Add(this.m_RowsLabel);
               this.Controls.Add(this.m_BoardSize);
               this.Controls.Add(this.m_Multiplayer);
               this.Controls.Add(this.m_Player2TextBox);
               this.Controls.Add(this.m_Player2Label);
               this.Controls.Add(this.m_Player1TextBox);
               this.Controls.Add(this.m_Player1Label);
               this.Controls.Add(this.m_PlayersLabel);
               this.Name = "GameSettingsForm";
               this.Text = "Game Settings";
               ((System.ComponentModel.ISupportInitialize)(this.m_RowsNumber)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.m_ColsNumber)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.Label m_PlayersLabel;
          private System.Windows.Forms.Label m_Player1Label;
          private System.Windows.Forms.TextBox m_Player1TextBox;
          private System.Windows.Forms.Label m_Player2Label;
          private System.Windows.Forms.TextBox m_Player2TextBox;
          private System.Windows.Forms.CheckBox m_Multiplayer;
          private System.Windows.Forms.Label m_BoardSize;
          private System.Windows.Forms.Label m_RowsLabel;
          private System.Windows.Forms.NumericUpDown m_RowsNumber;
          private System.Windows.Forms.Label m_ColsLabel;
          private System.Windows.Forms.NumericUpDown m_ColsNumber;
          private System.Windows.Forms.Button button1;
     }
}