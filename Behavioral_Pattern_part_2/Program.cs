using StatePattern;

namespace Behavioral_Pattern_part_2
{
    namespace MainProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                VendingMachine vendingMachine = new VendingMachine(3);

                vendingMachine.SelectProduct();
                vendingMachine.InsertMoney(1.50m);
                vendingMachine.DispenseProduct();

                vendingMachine.SelectProduct();
                vendingMachine.InsertMoney(1.00m);
                vendingMachine.DispenseProduct();

                vendingMachine.SelectProduct();
                vendingMachine.InsertMoney(2.00m);
                vendingMachine.DispenseProduct();

                vendingMachine.SelectProduct();
                vendingMachine.DispenseProduct();
            }
        }
    }
}