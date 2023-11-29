namespace Dictations.Interfaces
{
    public class Helper : IHelper
    {
        public string GetAltName(string soundName)
        {
            var altName = string.Empty;

            switch (soundName)
            {
                case "cis":
                    altName = "des";
                    break;
                case "dis":
                    altName = "es";
                    break;
                case "fis":
                    altName = "ges";
                    break;
                case "gis":
                    altName = "as";
                    break;
                case "ais":
                    altName = "b";
                    break;
            }

            return altName;
        }
    }
}
