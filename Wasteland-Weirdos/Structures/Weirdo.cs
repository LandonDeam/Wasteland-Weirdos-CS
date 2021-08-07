using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_Weirdos.Structures
{
    // Default class for all weirdos
    class Weirdo
    {
        // Variables to share across all class members
        private static List<Race> Races;
        private static List<Bionic> bionicUpgrades;
        private static List<Blood> bloodUpgrades;

        // Individual Weirdo build options
        private Race Body;
        private Race Brain;
        private List<Bionic> ownedBionicUpgrades;
        private List<Blood> ownedBloodUpgrades;

        // Individual Stats
        private int Strength;
        private int Dexterity;
        private int Constitution;
        private int Willpower;
        private int Intellect;
        private int Charisma;
        private double Height;
        private double Weight;
        private string HairColor;
        private string EyeColor;
        private string SkinColor;
        private int level;



        // Constructors
        public Weirdo(Race body, Race brain, List<Bionic> bionics, List<Blood> bloods)
        {
            this.Initialize(body, brain, bionics, bloods);
        }

        public Weirdo(Race body, Race brain, List<Bionic> bionics)
        {
            this.Initialize(body, brain, bionics, null);
        }

        public Weirdo(Race body, Race brain, List<Blood> bloods)
        {
            this.Initialize(body, brain, null, bloods);
        }

        public Weirdo(Race body, Race brain)
        {
            this.Initialize(body, brain, null, null);
        }

        private void Initialize(Race body, Race brain, List<Bionic> bionics, List<Blood> bloods)
        {
            checkRaceOverlap(body, brain);
            this.Body = body;
            this.Brain = brain;
            this.ownedBionicUpgrades = bionics;
            this.ownedBloodUpgrades = bloods;
        }

        // Throws an exception if the brain and body are from the same race
        private static void checkRaceOverlap(Race rOne, Race rTwo)
        {
            if (rOne.Equals(rTwo)) throw new ArgumentException("Race overlap found!");
        }
    }

    // Default class for all races
    class Race
    {
        private string description { get; set; }
        private int Strength { get; set; }
        private int Dexterity { get; set; }
        private int Constitution { get; set; }
        private int Willpower { get; set; }
        private int Intellect { get; set; }
        private int Charisma { get; set; }
        private double[] Height { get; set; }
        private double[] Weight { get; set; }
        private string[] HairColors { get; set; }
        private string[] EyeColors { get; set; }
        private string[] SkinColors { get; set; }
    }

    // Default class for all bionic upgrades
    class Bionic
    {
        private string description { get; set; }
        private int Strength { get; set; }
        private int Dexterity { get; set; }
        private int Constitution { get; set; }
        private int Willpower { get; set; }
        private int Intellect { get; set; }
        private int Charisma { get; set; }

    }

    // Default class for all blood upgrades
    class Blood
    {
        private string description { get; set; }
        private int Strength { get; set; }
        private int Dexterity { get; set; }
        private int Constitution { get; set; }
        private int Willpower { get; set; }
        private int Intellect { get; set; }
        private int Charisma { get; set; }
    }
}
