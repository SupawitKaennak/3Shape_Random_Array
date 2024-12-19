namespace midterm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            richTextBox1 = new RichTextBox();
            btnGenerateShape = new Button();
            comboBoxShapeType = new ComboBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(96, 52);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(552, 462);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // btnGenerateShape
            // 
            btnGenerateShape.Location = new Point(263, 545);
            btnGenerateShape.Name = "btnGenerateShape";
            btnGenerateShape.Size = new Size(94, 29);
            btnGenerateShape.TabIndex = 3;
            btnGenerateShape.Text = "select";
            btnGenerateShape.UseVisualStyleBackColor = true;
            btnGenerateShape.Click += btnGenerateShape_Click;
            // 
            // comboBoxShapeType
            // 
            comboBoxShapeType.FormattingEnabled = true;
            comboBoxShapeType.Location = new Point(96, 545);
            comboBoxShapeType.Name = "comboBoxShapeType";
            comboBoxShapeType.Size = new Size(151, 28);
            comboBoxShapeType.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 629);
            Controls.Add(comboBoxShapeType);
            Controls.Add(btnGenerateShape);
            Controls.Add(richTextBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btnGenerateShape;
        private ComboBox comboBoxShapeType;
        private System.Windows.Forms.Timer timer1;
    }
}
