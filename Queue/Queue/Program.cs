using System;

class Program
{
    static void Main()
    {
        var queue = new PriorityQueue(3);

        queue.Enqueue(100, 1);
        queue.Enqueue(200, 3);
        queue.Enqueue(300, 2);

        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
    }
}