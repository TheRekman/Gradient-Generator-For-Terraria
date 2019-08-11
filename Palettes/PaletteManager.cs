using System;
using System.IO;
using Newtonsoft.Json;

namespace GradientGenerator.Palettes
{
    public static class PaletteManager
    {
        public static void Save(string path, Palette[] palette)
        {
            string jsonString = JsonConvert.SerializeObject(palette);
            File.WriteAllText(path, jsonString);
        }
        public static void Save(string path, Palette palette)
        {
            Palette[] palettes;
            if (File.Exists(path))
            {
                palettes = LoadJSON(path);
                for(int i = 0; i < palettes.Length; i++)
                {
                    if(palettes[i].Name == palette.Name)
                    {
                        palettes[i] = palette;
                        break;
                    }
                }
            }
            else palettes = new Palette[1] { palette };
            Save(path, palettes);
        }
        public static Palette[] Load(string path)
        {
            Palette[] result = LoadJSON(path);
            return result;
        }
        private static Palette[] LoadJSON(string path)
        {
            string content = File.ReadAllText(path);
            Palette[] palettes = JsonConvert.DeserializeObject<Palette[]>(content);
            return palettes;
        }
    }
}
