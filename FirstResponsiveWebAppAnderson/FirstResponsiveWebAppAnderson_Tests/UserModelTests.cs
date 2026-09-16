using FirstResponsiveWebAppAnderson.Models;
using FirstResponsiveWebAppLastName.Models;
using Xunit;

namespace FirstResponsiveWebAppAnderson_Tests
{
    public class UserModelTests
    {
        [Fact]
        public void AgeThisYearPassingCaseTest()
        {
            // Arrange
            string name = "Megan";
            int birthYear = 2000;

            int expected = 26;
            int actual;

            UserModel user = new UserModel();
            user.Name = name;
            user.BirthYear = birthYear;

            // Act
            actual = user.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AgeThisYearYoungPersonTest()
        {
            // Arrange
            string name = "Alex";
            int birthYear = 2010;

            int expected = 16;
            int actual;

            UserModel user = new UserModel();
            user.Name = name;
            user.BirthYear = birthYear;

            // Act
            actual = user.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AgeThisYearOlderPersonTest()
        {
            // Arrange
            string name = "Robert";
            int birthYear = 1950;

            int expected = 76;
            int actual;

            UserModel user = new UserModel();
            user.Name = name;
            user.BirthYear = birthYear;

            // Act
            actual = user.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AgeThisYearBornThisYearTest()
        {
            // Arrange
            string name = "Baby";
            int birthYear = 2026;

            int expected = 0;
            int actual;

            UserModel user = new UserModel();
            user.Name = name;
            user.BirthYear = birthYear;

            // Act
            actual = user.AgeThisYear();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
