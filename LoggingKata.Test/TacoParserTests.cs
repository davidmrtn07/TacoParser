using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.556383, -86.889051, Taco Bell Birmingha...", -86.889051)]
        [InlineData("32.326279,-86.325015,Taco Bell Montgomery....", -86.325015)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("33.556383, -86.889051, Taco Bell Birmingha...", 33.556383)]
        [InlineData("32.326279,-86.325015,Taco Bell Montgomery....", 32.326279)]
        public void ShouldParseLatitude(string line, double expected)
        {
           
            //Arrange
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }
        
    }
}
