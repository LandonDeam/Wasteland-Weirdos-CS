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
        public void loadPage()
        {
            frmWastelandWeirdos.mainForm.SuspendLayout();
            tvwRaceSelectors = new TreeView();
            tvwRaceSelectors.Nodes.AddRange(generateRaceTreeNodes());
            tvwRaceSelectors.Location = new System.Drawing.Point(145, 145);
            tvwRaceSelectors.Name = "tvwBrainSelector";
            tvwRaceSelectors.Size = new System.Drawing.Size(400, 400);
            tvwRaceSelectors.TabIndex = 0;
            frmWastelandWeirdos.mainForm.Controls.Add(tvwRaceSelectors);
            frmWastelandWeirdos.mainForm.ResumeLayout(false);
        }

        private static TreeNode[] generateRaceTreeNodes()
        {
            List<TreeNode> races = ToTreeNode(Structures.Weirdo.Races.Where(_ => _.SuperRace.Equals("None")).ToArray()).ToList();
            List<Structures.Race> subRaces = Structures.Weirdo.Races.Where(_ => !_.SuperRace.Equals("None")).ToList();
            List<string> superRaces = new List<string>();
            foreach (Structures.Race subRace in subRaces)
            {
                if (!superRaces.Contains(subRace.SuperRace))
                    superRaces.Add(subRace.SuperRace);
            }
            foreach (string superRace in superRaces)
            {
                TreeNode _ = new TreeNode(superRace, ToTreeNode(subRaces.Where(race => race.SuperRace.Equals(superRace)).ToArray()));
                _.Name = superRace;
                _.Text = superRace;
                _.Tag = "SuperRace";
                races.Add(_);
            }
            return races.ToArray();
        }

        private static TreeNode[] ToTreeNode(Structures.Race[] races)
        {
            TreeNode[] nodes = new TreeNode[races.Length];
            for(int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new TreeNode(races[i].Name);
                nodes[i].Name = races[i].Name;
                nodes[i].Text = races[i].Name;
            }
            return nodes;
        }
    }
}
