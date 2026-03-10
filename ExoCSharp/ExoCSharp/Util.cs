using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoCSharp
{
    public static class Util
    {
        public static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static bool IsPalindrome(string str)
        {
            string cleanedStr = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleanedStr.SequenceEqual(cleanedStr.Reverse());
        }

        public static bool EstPalindrome(string str)
        {
            // Nettoyer : enlever espaces et mettre en minuscule
            string clean = str.Replace(" ", "").ToLower();

            // Comparer avec deux pointeurs
            int gauche = 0;
            int droite = clean.Length - 1;

            while (gauche < droite)
            {
                if (clean[gauche] != clean[droite])
                    return false;
                gauche++;
                droite--;
            }

            return true;
        }

        public static bool IsAnagram(string str1, string str2)
        {
            var sortedStr1 = new string(str1.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c).ToArray());
            var sortedStr2 = new string(str2.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c).ToArray());
            return sortedStr1 == sortedStr2;
        }

        public static int plusGrandNombre(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Le tableau ne peut pas être vide.");
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max)
                    max = num;
            }

            int maxInt = arr.Max();
            return maxInt;
        }

        // Trouve deux indices dans un tableau dont les valeurs somment à une cible donnée.
        /*
         * Exemples :
        •	Entrée : [2, 7, 11, 15], cible = 9 → Sortie : [0, 1]
        •	Entrée : [3, 2, 4], cible = 6 → Sortie : [1, 2]
        */
        public static int[] TrouverDeuxIndices(int[] nombres, int cible)
        {
            Dictionary<int, int> valeurVersIndex = new Dictionary<int, int>();

            for (int i = 0; i < nombres.Length; i++)
            {
                int nombreActuel = nombres[i];
                int complement = cible - nombreActuel;

                if (valeurVersIndex.ContainsKey(complement))
                {
                    return new int[] { valeurVersIndex[complement], i };
                }

                valeurVersIndex[nombreActuel] = i;
            }

            throw new ArgumentException("Aucune solution trouvée.");
        }

    }
}
