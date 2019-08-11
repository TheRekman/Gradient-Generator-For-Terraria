using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using GradientGenerator.Palettes;


namespace GradientGenerator
{
    public partial class MainForm : Form
    {

        ColorDialog colorDialog = new ColorDialog();

        List<Color> Colors = new List<Color> { };

        public MainForm()
        {

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GradientPalettes.Initialize();
            GradientPaletteComboBox.Items.AddRange(GradientPalettes.Palettes.Keys.ToArray());
            SyncColor();
        }

        #region CopyPaste
        private void InputPasteButton_Click(object sender, EventArgs e) =>
            InputTextBox.Text = Clipboard.GetText();
        private void CopyInputButton_Click(object sender, EventArgs e) =>
            Clipboard.SetText(InputTextBox.Text);
        private void CopyOutputButton_Click(object sender, EventArgs e) =>
            Clipboard.SetText(OutputTextBox.Text);
        #endregion

        #region CharsCount
        private void InputTextBox_TextChanged(object sender, EventArgs e) =>
            InputCountChars.Text = InputTextBox.Text.Count().ToString();
        private void OutputTextBox_TextChanged(object sender, EventArgs e) =>
            OutputCountChars.Text = OutputTextBox.Text.Count().ToString();
        #endregion

        #region ColorListManager
        private void AddColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Colors.Add(colorDialog.Color);
            ColorPickedID.Maximum = Colors.Count - 1;
            ColorPickedID.Value = ColorPickedID.Maximum;
            SyncColor();
        }

        private void ChangeColorButton_Click(object sender, EventArgs e)
        {
            if (Colors.Count != 0)
            {
                colorDialog.Color = Colors[(int)ColorPickedID.Value];
                colorDialog.ShowDialog();
                Colors[(int)ColorPickedID.Value] = colorDialog.Color;
            }
            SyncColor();
        }

        private void ClearColorsButton_Click(object sender, EventArgs e)
        {
            Colors.Clear();
            ColorPickedID.Value = 0;
            ColorPickedID.Maximum = 0;
            SyncColor();
        }

        private void ColorPickedID_ValueChanged(object sender, EventArgs e) =>
            SyncColor();

        private void SyncColor()
        {
            CountColors.Text = Colors.Count.ToString();
            if (Colors.Count == 0)
            {
                ColorRGB.Text = "-";
                ColorHEX.Text = "-";
                return;
            }
            Color pickedColor = Colors[(int)ColorPickedID.Value];
            ColorRGB.Text =
            pickedColor.R + "," +
            pickedColor.G + "," +
            pickedColor.B;
            ColorHEX.Text = ToHEX(pickedColor);
            PaintEventArgs e;
            e = new PaintEventArgs(PickedColorPictureBox.CreateGraphics(), PickedColorPictureBox.ClientRectangle);
            FillRectangle(pickedColor, e);
            e = new PaintEventArgs(GradientExamplePictureBox.CreateGraphics(), GradientExamplePictureBox.ClientRectangle);
            DrawGradient(Colors.ToArray(), e);
        }

        private void DeleteColorButton_Click(object sender, EventArgs e)
        {
            if (Colors.Count < 2)
            {
                ClearColorsButton_Click(sender, e);
                return;
            }
            Colors.RemoveAt((int)ColorPickedID.Value);
            if (ColorPickedID.Value == Colors.Count) ColorPickedID.Value--;
            else SyncColor();
            ColorPickedID.Maximum--;

        }


        #endregion

        #region Drawing
        private void DrawGradient(Color[] colors, PaintEventArgs e)
        {
            int count = colors.Count();
            if (count == 1)
            {
                FillRectangle(colors[0], e);
                return;
            }
            ColorBlend cb = new ColorBlend(count);
            LinearGradientBrush brush = new LinearGradientBrush(e.ClipRectangle, Color.Black, Color.Black, 0, false);

            float[] pos = new float[count];
            for (int i = 0; i < count; i++)
                pos[i] = (float)i / (count - 1);

            cb.Positions = pos;
            cb.Colors = colors;
            brush.InterpolationColors = cb;

            e.Graphics.FillRectangle(brush, e.ClipRectangle);

        }

        private void FillRectangle(Color color, PaintEventArgs e)
        {
            Brush brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }
        #endregion

        #region HEX_RGB_Input
        private void ColorRGB_Leave(object sender, EventArgs e) =>
            RGBInput();


        private void ColorRGB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) RGBInput();
        }
        private void RGBInput()
        {
            if (Colors.Count == 0)
            {
                SyncColor();
                return;
            }

            string[] rgb = ColorRGB.Text.Replace(" ", "").Split(',');
            byte red, green, blue;
            if (Byte.TryParse(rgb[0], out red) &&
            Byte.TryParse(rgb[1], out green) &&
            Byte.TryParse(rgb[2], out blue))
            {
                int colorID = (int)ColorPickedID.Value;
                Colors[colorID] = Color.FromArgb(red, green, blue);
            }
            SyncColor();
        }

        private void ColorHEX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) HEXInput();
        }

        private void ColorHEX_Leave(object sender, EventArgs e) =>
            HEXInput();


        private void HEXInput()
        {
            if (Colors.Count == 0)
            {
                SyncColor();
                return;
            }
            string text = ColorHEX.Text;
            text = text.Replace("#", "");
            if (text.Length == 6)
            {
                string[] hex = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    hex[i] = text[i * 2].ToString() + text[i * 2 + 1].ToString();
                }
                int colorID = (int)ColorPickedID.Value;
                int red, green, blue;
                try
                {
                    red = Convert.ToInt32(hex[0], 16);
                    green = Convert.ToInt32(hex[1], 16);
                    blue = Convert.ToInt32(hex[2], 16);
                }
                catch
                {
                    SyncColor();
                    return;
                }
                Colors[colorID] = Color.FromArgb(red, green, blue);
            }
            SyncColor();
        }
        #endregion

        private string ToHEX(Color color)
        {
            string result = null;
            if (color.R < 16) result += "0";
            result += Convert.ToString(color.R, 16);
            if (color.G < 16) result += "0";
            result += Convert.ToString(color.G, 16);
            if (color.B < 16) result += "0";
            result += Convert.ToString(color.B, 16);
            return result;
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (Colors.Count == 0) return;
            string text = InputTextBox.Text;
            string result = null;
            Color[] gradient = GenerateGradient(Colors.ToArray(), text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(text[i].ToString()))
                {
                    result += text[i].ToString();
                    continue;
                }

                string HEX = ToHEX(gradient[i]);
                result += string.Concat("[c/", HEX, ":", text[i].ToString(), "]");
            }
            OutputTextBox.Text = result;
        }

        private Color[] GenerateGradient(Color[] colors, int count)
        {
            Color[] result = new Color[count];
            if (colors.Count() == 1)
            {
                for (int i = 0; i < count; i++)
                    result[i] = colors[0];
                return result;
            }
            int clrCount = colors.Count();
            if (clrCount > count) clrCount = count;

            float[] positions = new float[clrCount];
            for (int i = 0; i < positions.Length; i++) positions[i] = (float)i / (clrCount - 1);

            float pos, partPosition;
            int Red, Green, Blue;
            int startRed, startGreen, startBlue;
            int endRed, endGreen, endBlue;
            int deltaRed, deltaGreen, deltaBlue;

            float step = positions[1] - positions[0];
            int colorID = 0;

            for (int i = 0; i < count; i++)
            {

                pos = (float)i / (count - 1);

                for (int j = 0; j < positions.Length - 1; j++)
                    if (pos >= positions[j] && pos < positions[j + 1])
                    {
                        colorID = j;
                        break;
                    }

                startRed = colors[colorID].R;
                startGreen = colors[colorID].G;
                startBlue = colors[colorID].B;

                endRed = colors[colorID + 1].R;
                endGreen = colors[colorID + 1].G;
                endBlue = colors[colorID + 1].B;

                deltaRed = endRed - startRed;
                deltaGreen = endGreen - startGreen;
                deltaBlue = endBlue - startBlue;

                partPosition = (pos - step * colorID) / step;

                Red = (int)(startRed + partPosition * deltaRed);
                Green = (int)(startGreen + partPosition * deltaGreen);
                Blue = (int)(startBlue + partPosition * deltaBlue);

                result[i] = Color.FromArgb(Red, Green, Blue);
            }
            return result;
        }

        private void GradientExamplePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (Colors.Count > 0) DrawGradient(Colors.ToArray(), e);
        }

        private void PickedColorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (Colors.Count > 0) FillRectangle(Colors[(int)ColorPickedID.Value], e);
        }



        private void Reverse_Click(object sender, EventArgs e)
        {
            Colors.Reverse();
            SyncColor();
        }

        private void SavePalleteButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "*.json|*.json";
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            if (String.IsNullOrEmpty(path) || Colors.Count == 0) return;
            PaletteManager.Save(path, new Palette(PaletteNameTextBox.Text, Colors.ToArray()));
        }

        private void LoadPaletteButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.json|*.json";
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            if (String.IsNullOrEmpty(path)) return;

            Palette[] loadPalettes = PaletteManager.Load(path);
            var paletts = GradientPalettes.Palettes;
            for (int i = 0; i < loadPalettes.Length; i++)
            {
                string name = loadPalettes[i].Name;
                Color[] colors = loadPalettes[i].GetColors();
                if (paletts.ContainsKey(name))
                    paletts[name] = colors;
                else paletts.Add(name, colors);
            }
            GradientPaletteComboBox.Items.Clear();
            GradientPaletteComboBox.Items.AddRange(paletts.Keys.ToArray());
        }

        private void GradientPaletteComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearColorsButton_Click(sender, e);
            Colors.AddRange(GradientPalettes.Palettes[GradientPaletteComboBox.SelectedItem.ToString()]);
            ColorPickedID.Maximum = Colors.Count - 1;
            PaletteNameTextBox.Text = GradientPaletteComboBox.SelectedItem.ToString();
            SyncColor();
        }

    }
}
