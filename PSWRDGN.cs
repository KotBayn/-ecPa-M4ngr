using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecPassM4ngr
{
    public class PSWRDGN
    {
        // VISUAL OBFUSCATION MAP (MiniMap)
        // Maps each lowercase letter to multiple visually similar characters
        public static readonly Dictionary<char, string[]> MiniMap = new()
        {
            {'a', ["@", "4", "∆", "α", "а", "∧", "A", "ᴀ", "∂", "∞"]},
            {'b', ["8", "ß", "β", "б", "Ᏼ", "Ḃ", "Ɓ", "ḃ", "6", "|3"]},
            {'c', ["(", "<", "¢", "©", "с", "ϲ", "ᴄ", "Ⅽ", "k", "◐"]},
            {'d', ["|)", "cl", "δ", "д", "Ꭰ", "Ḋ", "ᗫ", "◗", "▹", "▷"]},
            {'e', ["3", "£", "€", "е", "ε", "ᴱ", "ḕ", "∑", "∈", "∃"]},
            {'f', ["₣", "ƒ", "ф", "Ḟ", "ꟻ", "Ⅎ", "ḟ", "ᶂ", "|=", "ʄ"]},
            {'g', ["9", "q", "6", "g", "γ", "ɡ", "Ɠ", "Ꮆ", "⊕", "⊖"]},
            {'h', ["#", "|-|", "һ", "Ꮒ", "Η", "Ḣ", "ʜ", "ℏ", "├", "┤"]},
            {'i', ["1", "!", "і", "丨", "|", "ι", "í", "ì", "ī", "ⁱ"]},
            {'j', ["ј", "ʝ", "ᴊ", "ĵ", "ɉ", "ʲ", "𝒿", "•", "⊂", "⊃"]},
            {'k', ["|<", "κ", "к", "Ꮶ", "Ḱ", "ᴋ", "ҟ", "ķ", "ᶄ", "ḱ"]},
            {'l', ["1", "!", "£", "|", "l", "ι", "ʟ", "ℓ", "│", "┃"]},
            {'m', ["/\\", "м", "μ", "Ꮇ", "ᗰ", "Ḿ", "ᴍ", "ɱ", "ᶆ", "Ⅲ"]},
            {'n', ["п", "η", "Ꮑ", "ᑎ", "Ṅ", "ŋ", "ɴ", "ᶇ", "∩", "∪"]},
            {'o', ["0", "°", "ø", "о", "⊙", "ο", "ᴏ", "◦", "○", "●"]},
            {'p', ["|)", "ρ", "р", "Ꭾ", "Ṗ", "ᴘ", "ք", "ᶈ", "¶", "þ"]},
            {'q', ["9", "q", "զ", "ʠ", "ᶋ", "ꝗ", "ꝙ", "ᵠ", "⊗", "⊘"]},
            {'r', ["2", "Γ", "я", "ρ", "Ꮢ", "ʀ", "ɍ", "ᶉ", "ŗ", "℞"]},
            {'s', ["$", "5", "§", "z", "s", "ς", "ѕ", "ʂ", "⊕", "⊖"]},
            {'t', ["7", "+", "†", "т", "τ", "Ṯ", "ᴛ", "ȶ", "┬", "┴"]},
            {'u', ["∪", "υ", "и", "Ꮎ", "Ṳ", "ᴜ", "ʊ", "ᶌ", "ṳ", "∩"]},
            {'v', ["√", "ν", "в", "Ṽ", "ᴠ", "ʋ", "\\/", "∨", "∧", "✓"]},
            {'w', ["√√", "ω", "ш", "Ẃ", "ᴡ", "ʍ", "ᶍ", "Ш", "Щ", "ѡ"]},
            {'x', ["+", "×", "✗", "х", "χ", "Ẍ", "x", "ᶍ", "⊗", "⊕"]},
            {'y', ["γ", "у", "ψ", "Ẏ", "ʏ", "ʎ", "¥", "⅄", "ⅇ", "ⅆ"]},
            {'z', ["2", "7", "ζ", "զ", "Ẑ", "ᴢ", "ʐ", "ƶ", "≥", "≤"]}
        };

        // Password structure configuration constants
        private const int KINGDOM = 7;        // Total words in password
        private const int PEASANTS = 4;       // Words with MiniMap only
        private const int THEEF = 2;          // Words with shift + MiniMap
        private const int KEYOFCITY = 1;      // Word that generates shift key
        private const int RICH = 10;          // Max shift value (prevents Unicode issues)
        private const int POOR = -10;         // Min shift value

        // Single Random instance (critical for proper randomness)
        private static readonly Random _random = new();

        // PASSWORD CONFIGURATION CLASS (stores positions for verification)
        // ============================================================================
        public class Envelope
        {
            public int CITY { get; set; }              // Position of key word (0-6)
            public int KeyPosition => CITY;            // Alias for compatibility
            public int[] ShiftPositions { get; set; }  // Positions of shifted words (2 positions)
            public int[] ShiftValues { get; set; }     // Actual shift values derived from key
            public string[] OriginalWords { get; set; } // Original 7 words before obfuscation
        }

        // Math function: Generate shift values from key word
        // Uses hash-based derivation to create deterministic but unpredictable shifts
        public static int[] ShapeShifter(string keyWord, int shiftCount = 2)
        {
            var shifts = new int[shiftCount];

            // Create hash from key word characters
            int hash = 0;
            foreach (char c in keyWord.ToLower())
            {
                hash = (hash * 31 + c) % 1000000;
            }

            // Generate shift values from hash (range: -10 to +10)
            for (int i = 0; i < shiftCount; i++)
            {
                hash = (hash * 17 + i) % 21;   // 21 possible values
                shifts[i] = hash - 10;         // Convert to range -10 to +10
            }

            return shifts;
        }

        // Obfuscate single word with optional shift
        public static string SneakyBastard(string word, int shift = 0)
        {
            if (string.IsNullOrEmpty(word)) return string.Empty;

            StringBuilder sb = new();

            foreach (char c in word.ToLower())
            {
                // Apply Unicode shift if specified
                int charCode = c;
                if (shift != 0)
                {
                    charCode = c + shift;

                    // Safety: prevent non-printable or invalid Unicode characters
                    if (charCode < 32) charCode = 32;
                    if (charCode > 65535) charCode = 65535;
                }

                char processedChar = (char)charCode;

                // Apply MiniMap visual obfuscation (75% chance)
                if (MiniMap.TryGetValue(processedChar, out string[] options) &&
                    _random.Next(100) < 75)
                {
                    sb.Append(options[_random.Next(options.Length)]);
                }
                else
                {
                    sb.Append(processedChar);
                }
            }

            return sb.ToString();
        }

        // Create password with RANDOM key and shift positions
        // Returns both password and configuration for later verification
        public static (string letter, Envelope config) PassWizard(string[] words)
        {
            if (words == null || words.Length != KINGDOM)
                throw new ArgumentException($"Password requires exactly {KINGDOM} words!");

            // Randomly select positions for key and shifted words
            var positions = Enumerable.Range(0, KINGDOM).OrderBy(x => _random.Next()).Take(3).ToArray();
            int CITY = positions[0];
            int[] shiftPositions = [positions[1], positions[2]];

            // Get key word and generate shifts from it
            string keyWord = words[CITY];
            int[] shifts = ShapeShifter(keyWord, THEEF);

            StringBuilder door = new();
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0) door.Append("-");

                string word = words[i];
                string hidden;

                if (i == CITY)
                {
                    // Key word - MiniMap only, NO shift (so it can be identified during verification)
                    hidden = SneakyBastard(word, shift: 0);
                }
                else if (shiftPositions.Contains(i))
                {
                    // Shifted words - apply shift from key + MiniMap
                    int shiftIndex = Array.IndexOf(shiftPositions, i);
                    hidden = SneakyBastard(word, shifts[shiftIndex]);
                }
                else
                {
                    // Normal words: MiniMap only
                    hidden = SneakyBastard(word, shift: 0);
                }

                door.Append(hidden);
            }

            // Create configuration for verification
            var config = new Envelope
            {
                CITY = CITY,
                ShiftPositions = shiftPositions,
                ShiftValues = shifts,
                OriginalWords = words
            };

            return (door.ToString(), config);
        }

        // Create password without returning config (for quick use)
        // OVERLOAD: Simple version without specifying positions
        public static string Warlock(string[] words)
        {
            var result = PassWizard(words);
            return result.letter;
        }

        // VERIFICATION: Try to verify password by testing all key positions
        // Returns the detected key position if successful, -1 if failed
        public static int Guardians(string obfuscatedPassword, string[] candidateWords)
        {
            if (candidateWords == null || candidateWords.Length != KINGDOM)
                return -1;

            // Try each word position as the potential key
            for (int keyPos = 0; keyPos < KINGDOM; keyPos++)
            {
                // Try all combinations of shift positions (2 out of remaining 6)
                var villages = Enumerable.Range(0, KINGDOM).Where(x => x != keyPos).ToArray();

                for (int i = 0; i < villages.Length; i++)
                {
                    for (int j = i + 1; j < villages.Length; j++)
                    {
                        int[] shiftPositions = new[] { villages[i], villages[j] };

                        // Generate password with this configuration
                        var testResult = Witch(candidateWords, keyPos, shiftPositions);

                        if (testResult == obfuscatedPassword)
                        {
                            return keyPos; // Found correct key position!
                        }
                    }
                }
            }

            return -1; // Verification failed
        }

        // OVERLOAD: Create password with random positions (used by Archer)
        private static (string letter, Envelope config) Witch(string[] words)
        {
            return PassWizard(words);
        }

        // Create password with specific key and shift positions
        private static string Witch(string[] words, int keyPosition, int[] shiftPositions)
        {
            string keyWord = words[keyPosition];
            int[] shifts = ShapeShifter(keyWord, THEEF);

            StringBuilder treasury = new();

            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0) treasury.Append("-");

                string word = words[i];
                string hidden;

                if (i == keyPosition)
                {
                    hidden = SneakyBastard(word, shift: 0);
                }
                else if (shiftPositions.Contains(i))
                {
                    int shiftIndex = Array.IndexOf(shiftPositions, i);
                    hidden = SneakyBastard(word, shifts[shiftIndex]);
                }
                else
                {
                    hidden = SneakyBastard(word, shift: 0);
                }

                treasury.Append(hidden);
            }

            return treasury.ToString();
        }

        // Generate random password from dictionary arrays
        public static (string letter, Envelope config) Archer(
            string[] dictionary1, string[] dictionary2, string[] dictionary3,
            string[] dictionary4, string[] dictionary5, string[] dictionary6)
        {
            var allDictionaries = new[] { dictionary1, dictionary2, dictionary3,
                                          dictionary4, dictionary5, dictionary6 };

            string[] selectedWords = new string[KINGDOM];

            // Pick random word from random dictionary for each position
            for (int i = 0; i < KINGDOM; i++)
            {
                var dict = allDictionaries[_random.Next(allDictionaries.Length)];
                selectedWords[i] = dict[_random.Next(dict.Length)].ToLower();
            }

            // Ensure all words are unique
            int attempts = 0;
            while (selectedWords.Distinct().Count() != selectedWords.Length && attempts < 100)
            {
                attempts++;
                for (int i = 0; i < KINGDOM; i++)
                {
                    var dict = allDictionaries[_random.Next(allDictionaries.Length)];
                    selectedWords[i] = dict[_random.Next(dict.Length)].ToLower();
                }
            }

            return Witch(selectedWords); // Calls overload with random positions
        }

        // LEGACY SUPPORT: Original FullMap method (simplified, no shift)
        public static string FullMap(string word)
        {
            return SneakyBastard(word, shift: 0);
        }
    }
}