using System.Media;

namespace Dictations.Interfaces
{
    public class Repository : IRepository
    {
        public void PlaySound(int soundId)
        {
            var soundDir = $"{Directory.GetCurrentDirectory()}/records/{soundId}.wav";

            if (!File.Exists(soundDir))
            {
                MessageBox.Show("Plik nie istnieje.", "Dyktando-inator");
                return;
            }

            var player = new SoundPlayer(soundDir);
            player.Play();
        }
    }
}
