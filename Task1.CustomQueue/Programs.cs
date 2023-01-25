using Task1.CustomQueue;

var queueArray = new  CustomQueue<int>(5);
Console.WriteLine($"Amount of elements at the beginning:{queueArray.Count}\n");
queueArray.Enqueue(100);
foreach (var item in queueArray)
{
    Console.Write(item + " ");
}
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

Console.ReadLine();