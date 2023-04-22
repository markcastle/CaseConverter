using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//#if DEBUG
using System.Threading;
//#endif

namespace CaseConverter
{
    /// <summary>
    /// Convert strings between different 'cases' (camelCase, snake_case, kebab-case, PascalCase and Train-Case)
    /// </summary>
    public static class Converters
    {
        /// <summary>
        /// Convert a string to Snake Case
        /// See https://stackoverflow.com/questions/63055621/how-to-convert-camel-case-to-snake-case-with-two-capitals-next-to-each-other
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            StringBuilder builder = new(text.Length + Math.Min(2, text.Length / 5));
            UnicodeCategory? previousCategory = default;

            for (int currentIndex = 0; currentIndex < text.Length; currentIndex++)
            {
                char currentChar = text[currentIndex];
                if (currentChar == '_')
                {
                    builder.Append('_');
                    previousCategory = null;
                    continue;
                }

                UnicodeCategory currentCategory = char.GetUnicodeCategory(currentChar);
                switch (currentCategory)
                {
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.TitlecaseLetter:
                        if (previousCategory == UnicodeCategory.SpaceSeparator ||
                            previousCategory == UnicodeCategory.LowercaseLetter ||
                            previousCategory != UnicodeCategory.DecimalDigitNumber &&
                            previousCategory != null &&
                            currentIndex > 0 &&
                            currentIndex + 1 < text.Length &&
                            char.IsLower(text[currentIndex + 1]))
                        {
                            builder.Append('_');
                        }

                        currentChar = char.ToLower(currentChar, CultureInfo.InvariantCulture);
                        break;

                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (previousCategory == UnicodeCategory.SpaceSeparator)
                        {
                            builder.Append('_');
                        }
                        break;

                    default:
                        if (previousCategory != null)
                        {
                            previousCategory = UnicodeCategory.SpaceSeparator;
                        }
                        continue;
                }

                builder.Append(currentChar);
                previousCategory = currentCategory;
            }

            return builder.ToString();
        }

     


        /// <summary>
        /// Converts a given string to camel case with the option to remove whitespace and preserve leading underscores.
        /// </summary>
        /// <param name="text">The string to be converted to camel case.</param>
        /// <param name="removeWhitespace">Whether to remove whitespace or not. By default, whitespace is removed.</param>
        /// <param name="preserveLeadingUnderscore">Whether to preserve leading underscores or not. By default, leading underscores are not preserved.</param>
        /// <returns>The resulting camel case string.</returns>
        public static string ToCamelCase(this string text,
                                         bool removeWhitespace = true,
                                         bool preserveLeadingUnderscore = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text; // if text is null or empty, return it as it is.
            }

            if (text.IsAllUpper())
            {
                text = text.ToLower(); // if the text is all uppercase, convert it to lowercase
            }

            bool addLeadingUnderscore = preserveLeadingUnderscore && text.StartsWith("_"); // check if the leading underscore should be preserved

            StringBuilder result = new(text.Length); // create a new instance of StringBuilder to store the output string
            bool toUpper = false; // flag to keep track of whether the current character should be uppercase or not

            foreach (char c in text) // iterate over each character in the input string
            {
                if (c == '-' || c == '_' || (removeWhitespace && char.IsWhiteSpace(c))) // if the current character is a separator or whitespace and the whitespace is to be removed
                {
                    toUpper = true; // set the flag to true
                }
                else
                {
                    result.Append(toUpper ? char.ToUpperInvariant(c) : c); // append the current character to the output string in uppercase or lowercase based on the flag
                    toUpper = false; // reset the flag to false
                }
            }

            if (result.Length > 0)
            {
                result[0] = char.ToLowerInvariant(result[0]); // convert the first character to lowercase
            }

            if (addLeadingUnderscore)
            {
                result.Insert(0, '_'); // insert the leading underscore at the beginning of the string
            }

            return result.ToString(); // return the resulting camel case string
        }



        /// <summary>
        /// Converts the specified string to PascalCase.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The PascalCase version of the string.</returns>
        public static string ToPascalCase(this string text)
        {
            // Create a StringBuilder object to store the result.
            StringBuilder result = new();

            // Get the TextInfo object for the current culture.
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            // Flag to track if we are at the beginning of a new word.
            bool newWord = true;

            // Iterate over each character in the string.
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                // If the current character is a letter or digit.
                if (char.IsLetterOrDigit(currentChar))
                {
                    // If we are at the beginning of a new word, convert the character to uppercase.
                    if (newWord)
                    {
                        result.Append(textInfo.ToUpper(currentChar));
                        newWord = false;
                    }
                    // Otherwise, convert the character to lowercase.
                    else
                    {
                        result.Append(textInfo.ToLower(currentChar));
                    }
                }
                // If the current character is not a letter or digit, we are at the beginning of a new word.
                else
                {
                    newWord = true;
                }

                // If the current character is a lowercase letter and the next character is an uppercase letter, 
                // we are at the beginning of a new word.
                if (i < text.Length - 1 && char.IsLower(text[i]) && char.IsUpper(text[i + 1]))
                {
                    newWord = true;
                }
            }

            // Return the result as a string.
            return result.ToString();
        }


        /// <summary>
        /// Splits a given camel case string into separate words using the specified separator.
        /// </summary>
        /// <param name="input">The camel case string to be split.</param>
        /// <param name="splitWith">The separator to be used. By default, a single space is used.</param>
        /// <returns>The resulting string with words separated by the specified separator.</returns>
        public static string SplitCamelCase(this string input, string splitWith = " ")
        {
            if (string.IsNullOrEmpty(input)) return input; // if input is null or empty, return it as it is.

            StringBuilder result = new(); // create a new instance of StringBuilder to store the output string
            bool isPrevUpper = false; // flag to keep track of whether the previous character was an uppercase letter or not

            for (int i = 0; i < input.Length; i++) // iterate over each character in the input string
            {
                char currentChar = input[i]; // get the current character

                if (i > 0 && char.IsUpper(currentChar)) // if the current character is uppercase and not the first character
                {
                    if (!isPrevUpper || (i < input.Length - 1 && !char.IsUpper(input[i + 1]))) // if the previous character was not uppercase or the next character is not uppercase
                    {
                        result.Append(splitWith); // append the separator to the output string
                    }
                }

                result.Append(currentChar); // append the current character to the output string
                isPrevUpper = char.IsUpper(currentChar); // update the flag to reflect whether the current character is uppercase or not
            }

            return result.ToString(); // return the resulting string with words separated by the specified separator
        }


        /// <summary>
        /// Converts a string to kebab-case, with words separated by hyphens.
        /// </summary>
        /// <param name="text">The input string to be converted to kebab-case.</param>
        /// <returns>A kebab-case representation of the input string.</returns>
        public static string ToKebabCase(this string text)
        {
            // Return the input text if it's null or empty
            if (string.IsNullOrEmpty(text)) return text;

            // Initialize a StringBuilder to store the result
            StringBuilder result = new();
            // Define a flag to track whether the previous character is a separator
            bool previousCharacterIsSeparator = true;

            // Iterate through each character in the input text
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                // If the current character is an uppercase letter or a digit
                if (char.IsUpper(currentChar) || char.IsDigit(currentChar))
                {
                    // Add a hyphen if the previous character is not a separator and
                    // the current character is preceded by a lowercase letter or followed by a lowercase letter
                    if (!previousCharacterIsSeparator && (i > 0 && (char.IsLower(text[i - 1]) || (i < text.Length - 1 && char.IsLower(text[i + 1])))))
                    {
                        result.Append("-");
                    }

                    // Append the lowercase version of the current character to the result
                    result.Append(char.ToLowerInvariant(currentChar));
                    // Update the flag to indicate that the current character is not a separator
                    previousCharacterIsSeparator = false;
                }
                // If the current character is a lowercase letter
                else if (char.IsLower(currentChar))
                {
                    // Append the current character to the result
                    result.Append(currentChar);
                    // Update the flag to indicate that the current character is not a separator
                    previousCharacterIsSeparator = false;
                }
                // If the current character is a space, underscore, or hyphen
                else if (currentChar == ' ' || currentChar == '_' || currentChar == '-')
                {
                    // Add a hyphen if the previous character is not a separator
                    if (!previousCharacterIsSeparator)
                    {
                        result.Append("-");
                    }
                    // Update the flag to indicate that the current character is a separator
                    previousCharacterIsSeparator = true;
                }
            }

            // Return the kebab-case representation of the input string
            return result.ToString();
        }





        // #if DEBUG

        #region -------------------- Old Methods --------------------

        private static readonly TextInfo TextInfo = CultureInfo.CurrentCulture.TextInfo;

        /// <summary>
        /// Converts the specified string to Title Case
        /// (except for words that are entirely in uppercase, which are considered to be acronyms).
        /// See: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.textinfo.totitlecase?view=net-5.0
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToTitleCaseOld(this string text)
        {
            return TextInfo.ToTitleCase(text);
        }

        /// <summary>
        /// Convert a string to PascalCase
        /// See: https://stackoverflow.com/questions/23345348/topascalcase-c-sharp-for-all-caps-abbreviations
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToPascalCaseOld(this string text)
        {
            StringBuilder result = new();
            Regex nonWordChars = new(@"[^a-zA-Z0-9]+");
            string[] tokens = nonWordChars.Split(text);
            foreach (string token in tokens)
            {
                result.Append(token.PascalCaseSingleWordOld());
            }

            return result.ToString();
        }

        /// <summary>
        /// Convert a single word to Pascal Case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string PascalCaseSingleWordOld(this string text)
        {
            // return text.FirstCharToUpperCase();
            Match match = Regex.Match(text, @"^(?<word>\d+|^[a-z]+|[A-Z]+|[A-Z][a-z]+|\d[a-z]+)+$");
            Group groups = match.Groups["word"];

            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            StringBuilder result = new();
            foreach (Capture capture in groups.Captures)
            {
                result.Append(textInfo.ToTitleCase(capture.Value.ToLower()));
            }
            return result.ToString();
        }

        /// <summary>
        /// Convert a string to Kebab Case
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToKebabCaseOld(this string text)
        {
            if (text.IsAllUpper())
                text = text.ToLower();

            // Remove all "punctuation" characters from the string
            char[] separators = new char[] { ' ', ';', ',', '-', '_' };
            text = text.Replace(separators, "-");

            // If we have any upper case characters then it's camelCase, so split the string up based on the upper cas chars
            // ensure there are no double hyphens then convert the entire thing to lower case.
            // If there were no upper case characters then we didn't need to do that camelCase Split.
            return text.Any(char.IsUpper) ? text.SplitCamelCaseOld("-").Replace("--", "-").ToLower() : text.Replace("--", "-").ToLower();

        }

        /// <summary>
        /// Converts any string to camelCase optionally removing whitespace
        /// See: https://stackoverflow.com/questions/42310727/convert-string-to-camelcase-from-titlecase-c-sharp
        /// See Also System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(text)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeWhitespace"></param>
        /// <param name="preserveLeadingUnderscore"></param>
        /// <returns>string</returns>
        public static string ToCamelCaseOld(this string text, bool removeWhitespace = true, bool preserveLeadingUnderscore = false)
        {

            if (text.IsAllUpper())
            {
                text = text.ToLower();
            }

            bool addLeadingUnderscore = preserveLeadingUnderscore && text.Substring(0, 1) == "_";

            if (text.Contains("-"))
                text = text.Replace("-", " ");

            if (text.Contains("_"))
                text = text.Replace("_", " ");

            // If we have spaces then convert each letter after the space to Upper Case
            if (text.Contains(" "))
                text = ToTitleCase(text).Trim();

            // Convert the first letter to lower case
            if (!string.IsNullOrEmpty(text) && text.Length > 1)
            {
                text = char.ToLowerInvariant(text[0]) + text.Substring(1);
            }

            if (removeWhitespace)
                text = text.Replace(" ", "");

            if (addLeadingUnderscore)
                text = "_" + text;

            return text;
        }

        /// <summary>
        /// Split a string by Uppercase whilst dealing correctly with acronyms
        /// The string you split with can be supplied or defaults to a space.
        /// Inspired by https://dotnetfiddle.net/VBuoy7
        /// See: https://stackoverflow.com/questions/36147162/c-sharp-string-split-separate-string-by-uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <param name="splitWith"></param>
        /// <returns>string</returns>
        public static string SplitCamelCaseOld(this string input, string splitWith = " ")
        {
            string first = Regex
                .Replace(input, "(?<before>[^A-Z])(?<after>([A-Z]))", "${before} ${after}", RegexOptions.Compiled)
                .Trim();

            return Regex
                .Replace(first, "(?<before>[^ ])(?<after>([A-Z][^A-Zs]))", "${before}" + splitWith + "${after}", RegexOptions.Compiled)
                .Trim().Replace(" ", splitWith);

        }

        #endregion

        // #endif

        /// <summary>
        /// Extension method to convert a given string to title case.
        /// </summary>
        /// <param name="text">The string to convert to title case.</param>
        /// <returns>A new string with each word in title case.</returns>
        public static string ToTitleCase(this string text)
        {
            // Check if the input string is null or empty, return the original string in that case
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            // Create a StringBuilder with the initial capacity set to the length of the input string
            // This helps avoid unnecessary memory allocations
            StringBuilder sb = new(text.Length);

            // A boolean flag to track if we are at the start of a new word
            bool newWord = true;

            // Iterate over each character in the input string
            foreach (char c in text)
            {
                // If the current character is a whitespace, hyphen, or underscore,
                // set the newWord flag to true and append the character to the StringBuilder
                if (char.IsWhiteSpace(c) || c is '-' or '_')
                {
                    newWord = true;
                    sb.Append(c);
                }
                // If we are at the start of a new word, append the uppercase version of the character
                // and set the newWord flag to false
                else if (newWord)
                {
                    sb.Append(char.ToUpper(c));
                    newWord = false;
                }
                // If we are not at the start of a new word, append the lowercase version of the character
                else
                {
                    sb.Append(char.ToLower(c));
                }
            }

            // Convert the StringBuilder to a string and return it
            return sb.ToString();
        }
        
        /// <summary>
        /// Convert a string to Train Case
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToTrainCase(this string text)
        {
            return text.ToPascalCase().SplitCamelCase("-").FirstCharToUpperCase().Replace("--", "-");
        }

      
        /// <summary>
        /// Insert any character before all upper space characters in a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns>string</returns>
        public static string InsertCharacterBeforeUpperCase(this string text, char character = ' ')
        {
            StringBuilder sb = new();
            char previousChar = char.MinValue; // Unicode '\0'
            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    // If not the first character and previous character is not a space, insert character before uppercase
                    if (sb.Length != 0 && previousChar != ' ')
                    {
                        sb.Append(character);
                    }
                }
                sb.Append(c);
                previousChar = c;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Insert a space before any upper case character in a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string InsertSpaceBeforeUpperCase(this string text)
        {
            return text.InsertCharacterBeforeUpperCase();
        }

        /// <summary>
        /// Replace specific characters found in a string
        /// See: https://stackoverflow.com/a/7265786/7986443
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separators"></param>
        /// <param name="newVal"></param>
        /// <returns>string</returns>
        public static string Replace(this string s, char[] separators, string newVal)
        {
            string[] temp = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(newVal, temp);
        }

        private static readonly Regex WhiteSpaceRegex = new(@"\s+");

        /// <summary>
        /// Replace all whitespace in a string
        /// See: https://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacement"></param>
        /// <returns>string</returns>
        public static string ReplaceWhitespace(this string input, string replacement)
        {
            return WhiteSpaceRegex.Replace(input, replacement);
        }


        /// <summary>
        /// Extension method to check if all the letters in the input string are uppercase.
        /// </summary>
        /// <param name="input">The string to check for uppercase letters.</param>
        /// <returns>True if all the letters in the input string are uppercase, otherwise false.</returns>
        public static bool IsAllUpper(this string input)
        {
            // Return early if the input string is null or empty
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            // Iterate over each character in the input string
            foreach (char c in input)
            {
                // If the current character is a letter and not uppercase, return false
                if (char.IsLetter(c) && !char.IsUpper(c))
                {
                    return false;
                }
            }

            // If all characters are either uppercase letters or non-letter characters, return true
            return true;
        }


        /// <summary>
        /// Convert SnakeCase to CamelCase
        /// See: https://www.codegrepper.com/code-examples/csharp/camelCase+and+snakeCase
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string SnakeCaseToCamelCase(this string text)
        {
            return Regex.Replace(text, "_[a-z]", m => m.ToString().TrimStart('_').ToUpper()).FirstCharToLowerCase();
        }

        /// <summary>
        /// Convert the first character in a string to lower case
        /// See: https://stackoverflow.com/questions/21755757/first-character-of-string-lowercase-c-sharp/21755933
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string FirstCharToLowerCase(this string text)
        {
            if (string.IsNullOrEmpty(text) || char.IsLower(text[0]))
                return text;

            return char.ToLower(text[0]) + text.Substring(1);
        }

        /// <summary>
        /// Convert the first character in a string to upper case
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string FirstCharToUpperCase(this string text)
        {
            if (string.IsNullOrEmpty(text) || char.IsUpper(text[0]))
                return text;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
