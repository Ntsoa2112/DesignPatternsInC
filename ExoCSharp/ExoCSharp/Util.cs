using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExoCSharp
{
    public static class Util
    {
        // exo 1: inverser chaine
        public static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // exo 2 : palindrome
        public static bool IsPalindrome(string str)
        {
            string cleanedStr = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return cleanedStr.SequenceEqual(cleanedStr.Reverse());
        }

        // exo 2 : palindrome
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

        // exo 3 : anagrammes
        public static bool IsAnagram(string str1, string str2)
        {
            var sortedStr1 = new string(str1.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c).ToArray());
            var sortedStr2 = new string(str2.Where(char.IsLetterOrDigit).Select(char.ToLower).OrderBy(c => c).ToArray());
            return sortedStr1 == sortedStr2;
        }

        // exo 4 : trouver le nombre maximum
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

        // exo 5 : supprimer les doublons
        // Supprime les éléments en double d'un tableau et retourne les valeurs uniques.
        public static int[] SupprimerDoublons(int[] arr)
        {
            return arr.Distinct().ToArray();
        }

        // Exo 6 : deux nombres qui somment
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

        // exo 7 : nombre premier
        public static bool EstNombrePremier(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        // exo 8 : Fibonacci
        // Génère les n premiers nombres de la suite de Fibonacci
        public static List<int> GenererFibonacci(int n)
        {
            List<int> fibonacci = new List<int>();
            if (n <= 0) return fibonacci;
            fibonacci.Add(0);
            if (n == 1) return fibonacci;
            fibonacci.Add(1);
            for (int i = 2; i < n; i++)
            {
                int nextFib = fibonacci[i - 1] + fibonacci[i - 2];
                fibonacci.Add(nextFib);
            }
            return fibonacci;
        }

        // exo 9 : Factorielle
        // Calcule la factorielle d'un nombre (n! = n × (n-1) × ... × 1)
        public static long Factorielle(int n)
        {
            if (n < 0) throw new ArgumentException("Le nombre doit être non négatif.");
            if (n == 0 || n == 1) return 1;
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // exo 10 : Tri à Bulles
        // Tri à Bulles (Bubble Sort)
        // Implémente l'algorithme de tri à bulles pour trier un tableau. Ex: •	Entrée : [5, 2, 8, 1, 9] → Sortie : [1, 2, 5, 8, 9]
        public static int[] TriABulles(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Échanger arr[j] et arr[j + 1]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        // exo 11 : Recherche Binaire
        // Implémente la recherche binaire dans un tableau trié. Sortie index, -1 si pas trouvé.
        public static int RechercheBinaire(int[] arr, int cible)
        {
            int gauche = 0;
            int droite = arr.Length - 1;
            while (gauche <= droite)
            {
                int milieu = gauche + (droite - gauche) / 2;
                if (arr[milieu] == cible)
                    return milieu;
                else if (arr[milieu] < cible)
                    gauche = milieu + 1;
                else
                    droite = milieu - 1;
            }
            return -1; // Cible non trouvée
        }

        // exo 12 : FizzBuzz
        // Retourner les nombres de 1 à n, en remplaçant les multiples de 3 par "Fizz", les multiples de 5 par "Buzz" et les multiples de 3 et 5 par "FizzBuzz".
        public static List<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    result.Add("FizzBuzz");
                else if (i % 3 == 0)
                    result.Add("Fizz");
                else if (i % 5 == 0)
                    result.Add("Buzz");
                else
                    result.Add(i.ToString());
            }
            return result;
        }

        // exo 13 : Compter les Occurrences
        // Compte le nombre d'occurrences de chaque caractère dans une chaîne.
        public static Dictionary<char, int> CompterOccurrences(string str)
        {
            Dictionary<char, int> occurrences = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (occurrences.ContainsKey(c))
                    occurrences[c]++;
                else
                    occurrences[c] = 1;
            }
            return occurrences;

        }

        // exo 14 : : Rotation de Tableau
        // Problème : Fais pivoter un tableau de k positions vers la droite.
        public static int[] RotationDeTableau(int[] arr, int k)
        {
            int n = arr.Length;
            int[] resultat = new int[n];

            k = k % n;

            for (int i = 0; i < n; i++)
            {
                int nouvelIndex = (i + k) % n;
                resultat[nouvelIndex] = arr[i];
            }

            return resultat;
        }

        // exo 15 Vérifie si les parenthèses/crochets dans une chaîne sont bien équilibrés.
        /*
        Exemples :
            •	Entrée : "()[]{}" → Sortie : true
            •	Entrée : "([)]" → Sortie : false
            •	Entrée : "{[]}" → Sortie : true
        */
        public static bool ParenthesesEquilibrees(string str)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> correspondances = new Dictionary<char, char>
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };
            foreach (char c in str)
            {
                if (correspondances.Values.Contains(c))
                {
                    stack.Push(c);
                }
                else if (correspondances.Keys.Contains(c))
                {
                    if (stack.Count == 0 || stack.Pop() != correspondances[c])
                        return false;
                }
            }
            return stack.Count == 0;

        }
    }
}

