using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_Weirdos.Structures
{
    class Bionic
    {
        public static List<Bionic> bionicUpgrades;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Willpower { get; set; }
        public int Intellect { get; set; }
        public int Charisma { get; set; }
    }
}
