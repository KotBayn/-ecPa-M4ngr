using Xunit;
using SecPassM4ngr;

namespace SecPassM4ngr.Tests
{
    public class UnitTests
    {

        [Fact]
        public void Test_LeetSpeak_Works()
        {
            // Вызываем метод из НОВОГО класса!
            string result = PSWRDGN.FullMap("cat");

            // Если метод отработает, строка как минимум не будет пустой
            Assert.NotEmpty(result);
        }

        /*
        [Fact] // Test
        public void test1()
        {
            // 1. Arrange 
            string input = "12345";

            // 2. Act 
            string result = PSWRDGN.FullMap(input);

            // 3. Assert 
            Assert.Equal("12345", result);
        }

        [Fact]
        public void test2()
        {
            // 1. Arrange
            string input = "";

            // 2. Act
            string result = PSWRDGN.FullMap(input);

            // 3. Assert 
            Assert.Equal("", result);
        }*/
    }
}