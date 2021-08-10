using System;
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
        public void loadPage()
        {
            Structures.Race[] races = JsonConvert.DeserializeObject<Structures.Race[]>(Encoding.UTF8.GetString(Properties.Resources.RaceStats));
            foreach (Structures.Race race in races)
            {
                System.Diagnostics.Debug.WriteLine("\n" + race.Description);
            }
        }
    }
}
