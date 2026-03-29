using Xunit;
using SecPassM4ngr;

namespace SecPassM4ngr.Tests
{
    public class UnitTests
    {

        [Fact]
        public void TestIsItWorks()
        {
            // Calling the method to see if it runs without exceptions
            string result = PSWRDGN.FullMap("cat");

            // If runs without exceptions, the result is not null or empty
            Assert.NotEmpty(result);
        }

        [Fact] // Test
        public void TestWordReturn()
        {
            // 1. Arrange 
            string input = "12345";

            // 2. Act 
            string result = PSWRDGN.FullMap(input);

            // 3. Assert 
            Assert.Equal("12345", result);
        }

        [Fact]
        public void TestVoidReturn()
        {
            // 1. Arrange
            string input = "";

            // 2. Act
            string result = PSWRDGN.FullMap(input);

            // 3. Assert 
            Assert.Equal("", result);
        }
    }
}