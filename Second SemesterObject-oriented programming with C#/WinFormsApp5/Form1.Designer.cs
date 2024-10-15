using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp5
{
    partial class FormOne
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
            Rectangle = new Button();
            btnSelectTriangle = new Button();
            btnSelectCircle = new Button();
            btnSelectColor = new Button();
            undo = new Button();
            redo = new Button();
            Line = new Button();
            button1 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // Rectangle
            // 
            Rectangle.Location = new Point(959, 98);
            Rectangle.Name = "Rectangle";
            Rectangle.Size = new Size(181, 30);
            Rectangle.TabIndex = 0;
            Rectangle.Text = "Rectangle";
            Rectangle.UseVisualStyleBackColor = true;
            Rectangle.Click += btnSelectRectangle_Click;
            // 
            // btnSelectTriangle
            // 
            btnSelectTriangle.Location = new Point(959, 26);
            btnSelectTriangle.Name = "btnSelectTriangle";
            btnSelectTriangle.Size = new Size(181, 30);
            btnSelectTriangle.TabIndex = 1;
            btnSelectTriangle.Text = "Triangle";
            btnSelectTriangle.UseVisualStyleBackColor = true;
            btnSelectTriangle.Click += btnSelectTriangle_Click;
            // 
            // btnSelectCircle
            // 
            btnSelectCircle.Location = new Point(959, 62);
            btnSelectCircle.Name = "btnSelectCircle";
            btnSelectCircle.Size = new Size(181, 30);
            btnSelectCircle.TabIndex = 2;
            btnSelectCircle.Text = "Circle";
            btnSelectCircle.UseVisualStyleBackColor = true;
            btnSelectCircle.Click += btnSelectCircle_Click;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Location = new Point(1028, 637);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(112, 39);
            btnSelectColor.TabIndex = 3;
            btnSelectColor.Text = "Colour";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click;
            // 
            // undo
            // 
            undo.Location = new Point(27, 637);
            undo.Name = "undo";
            undo.Size = new Size(73, 32);
            undo.TabIndex = 4;
            undo.Text = "undo";
            undo.UseVisualStyleBackColor = true;
            undo.Click += btnUndo_Click;
            // 
            // redo
            // 
            redo.Location = new Point(106, 637);
            redo.Name = "redo";
            redo.Size = new Size(85, 30);
            redo.TabIndex = 5;
            redo.Text = "redo";
            redo.UseVisualStyleBackColor = true;
            redo.Click += btnRedo_Click;
            // 
            // Line
            // 
            Line.Location = new Point(959, 134);
            Line.Name = "Line";
            Line.Size = new Size(181, 30);
            Line.TabIndex = 6;
            Line.Text = "Line";
            Line.UseVisualStyleBackColor = true;
            Line.Click += btnSelectLine_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1026, 572);
            button1.Name = "button1";
            button1.Size = new Size(123, 51);
            button1.TabIndex = 7;
            button1.Text = "clear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 28);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(170, 29);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "Sorting by name";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(12, 110);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(176, 29);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "Sorting by colour";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged_1;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(12, 191);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(207, 29);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "Most common figure";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(12, 275);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(211, 29);
            checkBox4.TabIndex = 11;
            checkBox4.Text = "Most common colour";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 31);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 145);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(204, 31);
            textBox2.TabIndex = 13;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 226);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 31);
            textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 310);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 31);
            textBox4.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(1028, 471);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 16;
            button2.Text = "SaveToFile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(999, 522);
            button3.Name = "button3";
            button3.Size = new Size(150, 34);
            button3.TabIndex = 17;
            button3.Text = "LoadFromFile";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // FormOne
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 688);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(Line);
            Controls.Add(redo);
            Controls.Add(undo);
            Controls.Add(btnSelectColor);
            Controls.Add(btnSelectCircle);
            Controls.Add(btnSelectTriangle);
            Controls.Add(Rectangle);
            DoubleBuffered = true;
            Name = "FormOne";
            Text = "Form1";
            Load += FormOne_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Rectangle;
        private Button btnSelectTriangle;
        private Button btnSelectCircle;
        private Button btnSelectColor;
        private Button undo;
        private Button redo;
        private Button Line;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
        private Button button3;
    }
}