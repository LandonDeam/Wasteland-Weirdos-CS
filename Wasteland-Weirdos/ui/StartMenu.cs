using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wasteland_Weirdos.ui
{
    public class StartMenu : Structures.Menu
    {
        private static frmWastelandWeirdos form;
        private static PictureBox picHeadShot;
        private static Button btnNewGame, btnSettings, btnLoadGame;
        public void loadPage(frmWastelandWeirdos frm)
        {
            form = frm;
            picHeadShot = new System.Windows.Forms.PictureBox();
            btnNewGame = new System.Windows.Forms.Button();
            btnSettings = new System.Windows.Forms.Button();
            btnLoadGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(picHeadShot)).BeginInit();
            form.SuspendLayout();
            // 
            // picHeadShot
            // 
            picHeadShot.Image = global::Wasteland_Weirdos.Properties.Resources.hs;
            picHeadShot.Location = new System.Drawing.Point(250, 175);
            picHeadShot.Name = "picHeadShot";
            picHeadShot.Size = new System.Drawing.Size(250, 250);
            picHeadShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picHeadShot.TabIndex = 0;
            picHeadShot.TabStop = false;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new System.Drawing.Point(175, 450);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new System.Drawing.Size(125, 45);
            btnNewGame.TabIndex = 1;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += new System.EventHandler(funcNewGame);
            // 
            // btnSettings
            // 
            btnSettings.Location = new System.Drawing.Point(475, 450);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(125, 45);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += new System.EventHandler(funcTest);
            // 
            // btnLoadGame
            // 
            btnLoadGame.Enabled = false;
            btnLoadGame.Location = new System.Drawing.Point(325, 450);
            btnLoadGame.Name = "btnLoadGame";
            btnLoadGame.Size = new System.Drawing.Size(125, 45);
            btnLoadGame.TabIndex = 3;
            btnLoadGame.Text = "Load Game";
            btnLoadGame.UseVisualStyleBackColor = true;
            // 
            // frmWastelandWeirdos
            // 
            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.BackgroundImage = global::Wasteland_Weirdos.Properties.Resources.background;
            form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            form.ClientSize = new System.Drawing.Size(766, 668);
            form.Controls.Add(btnLoadGame);
            form.Controls.Add(btnSettings);
            form.Controls.Add(btnNewGame);
            form.Controls.Add(picHeadShot);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            form.Name = "frmWastelandWeirdos";
            form.Text = "frmStartMenu";
            ((System.ComponentModel.ISupportInitialize)(picHeadShot)).EndInit();
            form.ResumeLayout(false);
        }

        private void funcNewGame(object sender, EventArgs e)
        {
            form.Controls.Clear();
            form.loadForm(new ui.CharacterCreator());
        }

        private void funcTest(object sender, EventArgs e)
        {
            MessageBox.Show("yep");
        }
    }
}
