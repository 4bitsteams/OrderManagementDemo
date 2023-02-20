﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.BLL.IManager;
using OrderManagement.Entity.Models;
using OrderManagementViewModel.ViewModels.SalesOrder;

namespace OrderManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _iOrderManager;
        public OrderController(IOrderManager iOrderManager)
        {
            _iOrderManager = iOrderManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetAllOrders()
        {
            return await _iOrderManager.GetOrdersAsync();
        }
    }
}