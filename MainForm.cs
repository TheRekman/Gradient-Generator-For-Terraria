using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Rectangle rectangle = e.ClipRectangle;
            int partCount = colors.Length - 1;
            if (partCount == 0) partCount = 1;
            int partLength = rectangle.Width / partCount;

            LinearGradientBrush brush;
            Rectangle partRectangle;
            Color startColor, endColor;

            for (int i = 0; i < partCount; i++)
            {
                startColor = colors[i];
                if (colors.Length < 2) endColor = startColor;
                else endColor = colors[i + 1];
                partRectangle = new Rectangle(rectangle.X + (partLength * i), rectangle.Y, partLength, rectangle.Height);
                brush = new LinearGradientBrush(
                    partRectangle,
                    startColor,
                    endColor,
                    0.0
                    );
                e.Graphics.FillRectangle(brush, partRectangle);
            }
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

            int stepRed, stepGreen, stepBlue;
            int startRed, startGreen, startBlue;
            int endRed, endGreen, endBlue;

            int partsCount;
            if (count < colors.Length) partsCount = count;
            else partsCount = colors.Length - 1;

            int stepInPart = count / partsCount;
            if (stepInPart == 0) stepInPart = 1;
            

            for(int i = 0; i < partsCount; i++)
            {
                startRed = colors[i].R;
                startGreen = colors[i].G;
                startBlue = colors[i].B;

                endRed = colors[i+1].R;
                endGreen = colors[i+1].G;
                endBlue = colors[i+1].B;

                stepRed = (endRed - startRed) / stepInPart;
                stepGreen = (endGreen - startGreen) / stepInPart;
                stepBlue = (endBlue - startBlue) / stepInPart;

                for (int j = 0; j < stepInPart; j++)
                {
                    int id = i * stepInPart + j;
                    result[id] = Color.FromArgb(startRed, startGreen, startBlue);

                    startRed += stepRed;
                    startGreen += stepGreen;
                    startBlue += stepBlue;
                }
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
