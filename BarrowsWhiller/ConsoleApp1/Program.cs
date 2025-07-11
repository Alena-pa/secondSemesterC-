using System.Text;

StringBuilder hello = new StringBuilder("Hello World!");
Console.WriteLine(hello);
hello[4] = '\0';
Console.WriteLine(hello);