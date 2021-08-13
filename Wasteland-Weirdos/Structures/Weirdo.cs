using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wasteland_Weirdos.Structures
{
    // Default class for all weirdos
    class Weirdo
    {
        // Variables to share across all class members
        
        public static List<Race> Races;
        public static List<Bionic> bionicUpgrades;
        public static List<Blood> bloodUpgrades;

        // Individual Weirdo build options
        public Race Body;
        public Race Brain;
        public List<Bionic> ownedBionicUpgrades;
        public List<Blood> ownedBloodUpgrades;

        // Individual Stats
        public int Strength = 5;
        public int Dexterity = 5;
        public int Constitution = 5;
        public int Willpower = 5;
        public int Intellect = 5;
        public int Charisma = 5;
        public int Level = 1;

        // Cosmetics
        public string Name;
        public double Height;
        public double Weight;
        public string HairColor;
        public string EyeColor;
        public string SkinColor;




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

        public static void Initialize()
        {
            Weirdo.Races = JsonConvert.DeserializeObject<List<Race>>(Encoding.UTF8.GetString(Properties.Resources.RaceStats));
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
        public string SuperRace { get; set; }
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

        public string getHeightSpread()
        {
            if(arrayIsEmpty<double>(this.Height)) { return "WIP"; }
            return $"{inchesToFeetAndInches(Convert.ToInt32(this.Height[0]))} - {inchesToFeetAndInches(Convert.ToInt32(this.Height[1]))}";
        }

        public static string inchesToFeetAndInches(int inches)
        {
            return ((inches / 12 > 0) ? $"{inches / 12}\'" : string.Empty) +
                   ((inches % 12 > 0) ? $"{inches % 12}\"" : string.Empty);
        }

        public string getWeightSpread()
        {
            if(arrayIsEmpty<double>(this.Weight)) { return "WIP"; }
            if(this.Weight[0] > 5)
            {
                return $"{this.Weight[0]} lbs - {this.Weight[1]} lbs";
            }
            return $"{this.Weight[0] * 16} oz - {this.Weight[1] * 16} oz";
        }

        public static bool arrayIsEmpty<T>(Array arr)
        {
            try {
                if (arr.Length < 1) return true;
                T _ = ((IList<T>)arr)[0];
                return false;
            }
            catch(Exception e)
            {
                return true;
            }
        }
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
