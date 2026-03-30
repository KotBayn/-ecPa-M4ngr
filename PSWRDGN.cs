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


        public static string FullMap(string word)
        {
            if (string.IsNullOrEmpty(word)) return word; // saving from null reference exception

            Random rnd = new();
            StringBuilder sb = new();

            foreach (char c in word)
            {
                char lowerC = char.ToLower(c);
                
                if (MiniMap.ContainsKey(lowerC) && rnd.Next(100) < 75)
                {
                    string[] options = MiniMap[lowerC];
                    sb.Append(options[rnd.Next(options.Length)]);
                    sb.Append(rnd.Next(2) == 0 ? char.ToUpper(c) : char.ToLower(c));
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
