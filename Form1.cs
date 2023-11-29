using Dictations.Interfaces;
using Dictations.Models;

namespace Dictations
{
    public partial class Form1 : Form
    {
        private readonly IRepository repository;
        private readonly IHelper helper;
        private string soundName;
        private int wonPoints;
        private int lostPoints;
        private bool isAnswered;
        private int soundsLeft;
        private int previousSoundId;
        private System.Timers.Timer timer;
        private int elapsedSeconds = 0;
        private int elapsedMinuts = 0;

        public Form1()
        {
            InitializeComponent();

            timer = new();
            timer.Interval = 1000;
            timer.Elapsed += TimerElapsed!;

            this.KeyDown += KeyBinding!;

            SoundNameDisplay.TextAlign = ContentAlignment.MiddleCenter;
            //SoundNameDisplay.TextChanged += OnTest;

            repository = new Repository();

            helper = new Helper();

            soundName = string.Empty;

            wonPoints = 0;
            lostPoints = 0;

            SetPointsLabel();
            SetLostPointsLabel();

            isAnswered = true;

            soundsLeft = 10;

            SoundNameDisplay.Text = string.Empty;

            SoundNameDisplay.Text = "?";

            PlayA.BackColor = Color.Red;

            CheckButton.Enabled = false;
            Replay.Enabled = false;

            var bestResult = repository.GetBestResult();

            FormatBestResult(bestResult);

            TimesInput.Text = "10";
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            elapsedSeconds++;

            if (elapsedSeconds == 60)
            {
                elapsedMinuts++;
                elapsedSeconds = 0;
            }

            SetTimer();
        }

        private void SetTimer()
        {
            var secondsToString = elapsedSeconds.ToString();

            if (elapsedSeconds < 10)
            {
                secondsToString = $"0{elapsedSeconds}";
            }

            Timer.Text = $"{elapsedMinuts}:{secondsToString}";
        }

        private void OnPlay(object sender, EventArgs e)
        {
            PlayButton.Enabled = false;
            CheckButton.Enabled = true;
            Replay.Enabled = true;

            if (int.TryParse(TimesInput.Text, out int times))
            {
                soundsLeft = times;
            }
            else
            {
                TimesInput.Text = "10";
            }

            SoundInput.Focus();

            PlaySound();

            timer.Start();
        }

        private void OnCheck(object sender, EventArgs e)
        {
            CheckHelper();
        }

        private async void CheckHelper()
        {
            SoundInput.Focus();

            var isAnswered = CheckSoundName();

            if (!isAnswered)
            {
                return;
            }

            if (soundsLeft > 1)
            {
                PlaySound();
                soundsLeft--;
            }
            else
            {
                timer.Stop();

                var points = wonPoints - lostPoints;

                var alertText = $"Koniec gry. Wynik: {points}. Czas: {Timer.Text}";

                var currentSeconds = GetResultInSeconds(elapsedMinuts, elapsedSeconds);

                var currentResult = new Result(currentSeconds, points);

                var currentBestResult = repository.GetBestResult();

                if (currentBestResult.Points == 0 || currentResult.Points >= currentBestResult.Points)
                {
                    alertText += " Nowy rekord!";
                    currentBestResult = currentResult;

                    await repository.SaveBestResult(currentResult);
                }

                FormatBestResult(currentBestResult);

                MessageBox.Show(alertText, "Dyktando-inator");
                soundsLeft = 10;

                elapsedMinuts = 0;
                elapsedSeconds = 0;
                wonPoints = 0;
                lostPoints = 0;

                SetTimer();

                PlayButton.Enabled = true;
                CheckButton.Enabled = false;
                Replay.Enabled = false;
            }
        }

        private int GetResultInSeconds(int minuts, int seconds)
        {
            return seconds + minuts * 60;
        }

        private void OnPlaySomeSound(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button!.Name == Replay.Name)
            {
                repository.PlaySoundById(previousSoundId);
                return;
            }

            if (button.Name == PlayA.Name)
            {
                repository.PlaySoundById(21);
            }

            SoundInput.Focus();
        }

        private void KeyBinding(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckSoundName();
            }
        }

        private void FormatBestResult(Result result)
        {
            if (result.Seconds == 0)
            {
                BestResultLabel.Text = string.Empty;
                return;
            }

            var minuts = 0;

            while (result.Seconds >= 60)
            {
                result.Seconds -= 60;
                minuts++;
            }

            var seconds = result.Seconds.ToString();

            if (result.Seconds < 10)
            {
                seconds = $"0{result.Seconds}";
            }

            BestResultLabel.Text = $"Rekord: {minuts}:{seconds}{Environment.NewLine}{result.Points} punktów";
        }

        private void PlaySound()
        {
            if (!isAnswered)
            {
                MessageBox.Show("Najpierw odpowiedz na poprzednie pytanie.", "Dyktando-inator");
                return;
            }

            var rand = new Random();

            var id = rand.Next(0, 37);

            while (id == previousSoundId)
            {
                id = rand.Next(0, 37);
            }

            soundName = repository.PlaySoundById(id);

            previousSoundId = id;

            isAnswered = false;
        }

        private bool CheckSoundName()
        {
            var input = SoundInput.Text.Trim().ToLower();

            if (input == string.Empty || input == null)
            {
                MessageBox.Show("Proszê podaæ nazwê dŸwiêku.", "Dyktando-inator");
                return false;
            }

            var altName = helper.GetAltName(soundName);

            if (input == soundName || input == altName)
            {
                wonPoints++;
                SetPointsLabel();

                var first = input[0].ToString().ToUpper();

                SoundNameDisplay.ForeColor = Color.Green;

                SoundNameDisplay.Text = first + input.Substring(1, input.Length - 1);
            }
            else
            {
                SoundNameDisplay.ForeColor = Color.Red;

                var first = soundName[0].ToString().ToUpper();

                SoundNameDisplay.Text = first + soundName.Substring(1, soundName.Length - 1);

                lostPoints++;
                SetLostPointsLabel();
            }

            SoundInput.Text = string.Empty;
            isAnswered = true;
            return true;
        }

        private void SetPointsLabel()
        {
            PointLabel.Text = $"Twoje punkty: {wonPoints}";
        }

        private void SetLostPointsLabel()
        {
            LostPointsLabel.Text = $"Stracone punkty: {lostPoints}";
        }

        private void SoundInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            CheckHelper();
            e.SuppressKeyPress = true;
        }
    }
}
