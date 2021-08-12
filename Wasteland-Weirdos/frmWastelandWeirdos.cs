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
        }

        public void loadForm(Structures.Menu newForm)
        {
            currentForm = newForm;
            currentForm.loadPage();
            // I may want to implement garbage collection here in the future to auto-destroy
            // unneeded objects left over from previous forms (GC.Collect is the method for it)
        }

        private void frmWastelandWeirdos_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Structures.Weirdo.Initialize();
            mainForm = this;
            loadForm(new ui.StartMenu());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
