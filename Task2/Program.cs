using System;

public class SortingBlocks
{
    private static int blockSize;
    private static int[] inputArray;
    private static int[] inputArrayCopy;

    /*private static void sortArray() {
        int gap = (inputArray.Length + blockSize -1) / blockSize;
        int[] indexs = new int[blockSize];
        while (gap > 0)
        {
            for (int i = 0; i < gap; i++) {
                for (int j = 0; j < blockSize; j++) {
                    if(j * blockSize < inputArray.Length)
                        indexs[j] = j*gap + i;
                    else
                        indexs[j] = inputArray.Length-1;
                }
                blockSort(indexs);
            }
            gap--;
        }
    }*/
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

    /*private static void swapBlocks(int start1, int start2, int blockSize)
    {
        for (int i = 0; i < blockSize; i++)
        {
            if (start1 + i < inputArrayCopy.Length && start2 + i < inputArrayCopy.Length)
            {
                int temp = inputArrayCopy[start1 + i];
                inputArrayCopy[start1 + i] = inputArrayCopy[start2 + i];
                inputArrayCopy[start2 + i] = temp;
            }
        }
    }

    private static void sortByBlocks()
    {
        int numBlocks = (inputArrayCopy.Length  + blockSize - 1) / blockSize;

        for (int i = 0; i < numBlocks; i++)
        {
            for (int j = i + 1; j < numBlocks; j++)
            {
                int firstA = inputArrayCopy[i * blockSize];
                int firstB = inputArrayCopy[j * blockSize];

                if (firstA > firstB)
                {
                    swapBlocks(i * blockSize, j * blockSize, blockSize);
                }
            }
        }
    }*/


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

    public static void Main()
    {
        inputArray = getArray("Введите массив");              //8 6 5 3 2 1 4 5 6 9 3
        inputArrayCopy = (int[])inputArray.Clone();
        blockSize = getNumber("Введите размер блока");        //3

        Console.WriteLine("Сортировка методом сортировки внутри блоков:\n");
        Console.WriteLine("Описание метода:");
        Console.WriteLine("Массив делится на группы (блоки) по заданной длине.\n"
                        + "Элементы внутри каждого блока сортируются отдельно,\n"
                        + "после чего блоки последовательно упорядочиваются.\n");
        Console.WriteLine("До сортировки: " + string.Join(", ", inputArray));
        sortArray();
        Console.WriteLine("После сортировки: " + string.Join(", ", inputArray));
        Console.WriteLine();
        /*
        Console.WriteLine("Сортировка методом перестановки блоков:\n");
        Console.WriteLine("Описание метода:");
        Console.WriteLine("Массив делится на блоки одинаковой длины.\n"
                        + "Блоки сравниваются между собой по первым элементам.\n"
                        + "Если порядок нарушен, два блока меняются местами.\n"
                        + "Так продолжается до тех пор, пока массив не будет упорядочен.\n");
        Console.WriteLine("До сортировки: " + string.Join(", ", inputArrayCopy));
        sortByBlocks();
        Console.WriteLine("После сортировки: " + string.Join(", ", inputArrayCopy));*/
    }

}