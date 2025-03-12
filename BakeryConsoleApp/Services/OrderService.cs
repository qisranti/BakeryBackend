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
        private readonly MenuService _menuService;
        private readonly OrderItemService _orderItemService;
        private readonly ConsoleUI _consoleUI;

        public OrderService(MenuService menuService, OrderItemService orderItemService, ConsoleUI consoleUI)
        {
            _menuService = menuService;
            _orderItemService = orderItemService;
            _consoleUI = consoleUI;
        }

        public async Task MakeOrderAsync(Office office, HttpClient client)
        {
            var order = await CreateOrderAsync(office, client);

            if (order == null)
            {
                _consoleUI.ShowError("Error al crear el pedido.");
                return;
            }

            _consoleUI.ShowOrderHeader(office, order);

            bool continueAddingItems = true;

            while (continueAddingItems)
            {
                var menu = await _menuService.GetOfficeMenuAsync(client, office.Id);
                if (menu == null)
                {
                    _consoleUI.ShowError("Error al obtener el menú de la oficina.");
                    break;
                }

                var selectedBread = _consoleUI.SelectBread(menu);
                if (selectedBread == null) continue;

                int? quantity = _consoleUI.GetQuantity();
                if (quantity == null) continue;

                int? sellPrice = _consoleUI.GetSellPrice((int)selectedBread.Bread_Cost);
                if (sellPrice == null) continue;

                var success = await _orderItemService.CreateOrderItemAsync(client, order.Entity.Id, selectedBread.Id, sellPrice.Value, quantity.Value);

                if (success)
                    _consoleUI.ShowMessage("Genial!");
                else
                    _consoleUI.ShowError("Error!");

                continueAddingItems = _consoleUI.AskToContinue();
            }
        }

        private async Task<OrderResponse?> CreateOrderAsync(Office office, HttpClient client)
        {
            var response = await client.PostAsync($"Orders/create?officeId={office.Id}", null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OrderResponse>();
            }
            return null;
        }
    }
}
