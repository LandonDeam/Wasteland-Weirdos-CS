using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Wasteland_Weirdos.ui
{
    public class CharacterCreator : Structures.Menu
    {
        private TreeView tvwRaceSelectors;
        private Button btnBack;
        private Button btnNext;
        private Label lblRace, lblDescription;
        private Structures.Race bodyRace = null;
        private string weirdoName;

        public void loadPage()
        {
            // Getting the TreeView object ready to be added to the form
            frmWastelandWeirdos.mainForm.SuspendLayout();

            // TreeView setup
            tvwRaceSelectors = new TreeView();
            tvwRaceSelectors.Nodes.AddRange(generateRaceTreeNodes());
            tvwRaceSelectors.Location = new System.Drawing.Point(35, 35);
            tvwRaceSelectors.Name = "tvwBrainSelector";
            tvwRaceSelectors.Size = new System.Drawing.Size(200, 500);
            tvwRaceSelectors.TabIndex = 0;
            tvwRaceSelectors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tvwRaceSelectors.ExpandAll();
            tvwRaceSelectors.LineColor = System.Drawing.Color.White;
            tvwRaceSelectors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.selectRace);

            // Back button setup
            btnBack = new Button();
            btnBack.Location = new Point(75, 575);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += new EventHandler(backToStart);

            // Next Button Setup
            btnNext = new Button();
            btnNext.Location = new Point(600, 575);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += new EventHandler(selectBrain);
            btnNext.Enabled = false;

            // selected race label setup
            lblRace = new Label();
            lblRace.AutoSize = true;
            lblRace.BackColor = System.Drawing.Color.Transparent;
            lblRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblRace.Location = new System.Drawing.Point(271, 35);
            lblRace.Name = "lblRace";
            lblRace.Size = new System.Drawing.Size(117, 20);
            lblRace.TabIndex = 3;
            lblRace.Text = string.Empty;

            // selected race description setup
            lblDescription = new Label();
            lblDescription.BackColor = System.Drawing.Color.Transparent;
            lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDescription.Location = new System.Drawing.Point(272, 75);
            lblDescription.Name = "label2";
            lblDescription.Size = new System.Drawing.Size(440, 231);
            lblDescription.TabIndex = 4;
            lblDescription.Text = string.Empty;

            // Settimg up the form layout
            frmWastelandWeirdos.mainForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmWastelandWeirdos.mainForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmWastelandWeirdos.mainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            frmWastelandWeirdos.mainForm.ClientSize = new System.Drawing.Size(766, 668);
            frmWastelandWeirdos.mainForm.Controls.Add(tvwRaceSelectors);
            frmWastelandWeirdos.mainForm.Controls.Add(btnBack);
            frmWastelandWeirdos.mainForm.Controls.Add(btnNext);
            frmWastelandWeirdos.mainForm.Controls.Add(lblRace);
            frmWastelandWeirdos.mainForm.Controls.Add(lblDescription);
            frmWastelandWeirdos.mainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            frmWastelandWeirdos.mainForm.Name = "frmWastelandWeirdos";
            frmWastelandWeirdos.mainForm.ResumeLayout(false);
        }

        private void backToStart(object sender, EventArgs e)
        {
            frmWastelandWeirdos.mainForm.SuspendLayout();
            frmWastelandWeirdos.mainForm.Controls.Clear();
            frmWastelandWeirdos.mainForm.loadForm(new StartMenu());
        }

        private void selectBrain(object sender, EventArgs e)
        {
            btnBack.Click -= backToStart;
            btnBack.Click += new EventHandler(backToSelectBody);
            //btnNext.Click -= selectBrain;
            btnNext.Enabled = false;

            tvwRaceSelectors.BeginUpdate();
            tvwRaceSelectors.Nodes.Clear();
            tvwRaceSelectors.Nodes.AddRange(generateRaceTreeNodes());
            tvwRaceSelectors.ExpandAll();
            tvwRaceSelectors.EndUpdate();
        }

        private void backToSelectBody(object sender, EventArgs e)
        {
            bodyRace = null;
            btnBack.Click -= backToSelectBody;
            btnBack.Click += new EventHandler(backToStart);
            //btnNext.Click -= foobar;
            //btnNext.Click += selectBrain;
            btnNext.Enabled = true;

            tvwRaceSelectors.BeginUpdate();
            tvwRaceSelectors.Nodes.Clear();
            tvwRaceSelectors.Nodes.AddRange(generateRaceTreeNodes());
            tvwRaceSelectors.ExpandAll();
            tvwRaceSelectors.EndUpdate();
        }

        private void selectRace(object sender, EventArgs e)
        {
            if (this.tvwRaceSelectors.SelectedNode.Tag.Equals("SuperRace")) { return; }
            btnNext.Enabled = true;
            bodyRace = (Structures.Race)tvwRaceSelectors.SelectedNode.Tag;

            lblRace.Text = bodyRace.Name;
            lblDescription.Text = bodyRace.Description;
        }

        private TreeNode[] generateRaceTreeNodes()
        {
            List<TreeNode> races = ToTreeNodeArray(this.GetRaceArray("None")).ToList();
            this.AddSubRacesToTreeNodeList(races);
            return races.ToArray();
        }

        private void AddSubRacesToTreeNodeList(List<TreeNode> races)
        {
            List<string> superRaces = new List<string>();
            foreach (Structures.Race race in Structures.Weirdo.Races)
            {
                if (race.SuperRace.Equals("None") || superRaces.Contains(race.SuperRace)) { continue; }
                superRaces.Add(race.SuperRace);
            }
            foreach (string superRace in superRaces)
            {
                TreeNode super = new TreeNode(superRace, ToTreeNodeArray(this.GetRaceArray(superRace)));
                super.Name = superRace;
                super.Text = superRace;
                super.Tag = "SuperRace";
                races.Add(super);
            }
        }

        private Structures.Race[] GetRaceArray(string filter)
        {
            return Structures.Weirdo.Races.Where(_ => _.SuperRace.Equals(filter) && (this.bodyRace == null || !this.bodyRace.Equals(_))).ToArray();
        }

        private static TreeNode[] ToTreeNodeArray(Structures.Race[] races)
        {
            TreeNode[] nodes = new TreeNode[races.Length];
            for(int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = ToTreeNode(races[i]);
            }
            return nodes;
        }

        private static TreeNode ToTreeNode(Structures.Race race)
        {
            TreeNode node = new TreeNode(race.Name);
            node.Name = race.Name;
            node.Text = race.Name;
            node.Tag = race;
            return node;
        }
    }
}
