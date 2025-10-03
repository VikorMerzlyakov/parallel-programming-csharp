// See https://aka.ms/new-console-template for more information
using System.Data;

static void ShowData(int[] arr, string name)
{
    Console.WriteLine($"{name}: ");
    for (int i = 0; i < arr.Length; i++)
    {
        if (i == arr.Length - 1)
        { Console.WriteLine(arr[i] + "."); }
        else { Console.Write(arr[i] + ", "); }
    }
}


static int[] RemoveEl(int[] source, int[] toRemove)
{
    int count = 0;
    for (int i = 0; i < source.Length; i++)
    {
        bool found = false;
        for (int j = 0; j < toRemove.Length; j++)
        {
            if (source[i] == toRemove[j])
            {
                found = true;
                break;
            }
        }
        if (!found) count++;
    }

    int[] res = new int[count];
    int index = 0;
    for (int i = 0; i< source.Length; i++)
    {
        bool found = false;
        for (int j = 0; j < toRemove.Length; j++)
        {
            if (source[i] == toRemove[j])
            {
                found = true;
                break;
            }
        }
        if (!found)
            res[index++] = source[i];
    }

    return res;
}




static void CutData(int[] arrA,out int[] arrB) 
{

    int min = arrA[0], max = arrA[0];
    for (int i = 1; i < arrA.Length; i++) {
        if (arrA[i] < min) min = arrA[i];
        if (arrA[i] > max) max = arrA[i];
    }

    double threshold = (double)(min + max) / 3;

    List<int> temp = new List<int>();
    foreach (int x in arrA)
    {
        if (x < threshold)
            temp.Add(x);
            
    }

    arrB = temp.ToArray();



}

static void Sort(int[] arr, bool descending = false) 
{
    for (int i = 0; i < arr.Length - 1; i++) {
        int maxInd = i;
        for (int j = 1 + i; j < arr.Length; j++)
        {
            if (arr[j] > arr[maxInd])
                maxInd = j;
        }

        int temp = arr[i];
        arr[i] = arr[maxInd];
        arr[maxInd] = temp;
    }
}



Console.WriteLine($"Колличество процессоров: {Environment.ProcessorCount}");

Thread.CurrentThread.Name = "Variant 16";

Console.WriteLine($"Имя потока: {Thread.CurrentThread.Name}");
Console.WriteLine($"ID потока: {Thread.CurrentThread.ManagedThreadId}");
Console.WriteLine($"Приоритет: {Thread.CurrentThread.Priority}");
Console.WriteLine();

Console.WriteLine($"Введите размер массива А (максимум 20 чисел): ");
int n = int.Parse(Console.ReadLine());

if (n < 0 || n > 20)
{
    Console.WriteLine("Размер должен быть от 0 до 20.");
    return;
}

int[] A = new int[n];
int[] B = null;

for (int i = 0; i < n; i++)
{
    A[i] = int.Parse(Console.ReadLine());
}   

ShowData(A, "Массив А");
Thread t1 = new Thread(() => CutData(A, out B));
Thread t2 = new Thread(() => Sort(B));


t1.Priority = ThreadPriority.BelowNormal;
t2.Priority = ThreadPriority.Highest;

t1.Start();
t1.Join();


A = RemoveEl(A, B);

t2.Start();
t2.Join();
ShowData(A, "Новый массив А");
ShowData(B, "Массив В");


