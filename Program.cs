using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_3._02
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Задание 1:
int[] a = new int[5];
            double[,] b = new double[3, 4];

            // Заполнение массива а с помощью ввода с клавиатуры:
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Enter number {0}:", i);
                a[i] = int.Parse(Console.Readline());
            }

            // Заполнение массива б случайными числами с помощью циклов:
            Random rand = new Random();
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = rand.NextDouble();
                }
            }

            // Вывод массивов на экран:
            Console.WriteLine("Array a:");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Array b:");
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    Console.Write("{0} ", b[i, j]);
                }
                Console.WriteLine();
            }

            // Поиск общего максимального элемента, минимального элемента, общей суммы всех элементов, общего произведения всех элементов, суммы четных элементов массива а и суммы нечетных столбцов массива б:
            int max = a[0];
            int min = a[0];
            double sum = 0;
            double product = 1;
            int evenSum = 0;
            double oddColumnSum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
                if (a[i] < min)
                    min = a[i];
                sum += a[i];
                product *= a[i];
                if (a[i] % 2 == 0)
                    evenSum += a[i];
            }

            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (j % 2 != 0)
                        oddColumnSum += b[i, j];
                    if (b[i, j] > max)
                        max = b[i, j];
                    if (b[i, j] < min)
                        min = b[i, j];
                    sum += b[i, j];
                    product *= b[i, j];
                }
            }

            Console.WriteLine("Max element: {0}", max);
            Console.WriteLine("Min element: {0}", min);

            //Задание 2:
int[,] array = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(-100, 101);
                }
            }

            // поиск минимального и максимального элемента
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                        min = array[i, j];
                    if (array[i, j] > max)
                        max = array[i, j];
                }
            }

            // суммирование элементов между min и max
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > min && array[i, j] < max)
                        sum += array[i, j];
                }
            }

            Console.WriteLine($"Сумма элементов между минимальным и максимальным значениями составляет: {sum}");


            //Задание 3:
string CaesarCipher(string input, int shift)
            {
                char[] output = input.ToCharArray();
                for (int i = 0; i < input.Length; i++)
                {
                    // check if the character is a letter
                    if ((input[i] >= 'A' && input[i] <= 'Z') || (input[i] >= 'a' && input[i] <= 'z'))
                    {
                        // shift the character
                        output[i] = (char)(input[i] + shift);
                        // check if character is out of range
                        if (output[i] > 'z')
                        {
                            output[i] = (char)(input[i] - (26 - shift));
                        }
                        else if (output[i] < 'a')
                        {
                            output[i] = (char)(input[i] + (26 - shift));
                        }
                    }
                }
                return new string(output);
            }

           // Задание 4:
int[,] matrix1 = {
{ 4, 7, 6 },
{ 9, 8, 5 },
{ 1, 4, 3 }
};

            int[,] matrix2 = {
{ 1, 6, 5 },
{ 3, 4, 8 },
{ 2, 5, 9 }
};

            int[,] result = new int[3, 3];

            Console.Write("Enter a number to multiply matrix1 by: ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = matrix1[i, j] * num;
                }
            }

            Console.WriteLine("Multiplication Result : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            Console.WriteLine("Addition Result : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            Console.WriteLine("Multiplication Result : ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}


//Задание 5:
Console.WriteLine("Введите арифметическое выражение:");
string expression = Console.ReadLine();

int result = 0;
string[] substrings = expression.Split('+', '-');

foreach (string s in substrings)
{
    int number = int.Parse(s);
    if (expression.StartsWith("-"))
    {
        result -= number;
    }
    else
    {
        result += number;
    }
}

Console.WriteLine($"Результат: {result}");
}
}
}


//Задание 6:
string input;

Console.WriteLine("Введите предложение:");
input = Console.ReadLine();

string[] words = input.Split(' ');

for (int i = 0; i < words.Length; i++)
{
    words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);
}

input = string.Join(" ", words);

Console.WriteLine(input);
}
}
}


//Задание 7:
string text = "Тест с не подходящими словами";
string forbiddenWords = "не подходящие ";
string[] words;
int counter = 0;

words = text.Split(new string[] { " " }, StringSplitOptions.None);

for (int i = 0; i < words.Length; i++)
{
    if (words[i] == forbiddenWords)
    {
        words[i] = "*****";
        counter++;
    }
}

Console.WriteLine("Иекси после проверки:");
text = string.Join(" ", words);
Console.WriteLine(text);
Console.WriteLine("FСлов найдено: {0}", counter);
}
}
        }
    }
}
