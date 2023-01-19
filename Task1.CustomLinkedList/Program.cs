using System.Xml.Linq;
using Task1.CustomLinkedList;

var list = new CustomLinkedList<int>();
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(4);
list.AddLast(5);
Console.WriteLine("Firts occurence of " + list.FindFirst(3).Data + " next item " + list.FindFirst(3).Next.Data);
Console.WriteLine("Last occurence of " + list.FindLast(5).Data + " previous item " + list.FindLast(5).Previous.Data);
list.Remove(1);
Console.WriteLine(list.Contains(6));
Console.WriteLine(list.Contains(3));
list.RemoveFirst();
list.RemoveLast();
list.AddFirst(1);
list.InsertAfter(1, 2);
list.InsertBefore(1, 0);
Console.WriteLine();

var secondList = new CustomLinkedList<int>();
list.CopyTo(secondList);
Console.WriteLine(secondList.Equals(list));

Console.ReadLine();
