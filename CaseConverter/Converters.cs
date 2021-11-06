using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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

            var builder = new StringBuilder(text.Length + Math.Min(2, text.Length / 5));
            var previousCategory = default(UnicodeCategory?);

            for (var currentIndex = 0; currentIndex < text.Length; currentIndex++)
            {
                var currentChar = text[currentIndex];
                if (currentChar == '_')
                {
                    builder.Append('_');
                    previousCategory = null;
                    continue;
                }

                var currentCategory = char.GetUnicodeCategory(currentChar);
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
        /// Converts any string to camelCase optionally removing whitespace
        /// See: https://stackoverflow.com/questions/42310727/convert-string-to-camelcase-from-titlecase-c-sharp
        /// See Also System.Text.Json.JsonNamingPolicy.CamelCase.ConvertName(text)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="removeWhitespace"></param>
        /// <param name="preserveLeadingUnderscore"></param>
        /// <returns>string</returns>
        public static string ToCamelCase(this string text, bool removeWhitespace = true, bool preserveLeadingUnderscore = false)
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
        /// Convert a string to Kebab Case
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToKebabCase(this string text)
        {
            if (text.IsAllUpper())
                text = text.ToLower();

            // Remove all "punctuation" characters from the string
            char[] separators = new char[] { ' ', ';', ',', '-', '_' };
            text = text.Replace(separators, "-");

            // If we have any upper case characters then it's camelCase, so split the string up based on the upper cas chars
            // ensure there are no double hyphens then convert the entire thing to lower case.
            // If there were no upper case characters then we didn't need to do that camelCase Split.
            return text.Any(char.IsUpper) ? text.SplitCamelCase("-").Replace("--", "-").ToLower() : text.Replace("--", "-").ToLower();

        }

        /// <summary>
        /// Convert a string to PascalCase
        /// See: https://stackoverflow.com/questions/23345348/topascalcase-c-sharp-for-all-caps-abbreviations
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToPascalCase(this string text)
        {
            StringBuilder result = new StringBuilder();
            Regex nonWordChars = new Regex(@"[^a-zA-Z0-9]+");
            string[] tokens = nonWordChars.Split(text);
            foreach (string token in tokens)
            {
                result.Append(token.PascalCaseSingleWord());
            }

            return result.ToString();
        }

        /// <summary>
        /// Converts the specified string to Title Case
        /// (except for words that are entirely in uppercase, which are considered to be acronyms).
        /// See: https://docs.microsoft.com/en-us/dotnet/api/system.globalization.textinfo.totitlecase?view=net-5.0
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string ToTitleCase(this string text)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(text);
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
        /// Convert a single word to Pascal Case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>string</returns>
        public static string PascalCaseSingleWord(this string text)
        {
            // return text.FirstCharToUpperCase();
            Match match = Regex.Match(text, @"^(?<word>\d+|^[a-z]+|[A-Z]+|[A-Z][a-z]+|\d[a-z]+)+$");
            Group groups = match.Groups["word"];

            TextInfo textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            StringBuilder result = new StringBuilder();
            foreach (Capture capture in groups.Captures)
            {
                result.Append(textInfo.ToTitleCase(capture.Value.ToLower()));
            }
            return result.ToString();
        }

        /// <summary>
        /// Insert any character before all upper space characters in a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <returns>string</returns>
        public static string InsertCharacterBeforeUpperCase(this string text, char character = ' ')
        {
            StringBuilder sb = new StringBuilder();
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
        /// Split a string by Uppercase whilst dealing correctly with acronyms
        /// The string you split with can be supplied or defaults to a space.
        /// Inspired by https://dotnetfiddle.net/VBuoy7
        /// See: https://stackoverflow.com/questions/36147162/c-sharp-string-split-separate-string-by-uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <param name="splitWith"></param>
        /// <returns>string</returns>
        public static string SplitCamelCase(this string input, string splitWith = " ")
        {
            var first = Regex
                .Replace(input, "(?<before>[^A-Z])(?<after>([A-Z]))", "${before} ${after}", RegexOptions.Compiled)
                .Trim();

            return Regex
                .Replace(first, "(?<before>[^ ])(?<after>([A-Z][^A-Zs]))", "${before}" + splitWith + "${after}", RegexOptions.Compiled)
                .Trim().Replace(" ", splitWith);

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

        private static readonly Regex WhiteSpaceRegex = new Regex(@"\s+");

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
        /// Test to determine if a string is all upper case
        /// See: https://stackoverflow.com/questions/448206/detecting-if-a-string-is-all-caps
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        public static bool IsAllUpper(this string input)
        {
            foreach (char t in input)
            {
                if (char.IsLetter(t) && !char.IsUpper(t))
                    return false;
            }

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
