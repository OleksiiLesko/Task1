using Task1.CustomStack;

var stackArray = new CustomStack<int>(10);
Console.WriteLine($"Amount of elements at the beginning:{stackArray.Count}\n");
stackArray.Push(100);
foreach (var item in stackArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();
stackArray.Clear();
foreach (var item in stackArray)
{
    Console.Write(item + " ");
}
Console.WriteLine();
stackArray.Push(200);
stackArray.Push(300);
stackArray.Push(400);
stackArray.Push(500);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Determines if an element is in a Stack collection:{stackArray.Contains(100)}\n");
Console.WriteLine($"Returns the object at the beginning of the Stack without deleting it:{stackArray.Peek()}\n");
Console.WriteLine($"Removes and returns the object at the beginning of the Stack:{stackArray.Pop()}\n");
Console.WriteLine($"Removes and returns the object at the beginning of the Stack:{stackArray.Pop()}\n");
Console.WriteLine($"Returns the object at the beginning of the Stack without deleting it:{stackArray.Peek()}\n");
Console.WriteLine();


var stackArray2 = new CustomStack<int>(10);
stackArray.CopyTo(stackArray2);
foreach (var item in stackArray2)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine($"stackArray is equal to stackArray2: {stackArray.Equals(stackArray2)}\n");
stackArray.Push(600);
Console.WriteLine($"stackArray is equal to stackArray2: {stackArray.Equals(stackArray2)}\n");
Console.WriteLine($"Determines if an element is in a Stack collection:{stackArray2.Contains(500)}\n");
Console.ReadLine();

