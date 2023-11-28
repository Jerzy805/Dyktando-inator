namespace Dictations
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
            PlayButton = new Button();
            IndexInput = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.Font = new Font("Segoe UI", 14F);
            PlayButton.Location = new Point(281, 124);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(96, 34);
            PlayButton.TabIndex = 0;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // IndexInput
            // 
            IndexInput.Font = new Font("Segoe UI", 14F);
            IndexInput.Location = new Point(281, 86);
            IndexInput.Name = "IndexInput";
            IndexInput.Size = new Size(96, 32);
            IndexInput.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(488, 115);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(IndexInput);
            Controls.Add(PlayButton);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Dictations";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PlayButton;
        private TextBox IndexInput;
        private Button button1;
    }
}
