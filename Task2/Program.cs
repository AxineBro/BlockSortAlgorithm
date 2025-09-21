using System;

public class SortingBlocks
{
    private static int blockSize;
    private static int blockSizeCopy;
    private static int[] inputArray;
    private static int[] inputArrayCopy;

    private static void sortArray()
    {
        int gap = (inputArray.Length + blockSize - 1) / blockSize;

        while (gap > 0)
        {
            for (int i = 0; i < gap; i++)
            {
                List<int> indicesList = new List<int>();
                for (int j = i; j < inputArray.Length; j += gap)
                {
                    indicesList.Add(j);
                }

                int[] indexs = indicesList.ToArray();
                blockSort(indexs);
            }
            gap--;
        }
    }

    private static void blockSort(int[] indexs)
    {
        int[] block = getBlock(indexs);
        Array.Sort(block);
        setBlock(indexs, block);
    }

    private static int[] getBlock(int[] indexs) {
        int[] block = new int[indexs.Length];
        for (int i = 0; i < indexs.Length; i++)
        {
            block[i] = inputArray[indexs[i]];
        }
        return block;
    }

    private static void setBlock(int[] indexs, int[] block)
    {
        for (int i = 0; i < indexs.Length; i++)
        {
            inputArray[indexs[i]] = block[i];
        }
    }
    private static void sortByBlocks()
    {
        if (blockSizeCopy <= 1) return;

        int half = blockSizeCopy / 2;
        bool changed;
        int passes = 0;

        do
        {
            changed = false;

            for (int i = 0; i < inputArrayCopy.Length; i += half)
            {
                int end = Math.Min(i + blockSizeCopy, inputArrayCopy.Length);
                int len = end - i;

                int[] block = new int[len];
                Array.Copy(inputArrayCopy, i, block, 0, len);
                Array.Sort(block);

                for (int j = 0; j < len; j++)
                {
                    if (inputArrayCopy[i + j] != block[j])
                    {
                        inputArrayCopy[i + j] = block[j];
                        changed = true;
                    }
                }
            }

            passes++;
            if (passes > inputArrayCopy.Length) break;

        } while (changed);  
    }

    private static int[] getArray(string msg)
    {
        bool isCorrect = false;
        int[] inputArray = null;
    w: while (!isCorrect)
        {
            Console.WriteLine(msg + ": ");
            string[] tempArray = Console.ReadLine().Split(" ");
            inputArray = new int[tempArray.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                try
                {
                    inputArray[i] = int.Parse(tempArray[i]);
                }
                catch (Exception)
                {
                    Console.WriteLine("НЕВЕРНЫЙ ФОРМАТ ВВОДА! ПОЖАЛУЙСТА, ПОВТОРИТЕ ПОПЫТКУ");
                    goto w;
                }
            }
            isCorrect = true;
        }
        return inputArray;
    }

    private static int getNumber(string msg) {
    w: while (true)
        {
            Console.WriteLine(msg + ": ");
            try
            {
                int tempNumber = int.Parse(Console.ReadLine());
                return tempNumber;
            }
            catch (Exception)
            {
                Console.WriteLine("НЕВЕРНЫЙ ФОРМАТ ВВОДА! ПОЖАЛУЙСТА, ПОВТОРИТЕ ПОПЫТКУ");
                goto w;
            }
        }
        return -1;
    }

    private static int[] generateArray(int size)
    {
        Random rnd = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
        {
            arr[i] = rnd.Next(0, 100);
        }

        return arr;
    }


    public static void Main()
    {
        inputArray = generateArray(getNumber("Введите размер массива"));
        if (inputArray.Length % 2 == 0)
        {
            inputArrayCopy = (int[])inputArray.Clone();
        }
        else {
            inputArrayCopy = new int[inputArray.Length - 1];
            Array.Copy(inputArray, inputArrayCopy, inputArray.Length - 1);
        }


        blockSize = getNumber("Введите размер блока");
        if (blockSize % 2 == 0)
        {
            blockSizeCopy = blockSize;
        }
        else
        {
            blockSizeCopy = blockSize - 1;
        }

        Console.WriteLine("Сортировка методом сортировки внутри блоков:\n");
        Console.WriteLine("Описание метода:");
        Console.WriteLine("Массив делится на группы (блоки) по заданной длине.\n"
                        + "Элементы внутри каждого блока сортируются отдельно,\n"
                        + "после чего блоки последовательно упорядочиваются.\n");
        Console.WriteLine("До сортировки: " + string.Join(", ", inputArray));
        sortArray();
        Console.WriteLine("После сортировки: " + string.Join(", ", inputArray));
        Console.WriteLine();

        Console.WriteLine("Сортировка методом деления блоков:\n");
        Console.WriteLine("Описание метода:");
        Console.WriteLine("Массив обрабатывается блоками заданной длины.\n"
                        + "Каждый блок делится на две половины.\n"
                        + "Объединённый блок сортируется целиком.\n"
                        + "Первая половина отсортированного блока остаётся на месте,\n"
                        + "а вторая половина переносится вперёд, образуя начало следующего блока.\n"
                        + "Процесс продолжается, пока не будет пройден весь массив.\n");

        Console.WriteLine("До сортировки: " + string.Join(", ", inputArrayCopy));
        sortByBlocks();
        Console.WriteLine("После сортировки: " + string.Join(", ", inputArrayCopy));

    }

}