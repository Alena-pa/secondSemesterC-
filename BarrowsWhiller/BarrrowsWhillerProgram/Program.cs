using BurrowsWheeler;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the word: ");
        StringBuilder input = new StringBuilder(Console.ReadLine());

        if (input == null || input.Length == 0)
        {
            return;
        }

        int indexOfLastElement = BurrowsWheelerTransform.BWT(ref input);

        Console.WriteLine(input);

        BurrowsWheelerTransform.ReverseBWT(ref input, indexOfLastElement);
        Console.WriteLine(input);
    }
}