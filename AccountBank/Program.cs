
public class Program
{
    static void Main()
    {
        BankAccount acc = new();

        Thread depositThread = new(() =>
        {
            Random r = new();
            while (true)
            {
                double summ = r.Next(100, 1000);
                acc.TopUpBalance(summ);
                Thread.Sleep(1000);
            }
        });

        depositThread.Start();

        acc.WithdrawMoney(5000);

        Console.WriteLine($"Остаток на балансе: {acc.Balance}");
    }
}