using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wasteland_Weirdos.Forms
{
    public class Template
    {
        public static void loadPage(Form frm)
        {
            form = frm;
            btnTest = new System.Windows.Forms.Button();
            form.SuspendLayout();
            // 
            // btnTest
            // 
            btnTest.Location = new System.Drawing.Point(325, 321);
            btnTest.Name = "btnTest";
            btnTest.Size = new System.Drawing.Size(100, 24);
            btnTest.TabIndex = 0;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += new System.EventHandler(funcLoadMenu);
            // 
            // frmWastelandWeirdos
            // 
            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            form.ClientSize = new System.Drawing.Size(766, 668);
            form.Controls.Add(btnTest);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            form.Name = "frmWastelandWeirdos";
            form.ResumeLayout(false);
        }

        private static void funcLoadMenu(object sender, EventArgs e)
        {
            form.Controls.Clear();
            StartMenu.loadPage(form);
        }

        private static System.Windows.Forms.Button btnTest;
        private static Form form;
    }
}
