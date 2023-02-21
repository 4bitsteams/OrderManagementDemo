using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.BLL.IManager;
using OrderManagement.DAL.Extensions;
using OrderManagement.Entity.Models;
using OrderManagement.WebApi.Models;
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
            Result<bool> result = Result.Ok<bool>(false);
            var orders = new List<OrderViewModel>();
            try
            {
                 orders= await _iOrderManager.GetOrdersAsync();
            }
            catch (System.Exception ex)
            {
                result = Result.Ok(true, ex.Message);
            }

            return orders;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> GetOrderInfo(int id)
        {
            Result<bool> result = Result.Ok<bool>(false);
            var order = new OrderViewModel();
            try
            {
                 order = await _iOrderManager.GetOrderAsync(id);

                if (order == null)
                    return NotFound();
            }
            catch (System.Exception ex)
            {
                result = Result.Ok(true, ex.Message);
            }

            return order;
        }


        [HttpPost]
        public async Task<Result> PostOrderInfo(OrderCreateViewModel model)
        {
            Result<bool> result = Result.Ok<bool>(false);
            try
            {
                 result = await _iOrderManager.CreateOrderAsync(model);
                return result;
            } 
            catch (System.Exception ex)
            {
                result = Result.Ok(true, ex.Message);
                return result;
             }
        }



        //[HttpPut("{id}")]

        //public async Task<ActionResult> PutEmployeeInfo(string id, EmployeeInfo employeeInfo)
        //{
        //    if (id != employeeInfo.EmpId)
        //        return BadRequest();

        //    _employeeBDContext.Entry(employeeInfo).State = EntityState.Modified;

        //    try
        //    {
        //        await _employeeBDContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeInfoExists(id))
        //            return NotFound();
        //        else
        //            throw;
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployeeInfo(string id)
        //{
        //    if (_employeeBDContext.EmployeeInfos == null)
        //        return NotFound();

        //    var employeeInfo = await _employeeBDContext.EmployeeInfos.FindAsync(id);

        //    if (employeeInfo == null)
        //        return NotFound();

        //    _employeeBDContext.EmployeeInfos.Remove(employeeInfo);
        //    await _employeeBDContext.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool EmployeeInfoExists(string id)
        //{
        //    return (_employeeBDContext.EmployeeInfos?.Any(e => e.EmpId == id)).GetValueOrDefault();
        //}

    }
}
