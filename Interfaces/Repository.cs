using System.Media;
using Dictations.Models;
using Newtonsoft.Json;

namespace Dictations.Interfaces
{
    public class Repository : IRepository
    {
        private string GetDir(int choice)
        {
            var currentDir = Directory.GetCurrentDirectory();

            if (choice == 1)
            {
                currentDir += "/records";
            }
            else if (choice == 2)
            {
                currentDir += "/bestResult.json";
            }
            else
            {
                currentDir += "/intervalBestResult.json";
            }

            return currentDir;
        }

        public string PlaySoundById(int id)
        {
            if (id < 0 || id > 36)
            {
                MessageBox.Show("Plik nie istnieje.", "Dyktando-inator");
                return "null";
            }

            var soundsNames = GetSoundsNames();

            var soundDir = string.Empty;
            var name = string.Empty;

            foreach (var soundName in soundsNames)
            {
                var firstIndex = soundName!.IndexOf('(');

                var soundId = int.Parse(soundName!.Substring(0, firstIndex));

                if (soundId == id)
                {
                    soundDir = $"{GetDir(1)}/{soundName}";

                    var lastIndex = soundName!.IndexOf(")");

                    var lenght = lastIndex - firstIndex - 1;

                    name = soundName!.Substring(firstIndex + 1, lenght);

                    break;
                }
            }

            if (!File.Exists(soundDir))
            {
                MessageBox.Show("Plik nie istnieje.", "Dyktando-inator");
                return "null";
            }

            var player = new SoundPlayer(soundDir);
            player.Play();
            player.Dispose();
            
            return name;
        }

        public List<string?> GetSoundsNames()
        {
            var directory = GetDir(1);

            var files = Directory.GetFiles(directory).Select(Path.GetFileName).ToList();

            return files;
        }

        public Result GetBestResult(int option)
        {
            var fileDir = GetDir(option);

            if (!File.Exists(fileDir))
            {
                return new Result(0, 0);
            }

            var data = File.ReadAllText(fileDir);

            try
            {
                return JsonConvert.DeserializeObject<Result>(data)!;
            }
            catch
            {
                return new Result(0, 0);
            }
        }

        public async Task SaveBestResult(Result bestResult, int option)
        {
            var data = JsonConvert.SerializeObject(bestResult);
            await File.WriteAllTextAsync(GetDir(option), data);
        }

        public async Task<string> PlayIntervalById(int firstSoundId, int secondSoundId)
        {
            PlaySoundById(firstSoundId);

            await Task.Delay(2000);

            PlaySoundById(secondSoundId);
            
            var difference = Math.Abs(firstSoundId - secondSoundId);

            while (difference > 12)
            {
                difference -= 12;
            }

            var result = string.Empty;

            switch (difference)
            {
                case 0:
                case 2:
                case 4:
                    result = ((difference + 2) / 2).ToString();
                    break;
                case 1:
                    result = "2>";
                    break;
                case 3:
                    result = "3>";
                    break;
                case 5:
                case 7:
                case 9:
                    result = ((difference + 3) / 2).ToString();
                    break;
                case 6:
                    result = "4<";
                    break;
                case 8:
                    result = "6>";
                    break;
                case 10:
                case 12:
                    result = ((difference + 4) / 2).ToString();
                    break;
                case 11:
                    result = "7<";
                    break;
            }

            return result;
        }
    }
}
