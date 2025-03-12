using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BakeryConsoleApp.Models;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;
using Newtonsoft.Json;

namespace BakeryConsoleApp.Services
{
    public class OrderService
    {
        public async Task MakeOrderAsync(Office office, HttpClient client)
        {
            var orderCreationResponse = await client.PostAsync($"Orders/create?officeId={office.Id}", null);
            if (orderCreationResponse.IsSuccessStatusCode)
            {
                var order = await orderCreationResponse.Content.ReadFromJsonAsync<OrderResponse>();
                Console.Clear();
                Console.WriteLine($"{office.Office_Name}");
                Console.WriteLine($"This is the order #{order.Entity.Id}");

                bool continueAddingItems = true;

                while (continueAddingItems)
                {
                    var response = await client.GetAsync($"Offices/getMenu?officeId={office.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var officeMenu = await response.Content.ReadFromJsonAsync<List<Bread>>();
                        Console.WriteLine("Menú de la Oficina:");
                        for (int i = 0; i < officeMenu.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {officeMenu[i].Bread_Name} - {officeMenu[i].Bread_Cost} $us");
                        }

                        Console.WriteLine("\nSelecciona una opción (número):");
                        string breadSelected = Console.ReadLine();
                        if (int.TryParse(breadSelected, out int selectedIndex) &&
                            selectedIndex >= 1 && selectedIndex <= officeMenu.Count)
                        {
                            Console.WriteLine("\nIngresa la cantidad:");
                            string quantity = Console.ReadLine();

                            var selectedBread = officeMenu[selectedIndex - 1];
                            if (int.TryParse(quantity, out int quantityInt) && quantityInt > 0)
                            {
                                Console.WriteLine("\nIngresa el precio de venta:");
                                string breadSellPrice = Console.ReadLine();
                                if (int.TryParse(breadSellPrice, out int breadSellPriceInt) && breadSellPriceInt > selectedBread.Bread_Cost)
                                {
                                    var orderId = order.Entity.Id;
                                    var breadId = selectedBread.Id;
                                    var orderItemPrice = breadSellPriceInt;
                                    var orderItemQuantity = quantityInt;

                                    var url = $"OrderItems/createOrderItem?orderId={orderId}&breadId={breadId}&orderItemPrice={orderItemPrice}&orderItemQuantity={orderItemQuantity}";

                                    var orderResponse = await client.PostAsync(url, null);

                                    var errorContent = await orderResponse.Content.ReadAsStringAsync();

                                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(errorContent);

                                    if (responseObject.success)
                                    {
                                        Console.WriteLine("¡Pedido realizado con éxito!");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Error al realizar el pedido: {responseObject.message}");
                                    }

                                    Console.WriteLine("\n¿Deseas agregar otro artículo? (s/n):");
                                    string continueInput = Console.ReadLine();
                                    Console.Clear();
                                    if (continueInput?.ToLower() != "s")
                                    {
                                        continueAddingItems = false; 
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El precio de venta debe ser mayor que el costo del pan.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Cantidad inválida");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error al obtener el menú de la oficina.");
                        continueAddingItems = false; 
                    }
                }
            }
            else
            {
                Console.WriteLine("Error al crear el pedido.");
            }
        }

    }
}
