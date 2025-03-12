using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryConsoleApp.Models;
using FinalBakery.Domain.Entities;

namespace BakeryConsoleApp.Services
{
    public class ConsoleUI
    {
        public void ShowOrderHeader(Office office, OrderResponse order)
        {
            Console.Clear();
            Console.WriteLine($"{office.Office_Name}");
            Console.WriteLine($"This is the order #{order.Entity.Id}");
        }

        public void ShowError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public Bread? SelectBread(List<Bread> breads)
        {
            Console.WriteLine("Menú de la Oficina:");
            for (int i = 0; i < breads.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {breads[i].Bread_Name} - {breads[i].Bread_Cost} $us");
            }

            Console.WriteLine("\nSelecciona una opción (número):");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index >= 1 && index <= breads.Count)
            {
                return breads[index - 1];
            }

            Console.WriteLine("Opción inválida");
            return null;
        }

        public int? GetQuantity()
        {
            Console.WriteLine("\nIngresa la cantidad:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int quantity) && quantity > 0)
            {
                return quantity;
            }

            Console.WriteLine("Cantidad inválida");
            return null;
        }

        public int? GetSellPrice(int cost)
        {
            Console.WriteLine("\nIngresa el precio de venta:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int price) && price > cost)
            {
                return price;
            }

            Console.WriteLine("El precio de venta debe ser mayor que el costo del pan.");
            return null;
        }

        public bool AskToContinue()
        {
            Console.WriteLine("\n¿Deseas agregar otro artículo? (s/n):");
            string? input = Console.ReadLine();
            Console.Clear();
            return input?.ToLower() == "s";
        }
    }

}
