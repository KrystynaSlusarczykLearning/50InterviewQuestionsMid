namespace InversionOfControl_WinFormsApp
{
    partial class HelloForm
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
            this.HelloLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.YearOfBirthTextBox = new System.Windows.Forms.TextBox();
            this.YearOfBirthLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelloLabel
            // 
            this.HelloLabel.AutoSize = true;
            this.HelloLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelloLabel.Location = new System.Drawing.Point(100, 9);
            this.HelloLabel.Name = "HelloLabel";
            this.HelloLabel.Size = new System.Drawing.Size(320, 37);
            this.HelloLabel.TabIndex = 0;
            this.HelloLabel.Text = "Hello! What\'s your name?";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameTextBox.Location = new System.Drawing.Point(100, 59);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "Type your name...";
            this.NameTextBox.Size = new System.Drawing.Size(320, 43);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox_KeyPress);
            // 
            // YearOfBirthTextBox
            // 
            this.YearOfBirthTextBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YearOfBirthTextBox.Location = new System.Drawing.Point(100, 174);
            this.YearOfBirthTextBox.Name = "YearOfBirthTextBox";
            this.YearOfBirthTextBox.PlaceholderText = "Type your year of birth...";
            this.YearOfBirthTextBox.Size = new System.Drawing.Size(320, 43);
            this.YearOfBirthTextBox.TabIndex = 3;
            this.YearOfBirthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YearOfBirthTextBox_KeyPress);
            // 
            // YearOfBirthLabel
            // 
            this.YearOfBirthLabel.AutoSize = true;
            this.YearOfBirthLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YearOfBirthLabel.Location = new System.Drawing.Point(100, 124);
            this.YearOfBirthLabel.Name = "YearOfBirthLabel";
            this.YearOfBirthLabel.Size = new System.Drawing.Size(327, 37);
            this.YearOfBirthLabel.TabIndex = 2;
            this.YearOfBirthLabel.Text = "What year you were born?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(189, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.AutoSize = true;
            this.ResultTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ResultTextBox.Location = new System.Drawing.Point(12, 276);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(0, 37);
            this.ResultTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 339);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YearOfBirthTextBox);
            this.Controls.Add(this.YearOfBirthLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.HelloLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label HelloLabel;
        private TextBox NameTextBox;
        private TextBox YearOfBirthTextBox;
        private Label YearOfBirthLabel;
        private Button button1;
        private Label ResultTextBox;
    }
}