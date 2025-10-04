for (int i = 1; i < 11; i++)
{
    Sleeper reader = new Sleeper(i);
}
class Sleeper
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;

    public Sleeper(int i)
    {
        myThread = new Thread(Sleep);
        myThread.Name = $"Поток {i}";
        myThread.Start();
    }

    public void Sleep()
    {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} засыпает");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} проснулся.");
            sem.Release();

    }
}