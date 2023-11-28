namespace Dictations.Interfaces
{
    public interface IRepository
    {
        void PlaySoundById(int soundId);
        List<string?> GetSoundsNames();
    }
}
