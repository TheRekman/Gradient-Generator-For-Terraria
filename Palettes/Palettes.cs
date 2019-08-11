using System;
using System.Collections.Generic;
using System.Drawing;

namespace GradientGenerator.Palettes
{
    public static class GradientPalettes
    {
        public static Dictionary<string, Color[]> Palettes = new Dictionary<string, Color[]>();

        public static void Initialize()
        {
            Palettes.Add("Rainbow", Rainbow);
            Palettes.Add("Heat Map", HeatMap);
            Palettes.Add("Terminal", Terminal);
            Palettes.Add("Mantle", Mantle);
            Palettes.Add("Combi", Combi);
        }

        static readonly Color[] Rainbow = new Color[7]
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Cyan,
            Color.Blue,
            Color.Purple
        };
        static readonly Color[] HeatMap = new Color[4]
        {
            Color.FromArgb(50, 50, 50),
            Color.FromArgb(255, 0, 0),
            Color.FromArgb(255, 255, 0),
            Color.FromArgb(255, 255, 255)
        };
        static readonly Color[] Terminal = new Color[2]
        {
            Color.FromArgb(30, 30, 30),
            Color.FromArgb(15, 155, 15)
        };
        static readonly Color[] Mantle = new Color[2]
        {
            Color.FromArgb(36, 198, 220),
            Color.FromArgb(81, 74, 157)
        };
        static readonly Color[] Combi = new Color[3]
        {
            Color.FromArgb(0, 65, 106),
            Color.FromArgb(121, 159, 12),
            Color.FromArgb(255, 224, 0)
        };
    }
}
