using System.Net.WebSockets;

using Dictations.Interfaces;
using Dictations.Models;

namespace Dictations
{
    public partial class Form1 : Form
    {
        private readonly IRepository repository;
        private readonly IHelper helper;
        private string soundName;
        private string interval;
        private int wonPoints;
        private int lostPoints;
        private bool isAnswered;
        private int soundsLeft;
        private int previousSoundId;
        private System.Timers.Timer timer;
        private int elapsedSeconds = 0;
        private int elapsedMinuts = 0;
        private int firstId, secondId;

        public Form1()
        {
            InitializeComponent();

            timer = new();
            timer.Interval = 1000;
            timer.Elapsed += TimerElapsed!;

            this.KeyDown += KeyBinding!;

            SoundNameDisplay.TextAlign = ContentAlignment.MiddleCenter;

            repository = new Repository();

            helper = new Helper();

            soundName = string.Empty;
            interval = string.Empty;

            wonPoints = 0;
            lostPoints = 0;

            SetPointsLabel();

            isAnswered = true;

            soundsLeft = 10;

            SoundNameDisplay.Text = string.Empty;
            SoundNameDisplay.Text = "?";

            SoundInput.Enabled = false;

            PlayA.BackColor = Color.Red;

            CheckButton.Enabled = false;
            ReplaySound.Enabled = false;
            CheckInterval.Enabled = false;
            ReplayInterval.Enabled = false;
            IntervalInput.Enabled = false;

            var bestResult = repository.GetBestResult(2);

            FormatBestResult(bestResult, 1);

            var intervalsBestResult = repository.GetBestResult(3);

            FormatBestResult(intervalsBestResult, 2);

            TimesInput.Text = "10";

            FinalPointsLabel.Text = string.Empty;

            SetGameMode(true);

            IntervalDisplay.Text = "?";
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

        private void OnStart(object sender, EventArgs e)
        {
            PlaySoundButton.Enabled = false;
            CheckButton.Enabled = true;
            ReplaySound.Enabled = true;
            SoundInput.Enabled = true;

            if (int.TryParse(TimesInput.Text, out int times))
            {
                soundsLeft = times;
            }
            else
            {
                TimesInput.Text = "10";
            }

            SoundInput.Focus();

            FinalPointsLabel.Text = string.Empty;

            PlaySound();

            timer.Start();

            ChangeGameModeButton.Enabled = false;

            SoundNameDisplay.Text = "?";
            SoundNameDisplay.ForeColor = DefaultForeColor;
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

                FinalPointsLabel.Text = $"Wynik: {points}";

                var currentSeconds = GetResultInSeconds(elapsedMinuts, elapsedSeconds);

                var currentResult = new Result(currentSeconds, points);

                var currentBestResult = repository.GetBestResult(2);

                ChangeGameModeButton.Enabled = true;

                var isRecord = false;

                if (currentBestResult.Points == 0 || currentResult.Points >= currentBestResult.Points)
                {
                    isRecord = true;
                    currentBestResult = currentResult;

                    await repository.SaveBestResult(currentResult, 2);
                }

                FormatBestResult(currentBestResult, 1);

                EndAlert(isRecord);

                SoundInput.Enabled = false;

                soundsLeft = 10;

                elapsedMinuts = 0;
                elapsedSeconds = 0;
                wonPoints = 0;
                lostPoints = 0;

                SetTimer();

                PlaySoundButton.Enabled = true;
                CheckButton.Enabled = false;
                ReplaySound.Enabled = false;
            }
        }

        private void EndAlert(bool isRecord)
        {
            var points = wonPoints - lostPoints;

            var alertText = $"Koniec gry. Wynik: {points}. Czas: {Timer.Text}";

            if (isRecord)
            {
                alertText += " Nowy rekord!";
            }

            MessageBox.Show(alertText, "Dyktando-inator");
        }

        private int GetResultInSeconds(int minuts, int seconds)
        {
            return seconds + minuts * 60;
        }

        private void OnPlaySomeSound(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button!.Name == ReplaySound.Name)
            {
                repository.PlaySoundById(previousSoundId);
                SoundInput.Focus();
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

        private void FormatBestResult(Result result, int option)
        {
            if (result.Seconds == 0)
            {
                if (option == 1)
                {
                    BestSoundsResultLabel.Text = string.Empty;
                }
                else
                {
                    BestIntervalsResultLabel.Text = string.Empty;
                }
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

            var text = $"Rekord: {minuts}:{seconds}{Environment.NewLine}{result.Points} punktów";

            if (option == 1)
            {
                BestSoundsResultLabel.Text = text;
                return;
            }
            else
            {
                BestIntervalsResultLabel.Text = text;
            }
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
            }

            SoundInput.Text = string.Empty;
            isAnswered = true;
            return true;
        }

        private void SetPointsLabel()
        {
            PointsLabel.Text = $"Zdobyte punkty: {wonPoints}";
            LostPointsLabel.Text = $"Stracone punkty: {lostPoints}";
        }

        private void SoundInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckHelper();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.R)
            {
                repository.PlaySoundById(previousSoundId);
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Q)
            {
                repository.PlaySoundById(21);
                e.SuppressKeyPress = true;
                return;
            }
        }

        private void SetGameMode(bool isGuessing)
        {
            SoundNameDisplay.Visible = isGuessing;
            SoundInput.Visible = isGuessing;
            CheckButton.Visible = isGuessing;
            PlaySoundButton.Visible = isGuessing;
            ReplaySound.Visible = isGuessing;
            BestSoundsResultLabel.Visible = isGuessing;

            IntervalInput.Visible = !isGuessing;
            IntervalDisplay.Visible = !isGuessing;
            StartIntervals.Visible = !isGuessing;
            CheckInterval.Visible = !isGuessing;
            ReplayInterval.Visible = !isGuessing;
            BestIntervalsResultLabel.Visible = !isGuessing;

            if (isGuessing)
            {
                label1.Text = "Liczba dŸwiêków";
            }
            else
            {
                label1.Text = "Liczba interwa³ów";
            }
        }

        private void OnChangeGameMode(object sender, EventArgs e)
        {
            if (ChangeGameModeButton.Text == "Interwa³y")
            {
                SetGameMode(false);
                ChangeGameModeButton.Text = "DŸwiêki";
            }
            else
            {
                SetGameMode(true);
                ChangeGameModeButton.Text = "Interwa³y";
            }
        }

        private void OnStartIntervals(object sender, EventArgs e)
        {
            if (!isAnswered)
            {
                MessageBox.Show("Najpierw odpowiedz na pytanie.", "Dyktando-inator");
                return;
            }

            StartIntervals.Enabled = false;
            IntervalInput.Enabled = true;
            CheckInterval.Enabled = true;
            ReplayInterval.Enabled = true;

            PlayInterval();

            timer.Start();

            if (int.TryParse(TimesInput.Text, out int times))
            {
                soundsLeft = times;
            }

            wonPoints = 0;
            lostPoints = 0;

            SetPointsLabel();

            FinalPointsLabel.Text = string.Empty;
        }

        private async void PlayInterval()
        {
            IntervalInput.Focus();

            var random = new Random();

            firstId = random.Next(0, 37);

            secondId = random.Next(0, 37);
            interval = await repository.PlayIntervalById(firstId, secondId);
            isAnswered = false;
        }

        private void OnCheckInterval(object sender, EventArgs e)
        {
            CheckIntervalHelper();
        }

        private async void CheckIntervalHelper()
        {
            var input = IntervalInput.Text.Trim();

            if (input == string.Empty)
            {
                MessageBox.Show("Najpierw odpowiedz na pytanie.", "Dyktando-inator");
                return;
            }

            var altName = string.Empty;

            if (interval == "4<")
            {
                altName = "5>";
            }

            if (input == interval || input == altName)
            {
                IntervalDisplay.Text = input;
                IntervalDisplay.ForeColor = Color.Green;
                wonPoints++;
            }
            else
            {
                IntervalDisplay.ForeColor = Color.Red;
                IntervalDisplay.Text = interval;
                lostPoints++;
            }

            SetPointsLabel();

            IntervalInput.Text = string.Empty;
            isAnswered = true;

            if (soundsLeft > 1)
            {
                PlayInterval();
                soundsLeft--;
            }
            else
            {
                timer.Stop();

                var points = wonPoints - lostPoints;
                FinalPointsLabel.Text = $"Wynik: {points}";

                var isRecord = false;

                var seconds = GetResultInSeconds(elapsedMinuts, elapsedSeconds);

                var currentResult = new Result(seconds, points);

                var currentBestResult = repository.GetBestResult(3);

                var isBetter = currentResult.Points == currentBestResult.Points && currentResult.Seconds <= currentBestResult.Seconds;

                if (currentResult.Points > currentBestResult.Points || currentBestResult.Points == 0 || isBetter)
                {
                    isRecord = true;

                    await repository.SaveBestResult(currentResult, 3);

                    currentBestResult = currentResult;
                }

                FormatBestResult(currentBestResult, 2);

                EndAlert(isRecord);
            }
        }

        private void IntervalInputKeyDow(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckIntervalHelper();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.R)
            {
                ReplayIntervalHelper();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Q)
            {
                repository.PlaySoundById(21);
                e.SuppressKeyPress= true;
                return;
            }
        }

        private void ReplayIntervalHelper()
        {
            repository.PlayIntervalById(firstId, secondId);
        }
    }
}
