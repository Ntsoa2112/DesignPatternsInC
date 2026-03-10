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

// Exo 5 : Two Sum
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