using System.ComponentModel;

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

          
            var cells = line.Split(',');

        
            if (cells.Length < 3)
            {
                logger.LogWarning("less than three items. incomplete data");
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
                logger.LogError("Bad data. Wasnt able to parse logitude as double");

            }

           
            var name = cells[2];

            if (cells[2] == null || cells[2].Length == 0)
            {
                logger.LogError("No location name found while parsing");
            }


            var point = new Point()
            {
                Latitude = lat,
                Longitude = longitude

            };

           
            var tacoBell = new TacoBell();

            tacoBell.Location = point;
            tacoBell.Name = name;

          
            return tacoBell;
        }
    }
}
