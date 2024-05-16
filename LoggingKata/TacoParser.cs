namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogWarning("Less than 3. There's an issue"); 
                return null; 
            }

            double lat = 0;

            if (double.TryParse(cells[0], out lat) == false)
            {
                logger.LogError($"{cells[0]} Bad data. Wasnt able to parse latitude as double");

            }

            double longitude = 0;
            if (double.TryParse(cells[1], out longitude) == false)
            {
                logger.LogError("Bad data Wasnt able to parse longitude as double");
            }

            var name = cells[2];
            
            if (cells[2] == null || cells[2].Length == 0)
            {
                logger.LogError("No location name found while parsing");
            }
            var point = new Point()
            {
                Latitude = lat,
                Longitude = longitude,
            };

            var tacoBell = new TacoBell();

            tacoBell.Location = point;
            tacoBell.Name = name;

            return tacoBell;
        }
    }
}
