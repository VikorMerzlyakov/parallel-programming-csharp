for (int i = 1; i < 11; i++)
{
    Client reader = new Client(i);
}
class Client
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;

    public Client(int i)
    {
        myThread = new Thread(EnterClub);
        myThread.Name = $"Посетитель {i}";
        myThread.Start();
    }

    public void EnterClub()
    {
        sem.WaitOne();
        Console.WriteLine($"{Thread.CurrentThread.Name} входит в клуб");
        Thread.Sleep(1000);
        Console.WriteLine($"{Thread.CurrentThread.Name} вышел из клуба.");
        sem.Release();

    }
}