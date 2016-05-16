using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// String extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Get the md5 hash of the string.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns a string containing the MD5 hash of the input.
    /// </returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Convert the string to boolean.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns True if the string is one of the following values:
    /// "true", "ok", "yes", "1", "да". Otherwise returns False.
    /// </returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Try parsing to short. One 'o' short of TooShort. BaDumTss
    /// </summary>
    /// <param name="input">
    /// The string to be parsed to short.
    /// </param>
    /// <returns>
    /// Returns 0 if the parsing has failed. Otherwise <see cref="short"/> number.
    /// </returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Try parsing to integer.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed to integer.
    /// </param>
    /// <returns>
    /// Returns 0 if the parsing has failed. Otherwise <see cref="int"/> number.
    /// </returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Try parsing to long.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed to long.
    /// </param>
    /// <returns>
    /// Returns 0 if the parsing has failed. Otherwise <see cref="long"/> number.
    /// </returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Try parsing to DateTime. 
    /// </summary>
    /// <param name="input">
    /// The string to be parsed to DateTime.
    /// </param>
    /// <returns>
    /// Returns {01/01/0001 00:00:00} if the parsing has failed. Otherwise <see cref="DateTime"/>.
    /// </returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalizes the first letter of a string.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the capitalized <see cref="string"/>.
    /// </returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Get the string between a start and end strings.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <param name="startString">
    /// The start string.
    /// </param>
    /// <param name="endString">
    /// The end string.
    /// </param>
    /// <param name="startFrom">
    /// The start index, default is 0.
    /// </param>
    /// <returns>
    /// Returns the <see cref="string"/> contained between "startString"
    /// and "endString", starting from index "startFrom". In case of
    /// invalid parameters, returns an empty string.
    /// </returns>
    public static string GetStringBetween(
        this string input,
        string startString,
        string endString,
        int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Convert cyrillic <see cref="string"/> to latin string.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the latin <see cref="string"/>.
    /// </returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters =
            new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
        var latinRepresentationsOfBulgarianLetters =
            new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(
                bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Convert latin <see cref="string"/> to cyrillic string.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the cyrillic <see cref="string"/>.
    /// </returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters =
            new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
                "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

        var bulgarianRepresentationOfLatinKeyboard =
            new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Convert string to a valid latin username containing only chars a-z, A-Z, 0-9, underscore and dot.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the resulting username <see cref="string"/>. Empty string if not valid.
    /// </returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Convert string to a valid latin filename containing only chars a-z, A-Z, 0-9, underscore, dot and hyphen.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the resulting filename <see cref="string"/>. Empty string if not valid.
    /// </returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Get the first characters of a string.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <param name="charsCount">
    /// How many characters to get.
    /// </param>
    /// <returns>
    /// Returns the <see cref="string"/> containing the first characters.
    /// </returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Get the file extension of a filename.
    /// </summary>
    /// <param name="fileName">
    /// The file name string.
    /// </param>
    /// <returns>
    /// Returns the <see cref="string"/> containing the extension. Returns empty string if input string is invalid.
    /// </returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Return the content type of a file based on its extension.
    /// </summary>
    /// <param name="fileExtension">
    /// The file extension string.
    /// </param>
    /// <returns>
    /// Returns the <see cref="string"/> representing the content type.
    /// </returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType =
            new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Convert string to byte array.
    /// </summary>
    /// <param name="input">
    /// The input string.
    /// </param>
    /// <returns>
    /// Returns the byte array of the string.
    /// </returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}