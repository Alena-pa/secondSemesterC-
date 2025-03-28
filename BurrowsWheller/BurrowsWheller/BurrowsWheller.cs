using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BurrowsWheeler;

public class BurrowsWheelerTransform
{
    public static string? BWT(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        int textLength = input.Length;
        var table = new string[textLength];
        for (int i = 0; i < textLength; i++)
        {
            table[i] = input.Substring(i) + input.Substring(0, i);
        }

        var sortedTable = table.OrderBy(s => s).ToArray();

        var bwtResult = new StringBuilder();
        foreach (var row in sortedTable)
        {
            bwtResult.Append(row[textLength - 1]);
        }

        return bwtResult.ToString();
    }

    public static string? ReverseBWT(string bwtText, int startIndex)
    {
        if (string.IsNullOrEmpty(bwtText) || startIndex < 0)
        {
            return null;
        }

        int textLength = bwtText.Length;

        var symbolCount = bwtText.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var sortedBwt = bwtText.OrderBy(c => c).ToArray();

        int[] indexMapping = new int[textLength];
        int[] count = new int[256];

        foreach (var c in bwtText)
        {
            count[c]++;
        }

        int cumulativeCount = 0;
        for (int i = 0; i < 256; i++)
        {
            int temp = count[i];
            count[i] = cumulativeCount;
            cumulativeCount += temp;
        }

        for (int i = 0; i < textLength; i++)
        {
            indexMapping[count[bwtText[i]]] = i;
            count[bwtText[i]]++;
        }

        char[] result = new char[textLength];
        int currentIndex = indexMapping[startIndex];

        for (int i = 0; i < textLength; i++)
        {
            result[i] = bwtText[currentIndex];
            currentIndex = indexMapping[currentIndex];
        }

        return new string(result);
    }
}