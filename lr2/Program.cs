using System;
using System.Threading;

int count = 0;

void IncCount()
{
    for (int i = 0; i < 100000; i++)
    {
        count++;
    }
}

void IntIncCount()
{
    for(int i = 0; i<100000; i++)
    {
        Interlocked.Increment(ref count);
    }
}

Thread t1 = new Thread(IncCount);
Thread t2 = new Thread(IncCount);
Thread t3 = new Thread(IncCount);
t3.Start();
t2.Start();
t1.Start();

t1.Join();
t2.Join();
t3.Join();

Console.WriteLine("Без потокобезопасности: " + count);
count = 0;

Thread t11 = new Thread(IntIncCount);
Thread t22 = new Thread(IntIncCount);
Thread t33 = new Thread(IntIncCount);
t33.Start();
t22.Start();
t11.Start();

t11.Join();
t22.Join();
t33.Join();

Console.WriteLine("С потокобезопасностью(класс Interloked): "+ count);