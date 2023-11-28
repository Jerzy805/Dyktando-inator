using System.Media;

namespace Dictations.Interfaces
{
    public class Repository : IRepository
    {
        private string GetDir()
        {
            return $"{Directory.GetCurrentDirectory()}/records";
        }

        public void PlaySoundById(int id)
        {
            //var soundDir = $"{GetDir()}/{id}.wav";

            var soundsNames = GetSoundsNames();

            var soundDir = string.Empty;

            foreach (var soundName in soundsNames)
            {
                var index = soundName!.IndexOf('(');

                var soundId = int.Parse(soundName!.Substring(0, index));

                if (soundId == id)
                {
                    soundDir = $"{GetDir()}/{soundName}";
                    break;
                }
            }

            if (!File.Exists(soundDir))
            {
                MessageBox.Show("Plik nie istnieje.", "Dyktando-inator");
                return;
            }

            var player = new SoundPlayer(soundDir);
            player.Play();
        }

        public List<string?> GetSoundsNames()
        {
            var directory = GetDir();

            var files = Directory.GetFiles(directory).Select(Path.GetFileName).ToList();

            return files;
        }

    }
}
