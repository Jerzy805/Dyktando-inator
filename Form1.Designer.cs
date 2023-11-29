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
            SoundInput = new TextBox();
            CheckButton = new Button();
            PointLabel = new Label();
            SoundNameDisplay = new Label();
            LostPointsLabel = new Label();
            Replay = new Button();
            PlayA = new Button();
            Timer = new Label();
            BestResultLabel = new Label();
            TimesInput = new TextBox();
            HowPointsWork = new Label();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.Font = new Font("Segoe UI", 14F);
            PlayButton.Location = new Point(264, 106);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(102, 32);
            PlayButton.TabIndex = 2;
            PlayButton.Text = "Zagraj";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += OnPlay;
            // 
            // SoundInput
            // 
            SoundInput.Font = new Font("Segoe UI", 14F);
            SoundInput.Location = new Point(330, 68);
            SoundInput.MaxLength = 3;
            SoundInput.Name = "SoundInput";
            SoundInput.PlaceholderText = "Dźwięk";
            SoundInput.Size = new Size(84, 32);
            SoundInput.TabIndex = 3;
            // 
            // CheckButton
            // 
            CheckButton.Font = new Font("Segoe UI", 14F);
            CheckButton.Location = new Point(372, 106);
            CheckButton.Name = "CheckButton";
            CheckButton.Size = new Size(102, 32);
            CheckButton.TabIndex = 4;
            CheckButton.Text = "Sprawdź";
            CheckButton.UseVisualStyleBackColor = true;
            CheckButton.Click += OnCheck;
            // 
            // PointLabel
            // 
            PointLabel.AutoSize = true;
            PointLabel.Font = new Font("Segoe UI", 14F);
            PointLabel.Location = new Point(20, 20);
            PointLabel.Name = "PointLabel";
            PointLabel.Size = new Size(100, 25);
            PointLabel.TabIndex = 5;
            PointLabel.Text = "PointLabel";
            // 
            // SoundNameDisplay
            // 
            SoundNameDisplay.AutoSize = true;
            SoundNameDisplay.Font = new Font("Segoe UI", 40F);
            SoundNameDisplay.Location = new Point(340, -7);
            SoundNameDisplay.Name = "SoundNameDisplay";
            SoundNameDisplay.Size = new Size(65, 72);
            SoundNameDisplay.TabIndex = 6;
            SoundNameDisplay.Text = "A";
            // 
            // LostPointsLabel
            // 
            LostPointsLabel.AutoSize = true;
            LostPointsLabel.Font = new Font("Segoe UI", 14F);
            LostPointsLabel.Location = new Point(20, 45);
            LostPointsLabel.Name = "LostPointsLabel";
            LostPointsLabel.Size = new Size(142, 25);
            LostPointsLabel.TabIndex = 7;
            LostPointsLabel.Text = "LostPointsLabel";
            // 
            // Replay
            // 
            Replay.Font = new Font("Segoe UI", 14F);
            Replay.Location = new Point(372, 144);
            Replay.Name = "Replay";
            Replay.Size = new Size(102, 32);
            Replay.TabIndex = 8;
            Replay.Text = "Powtórz";
            Replay.UseVisualStyleBackColor = true;
            Replay.Click += OnPlaySomeSound;
            // 
            // PlayA
            // 
            PlayA.BackColor = SystemColors.ActiveCaption;
            PlayA.Font = new Font("Segoe UI", 14F);
            PlayA.Location = new Point(264, 144);
            PlayA.Name = "PlayA";
            PlayA.Size = new Size(102, 32);
            PlayA.TabIndex = 9;
            PlayA.Text = "Dźwięk A";
            PlayA.UseVisualStyleBackColor = false;
            PlayA.Click += OnPlaySomeSound;
            // 
            // Timer
            // 
            Timer.AutoSize = true;
            Timer.Font = new Font("Segoe UI", 18F);
            Timer.Location = new Point(546, 30);
            Timer.Name = "Timer";
            Timer.Size = new Size(58, 32);
            Timer.TabIndex = 10;
            Timer.Text = "0:00";
            // 
            // BestResultLabel
            // 
            BestResultLabel.AutoSize = true;
            BestResultLabel.Font = new Font("Segoe UI", 18F);
            BestResultLabel.Location = new Point(546, 68);
            BestResultLabel.Name = "BestResultLabel";
            BestResultLabel.Size = new Size(93, 32);
            BestResultLabel.TabIndex = 11;
            BestResultLabel.Text = "Rekord:";
            // 
            // TimesInput
            // 
            TimesInput.Font = new Font("Segoe UI", 14F);
            TimesInput.Location = new Point(455, 27);
            TimesInput.Name = "TimesInput";
            TimesInput.PlaceholderText = "Liczba";
            TimesInput.Size = new Size(75, 32);
            TimesInput.TabIndex = 12;
            // 
            // HowPointsWork
            // 
            HowPointsWork.AutoSize = true;
            HowPointsWork.Font = new Font("Segoe UI", 18F);
            HowPointsWork.Location = new Point(31, 284);
            HowPointsWork.Name = "HowPointsWork";
            HowPointsWork.Size = new Size(725, 32);
            HowPointsWork.TabIndex = 13;
            HowPointsWork.Text = "Punktacja: od zdobytych punktów odejmowane są stracone punkty";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(HowPointsWork);
            Controls.Add(TimesInput);
            Controls.Add(BestResultLabel);
            Controls.Add(Timer);
            Controls.Add(PlayA);
            Controls.Add(Replay);
            Controls.Add(LostPointsLabel);
            Controls.Add(SoundNameDisplay);
            Controls.Add(PointLabel);
            Controls.Add(CheckButton);
            Controls.Add(SoundInput);
            Controls.Add(PlayButton);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Dyktando-inator";
            KeyDown += KeyBinding;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PlayButton;
        private TextBox SoundInput;
        private Button CheckButton;
        private Label PointLabel;
        private Label SoundNameDisplay;
        private Label LostPointsLabel;
        private Button Replay;
        private Button PlayA;
        private Label Timer;
        private Label BestResultLabel;
        private TextBox TimesInput;
        private Label HowPointsWork;
    }
}
