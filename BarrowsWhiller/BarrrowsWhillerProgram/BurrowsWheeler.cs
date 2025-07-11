using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BurrowsWheeler;

public class BurrowsWheelerTransform
{
    public static int BWT(ref StringBuilder input)
    {
        if (input == null || input.Length == 0)
        {
            throw new ArgumentException("Incorrect input");
        }

        input.Append('\0');
        int textLength = input.Length;
        var table = new string[textLength];
        for (int i = 0; i < textLength; i++)
        {
            table[i] = input.ToString().Substring(i) + input.ToString().Substring(0, i);
        }

        var sortedTable = table.OrderBy(s => s).ToArray();

        var bwtResult = new StringBuilder();
        foreach (var row in sortedTable)
        {
            bwtResult.Append(row[textLength - 1]);
        }

        input = bwtResult;
        return input.ToString().IndexOf('\0');
    }

    public static void ReverseBWT(ref StringBuilder bwtText, int startIndex)
    {
        if (bwtText == null || bwtText.Length == 0)
        {
            return;
        }
        int textLength = bwtText.Length;
        var table = new StringBuilder[textLength];
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = new StringBuilder();
        }
        for (int i = 0; i < textLength; i++)
        {
            for (int j = 0; j < textLength; j++)
            {
                table[j].Insert(0, bwtText[j]);
                table = table.OrderBy(s => s.ToString()).ToArray();
            }
        }
        for (int i = 0; i < textLength; i++)
        {
            if (table[i][table[i].Length - 1] == '\0')
            {
                bwtText = table[i];
                return;
            }
        }
    }
}