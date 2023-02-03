using Task1.CustomLinkedList;

var list = new CustomLinkedList<int>();
list.Add += List_Add;
list.Delete += List_Delete;
list.Empty += List_Empty;
list.Full += List_Full;
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(4);
list.AddLast(5);
Console.WriteLine("\nFirts occurence of " + list.FindFirst(3).Data + " next item " + list.FindFirst(3).Next.Data);
Console.WriteLine("Last occurence of " + list.FindLast(5).Data + " previous item " + list.FindLast(5).Previous.Data);
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
for (int i = 0; i < list.Count; i++)
{
    list[4] = 700;
    Console.Write(list[i] + " ");
}
Console.WriteLine();
Console.WriteLine(list[1]);
Console.WriteLine();
list.Remove(1);
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine(list.Contains(6));
Console.WriteLine(list.Contains(3));
list.RemoveFirst();
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
list.RemoveLast();;
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
list.AddFirst(1);
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
list.InsertAfter(1, 2);
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
list.InsertBefore(1, 0);
Console.WriteLine();
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
void List_Full(CustomLinkedList<int> sender, CustomLinkedListEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
}

void List_Empty(CustomLinkedList<int> sender, CustomLinkedListEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
}

void List_Delete(CustomLinkedList<int> sender, CustomLinkedListEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement removed ");
}

void List_Add(CustomLinkedList<int> sender, CustomLinkedListEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
}

var secondList = new CustomLinkedList<int>();
list.CopyTo(secondList);
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine(secondList.Equals(list));

var thirdList = new CustomLinkedList<int>();
thirdList.Add += ThirdList_Add;
thirdList.AddLast(2);
thirdList.AddLast(5);
foreach (var item in thirdList.Filter(8))
{
    Console.Write(item + " ");
}
void ThirdList_Add(CustomLinkedList<int> sender, CustomLinkedListEventArgs eventArgs)
{
    Console.WriteLine(eventArgs.Message);
    foreach (var item in list)
    {
        Console.Write(item + " ");
    }
    Console.WriteLine($"\nElement added: {sender.Count}");
}


Console.ReadLine();
