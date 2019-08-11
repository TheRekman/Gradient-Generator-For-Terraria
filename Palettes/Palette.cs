using System;
using System.Drawing;
using Newtonsoft.Json;

namespace GradientGenerator.Palettes
{
    public class Palette
    {
        public string Name { get; private set; }
        public string[] RGBcolors { get; private set; }

        [JsonConstructor]
        public Palette(string name, string[] RGBcolors)
        {
            Name = name;
            this.RGBcolors = new string[RGBcolors.Length];
            for(int i = 0; i < RGBcolors.Length; i++)
            {
                this.RGBcolors[i] = RGBcolors[i].Replace(" ", "");
            }
        }
        public Palette(string name, Color[] colors)
        {
            Name = name;
            RGBcolors = new string[colors.Length];
            for (int i = 0; i < colors.Length; i++)
                RGBcolors[i] = $"{colors[i].R},{colors[i].G},{colors[i].B}";
        }
        public Color[] GetColors()
        {
            Color[] result = new Color[RGBcolors.Length];
            byte red, green, blue;
            for(int i = 0; i < result.Length; i++)
            {
                string[] RGB = RGBcolors[i].Split(',');
                red = Byte.Parse(RGB[0]);
                green = Byte.Parse(RGB[1]);
                blue = Byte.Parse(RGB[2]);
                result[i] = Color.FromArgb(red, green, blue);
            }
            return result;
        }
    }
}
