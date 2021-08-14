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
        private Label lblStrength, lblDexterity, lblConstitution, lblWillpower, lblIntellect, lblCharisma;
        private Label lblHeight, lblWeight;
        private Label lblToolTipText;
        private Structures.Race bodyRace = null, brainRace = null;

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
            tvwRaceSelectors.TabIndex = 13;
            tvwRaceSelectors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tvwRaceSelectors.ExpandAll();
            tvwRaceSelectors.LineColor = System.Drawing.Color.White;
            tvwRaceSelectors.ShowNodeToolTips = true;
            tvwRaceSelectors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.selectBodyRace);

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
            btnNext.Click += new EventHandler(toSelectBrain);
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
            lblRace.Text = "Select Body Race";

            // selected race description setup
            lblDescription = new Label();
            lblDescription.BackColor = System.Drawing.Color.Transparent;
            lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDescription.Location = new System.Drawing.Point(272, 75);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(440, 231);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "You must select a race for your body, and a different race for your brain. Hover over each race to view their stat changes.";

            // Strength stat label setup
            lblStrength = new Label();
            lblStrength.AutoSize = true;
            lblStrength.BackColor = System.Drawing.Color.Transparent;
            lblStrength.Location = new System.Drawing.Point(272, 324);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new System.Drawing.Size(65, 13);
            lblStrength.TabIndex = 5;
            lblStrength.Text = "Strength    5";

            // Dex stat label setup
            lblDexterity = new Label();
            lblDexterity.AutoSize = true;
            lblDexterity.BackColor = System.Drawing.Color.Transparent;
            lblDexterity.Location = new System.Drawing.Point(366, 324);
            lblDexterity.Name = "lblDexterity";
            lblDexterity.Size = new System.Drawing.Size(66, 13);
            lblDexterity.TabIndex = 6;
            lblDexterity.Text = "Dexterity    5";

            // Constitution stat label setup
            lblConstitution = new Label();
            lblConstitution.AutoSize = true;
            lblConstitution.BackColor = System.Drawing.Color.Transparent;
            lblConstitution.Location = new System.Drawing.Point(460, 324);
            lblConstitution.Name = "lblConstitution";
            lblConstitution.Size = new System.Drawing.Size(80, 13);
            lblConstitution.TabIndex = 7;
            lblConstitution.Text = "Constitution    5";


            // Willpower stat label setup
            lblWillpower = new Label();
            lblWillpower.AutoSize = true;
            lblWillpower.BackColor = System.Drawing.Color.Transparent;
            lblWillpower.Location = new System.Drawing.Point(272, 357);
            lblWillpower.Name = "lblWillpower";
            lblWillpower.Size = new System.Drawing.Size(71, 13);
            lblWillpower.TabIndex = 8;
            lblWillpower.Text = "Willpower    5";

            // Intellect stat label setup
            lblIntellect = new Label();
            lblIntellect.AutoSize = true;
            lblIntellect.BackColor = System.Drawing.Color.Transparent;
            lblIntellect.Location = new System.Drawing.Point(366, 357);
            lblIntellect.Name = "lblIntellect";
            lblIntellect.Size = new System.Drawing.Size(62, 13);
            lblIntellect.TabIndex = 9;
            lblIntellect.Text = "Intellect    5";

            // Charisma stat label setup
            lblCharisma = new Label();
            lblCharisma.AutoSize = true;
            lblCharisma.BackColor = System.Drawing.Color.Transparent;
            lblCharisma.Location = new System.Drawing.Point(460, 357);
            lblCharisma.Name = "lblCharisma";
            lblCharisma.Size = new System.Drawing.Size(68, 13);
            lblCharisma.TabIndex = 10;
            lblCharisma.Text = "Charisma    5";

            // Height range label setup
            lblHeight = new Label();
            lblHeight.AutoSize = true;
            lblHeight.BackColor = System.Drawing.Color.Transparent;
            lblHeight.Location = new System.Drawing.Point(272, 390);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(81, 13);
            lblHeight.TabIndex = 11;
            lblHeight.Text = "Height    ";

            // Weight range label setup
            lblWeight = new Label();
            lblWeight.AutoSize = true;
            lblWeight.BackColor = System.Drawing.Color.Transparent;
            lblWeight.Location = new System.Drawing.Point(272, 423);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new System.Drawing.Size(106, 13);
            lblWeight.TabIndex = 12;
            lblWeight.Text = "Weight    ";

            // Tool tip text label setup
            lblToolTipText = new Label();
            lblToolTipText.AutoSize = true;
            lblToolTipText.BackColor = System.Drawing.Color.White;
            lblToolTipText.Location = new System.Drawing.Point(0, 0);
            lblToolTipText.Name = "lblToolTipText";
            lblToolTipText.Size = new System.Drawing.Size(0, 13);
            lblToolTipText.TabIndex = 0;
            lblToolTipText.Visible = false;
            lblToolTipText.Enabled = false;


            // Settimg up the form layout
            frmWastelandWeirdos.mainForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            frmWastelandWeirdos.mainForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            frmWastelandWeirdos.mainForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            frmWastelandWeirdos.mainForm.ClientSize = new System.Drawing.Size(766, 668);
            frmWastelandWeirdos.mainForm.Controls.Add(lblToolTipText);
            frmWastelandWeirdos.mainForm.Controls.Add(tvwRaceSelectors);
            frmWastelandWeirdos.mainForm.Controls.Add(btnBack);
            frmWastelandWeirdos.mainForm.Controls.Add(btnNext);
            frmWastelandWeirdos.mainForm.Controls.Add(lblRace);
            frmWastelandWeirdos.mainForm.Controls.Add(lblDescription);
            frmWastelandWeirdos.mainForm.Controls.Add(lblStrength);
            frmWastelandWeirdos.mainForm.Controls.Add(lblDexterity);
            frmWastelandWeirdos.mainForm.Controls.Add(lblConstitution);
            frmWastelandWeirdos.mainForm.Controls.Add(lblWillpower);
            frmWastelandWeirdos.mainForm.Controls.Add(lblIntellect);
            frmWastelandWeirdos.mainForm.Controls.Add(lblCharisma);
            frmWastelandWeirdos.mainForm.Controls.Add(lblHeight);
            frmWastelandWeirdos.mainForm.Controls.Add(lblWeight);
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

        private void toSelectBrain(object sender, EventArgs e)
        {
            btnBack.Click -= backToStart;
            btnBack.Click += new EventHandler(backToSelectBody);
            //btnNext.Click -= toSelectBrain;
            //btnNext.Click += foobar;
            btnNext.Enabled = false;

            lblRace.Text = "Select Brain Race";
            lblDescription.Text = string.Empty;

            tvwRaceSelectors.AfterSelect -= selectBodyRace;
            tvwRaceSelectors.AfterSelect += selectBrainRace;
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
            //btnNext.Click += toSelectBrain;
            btnNext.Enabled = true;

            tvwRaceSelectors.AfterSelect -= selectBrainRace;
            tvwRaceSelectors.AfterSelect += selectBodyRace;
            tvwRaceSelectors.BeginUpdate();
            tvwRaceSelectors.Nodes.Clear();
            tvwRaceSelectors.Nodes.AddRange(generateRaceTreeNodes());
            tvwRaceSelectors.ExpandAll();
            tvwRaceSelectors.EndUpdate();
        }

        private void selectBodyRace(object sender, EventArgs e)
        {
            if (this.tvwRaceSelectors.SelectedNode.Tag.Equals("SuperRace")) { return; }
            btnNext.Enabled = true;
            bodyRace = (Structures.Race)tvwRaceSelectors.SelectedNode.Tag;

            lblRace.Text = bodyRace.Name;
            lblDescription.Text = bodyRace.Description;
            lblStrength.Text = $"Strength    {5 + bodyRace.Strength}";
            lblDexterity.Text = $"Dexterity    {5 + bodyRace.Dexterity}";
            lblConstitution.Text = $"Constitution    {5 + bodyRace.Constitution}";
            lblHeight.Text = $"Height    {bodyRace.getHeightSpread()}";
            lblWeight.Text = $"Weight    {bodyRace.getWeightSpread()}";
        }
        
        private void selectBrainRace(object sender, EventArgs e)
        {
            if (this.tvwRaceSelectors.SelectedNode.Tag.Equals("SuperRace")) { return; }
            brainRace = (Structures.Race)tvwRaceSelectors.SelectedNode.Tag;

            lblRace.Text = brainRace.Name;
            lblDescription.Text = brainRace.Description;
            lblWillpower.Text = $"Willpower    {5 + brainRace.Willpower}";
            lblIntellect.Text = $"Intellect    {5 + brainRace.Intellect}";
            lblCharisma.Text = $"Charisma    {5 + brainRace.Charisma}";
        }

        private TreeNode[] generateRaceTreeNodes()
        {
            bool isBody = this.bodyRace == null;
            List<TreeNode> races = ToTreeNodeArray(this.GetRaceArray("None"), isBody).ToList();
            this.AddSubRacesToTreeNodeList(races, isBody);
            return races.ToArray();
        }

        private void AddSubRacesToTreeNodeList(List<TreeNode> races, bool isBody)
        {
            List<string> superRaces = new List<string>();
            foreach (Structures.Race race in Structures.Race.Races)
            {
                if (race.SuperRace.Equals("None") || superRaces.Contains(race.SuperRace)) { continue; }
                superRaces.Add(race.SuperRace);
            }
            foreach (string superRace in superRaces)
            {
                TreeNode super = new TreeNode(superRace, ToTreeNodeArray(this.GetRaceArray(superRace), isBody));
                super.Name = superRace;
                super.Text = superRace;
                super.Tag = "SuperRace";
                races.Add(super);
            }
        }

        private Structures.Race[] GetRaceArray(string filter)
        {
            return Structures.Race.Races.Where(_ => _.SuperRace.Equals(filter) && (this.bodyRace == null || !this.bodyRace.Equals(_))).ToArray();
        }

        private static TreeNode[] ToTreeNodeArray(Structures.Race[] races, bool isBody)
        {
            TreeNode[] nodes = new TreeNode[races.Length];
            for(int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = ToTreeNode(races[i], isBody);
            }
            return nodes;
        }

        private static TreeNode ToTreeNode(Structures.Race race, bool isBody)
        {
            TreeNode node = new TreeNode(race.Name);
            node.Name = race.Name;
            node.Text = race.Name;
            node.Tag = race;
            node.ToolTipText = getToolTipText(race, isBody);
            return node;
        }

        private static string getToolTipText(Structures.Race race, bool isBody)
        {
            string str = "";
            if (isBody)
            {
                str += "Str " + ((race.Strength > 0) ? "+" : "") + race.Strength.ToString() + "; ";
                str += "Dex " + ((race.Dexterity > 0) ? "+" : "") + race.Dexterity.ToString() + "; ";
                str += "Con " + ((race.Constitution > 0) ? "+" : "") + race.Constitution.ToString() + "; ";
            }
            else
            {
                str += "Wil " + ((race.Willpower >= 0) ? "+" : "") + race.Willpower.ToString() + "; ";
                str += "Int " + ((race.Intellect >= 0) ? "+" : "") + race.Intellect.ToString() + "; ";
                str += "Chr " + ((race.Charisma >= 0) ? "+" : "") + race.Charisma.ToString() + "; ";
            }
            return str;
        }
    }
}