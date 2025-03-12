using System.Net.Http;
using System.Net.Http.Json;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;

namespace BakeryConsoleApp.Services
{
    public class OfficeService
    {
        private readonly HttpClient _client;

        public OfficeService(HttpClient client)
        {
            _client = client;
        }

        public async Task ShowOfficeMenuAsync()
        {
            var response = await _client.GetAsync("Offices/getAllOffices");

            if (response.IsSuccessStatusCode)
            {
                var offices = await response.Content.ReadFromJsonAsync<List<Office>>();

                Console.WriteLine("Menú de Oficinas:");
                for (int i = 0; i < offices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {offices[i].Office_Name}");
                }

                Console.WriteLine("\nSelecciona una opción (número):");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int selectedIndex) &&
                    selectedIndex >= 1 && selectedIndex <= offices.Count)
                {
                    Console.Clear();
                    var selectedOffice = offices[selectedIndex - 1];
                    bool continueMenu = true;
                    while (continueMenu)
                    {
                        Console.WriteLine($"Selected Office: {selectedOffice.Office_Name}");
                        Console.WriteLine($"Office Capacity: {selectedOffice.Office_Capacity}\n");
                        Console.WriteLine("\nQue quieres hacer ahora?");
                        Console.WriteLine("\n1. Hacer un pedido");
                        Console.WriteLine("\n2. Obtener las ganancias");
                        Console.WriteLine("\n3. Preparar los pedidos");
                        Console.WriteLine("\n4. Volver");
                        Console.WriteLine("\nSelecciona una opción (número):");
                        string option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                Console.Clear();
                                var menuService = new MenuService();
                                var orderItemService = new OrderItemService();
                                var consoleUI = new ConsoleUI();
                                var orderService = new OrderService(menuService, orderItemService, consoleUI);

                                await orderService.MakeOrderAsync(selectedOffice, _client);
                                break;
                            case "2":
                                Console.Clear();
                                var profitService = new ProfitService();
                                profitService.ShowProfitsAsync(selectedOffice, _client);
                                break;
                            case "3":
                                Console.Clear();
                                var prepService = new PreparationService();
                                prepService.PrepareOrdersAsync(selectedOffice, _client);
                                break;
                            case "4":
                                continueMenu = false;
                                break;
                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }
                    }

                        
                    
                    Console.WriteLine($"\nElegiste: {selectedOffice}");
                }
                else
                {
                    Console.WriteLine("❌ Opción inválida");
                }
            }
            else
            {
                Console.WriteLine("❌ Error al obtener oficinas:");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
