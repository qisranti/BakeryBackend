using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryConsoleApp.Models;
using FinalBakery.Application.DTOs;
using FinalBakery.Domain.Entities;
using Newtonsoft.Json;

namespace BakeryConsoleApp.Services
{
    public class PreparationService
    {
        public async Task PrepareOrdersAsync(Office office, HttpClient client)
        {
            
            
            var response = await client.PostAsync($"Offices/prepareOfficeOrders?officeId={office.Id}", null);

            var orderResponseContent = await response.Content.ReadAsStringAsync();

            try
            {
                Console.Clear();
                Console.WriteLine($"Preparando pedidos en la oficina: {office.Office_Name}");
                var orderData = JsonConvert.DeserializeObject<ApiPreparationResponse>(orderResponseContent);

                if (orderData.success)
                {
                    var preparationResponse = orderData.entity;

                    foreach (var orderItem in preparationResponse)
                    {
                        Console.WriteLine($"Order ID: {orderItem.orderId}, Office ID: {orderItem.officeId}");

                        foreach (var item in orderItem.orderItems)
                        {
                            Console.WriteLine($"Bread Name: {item.breadName}");

                            Console.WriteLine("List of Steps:");

                            foreach (var step in item.preparationSteps)
                            {
                                Console.WriteLine($"  - Step Name: {step.step_Name}, Duration: {step.step_Duration} minutes");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {orderData.message}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }
    }
}
