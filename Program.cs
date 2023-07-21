using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a piece of text:");
            string userInput = Console.ReadLine();

            // Call the method to count words
            int wordCount = CountWords(userInput);

            // Call the method to validate email addresses
            List<string> emails = ValidateEmailAddresses(userInput);

            // Call the method to extract mobile numbers
            List<string> mobileNumbers = ExtractMobileNumbers(userInput);

            Console.WriteLine("\n----- Results -----");
            Console.WriteLine($"Word Count: {wordCount}");
            Console.WriteLine($"Email Addresses found: {string.Join(", ", emails)}");
            Console.WriteLine($"Extracted Mobile Numbers: {string.Join(", ", mobileNumbers)}");

            // Custom Regex search
            Console.WriteLine("\nEnter a custom regular expression:");
            string customRegexPattern = Console.ReadLine();
            List<string> customRegexMatches = CustomRegexSearch(userInput, customRegexPattern);
            Console.WriteLine($"Custom Regex Matches: {string.Join(", ", customRegexMatches)}");
        }

        static int CountWords(string input)
        {
            // Split the input text by spaces to count words
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        static List<string> ValidateEmailAddresses(string input)
        {
            List<string> emails = new List<string>();

            // Use a regular expression to find email addresses in the input text
            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            // Add the found email addresses to the list
            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }

            return emails;
        }

        static List<string> ExtractMobileNumbers(string input)
        {
            List<string> mobileNumbers = new List<string>();

            // Use a regular expression to find mobile numbers in the input text
            string pattern = @"\b\d{10}\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            // Add the found mobile numbers to the list
            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }

            return mobileNumbers;
        }

        static List<string> CustomRegexSearch(string input, string pattern)
        {
            List<string> matches = new List<string>();

            // Use the user-provided custom regular expression to find matches in the input text
            MatchCollection customMatches = Regex.Matches(input, pattern);

            // Add the found matches to the list
            foreach (Match match in customMatches)
            {
                matches.Add(match.Value);
            }

            return matches;
        }
    }
}

