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
            PlaySoundButton = new Button();
            SoundInput = new TextBox();
            CheckButton = new Button();
            PointsLabel = new Label();
            SoundNameDisplay = new Label();
            LostPointsLabel = new Label();
            ReplaySound = new Button();
            PlayA = new Button();
            Timer = new Label();
            BestSoundsResultLabel = new Label();
            TimesInput = new TextBox();
            HowPointsWork = new Label();
            label1 = new Label();
            FinalPointsLabel = new Label();
            IntervalInput = new TextBox();
            ChangeGameModeButton = new Button();
            IntervalDisplay = new Label();
            StartIntervals = new Button();
            CheckInterval = new Button();
            ReplayInterval = new Button();
            BestIntervalsResultLabel = new Label();
            SuspendLayout();
            // 
            // PlaySoundButton
            // 
            PlaySoundButton.Font = new Font("Segoe UI", 14F);
            PlaySoundButton.Location = new Point(264, 106);
            PlaySoundButton.Name = "PlaySoundButton";
            PlaySoundButton.Size = new Size(102, 32);
            PlaySoundButton.TabIndex = 2;
            PlaySoundButton.Text = "Start";
            PlaySoundButton.UseVisualStyleBackColor = true;
            PlaySoundButton.Click += OnStart;
            // 
            // SoundInput
            // 
            SoundInput.Font = new Font("Segoe UI", 14F);
            SoundInput.Location = new Point(330, 68);
            SoundInput.MaxLength = 5;
            SoundInput.Name = "SoundInput";
            SoundInput.PlaceholderText = "Dźwięk";
            SoundInput.Size = new Size(84, 32);
            SoundInput.TabIndex = 3;
            SoundInput.KeyDown += SoundInput_KeyDown;
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
            // PointsLabel
            // 
            PointsLabel.AutoSize = true;
            PointsLabel.Font = new Font("Segoe UI", 14F);
            PointsLabel.Location = new Point(20, 20);
            PointsLabel.Name = "PointsLabel";
            PointsLabel.Size = new Size(100, 25);
            PointsLabel.TabIndex = 5;
            PointsLabel.Text = "PointLabel";
            // 
            // SoundNameDisplay
            // 
            SoundNameDisplay.AutoSize = true;
            SoundNameDisplay.Font = new Font("Segoe UI", 40F);
            SoundNameDisplay.Location = new Point(339, -7);
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
            // ReplaySound
            // 
            ReplaySound.Font = new Font("Segoe UI", 14F);
            ReplaySound.Location = new Point(372, 144);
            ReplaySound.Name = "ReplaySound";
            ReplaySound.Size = new Size(102, 32);
            ReplaySound.TabIndex = 8;
            ReplaySound.Text = "Powtórz";
            ReplaySound.UseVisualStyleBackColor = true;
            ReplaySound.Click += OnPlaySomeSound;
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
            // BestSoundsResultLabel
            // 
            BestSoundsResultLabel.AutoSize = true;
            BestSoundsResultLabel.Font = new Font("Segoe UI", 18F);
            BestSoundsResultLabel.Location = new Point(546, 68);
            BestSoundsResultLabel.Name = "BestSoundsResultLabel";
            BestSoundsResultLabel.Size = new Size(93, 32);
            BestSoundsResultLabel.TabIndex = 11;
            BestSoundsResultLabel.Text = "Rekord:";
            // 
            // TimesInput
            // 
            TimesInput.Font = new Font("Segoe UI", 14F);
            TimesInput.Location = new Point(20, 144);
            TimesInput.Name = "TimesInput";
            TimesInput.PlaceholderText = "Liczba";
            TimesInput.Size = new Size(75, 32);
            TimesInput.TabIndex = 12;
            // 
            // HowPointsWork
            // 
            HowPointsWork.AutoSize = true;
            HowPointsWork.Font = new Font("Segoe UI", 18F);
            HowPointsWork.Location = new Point(31, 249);
            HowPointsWork.Name = "HowPointsWork";
            HowPointsWork.Size = new Size(730, 192);
            HowPointsWork.TabIndex = 13;
            HowPointsWork.Text = "Punktacja: od zdobytych punktów odejmowane są stracone punkty.\r\nSkróty klawiaturowe:\r\n\r\nR - powtórzenie bieżącego dźwięku / interwału\r\nQ - odtworzenie dźwięku A\r\nEnter - sprawdzenie odpowiedzi\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 112);
            label1.Name = "label1";
            label1.Size = new Size(174, 30);
            label1.TabIndex = 14;
            label1.Text = "Liczba dźwięków";
            // 
            // FinalPointsLabel
            // 
            FinalPointsLabel.AutoSize = true;
            FinalPointsLabel.Font = new Font("Segoe UI", 16F);
            FinalPointsLabel.Location = new Point(309, 201);
            FinalPointsLabel.Name = "FinalPointsLabel";
            FinalPointsLabel.Size = new Size(165, 30);
            FinalPointsLabel.TabIndex = 15;
            FinalPointsLabel.Text = "FinalPointsLabel";
            // 
            // IntervalInput
            // 
            IntervalInput.Font = new Font("Segoe UI", 14F);
            IntervalInput.Location = new Point(330, 68);
            IntervalInput.MaxLength = 5;
            IntervalInput.Name = "IntervalInput";
            IntervalInput.PlaceholderText = "Interwał";
            IntervalInput.Size = new Size(84, 32);
            IntervalInput.TabIndex = 16;
            IntervalInput.KeyDown += IntervalInputKeyDow;
            // 
            // ChangeGameModeButton
            // 
            ChangeGameModeButton.Font = new Font("Segoe UI", 14F);
            ChangeGameModeButton.Location = new Point(621, 199);
            ChangeGameModeButton.Name = "ChangeGameModeButton";
            ChangeGameModeButton.Size = new Size(102, 32);
            ChangeGameModeButton.TabIndex = 17;
            ChangeGameModeButton.Text = "Interwały";
            ChangeGameModeButton.UseVisualStyleBackColor = true;
            ChangeGameModeButton.Click += OnChangeGameMode;
            // 
            // IntervalDisplay
            // 
            IntervalDisplay.AutoSize = true;
            IntervalDisplay.Font = new Font("Segoe UI", 40F);
            IntervalDisplay.Location = new Point(339, -7);
            IntervalDisplay.Name = "IntervalDisplay";
            IntervalDisplay.Size = new Size(96, 72);
            IntervalDisplay.TabIndex = 18;
            IntervalDisplay.Text = "5>";
            // 
            // StartIntervals
            // 
            StartIntervals.Font = new Font("Segoe UI", 14F);
            StartIntervals.Location = new Point(264, 106);
            StartIntervals.Name = "StartIntervals";
            StartIntervals.Size = new Size(102, 32);
            StartIntervals.TabIndex = 19;
            StartIntervals.Text = "Start";
            StartIntervals.UseVisualStyleBackColor = true;
            StartIntervals.Click += OnStartIntervals;
            // 
            // CheckInterval
            // 
            CheckInterval.Font = new Font("Segoe UI", 14F);
            CheckInterval.Location = new Point(372, 106);
            CheckInterval.Name = "CheckInterval";
            CheckInterval.Size = new Size(102, 32);
            CheckInterval.TabIndex = 20;
            CheckInterval.Text = "Sprawdź";
            CheckInterval.UseVisualStyleBackColor = true;
            CheckInterval.Click += OnCheckInterval;
            // 
            // ReplayInterval
            // 
            ReplayInterval.Font = new Font("Segoe UI", 14F);
            ReplayInterval.Location = new Point(372, 144);
            ReplayInterval.Name = "ReplayInterval";
            ReplayInterval.Size = new Size(102, 32);
            ReplayInterval.TabIndex = 21;
            ReplayInterval.Text = "Powtórz";
            ReplayInterval.UseVisualStyleBackColor = true;
            // 
            // BestIntervalsResultLabel
            // 
            BestIntervalsResultLabel.AutoSize = true;
            BestIntervalsResultLabel.Font = new Font("Segoe UI", 18F);
            BestIntervalsResultLabel.Location = new Point(546, 68);
            BestIntervalsResultLabel.Name = "BestIntervalsResultLabel";
            BestIntervalsResultLabel.Size = new Size(93, 32);
            BestIntervalsResultLabel.TabIndex = 22;
            BestIntervalsResultLabel.Text = "Rekord:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BestIntervalsResultLabel);
            Controls.Add(ReplayInterval);
            Controls.Add(CheckInterval);
            Controls.Add(StartIntervals);
            Controls.Add(IntervalDisplay);
            Controls.Add(ChangeGameModeButton);
            Controls.Add(IntervalInput);
            Controls.Add(FinalPointsLabel);
            Controls.Add(label1);
            Controls.Add(HowPointsWork);
            Controls.Add(TimesInput);
            Controls.Add(BestSoundsResultLabel);
            Controls.Add(Timer);
            Controls.Add(PlayA);
            Controls.Add(ReplaySound);
            Controls.Add(LostPointsLabel);
            Controls.Add(SoundNameDisplay);
            Controls.Add(PointsLabel);
            Controls.Add(CheckButton);
            Controls.Add(SoundInput);
            Controls.Add(PlaySoundButton);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Dyktando-inator";
            KeyDown += KeyBinding;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PlaySoundButton;
        private TextBox SoundInput;
        private Button CheckButton;
        private Label PointsLabel;
        private Label SoundNameDisplay;
        private Label LostPointsLabel;
        private Button ReplaySound;
        private Button PlayA;
        private Label Timer;
        private Label BestSoundsResultLabel;
        private TextBox TimesInput;
        private Label HowPointsWork;
        private Label label1;
        private Label FinalPointsLabel;
        private TextBox IntervalInput;
        private Button ChangeGameModeButton;
        private Label IntervalDisplay;
        private Button StartIntervals;
        private Button CheckInterval;
        private Button ReplayInterval;
        private Label BestIntervalsResultLabel;
    }
}
