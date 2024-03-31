using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            One<int> ints = new One<int>();
            One<char> chars = new One<char>();
            ints.CreateWithDefLen();
            chars.CreateWithFixLen(5);

            ints.PushBack(2);
            ints.PushBack(6);
            ints.PushBack(8);
            ints.PushBack(0);

            chars.PushBack('b');
            chars.PushBack('v');
            chars.PushBack('k');

            Console.WriteLine("Минимальное значение в int: " + ints.GetMin());
            Console.WriteLine("Максимальнрое значение в int: " + ints.GetMax());
            Console.WriteLine();
            Console.WriteLine("Минимальное значение в chars: " + chars.GetMin());
            Console.WriteLine("Максимальное значение в chars: " + chars.GetMax());

            ints.Sort();
            chars.Sort();

            Console.WriteLine("Отсортированный массив ints: ");
            ints.array_output();
            Console.WriteLine();
            Console.WriteLine("Отсортированный массив chars: ");
            chars.array_output();
        } 
    }
}
