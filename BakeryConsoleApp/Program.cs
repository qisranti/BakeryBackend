using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BakeryConsoleApp.Services;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7257/api/")
        };

        var officeService = new OfficeService(client);

        await officeService.ShowOfficeMenuAsync();

        Console.WriteLine("\nPresiona Enter para salir...");
        Console.ReadLine();
    }
}