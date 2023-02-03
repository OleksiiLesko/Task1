using Task1.CustomStack;
var stackArray = new CustomStack<int>(10);
stackArray.Add += StackArray_Add;
stackArray.Delete += StackArray_Delete;
stackArray.Empty += StackArray_Empty;
stackArray.Full += StackArray_Full;
Console.WriteLine($"Amount of elements at the beginning:{stackArray.Count}\n");
stackArray.Push(100);
Console.WriteLine();
stackArray.Clear();
Console.WriteLine();
stackArray.Push(200);
stackArray.Push(300);
stackArray.Push(400);
stackArray.Push(500);
Console.WriteLine();
for (int i = 0; i < stackArray.Count; i++)
{
    stackArray[2] = 700;
    Console.Write(stackArray[i] + " ");
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Determines if an element is in a Stack collection:{stackArray.Contains(100)}\n");
Console.WriteLine($"Returns the object at the beginning of the Stack without deleting it:{stackArray.Peek()}\n");
Console.WriteLine($"Removes and returns the object at the beginning of the Stack:{stackArray.Pop()}\n");
Console.WriteLine($"Removes and returns the object at the beginning of the Stack:{stackArray.Pop()}\n");
Console.WriteLine($"Returns the object at the beginning of the Stack without deleting it:{stackArray.Peek()}\n");
Console.WriteLine();

void StackArray_Add(CustomStack<int> sender, CustomStackEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in stackArray)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
};
void StackArray_Full(CustomStack<int> sender, CustomStackEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in stackArray)
    {
        Console.Write(item + " ");
    }
}

void StackArray_Empty(CustomStack<int> sender, CustomStackEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in stackArray)
    {
        Console.Write(item + " ");
    }
}

void StackArray_Delete(CustomStack<int> sender, CustomStackEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in stackArray)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement removed");
}


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

var stackArray3 = new CustomStack<int>(20);
stackArray3.Add += StackArray3_Add;
stackArray3.Push(4);
stackArray3.Push(5);
foreach (var item in stackArray3.Filter(8))
{
    Console.Write(item + " ");
}
void StackArray3_Add(CustomStack<int> sender, CustomStackEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in stackArray3)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
}


Console.ReadLine();