using Dictations.Models;

namespace Dictations.Interfaces
{
    public interface IRepository
    {
        string PlaySoundById(int soundId);
        List<string?> GetSoundsNames();
        Result GetBestResult();
        Task SaveBestResult(Result bestResultInSeconds);
        string PlayIntervalById(int firstSoundId, int secondSoundId);
    }
}
