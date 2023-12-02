namespace Dictations.Models
{
    public class Interval(string firstAnswer, string secondAnswer)
    {
        public string FirstAnswer { get; set; } = firstAnswer;
        public string SecondAnswer { get; set; } = secondAnswer;
    }
}
