using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wasteland_Weirdos
{
    public partial class frmWastelandWeirdos : Form
    {
        public Structures.Menu currentForm;
        public static frmWastelandWeirdos mainForm;
        public frmWastelandWeirdos()
        {
            InitializeComponent();
            this.Controls.Clear();
            Structures.Weirdo.Initialize();
            mainForm = this;
            loadForm(new ui.StartMenu());
        } 

        public void loadForm(Structures.Menu newForm)
        {
            currentForm = newForm;
            currentForm.loadPage();
            // I may want to implement garbage collection here in the future to auto-destroy
            // unneeded objects left over from previous forms (GC.Collect is the method for it)
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
