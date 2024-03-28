using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class VendingMachine
    {
        private IVendingMachineState _state;
        public int Stock { get; set; }
        public decimal Amount { get; set; }

        public VendingMachine(int stock)
        {
            Stock = stock;
            Amount = 0;
            _state = new NoSelectionState(this);
        }

        public void SetState(IVendingMachineState state)
        {
            _state = state;
        }

        public void SelectProduct()
        {
            _state.SelectProduct();
        }

        public void InsertMoney(decimal amount)
        {
            _state.InsertMoney(amount);
        }

        public void DispenseProduct()
        {
            _state.DispenseProduct();
        }

        public void AddStock(int quantity)
        {
            Stock += quantity;
        }

        public void RemoveStock(int quantity)
        {
            Stock -= quantity;
        }

        public void AddAmount(decimal amount)
        {
            Amount += amount;
        }

        public void RemoveAmount(decimal amount)
        {
            Amount -= amount;
        }
    }
    public interface IVendingMachineState
    {
        void SelectProduct();
        void InsertMoney(decimal amount);
        void DispenseProduct();
    }

    public class NoSelectionState : IVendingMachineState
    {
        private readonly VendingMachine _vendingMachine;

        public NoSelectionState(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public void SelectProduct()
        {
            Console.WriteLine("Please select a product first.");
        }

        public void InsertMoney(decimal amount)
        {
            _vendingMachine.Amount += amount;
            _vendingMachine.SetState(new ProductSelectedState(_vendingMachine));
            Console.WriteLine($"Amount inserted: {amount}");
        }

        public void DispenseProduct()
        {
            Console.WriteLine("Please select a product first.");
        }
    }

    public class ProductSelectedState : IVendingMachineState
    {
        private readonly VendingMachine _vendingMachine;

        public ProductSelectedState(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public void SelectProduct()
        {
            Console.WriteLine("You have already selected a product.");
        }

        public void InsertMoney(decimal amount)
        {
            _vendingMachine.Amount += amount;
            Console.WriteLine($"Amount inserted: {amount}. Total amount: {_vendingMachine.Amount}");
        }

        public void DispenseProduct()
        {
            if (_vendingMachine.Amount >= 1.50m && _vendingMachine.Stock > 0)
            {
                _vendingMachine.Stock--;
                _vendingMachine.Amount -= 1.50m;
                Console.WriteLine("Product dispensed. Thank you for your purchase!");
                if (_vendingMachine.Stock == 0)
                {
                    _vendingMachine.SetState(new OutOfStockState(_vendingMachine));
                }
                else
                {
                    _vendingMachine.SetState(new NoSelectionState(_vendingMachine));
                }
            }
            else
            {
                Console.WriteLine("Insufficient amount or out of stock.");
            }
        }
    }

    public class OutOfStockState : IVendingMachineState
    {
        private readonly VendingMachine _vendingMachine;

        public OutOfStockState(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }

        public void SelectProduct()
        {
            Console.WriteLine("Out of stock. Please select another product.");
        }

        public void InsertMoney(decimal amount)
        {
            Console.WriteLine("Out of stock. Cannot insert money.");
        }

        public void DispenseProduct()
        {
            Console.WriteLine("Out of stock.");
        }
    }
}