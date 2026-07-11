using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a priorityQueue with the following value and priority Bob(2), Sue(5), Tim(3)
    // Expected Result: Sue, Tim, Bob
    // Defect(s) Found: Dequeue method do not remove the item with the highest priority, it only returns it.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Sue", 5);
        priorityQueue.Enqueue("Tim", 3);

        string[] expectedResult = ["Sue", "Tim", "Bob"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
    }

    [TestMethod]
    // Scenario: Create a priorityQueue with the following values and priorities Bob(2), Tim(3), Sue(3), Anne(1)
    // Expected Result: Tim, Sue, Bob, Anne (items with the same priority preserved in insertion order)
    // Defect(s) Found: The highest priority index was set wrongly causing the last dequeue to return incorrect item
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 3);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Anne", 1);

        string[] expectedResult = ["Tim", "Sue", "Bob", "Anne"];

        for (int i = 0; i < expectedResult.Length; i++)
        {
            var value = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], value);
        }
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue
    // Expected Result: Exception should be thrown with an appropriate message.
    // Defect(s) Found: Dequeue should not succeed when the queue has no items.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("Queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}