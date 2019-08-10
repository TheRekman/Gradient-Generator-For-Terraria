using System;
using System.Collections.Generic;
using System.Drawing;

namespace GradientGenerator
{
    public static class GradientTemplates
    {
        public static Dictionary<string, Color[]> Templates = new Dictionary<string, Color[]>();

        public static void Initialize()
        {
            Templates.Add("Rainbow", Rainbow);
            Templates.Add("Heat Map", HeatMap);
            Templates.Add("Terminal", Terminal);
            Templates.Add("Mantle", Mantle);
            Templates.Add("Combi", Combi);
        }

        public static readonly Color[] Rainbow = new Color[7]
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Cyan,
            Color.Blue,
            Color.Purple
        };

        public static readonly Color[] HeatMap = new Color[4]
        {
            Color.FromArgb(50, 50, 50),
            Color.FromArgb(255, 0, 0),
            Color.FromArgb(255, 255, 0),
            Color.FromArgb(255, 255, 255)
        };
        public static readonly Color[] Terminal = new Color[2]
        {
            Color.FromArgb(30, 30, 30),
            Color.FromArgb(15, 155, 15)
        };
        public static readonly Color[] Mantle = new Color[2]
        {
            Color.FromArgb(36, 198, 220),
            Color.FromArgb(81, 74, 157)
        };
        public static readonly Color[] Combi = new Color[3]
        {
            Color.FromArgb(0, 65, 106),
            Color.FromArgb(121, 159, 12),
            Color.FromArgb(255, 224, 0)
        };
    }
}
