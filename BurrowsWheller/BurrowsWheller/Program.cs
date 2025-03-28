using BurrowsWheeler;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the word: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        string? result = BurrowsWheelerTransform.BWT(input);

        if (result != null)
        {
            Console.WriteLine($"\nDirect transformation: {result}\n");

            int index = result.LastIndexOf('$');
            if (index != -1)
            {
                string? inverseResult = BurrowsWheelerTransform.ReverseBWT(result, index);
                Console.WriteLine("Inverse transformation: " + inverseResult + "\n");
            }
        }
        else
        {
            Console.WriteLine("Error: Input string is null.");
        }
    }
}