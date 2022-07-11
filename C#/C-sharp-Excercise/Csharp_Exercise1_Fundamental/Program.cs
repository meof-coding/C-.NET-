using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Csharp_Exercise1_Fundamental
{

    class Program
    {

        //EX1:
        Console.WriteLine("the result of dividing 24 into 5 is: " + 24 / 5);

                //EX2:
                Console.WriteLine("-1 + 4 * 6 = " + (-1 + 4 * 6));
                Console.WriteLine("( 35+ 5 ) % 7 = " + (35 + 5) % 7);
                Console.WriteLine("14 + -4 * 6 / 11 = " + (14 + -4 * 6 / 11));
                Console.WriteLine("2 + 15 / 6 * 1 - 7 % 2 = " + (2 + 15 / 6 * 1 - 7 % 2));

                //EX3
                Console.Write("Input first number: ");
                int num = int.Parse(Console.ReadLine());
        Console.Write("Input second number :");
                int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine($"{num} + {num1} = {num + num1}");
                Console.WriteLine($"{num} - {num1} = {num - num1}");
                Console.WriteLine($"{num} * {num1} = {num * num1}");
                Console.WriteLine($"{num} / {num1} = {num / num1}");
                Console.WriteLine($"{num} % {num1} = {num % num1}");

                //EX4
                Console.Write("Input first number: ");
                int num1 = int.Parse(Console.ReadLine());
        Console.Write("Input second number :");
                int num2 = int.Parse(Console.ReadLine());
        Console.Write("Input third number: ");
                int num3 = int.Parse(Console.ReadLine());
        Console.Write("Input four number :");
                int num4 = int.Parse(Console.ReadLine());
        Console.Write($"The average of {num1} , {num2} , {num3} , {num4} is: {(num1 + num2 + num3 + num4) / 4}");

                //EX5
                Console.Write("Input a number: ");
                int num1 = int.Parse(Console.ReadLine());
        List<int> a = new List<int>();
                while (num1 > 0)
                {
                    int ele = num1 % 10;
        a.Add(ele);
                    num1 = num1 / 10;
                }
    Console.Write("The number in reverse order is : ");
                foreach (int i in a)
                {
                    Console.Write(i);
                }

//EX6
Console.Write("Input the number of elements to store in the array : ");
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];
Console.WriteLine($"Input {n} number of elements in the array : ");
for (int i = 0; i < n; i++)
{
    Console.Write($"element -{i}:");
    int a = int.Parse(Console.ReadLine());
    array[i] = a;
}
Console.WriteLine("The values store into the array are: ");
foreach (int i in array)
{
    Console.Write($"{i} ");
}
Console.WriteLine();
Console.WriteLine("The values store into the array in reverse are : ");
for (int i = n - 1; i >= 0; i--)
{
    Console.Write($"{array[i]} ");

}

//EX7
void Print(List<int> array)
{
    foreach (int i in array)
    {
        Console.Write($"{i} ");
    }
}
Console.Write("Input the number of elements to store in the array : ");
int n = int.Parse(Console.ReadLine());
List<int> even = new List<int>();
List<int> odd = new List<int>();
Console.WriteLine($"Input {n} number of elements in the array : ");
for (int i = 0; i < n; i++)
{
    Console.Write($"element -{i}:");
    int a = int.Parse(Console.ReadLine());
    if (a % 2 == 0)
    {
        even.Add(a);
    }
    else
    {
        odd.Add(a);
    }
};
Console.WriteLine("The Even elements are: ");
Print(even);
Console.WriteLine();
Console.WriteLine("The Odd elements are: ");
Print(odd);

//EX8
void Print(List<int> array)
{
    foreach (int i in array)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}
Console.Write("Input the number of elements to store in the array : ");
int n = int.Parse(Console.ReadLine());
List<int> array = new List<int>();
Console.WriteLine($"Input {n} number of elements in the array : ");
for (int i = 0; i < n; i++)
{
    Console.Write($"element -{i}:");
    int a = int.Parse(Console.ReadLine());
    array.Add(a);
}
Console.WriteLine("Input the value to be inserted : ");
int num = int.Parse(Console.ReadLine());
Console.WriteLine("Input the Position, where the value to be inserted :");
int position = int.Parse(Console.ReadLine());
Console.WriteLine("The current list of the array :");
Print(array);
array.Insert(position - 1, num);
Console.WriteLine("After Insert the element the new list is :");
Print(array);

//EX9
string line = Console.ReadLine();
Console.WriteLine("Enter index of a chracter you want to remove: ");
int n = int.Parse(Console.ReadLine());
Console.WriteLine(line.Remove(n, 1));

//EX10
void Convert(string a)
{
    StringBuilder sb = new StringBuilder(a);
    char temp = sb[0];
    sb[0] = a[a.Length - 1];
    sb[a.Length - 1] = temp;
    Console.WriteLine(sb);
}
string line = Console.ReadLine();
string line1 = Console.ReadLine();
Convert(line);
Convert(line1);

//EX11
string line = Console.ReadLine();
List<string> list = new List<string>();
var word = line.Split(" ");
foreach (string i in word)
{
    list.Add(i);
}
Console.WriteLine(list.OrderByDescending(n => n.Length).First());

//EX12
Console.Write("Original String: ");
string line = Console.ReadLine();
var word = line.Split(" ");
Console.Write("Reverse String: ");
for (int i = word.Length - 1; i >= 0; i--)
{
    Console.Write(word[i] + " ");
}
        }
    }
}
