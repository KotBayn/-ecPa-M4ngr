using Xunit;
using SecPassM4ngr;
using System;
using System.Linq;

namespace SecPassM4ngr.Tests
{
    public class PSWRDGN_Tests
    {
        // TEST DICTIONARIES (small samples for testing)
        private static readonly string[] TestDict1 = ["shadow", "thunder", "falcon", "nexus", "alpha"];
        private static readonly string[] TestDict2 = ["galaxy", "nebula", "pulsar", "quasar", "orbit"];
        private static readonly string[] TestDict3 = ["quantum", "neutron", "proton", "electron", "photon"];
        private static readonly string[] TestDict4 = ["tower", "bridge", "road", "street", "avenue"];
        private static readonly string[] TestDict5 = ["tree", "bush", "shrub", "flower", "plant"];
        private static readonly string[] TestDict6 = ["hope", "dream", "wish", "desire", "want"];

        // FULLMAP TESTS (Legacy method)
        [Fact]
        public void FullMap_WithValidWord_ReturnsNonEmptyString()
        {
            // Arrange
            string input = "cat";

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(input.Length, result.Length); // Length should be preserved
        }

        [Fact]
        public void FullMap_WithNumbers_ReturnsUnchanged()
        {
            // Arrange
            string input = "12345";

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.Equal(input, result); // Numbers not in MiniMap, should stay same
        }

        [Fact]
        public void FullMap_WithEmptyString_ReturnsEmptyString()
        {
            // Arrange
            string input = "";

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FullMap_WithNull_ReturnsEmptyString()
        {
            // Arrange
            string? input = null;

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FullMap_WithUpperCase_ConvertsToLowerAndObfuscates()
        {
            // Arrange
            string input = "CAT";

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(input.Length, result.Length);
        }

        [Fact]
        public void FullMap_WithSpecialCharacters_HandlesGracefully()
        {
            // Arrange
            string input = "cat!@#";

            // Act
            string result = PSWRDGN.FullMap(input);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(input.Length, result.Length);
        }

        // MINIMAP TESTS
        [Fact]
        public void MiniMap_ContainsAllLowercaseLetters()
        {
            // Arrange & Act
            var missingLetters = "abcdefghijklmnopqrstuvwxyz"
                .Where(c => !PSWRDGN.MiniMap.ContainsKey(c))
                .ToList();

            // Assert
            Assert.Empty(missingLetters); // All letters should be in MiniMap
        }

        [Fact]
        public void MiniMap_EachLetterHasMultipleOptions()
        {
            // Arrange & Act
            var minOptions = PSWRDGN.MiniMap.Values.Min(arr => arr.Length);

            // Assert
            Assert.True(minOptions >= 5, "Each letter should have at least 5 substitution options");
        }

        [Fact]
        public void MiniMap_OptionsAreUnique()
        {
            // Arrange & Act
            foreach (var entry in PSWRDGN.MiniMap)
            {
                // Assert
                Assert.Equal(entry.Value.Length, entry.Value.Distinct().Count());
            }
        }

        // SHAPESHIFTER TESTS (Shift generation from key word)
        [Fact]
        public void ShapeShifter_WithValidKey_ReturnsTwoShifts()
        {
            // Arrange
            string keyWord = "dragon";

            // Act
            int[] shifts = PSWRDGN.ShapeShifter(keyWord, 2);

            // Assert
            Assert.Equal(2, shifts.Length);
        }

        [Fact]
        public void ShapeShifter_ShiftsAreWithinSafeRange()
        {
            // Arrange
            string keyWord = "platinum";

            // Act
            int[] shifts = PSWRDGN.ShapeShifter(keyWord, 2);

            // Assert
            foreach (var shift in shifts)
            {
                Assert.True(shift >= -10 && shift <= 10, $"Shift {shift} is outside safe range [-10, 10]");
            }
        }

        [Fact]
        public void ShapeShifter_SameKeyProducesSameShifts()
        {
            // Arrange
            string keyWord = "secret";

            // Act
            int[] shifts1 = PSWRDGN.ShapeShifter(keyWord, 2);
            int[] shifts2 = PSWRDGN.ShapeShifter(keyWord, 2);

            // Assert
            Assert.Equal(shifts1, shifts2); // Deterministic!
        }

        [Fact]
        public void ShapeShifter_DifferentKeysProduceDifferentShifts()
        {
            // Arrange
            string keyWord1 = "alpha";
            string keyWord2 = "omega";

            // Act
            int[] shifts1 = PSWRDGN.ShapeShifter(keyWord1, 2);
            int[] shifts2 = PSWRDGN.ShapeShifter(keyWord2, 2);

            // Assert
            Assert.NotEqual(shifts1, shifts2);
        }

        [Fact]
        public void ShapeShifter_EmptyKey_ReturnsShiftsInRange()
        {
            // Arrange
            string keyWord = "";

            // Act
            int[] shifts = PSWRDGN.ShapeShifter(keyWord, 2);

            // Assert
            Assert.Equal(2, shifts.Length);
            // Empty key still produces shifts in valid range (not necessarily 0)
            Assert.All(shifts, shift => Assert.True(shift >= -10 && shift <= 10));
        }

        // SNEAKYBASTARD TESTS (Word obfuscation with shift)
        [Fact]
        public void SneakyBastard_WithZeroShift_UsesMiniMapOnly()
        {
            // Arrange
            string word = "test";

            // Act
            string result = PSWRDGN.SneakyBastard(word, 0);

            // Assert
            Assert.Equal(word.Length, result.Length);
            Assert.NotEqual(word, result); // Should be obfuscated
        }

        [Fact]
        public void SneakyBastard_WithPositiveShift_AppliesShift()
        {
            // Arrange
            string word = "abc";

            // Act
            string result = PSWRDGN.SneakyBastard(word, 5);

            // Assert
            Assert.Equal(word.Length, result.Length);
        }

        [Fact]
        public void SneakyBastard_WithNegativeShift_AppliesShift()
        {
            // Arrange
            string word = "xyz";

            // Act
            string result = PSWRDGN.SneakyBastard(word, -5);

            // Assert
            Assert.Equal(word.Length, result.Length);
        }

        [Fact]
        public void SneakyBastard_EmptyWord_ReturnsEmpty()
        {
            // Arrange
            string word = "";

            // Act
            string result = PSWRDGN.SneakyBastard(word, 5);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SneakyBastard_NullWord_ReturnsEmpty()
        {
            // Arrange
            string? word = null;

            // Act
            string result = PSWRDGN.SneakyBastard(word, 5);

            // Assert
            Assert.Empty(result);
        }

        // PASSWIZARD TESTS (Full password generation)
        [Fact]
        public void PassWizard_WithSevenWords_ReturnsPasswordAndConfig()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.NotEmpty(result.letter);
            Assert.NotNull(result.config);
            Assert.Equal(7, result.config.OriginalWords.Length);
        }

        [Fact]
        public void PassWizard_WithWrongWordCount_ThrowsException()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3"]; // Only 3 words

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PSWRDGN.PassWizard(words));
        }

        [Fact]
        public void PassWizard_KeyPositionIsWithinValidRange()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.True(result.config.KeyPosition >= 0 && result.config.KeyPosition <= 6);
        }

        [Fact]
        public void PassWizard_ShiftPositionsAreUnique()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.Equal(2, result.config.ShiftPositions.Distinct().Count());
        }

        [Fact]
        public void PassWizard_ShiftPositionsDontIncludeKeyPosition()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.DoesNotContain(result.config.KeyPosition, result.config.ShiftPositions);
        }

        [Fact]
        public void PassWizard_PasswordContainsHyphens()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.Contains("-", result.letter);
            Assert.Equal(6, result.letter.Count(c => c == '-')); // 7 words = 6 hyphens
        }

        [Fact]
        public void PassWizard_MultipleGenerationsProduceDifferentPasswords()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result1 = PSWRDGN.PassWizard(words);
            var result2 = PSWRDGN.PassWizard(words);

            // Assert
            Assert.NotEqual(result1.letter, result2.letter); // Random MiniMap choices
        }

        // GUARDIANS TESTS (Verification system)
        [Fact]
        public void Guardians_WithCorrectWords_ReturnsKeyPosition()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];
            var (letter, config) = PSWRDGN.PassWizard(words);

            // Act - Use the SAME words that were used to generate
            int verifiedPos = PSWRDGN.Guardians(letter, config.OriginalWords);

            // Assert
            Assert.Equal(config.KeyPosition, verifiedPos);
        }

        [Fact]
        public void Guardians_WithWrongWords_ReturnsMinusOne()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];
            string[] wrongWords = ["wrong1", "wrong2", "wrong3", "wrong4", "wrong5", "wrong6", "wrong7"];
            var result = PSWRDGN.PassWizard(words);

            // Act
            int verifiedPos = PSWRDGN.Guardians(result.letter, wrongWords);

            // Assert
            Assert.Equal(-1, verifiedPos);
        }

        [Fact]
        public void Guardians_WithNullWords_ReturnsMinusOne()
        {
            // Arrange
            string[] words = null;
            string password = "test-password";

            // Act
            int verifiedPos = PSWRDGN.Guardians(password, words);

            // Assert
            Assert.Equal(-1, verifiedPos);
        }

        [Fact]
        public void Guardians_WithWrongWordCount_ReturnsMinusOne()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3"]; // Only 3 words
            string password = "test-password";

            // Act
            int verifiedPos = PSWRDGN.Guardians(password, words);

            // Assert
            Assert.Equal(-1, verifiedPos);
        }

        // ARCHER TESTS (Random dictionary-based generation)
        [Fact]
        public void Archer_ReturnsPasswordAndConfig()
        {
            // Act
            var result = PSWRDGN.Archer(TestDict1, TestDict2, TestDict3, TestDict4, TestDict5, TestDict6);

            // Assert
            Assert.NotEmpty(result.letter);
            Assert.NotNull(result.config);
        }

        [Fact]
        public void Archer_AllWordsAreUnique()
        {
            // Act
            var result = PSWRDGN.Archer(TestDict1, TestDict2, TestDict3, TestDict4, TestDict5, TestDict6);

            // Assert
            Assert.Equal(7, result.config.OriginalWords.Distinct().Count());
        }

        [Fact]
        public void Archer_WordsComeFromDictionaries()
        {
            // Act
            var result = PSWRDGN.Archer(TestDict1, TestDict2, TestDict3, TestDict4, TestDict5, TestDict6);

            // Assert
            var allDictWords = TestDict1.Concat(TestDict2).Concat(TestDict3)
                .Concat(TestDict4).Concat(TestDict5).Concat(TestDict6)
                .Select(w => w.ToLower()).ToList();

            foreach (var word in result.config.OriginalWords)
            {
                Assert.Contains(word, allDictWords);
            }
        }

         
        // WARLOCK TESTS (Simplified password generation)
         [Fact]
        public void Warlock_ReturnsPasswordString()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            string result = PSWRDGN.Warlock(words);

            // Assert
            Assert.NotEmpty(result);
            Assert.Contains("-", result);
        }

        // SECURITY TESTS
        [Fact]
        public void Password_LengthIsSufficient()
        {
            // Arrange
            string[] words = ["shadow", "thunder", "falcon", "nexus", "alpha", "galaxy", "quantum"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.True(result.letter.Length >= 40, "Password should be at least 40 characters");
        }

        [Fact]
        public void Password_ContainsSpecialCharacters()
        {
            // Arrange
            string[] words = ["shadow", "thunder", "falcon", "nexus", "alpha", "galaxy", "quantum"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            var specialChars = result.letter.Where(c => !char.IsLetterOrDigit(c) && c != '-');
            Assert.NotEmpty(specialChars);
        }

        [Fact]
        public void Password_NoPlaintextWordsVisible()
        {
            // Arrange
            string[] words = ["shadow", "thunder", "falcon", "nexus", "alpha", "galaxy", "quantum"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            foreach (var word in words)
            {
                Assert.DoesNotContain(word, result.letter, StringComparison.OrdinalIgnoreCase);
            }
        }

        [Fact]
        public void Envelope_ConfigContainsAllRequiredData()
        {
            // Arrange
            string[] words = ["word1", "word2", "word3", "word4", "word5", "word6", "word7"];

            // Act
            var result = PSWRDGN.PassWizard(words);

            // Assert
            Assert.NotNull(result.config.OriginalWords);
            Assert.NotNull(result.config.ShiftPositions);
            Assert.NotNull(result.config.ShiftValues);
            Assert.True(result.config.KeyPosition >= 0 && result.config.KeyPosition <= 6);
        }
    }
}