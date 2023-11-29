namespace Dictations.Models
{
    public class Result(int seconds, int points)
    {
        public int Seconds { get; set; } = seconds;
        public int Points { get; set; } = points;
    }
}
