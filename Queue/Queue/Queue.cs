using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PriorityQueue
{
    private int[] _items;
    private int[] _priorities;
    private int _size;
    private int _capacity;

    public int Count => _size;
    public bool Empty => _size == 0;

    public PriorityQueue(int initialCapacity)
    {
        _capacity = initialCapacity;
        _items = new int[_capacity];
        _priorities = new int[_capacity];
        _size = 0;
    }
    public void Enqueue(int value, int priority)
    {
        if (_size == _capacity)
        {
            int newCapacity = _capacity * 2;
            Array.Resize(ref _items, newCapacity);
            Array.Resize(ref _priorities, newCapacity);
            _capacity = newCapacity;
        }

        _items[_size] = value;
        _priorities[_size] = priority;
        _size++;
    }
    public int Dequeue()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        int maxPriorityIndex = FindMaxPriorityIndex();

        int result = _items[maxPriorityIndex];

        for (int i = maxPriorityIndex; i < _size - 1; i++)
        {
            _items[i] = _items[i + 1];
            _priorities[i] = _priorities[i + 1];
        }
        _size--;

        if (_capacity > 4 && _size <= _capacity / 4)
        {
            int newCapacity = Math.Max(4, _capacity / 2);
            Array.Resize(ref _items, newCapacity);
            Array.Resize(ref _priorities, newCapacity);
            _capacity = newCapacity;
        }
        return result;
    }
    public int Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("Queue is empty");

        return _items[FindMaxPriorityIndex()];
    }
    private int FindMaxPriorityIndex()
    {
        int maxIndex = 0;
        for (int i = 1; i < _size; i++)
        {
            if (_priorities[i] > _priorities[maxIndex])
                maxIndex = i;
        }
        return maxIndex;
    }
}