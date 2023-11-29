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
            else
            {
                currentDir += "/bestResult.json";
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
            
            return name;
        }

        public List<string?> GetSoundsNames()
        {
            var directory = GetDir(1);

            var files = Directory.GetFiles(directory).Select(Path.GetFileName).ToList();

            return files;
        }

        public Result GetBestResult()
        {
            var fileDir = GetDir(2);

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

        public async Task SaveBestResult(Result bestResult)
        {
            var data = JsonConvert.SerializeObject(bestResult);
            await File.WriteAllTextAsync(GetDir(2), data);
        }
    }
}
