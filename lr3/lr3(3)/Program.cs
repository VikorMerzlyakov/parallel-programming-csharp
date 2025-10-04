for (int i = 1; i < 11; i++)
{
    Sleeper reader = new Sleeper(i);
}
class Sleeper
{
    static Semaphore sem = new Semaphore(10, 10);
    Thread myThread;
    int count = 3;

    public Sleeper(int i)
    {
        myThread = new Thread(ParkCar);
        myThread.Name = $"Поток {i}";
        myThread.Start();
    }

    public void ParkCar()
    {
        for (int day = 0; day < 3; day++)
        {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} припарковался.");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} выехал.");
            sem.Release();
            Thread.Sleep(500);
        }

    }
}