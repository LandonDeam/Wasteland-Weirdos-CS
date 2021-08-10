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
        private int Strength = 5;
        private int Dexterity = 5;
        private int Constitution = 5;
        private int Willpower = 5;
        private int Intellect = 5;
        private int Charisma = 5;
        private int Level = 1;

        // Cosmetics
        private double Height;
        private double Weight;
        private string HairColor;
        private string EyeColor;
        private string SkinColor;




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
            // Weirdo Build
            this.Body = body;
            this.Brain = brain;
            this.ownedBionicUpgrades = bionics;
            this.ownedBloodUpgrades = bloods;

            // Base Stats
            this.Strength += this.getStrengthModifier();
            this.Dexterity += this.getDexterityModifier();
            this.Constitution += this.getConstitutionModifier();
            this.Willpower += this.getWillpowerModifier();
            this.Intellect += this.getIntellectModifier();
            this.Charisma += this.getCharismaModifier();

            // Cosmetics
            this.Height = Program.rand.NextDouble() * (this.Body.Height[1] - this.Body.Height[0]);
            this.Weight = Program.rand.NextDouble() * (this.Body.Height[1] - this.Body.Height[0]);
            this.HairColor = this.Body.HairColors[Program.rand.Next(0, this.Body.HairColors.Length) - 1];
            this.EyeColor = this.Body.EyeColors[Program.rand.Next(0, this.Body.EyeColors.Length) - 1];
            this.SkinColor = this.Body.SkinColors[Program.rand.Next(0, this.Body.SkinColors.Length) - 1];
        }

        public void levelUp()
        {
            this.Strength += (this.getStrengthModifier() > 0) ? this.getStrengthModifier() : 1;
            this.Dexterity += (this.getDexterityModifier() > 0) ? this.getDexterityModifier() : 1;
            this.Constitution += (this.getConstitutionModifier() > 0) ? this.getConstitutionModifier() : 1;
            this.Willpower += (this.getWillpowerModifier() > 0) ? this.getWillpowerModifier() : 1;
            this.Intellect += (this.getIntellectModifier() > 0) ? this.getIntellectModifier() : 1;
            this.Charisma += (this.getCharismaModifier() > 0) ? this.getCharismaModifier() : 1;
        }

        public int getStrengthModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Strength;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Strength;
            }
            return _ + this.Body.Strength;
        }

        public int getDexterityModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Dexterity;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Dexterity;
            }
            return _ + this.Body.Dexterity;
        }

        public int getConstitutionModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Constitution;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Constitution;
            }
            return _ + this.Body.Constitution;
        }

        public int getWillpowerModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Willpower;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Willpower;
            }
            return _ + this.Brain.Willpower;
        }

        public int getIntellectModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Intellect;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Intellect;
            }
            return _ + this.Brain.Intellect;
        }

        public int getCharismaModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.ownedBionicUpgrades)
            {
                _ += bionic.Charisma;
            }
            foreach (Blood blood in this.ownedBloodUpgrades)
            {
                _ += blood.Charisma;
            }
            return _ + this.Brain.Charisma;
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
        public string Name { get; set; }
        public string SubRace { get; set; }
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Willpower { get; set; }
        public int Intellect { get; set; }
        public int Charisma { get; set; }
        public double[] Height { get; set; }
        public double[] Weight { get; set; }
        public string[] HairColors { get; set; }
        public string[] EyeColors { get; set; }
        public string[] SkinColors { get; set; }
    }

    // Default class for all bionic upgrades
    class Bionic
    {
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Willpower { get; set; }
        public int Intellect { get; set; }
        public int Charisma { get; set; }

    }

    // Default class for all blood upgrades
    class Blood
    {
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Willpower { get; set; }
        public int Intellect { get; set; }
        public int Charisma { get; set; }
    }
}
