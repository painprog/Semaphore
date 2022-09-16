namespace Semaphore
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
            this.input = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.englishLetters = new System.Windows.Forms.RichTextBox();
            this.numbers = new System.Windows.Forms.RichTextBox();
            this.symbols = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(163, 368);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(392, 39);
            this.input.TabIndex = 1;
            this.input.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter text";
            // 
            // englishLetters
            // 
            this.englishLetters.Location = new System.Drawing.Point(163, 84);
            this.englishLetters.Name = "englishLetters";
            this.englishLetters.Size = new System.Drawing.Size(392, 51);
            this.englishLetters.TabIndex = 3;
            this.englishLetters.Text = "";
            // 
            // numbers
            // 
            this.numbers.Location = new System.Drawing.Point(163, 166);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(392, 51);
            this.numbers.TabIndex = 4;
            this.numbers.Text = "";
            // 
            // symbols
            // 
            this.symbols.Location = new System.Drawing.Point(163, 247);
            this.symbols.Name = "symbols";
            this.symbols.Size = new System.Drawing.Size(392, 51);
            this.symbols.TabIndex = 5;
            this.symbols.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "English letters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numbers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Symbols";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.symbols);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.englishLetters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox englishLetters;
        private System.Windows.Forms.RichTextBox numbers;
        private System.Windows.Forms.RichTextBox symbols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
