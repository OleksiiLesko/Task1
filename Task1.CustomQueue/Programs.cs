using Task1.CustomQueue;

var queueArray = new  CustomQueue<int>(5);
queueArray.Add += QueueArray_Add;
queueArray.Delete += QueueArray_Delete;
queueArray.Empty += QueueArray_Empty;
queueArray.Full += QueueArray_Full;
Console.WriteLine($"Amount of elements at the beginning:{queueArray.Count}\n");
queueArray.Enqueue(100);
Console.WriteLine();
queueArray.Clear();
Console.WriteLine();
foreach (var item in queueArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();
queueArray.Enqueue(200);
queueArray.Enqueue(300);
queueArray.Enqueue(400);
queueArray.Enqueue(500);
Console.WriteLine();
foreach (var item in queueArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();
for (int i = 0; i < queueArray.Count; i++)
{
    queueArray[2] = 700;
    Console.Write(queueArray[i] + " ");
}
Console.WriteLine();
Console.WriteLine(queueArray[3]);
Console.WriteLine($"Determines if an element is in a CustomQueue collection:{queueArray.Contains(100)}\n");
Console.WriteLine($"Removes an object from the front of the CustomQueue and returns it:{queueArray.Dequeue()}\n");
Console.WriteLine($"Returns the object at the head of the CustomQueue , but does not remove it:{queueArray.Peek()}\n");
Console.WriteLine();
foreach (var item in queueArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine($"Removes an object from the front of the CustomQueue and returns it:{queueArray.Dequeue()}\n");
Console.WriteLine($"Returns the object at the head of the CustomQueue , but does not remove it:{queueArray.Peek()}\n");
Console.WriteLine();
foreach (var item in queueArray)
{
    Console.Write(item + " ");
}
void QueueArray_Delete(CustomQueue<int> sender, CustomQueueEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in queueArray)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement removed ");
}
void QueueArray_Add(CustomQueue<int> sender, CustomQueueEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in queueArray)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
}
void QueueArray_Full(CustomQueue<int> sender, CustomQueueEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in queueArray)
    {
        Console.Write(item + " ");
    }
}

void QueueArray_Empty(CustomQueue<int> sender, CustomQueueEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in queueArray)
    {
        Console.Write(item + " ");
    }
}
Console.WriteLine();

var queueArray2 = new CustomQueue<int>(5);
queueArray.CopyTo(queueArray2);
Console.WriteLine();
foreach (var item in queueArray2)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine($"queueArray is equal to queueArray2: {queueArray.Equals(queueArray2)}\n");
queueArray2.Enqueue(600);
Console.WriteLine($"queueArray is equal to queueArray2: {queueArray.Equals(queueArray2)}\n");
Console.WriteLine($"Determines if an element is in a CustomQueue collection:{queueArray2.Contains(500)}");

var queueArray3 = new CustomQueue<int>(20);
queueArray3.Add += QueueArray3_Add;
queueArray3.Enqueue(4);
queueArray3.Enqueue(5);
void QueueArray3_Add(CustomQueue<int> sender, CustomQueueEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in queueArray)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
}
foreach (var item in queueArray3.Filter(1))
{
    Console.Write(item + " ");
}


Console.ReadLine();