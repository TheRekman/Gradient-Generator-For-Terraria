using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace GradientGenerator
{
    public partial class MainForm : Form
    {

        ColorDialog colorDialog = new ColorDialog();
        List<Color> Colors = new List<Color> {  };
        Dictionary<string, Color[]> Templates = new Dictionary<string, Color[]>();
        public MainForm()
        {
            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Templates.Add("Rainbow", GradientTemplates.Rainbow);
            GradientTemplateComboBox.Items.AddRange(Templates.Keys.ToArray());
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
            if(Colors.Count == 0)
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
            if(ColorPickedID.Value == Colors.Count) ColorPickedID.Value--;
            else SyncColor();
            ColorPickedID.Maximum--;
            
        }


        #endregion

        #region Drawing
        private void DrawGradient(Color[] colors, PaintEventArgs e)
        {
            int count = colors.Count();
            if(count == 1)
            {
                FillRectangle(colors[0],e);
                return;
            }
            ColorBlend cb = new ColorBlend(count);
            LinearGradientBrush brush = new LinearGradientBrush(e.ClipRectangle, Color.Black, Color.Black, 0 , false);

            float[] pos = new float[count];
            for(int i = 0; i < count; i++)
                pos[i] = (float)i/(count - 1);

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
                if(text[i] == ' ')
                {
                    result += " ";
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

                pos = (float)i / (count-1);

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
            if(Colors.Count > 0) DrawGradient(Colors.ToArray(), e);
        }

        private void PickedColorPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(Colors.Count > 0) FillRectangle(Colors[(int)ColorPickedID.Value], e);
        }

        private void GradientTemplateComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearColorsButton_Click(sender, e);
            Colors.AddRange(Templates[GradientTemplateComboBox.SelectedItem.ToString()]);
            ColorPickedID.Maximum = Colors.Count - 1;
            SyncColor();
        }
    }
}
