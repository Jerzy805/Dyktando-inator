using Dictations.Models;

namespace Dictations.Interfaces
{
    public interface IRepository
    {
        string PlaySoundById(int soundId);
        List<string?> GetSoundsNames();
        Result GetBestResult(int option);
        Task SaveBestResult(Result bestResult, int option);
        Task<string> PlayIntervalById(int firstSoundId, int secondSoundId);
    }
}
