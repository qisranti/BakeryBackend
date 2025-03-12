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
    public class ProfitService
    {
        public async Task ShowProfitsAsync(Office office, HttpClient client)
        {
            
            var response = await client.GetAsync($"Offices/getTodayEarnings?officeId={office.Id}");
            var earningsResponseContent = await response.Content.ReadAsStringAsync();

            try
            {
                var earningsData = JsonConvert.DeserializeObject<ApiEarningsResponse>(earningsResponseContent);

                if (earningsData.success)
                {
                    var earningsEntity = earningsData.entity;

                    Console.Clear();
                    Console.WriteLine($"Mostrando ganancias de la oficina: {office.Office_Name}");
                    Console.WriteLine($"Office ID: {earningsEntity.officeId}");
                    Console.WriteLine($"Office Name: {office.Office_Name}");
                    Console.WriteLine($"Number of Orders: {earningsEntity.numberOfOrders}");
                    Console.WriteLine($"Total Preparation Cost: {earningsEntity.totalPreparationCost:C}");
                    Console.WriteLine($"Total Sells: {earningsEntity.totalSells:C}");
                    Console.WriteLine($"Earnings: {earningsEntity.earnings:C}");
                }
                else
                {
                    Console.WriteLine($"Error: {earningsData.message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
