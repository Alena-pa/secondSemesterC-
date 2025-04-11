using System.Collections.Generic;

namespace QueueTest
{
    public class UnitTest1
    {
        [Fact]
        public void Enqueue_AddsItem()
        {
            var queue = new PriorityQueue(2);
            queue.Enqueue(10, 1);

            Assert.Equal(1, queue.Count);
            Assert.False(queue.Empty);
        }

        [Fact]
        public void Dequeue_ReturnsHighestPriorityItem()
        {
            var queue = new PriorityQueue(2);
            queue.Enqueue(10, 1);
            queue.Enqueue(20, 2);

            Assert.Equal(20, queue.Dequeue());
            Assert.Equal(10, queue.Dequeue());
        }
    }
}