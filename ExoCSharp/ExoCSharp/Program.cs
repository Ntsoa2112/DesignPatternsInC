// See https://aka.ms/new-console-template for more information
using ExoCSharp;

// Exo 1: Reverse a string
string input = "Hello, World!";
string reversed = Util.ReverseString(input);
Console.WriteLine($"Original string: {input}");
Console.WriteLine($"Reversed string: {reversed}");

// Exo 2: Check if a string is a palindrome
bool isPalindrome = Util.IsPalindrome("hello");
Console.WriteLine($"Is 'hello' a palindrome? {isPalindrome}");

// Exo 3 : Is anagram
bool isAnagram = Util.IsAnagram("listen", "silent");
Console.WriteLine($"Are 'listen' and 'silent' anagrams? {isAnagram}");

// Exo 4 : Plus grand nombre
int[] numbers = { 3, 5, 7, 2, 8 };
int maxNumber = Util.plusGrandNombre(numbers);
Console.WriteLine($"The largest number in the array is: {maxNumber}");

// Exo 5 : Supprime les éléments en double d'un tableau et retourne les valeurs uniques.
int[] arrayWithDuplicates = { 1, 2, 2, 3, 4, 4, 5 };
int[] uniqueArray = Util.SupprimerDoublons(arrayWithDuplicates);
Console.WriteLine($"Array with duplicates: {string.Join(", ", arrayWithDuplicates)}");
Console.WriteLine($"Unique array: {string.Join(", ", uniqueArray)}");

// Exo 6 : Two Sum
int[] arr = { 3, 2, 4 };
int target = 6;
var result = Util.TrouverDeuxIndices(arr, target);
if (result != null)
{
    Console.WriteLine($"Indices found: {result[0]}, {result[1]}");
}
else
{
    Console.WriteLine("No two sum solution");
}

// Exo 7 : Est nombre premier
int numberToCheck = 2;
bool isNombrePremier = Util.EstNombrePremier(numberToCheck);
Console.WriteLine($"Is {numberToCheck} a prime number? {isNombrePremier}");

// Exo 8: Fibonacci
int n = 10;
List<int> fibonacciSequence = Util.GenererFibonacci(n);
Console.WriteLine($"Fibonacci sequence (first {n} numbers): {string.Join(", ", fibonacciSequence)}");

// Exo 9: Factorial
int factorialInput = 5;
long factorialResult = Util.Factorielle(factorialInput);
Console.WriteLine($"Factorial of {factorialInput} is: {factorialResult}");

// Exo 10 : Tri à Bulles (Bubble Sort)
int[] sortedArray = { 1, 10, 20, 3, 5, 7, 9 };
int[] results = Util.TriABulles(sortedArray);
Console.WriteLine($"Sorted array: {string.Join(", ", results)}");   

// Exo 11 : Recherche Binaire
int[] binarySearchArray = { 1, 2, 3, 4, 5 };
int binarySearchTarget = 3;
int binarySearchResult = Util.RechercheBinaire(binarySearchArray, binarySearchTarget);
if (binarySearchResult != -1)
{
    Console.WriteLine($"Element {binarySearchTarget} found at index: {binarySearchResult}");
}
else
{
    Console.WriteLine($"Element {binarySearchTarget} not found in the array.");
}

// Exo 12 : FizzBuzz
int fizzBuzzLimit = 15;
List<string> fizzBuzzResult = Util.FizzBuzz(fizzBuzzLimit);
Console.WriteLine($"FizzBuzz up to {fizzBuzzLimit}: {string.Join(", ", fizzBuzzResult)}");

// Exo 13 : Compter les Occurrences
string stringToCount = "hello world";
Dictionary<char, int> occurrences = Util.CompterOccurrences(stringToCount);
Console.WriteLine($"Occurrences in '{stringToCount}':");
foreach (var kvp in occurrences)
{
    Console.WriteLine($"Character '{kvp.Key}': {kvp.Value} time(s)");
}

// Exo 14 : Rotation de Tableau
int[] arrayToRotate = { 1, 2, 3, 4, 5 };
int rotationSteps = 2;
int[] rotatedArray = Util.RotationDeTableau(arrayToRotate, rotationSteps);
Console.WriteLine($"Original array: {string.Join(", ", arrayToRotate)}");
Console.WriteLine($"New array: {string.Join(", ", rotatedArray)}");

// Exo 15 : valider une parenthèse
string parenthesesInput = "([)]";
bool isValidParentheses = Util.ParenthesesEquilibrees(parenthesesInput);
Console.WriteLine($"Are the parentheses in '{parenthesesInput}' balanced? {isValidParentheses}");
