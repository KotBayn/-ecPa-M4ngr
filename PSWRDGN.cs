using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecPassM4ngr
{
    public class PSWRDGN
    {
        public static readonly Dictionary<char, string[]> MiniMap = new()
        {
             {'a', ["@", "4", "∆", "α", "а"]},
             {'b', ["8", "ß", "฿"]},
             {'c', ["(", "<", "¢", "©"]},
             {'e', ["3", "£", "€", "е"]},
             {'g', ["9", "q", "6"]},
             {'i', ["1", "!", "і", "丨", "|"]},
             {'l', ["1", "!", "£", "|"]},
             {'o', ["0", "°", "ø", "о", "⊙"]},
             {'s', ["$", "5", "§", "z"]},
             {'t', ["7", "+", "†", "т"]},
             {'x', ["+", "×", "✗", "х"]}
        };

        public static string FullMap(string word)
        {
            if (string.IsNullOrEmpty(word)) return word; // Защита от пустоты

            Random rnd = new();
            StringBuilder sb = new();

            foreach (char c in word)
            {
                char lowerC = char.ToLower(c);

                if (MiniMap.ContainsKey(lowerC) && rnd.Next(100) < 75)
                {
                    string[] options = MiniMap[lowerC];
                    sb.Append(options[rnd.Next(options.Length)]);
                }
                else
                {
                    sb.Append(rnd.Next(2) == 0 ? char.ToUpper(c) : char.ToLower(c));
                }
            }

            return sb.ToString();
        }
    }
}
