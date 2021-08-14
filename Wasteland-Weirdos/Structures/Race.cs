using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wasteland_Weirdos.Structures
{
    class Race
    {
        public static List<Race> Races { get; set; }
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
            if (arrayIsEmpty<double>(this.Height)) { return "WIP"; }
            return $"{inchesToFeetAndInches(Convert.ToInt32(this.Height[0]))} - {inchesToFeetAndInches(Convert.ToInt32(this.Height[1]))}";
        }

        public static string inchesToFeetAndInches(int inches)
        {
            return ((inches / 12 > 0) ? $"{inches / 12}\'" : string.Empty) +
                   ((inches % 12 > 0) ? $"{inches % 12}\"" : string.Empty);
        }

        public string getWeightSpread()
        {
            if (arrayIsEmpty<double>(this.Weight)) { return "WIP"; }
            if (this.Weight[0] > 5)
            {
                return $"{this.Weight[0]} lbs - {this.Weight[1]} lbs";
            }
            return $"{this.Weight[0] * 16} oz - {this.Weight[1] * 16} oz";
        }

        public static bool arrayIsEmpty<T>(Array arr)
        {
            try
            {
                if (arr.Length < 1) return true;
                T _ = ((IList<T>)arr)[0];
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }
    }
}
