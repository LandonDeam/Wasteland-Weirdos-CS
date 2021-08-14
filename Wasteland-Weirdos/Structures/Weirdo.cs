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
        // Individual Weirdo build options
        private Race Body { get; set; }
        private Race Brain { get; set; }
        private List<Bionic> OwnedBionicUpgrades { get; set; }
        private List<Blood> OwnedBloodUpgrades { get; set; }

        // Individual Stats
        private int Strength { get; set; } = 5;
        private int Dexterity { get; set; } = 5;
        private int Constitution { get; set; } = 5;
        private int Willpower { get; set; } = 5;
        private int Intellect { get; set; } = 5;
        private int Charisma { get; set; } = 5;
        private int Level { get; set; } = 1;

        // Cosmetics
        private string Name { get; set; }
        private double Height { get; set; }
        private double Weight { get; set; }
        private string HairColor { get; set; }
        private string EyeColor { get; set; }
        private string SkinColor { get; set; }




        // Constructors
        public Weirdo(Race body, Race brain, List<Bionic> bionics, List<Blood> bloods)
        {
            this.Initialize(body, brain, bionics, bloods);
        }

        public Weirdo(Race body, Race brain, List<Bionic> bionics)
        {
            this.Initialize(body, brain, bionics, new List<Blood>());
        }

        public Weirdo(Race body, Race brain, List<Blood> bloods)
        {
            this.Initialize(body, brain, new List<Bionic>(), bloods);
        }

        public Weirdo(Race body, Race brain)
        {
            this.Initialize(body, brain, new List<Bionic>(), new List<Blood>());
        }

        private void Initialize(Race body, Race brain, List<Bionic> bionics, List<Blood> bloods)
        {
            checkRaceOverlap(body, brain);
            // Weirdo Build
            this.Body = body;
            this.Brain = brain;
            this.OwnedBionicUpgrades = bionics;
            this.OwnedBloodUpgrades = bloods;

            // Base Stats
            this.Strength += this.StrengthModifier();
            this.Dexterity += this.DexterityModifier();
            this.Constitution += this.ConstitutionModifier();
            this.Willpower += this.WillpowerModifier();
            this.Intellect += this.IntellectModifier();
            this.Charisma += this.CharismaModifier();

            // Cosmetics
            this.Height = Program.rand.NextDouble() * (this.Body.Height[1] - this.Body.Height[0]);
            this.Weight = Program.rand.NextDouble() * (this.Body.Height[1] - this.Body.Height[0]);
            this.HairColor = this.Body.HairColors[Program.rand.Next(0, this.Body.HairColors.Length) - 1];
            this.EyeColor = this.Body.EyeColors[Program.rand.Next(0, this.Body.EyeColors.Length) - 1];
            this.SkinColor = this.Body.SkinColors[Program.rand.Next(0, this.Body.SkinColors.Length) - 1];
        }

        public static void Initialize()
        {
            Race.Races = JsonConvert.DeserializeObject<List<Race>>(Encoding.UTF8.GetString(Properties.Resources.RaceStats));
        }

        public void levelUp()
        {
            this.Strength += (this.StrengthModifier() > 0) ? this.StrengthModifier() : 1;
            this.Dexterity += (this.DexterityModifier() > 0) ? this.DexterityModifier() : 1;
            this.Constitution += (this.ConstitutionModifier() > 0) ? this.ConstitutionModifier() : 1;
            this.Willpower += (this.WillpowerModifier() > 0) ? this.WillpowerModifier() : 1;
            this.Intellect += (this.IntellectModifier() > 0) ? this.IntellectModifier() : 1;
            this.Charisma += (this.CharismaModifier() > 0) ? this.CharismaModifier() : 1;
        }

        public int StrengthModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Strength;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
            {
                _ += blood.Strength;
            }
            return _ + this.Body.Strength;
        }

        public int DexterityModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Dexterity;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
            {
                _ += blood.Dexterity;
            }
            return _ + this.Body.Dexterity;
        }

        public int ConstitutionModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Constitution;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
            {
                _ += blood.Constitution;
            }
            return _ + this.Body.Constitution;
        }

        public int WillpowerModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Willpower;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
            {
                _ += blood.Willpower;
            }
            return _ + this.Brain.Willpower;
        }

        public int IntellectModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Intellect;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
            {
                _ += blood.Intellect;
            }
            return _ + this.Brain.Intellect;
        }

        public int CharismaModifier()
        {
            int _ = 0;
            foreach (Bionic bionic in this.OwnedBionicUpgrades)
            {
                _ += bionic.Charisma;
            }
            foreach (Blood blood in this.OwnedBloodUpgrades)
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
}
