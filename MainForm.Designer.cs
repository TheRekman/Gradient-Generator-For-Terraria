namespace GradientGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.PasteInputButton = new System.Windows.Forms.Button();
            this.CopyInputButton = new System.Windows.Forms.Button();
            this.CopyOutputButton = new System.Windows.Forms.Button();
            this.GradientExamplePictureBox = new System.Windows.Forms.PictureBox();
            this.AddColorButton = new System.Windows.Forms.Button();
            this.PickedColorPictureBox = new System.Windows.Forms.PictureBox();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.ColorPickedID = new System.Windows.Forms.NumericUpDown();
            this.LabelColorID = new System.Windows.Forms.Label();
            this.LabelRGB = new System.Windows.Forms.Label();
            this.LabelHEX = new System.Windows.Forms.Label();
            this.ColorRGB = new System.Windows.Forms.TextBox();
            this.ColorHEX = new System.Windows.Forms.TextBox();
            this.ClearColorsButton = new System.Windows.Forms.Button();
            this.LabelInputCountChars = new System.Windows.Forms.Label();
            this.LabelOutputCountChars = new System.Windows.Forms.Label();
            this.InputCountChars = new System.Windows.Forms.Label();
            this.OutputCountChars = new System.Windows.Forms.Label();
            this.DeleteColorButton = new System.Windows.Forms.Button();
            this.LabelCountColor = new System.Windows.Forms.Label();
            this.CountColors = new System.Windows.Forms.Label();
            this.GradientTemplateComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GradientExamplePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickedColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPickedID)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 12);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputTextBox.Size = new System.Drawing.Size(200, 230);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OutputTextBox.Location = new System.Drawing.Point(223, 12);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputTextBox.Size = new System.Drawing.Size(200, 230);
            this.OutputTextBox.TabIndex = 1;
            this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(12, 290);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(139, 171);
            this.GenerateButton.TabIndex = 2;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // PasteInputButton
            // 
            this.PasteInputButton.Location = new System.Drawing.Point(12, 261);
            this.PasteInputButton.Name = "PasteInputButton";
            this.PasteInputButton.Size = new System.Drawing.Size(75, 23);
            this.PasteInputButton.TabIndex = 4;
            this.PasteInputButton.Text = "Paste";
            this.PasteInputButton.UseVisualStyleBackColor = true;
            this.PasteInputButton.Click += new System.EventHandler(this.InputPasteButton_Click);
            // 
            // CopyInputButton
            // 
            this.CopyInputButton.Location = new System.Drawing.Point(93, 261);
            this.CopyInputButton.Name = "CopyInputButton";
            this.CopyInputButton.Size = new System.Drawing.Size(75, 23);
            this.CopyInputButton.TabIndex = 5;
            this.CopyInputButton.Text = "Copy";
            this.CopyInputButton.UseVisualStyleBackColor = true;
            this.CopyInputButton.Click += new System.EventHandler(this.CopyInputButton_Click);
            // 
            // CopyOutputButton
            // 
            this.CopyOutputButton.Location = new System.Drawing.Point(218, 261);
            this.CopyOutputButton.Name = "CopyOutputButton";
            this.CopyOutputButton.Size = new System.Drawing.Size(75, 23);
            this.CopyOutputButton.TabIndex = 6;
            this.CopyOutputButton.Text = "Copy";
            this.CopyOutputButton.UseVisualStyleBackColor = true;
            this.CopyOutputButton.Click += new System.EventHandler(this.CopyOutputButton_Click);
            // 
            // GradientExamplePictureBox
            // 
            this.GradientExamplePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GradientExamplePictureBox.Location = new System.Drawing.Point(157, 290);
            this.GradientExamplePictureBox.Name = "GradientExamplePictureBox";
            this.GradientExamplePictureBox.Size = new System.Drawing.Size(266, 55);
            this.GradientExamplePictureBox.TabIndex = 7;
            this.GradientExamplePictureBox.TabStop = false;
            this.GradientExamplePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GradientExamplePictureBox_Paint);
            // 
            // AddColorButton
            // 
            this.AddColorButton.Location = new System.Drawing.Point(157, 351);
            this.AddColorButton.Name = "AddColorButton";
            this.AddColorButton.Size = new System.Drawing.Size(85, 23);
            this.AddColorButton.TabIndex = 8;
            this.AddColorButton.Text = "Add Color";
            this.AddColorButton.UseVisualStyleBackColor = true;
            this.AddColorButton.Click += new System.EventHandler(this.AddColorButton_Click);
            // 
            // PickedColorPictureBox
            // 
            this.PickedColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PickedColorPictureBox.Location = new System.Drawing.Point(368, 351);
            this.PickedColorPictureBox.Name = "PickedColorPictureBox";
            this.PickedColorPictureBox.Size = new System.Drawing.Size(55, 55);
            this.PickedColorPictureBox.TabIndex = 9;
            this.PickedColorPictureBox.TabStop = false;
            this.PickedColorPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PickedColorPictureBox_Paint);
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Location = new System.Drawing.Point(157, 380);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(85, 23);
            this.ChangeColorButton.TabIndex = 10;
            this.ChangeColorButton.Text = "Change Color";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            this.ChangeColorButton.Click += new System.EventHandler(this.ChangeColorButton_Click);
            // 
            // ColorPickedID
            // 
            this.ColorPickedID.Location = new System.Drawing.Point(299, 351);
            this.ColorPickedID.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ColorPickedID.Name = "ColorPickedID";
            this.ColorPickedID.Size = new System.Drawing.Size(51, 20);
            this.ColorPickedID.TabIndex = 11;
            this.ColorPickedID.ValueChanged += new System.EventHandler(this.ColorPickedID_ValueChanged);
            // 
            // LabelColorID
            // 
            this.LabelColorID.AutoSize = true;
            this.LabelColorID.Location = new System.Drawing.Point(248, 353);
            this.LabelColorID.Name = "LabelColorID";
            this.LabelColorID.Size = new System.Drawing.Size(45, 13);
            this.LabelColorID.TabIndex = 12;
            this.LabelColorID.Text = "Color ID";
            // 
            // LabelRGB
            // 
            this.LabelRGB.AutoSize = true;
            this.LabelRGB.Location = new System.Drawing.Point(247, 380);
            this.LabelRGB.Name = "LabelRGB";
            this.LabelRGB.Size = new System.Drawing.Size(30, 13);
            this.LabelRGB.TabIndex = 13;
            this.LabelRGB.Text = "RGB";
            // 
            // LabelHEX
            // 
            this.LabelHEX.AutoSize = true;
            this.LabelHEX.Location = new System.Drawing.Point(248, 406);
            this.LabelHEX.Name = "LabelHEX";
            this.LabelHEX.Size = new System.Drawing.Size(29, 13);
            this.LabelHEX.TabIndex = 14;
            this.LabelHEX.Text = "HEX";
            // 
            // ColorRGB
            // 
            this.ColorRGB.Location = new System.Drawing.Point(284, 377);
            this.ColorRGB.Name = "ColorRGB";
            this.ColorRGB.ReadOnly = true;
            this.ColorRGB.Size = new System.Drawing.Size(78, 20);
            this.ColorRGB.TabIndex = 15;
            // 
            // ColorHEX
            // 
            this.ColorHEX.Location = new System.Drawing.Point(283, 403);
            this.ColorHEX.Name = "ColorHEX";
            this.ColorHEX.ReadOnly = true;
            this.ColorHEX.Size = new System.Drawing.Size(78, 20);
            this.ColorHEX.TabIndex = 16;
            // 
            // ClearColorsButton
            // 
            this.ClearColorsButton.Location = new System.Drawing.Point(159, 438);
            this.ClearColorsButton.Name = "ClearColorsButton";
            this.ClearColorsButton.Size = new System.Drawing.Size(85, 23);
            this.ClearColorsButton.TabIndex = 17;
            this.ClearColorsButton.Text = "Clear";
            this.ClearColorsButton.UseVisualStyleBackColor = true;
            this.ClearColorsButton.Click += new System.EventHandler(this.ClearColorsButton_Click);
            // 
            // LabelInputCountChars
            // 
            this.LabelInputCountChars.AutoSize = true;
            this.LabelInputCountChars.Location = new System.Drawing.Point(12, 245);
            this.LabelInputCountChars.Name = "LabelInputCountChars";
            this.LabelInputCountChars.Size = new System.Drawing.Size(68, 13);
            this.LabelInputCountChars.TabIndex = 18;
            this.LabelInputCountChars.Text = "Count Chars:";
            // 
            // LabelOutputCountChars
            // 
            this.LabelOutputCountChars.AutoSize = true;
            this.LabelOutputCountChars.Location = new System.Drawing.Point(220, 245);
            this.LabelOutputCountChars.Name = "LabelOutputCountChars";
            this.LabelOutputCountChars.Size = new System.Drawing.Size(68, 13);
            this.LabelOutputCountChars.TabIndex = 19;
            this.LabelOutputCountChars.Text = "Count Chars:";
            // 
            // InputCountChars
            // 
            this.InputCountChars.AutoSize = true;
            this.InputCountChars.Location = new System.Drawing.Point(86, 245);
            this.InputCountChars.Name = "InputCountChars";
            this.InputCountChars.Size = new System.Drawing.Size(13, 13);
            this.InputCountChars.TabIndex = 20;
            this.InputCountChars.Text = "0";
            // 
            // OutputCountChars
            // 
            this.OutputCountChars.AutoSize = true;
            this.OutputCountChars.Location = new System.Drawing.Point(294, 245);
            this.OutputCountChars.Name = "OutputCountChars";
            this.OutputCountChars.Size = new System.Drawing.Size(13, 13);
            this.OutputCountChars.TabIndex = 21;
            this.OutputCountChars.Text = "0";
            // 
            // DeleteColorButton
            // 
            this.DeleteColorButton.Location = new System.Drawing.Point(159, 409);
            this.DeleteColorButton.Name = "DeleteColorButton";
            this.DeleteColorButton.Size = new System.Drawing.Size(85, 23);
            this.DeleteColorButton.TabIndex = 22;
            this.DeleteColorButton.Text = "Delete Color";
            this.DeleteColorButton.UseVisualStyleBackColor = true;
            this.DeleteColorButton.Click += new System.EventHandler(this.DeleteColorButton_Click);
            // 
            // LabelCountColor
            // 
            this.LabelCountColor.AutoSize = true;
            this.LabelCountColor.Location = new System.Drawing.Point(248, 426);
            this.LabelCountColor.Name = "LabelCountColor";
            this.LabelCountColor.Size = new System.Drawing.Size(65, 13);
            this.LabelCountColor.TabIndex = 23;
            this.LabelCountColor.Text = "Count Color:";
            // 
            // CountColors
            // 
            this.CountColors.AutoSize = true;
            this.CountColors.Location = new System.Drawing.Point(319, 426);
            this.CountColors.Name = "CountColors";
            this.CountColors.Size = new System.Drawing.Size(13, 13);
            this.CountColors.TabIndex = 25;
            this.CountColors.Text = "0";
            // 
            // GradientTemplateComboBox
            // 
            this.GradientTemplateComboBox.FormattingEnabled = true;
            this.GradientTemplateComboBox.Location = new System.Drawing.Point(341, 426);
            this.GradientTemplateComboBox.Name = "GradientTemplateComboBox";
            this.GradientTemplateComboBox.Size = new System.Drawing.Size(82, 21);
            this.GradientTemplateComboBox.TabIndex = 26;
            this.GradientTemplateComboBox.Text = "Template";
            this.GradientTemplateComboBox.SelectedValueChanged += new System.EventHandler(this.GradientTemplateComboBox_SelectedValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 470);
            this.Controls.Add(this.GradientTemplateComboBox);
            this.Controls.Add(this.CountColors);
            this.Controls.Add(this.LabelCountColor);
            this.Controls.Add(this.DeleteColorButton);
            this.Controls.Add(this.OutputCountChars);
            this.Controls.Add(this.InputCountChars);
            this.Controls.Add(this.LabelOutputCountChars);
            this.Controls.Add(this.LabelInputCountChars);
            this.Controls.Add(this.ClearColorsButton);
            this.Controls.Add(this.ColorHEX);
            this.Controls.Add(this.ColorRGB);
            this.Controls.Add(this.LabelHEX);
            this.Controls.Add(this.LabelRGB);
            this.Controls.Add(this.LabelColorID);
            this.Controls.Add(this.ColorPickedID);
            this.Controls.Add(this.ChangeColorButton);
            this.Controls.Add(this.PickedColorPictureBox);
            this.Controls.Add(this.AddColorButton);
            this.Controls.Add(this.GradientExamplePictureBox);
            this.Controls.Add(this.CopyOutputButton);
            this.Controls.Add(this.CopyInputButton);
            this.Controls.Add(this.PasteInputButton);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Gradient Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradientExamplePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PickedColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorPickedID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button PasteInputButton;
        private System.Windows.Forms.Button CopyInputButton;
        private System.Windows.Forms.Button CopyOutputButton;
        private System.Windows.Forms.PictureBox GradientExamplePictureBox;
        private System.Windows.Forms.Button AddColorButton;
        private System.Windows.Forms.PictureBox PickedColorPictureBox;
        private System.Windows.Forms.Button ChangeColorButton;
        private System.Windows.Forms.NumericUpDown ColorPickedID;
        private System.Windows.Forms.Label LabelColorID;
        private System.Windows.Forms.Label LabelRGB;
        private System.Windows.Forms.Label LabelHEX;
        private System.Windows.Forms.TextBox ColorRGB;
        private System.Windows.Forms.TextBox ColorHEX;
        private System.Windows.Forms.Button ClearColorsButton;
        private System.Windows.Forms.Label LabelInputCountChars;
        private System.Windows.Forms.Label LabelOutputCountChars;
        private System.Windows.Forms.Label InputCountChars;
        private System.Windows.Forms.Label OutputCountChars;
        private System.Windows.Forms.Button DeleteColorButton;
        private System.Windows.Forms.Label LabelCountColor;
        private System.Windows.Forms.Label CountColors;
        private System.Windows.Forms.ComboBox GradientTemplateComboBox;
    }
}

