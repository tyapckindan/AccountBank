public class BankAccount
{
    private double balance;
    private object @lock = new();

    public double Balance
    {
        get { return balance; }
    }
    public void TopUpBalance(double summ)
    {
        lock (@lock)
        {
            balance += summ;
            Console.WriteLine("Пополнено на: {0} рублей.\nБаланс: {1}", summ, balance);
            Monitor.Pulse(@lock);
        }
    }

    public void WithdrawMoney(double summ)
    {
        lock (@lock)
        {
            while (balance < summ)
            {
                Console.WriteLine("Ожидание пополнения баланса до {0} рублей.", summ);
                Monitor.Wait(@lock);
            }

            balance -= summ;
            Console.WriteLine("Снято: {0} рублей.\nБаланс составляет: {1}", summ, balance);
        }
    }
}
