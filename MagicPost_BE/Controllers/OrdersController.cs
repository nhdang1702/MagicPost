using AutoMapper;
using MagicPost_BE.Data;
using MagicPost_BE.DTO;
using MagicPost_BE.Interfaces;
using MagicPost_BE.Models;
using MagicPost_BE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicPost_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(DataContext context, IOrderRepository orderRepository, IMapper mapper)
        {
            _context = context;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetAllOrders()
        {
            var orders = _mapper.Map<List<OrderDTO>>(_orderRepository.GetAllOrders());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orders);
        }

        //Get all orders are sending to this Office
        [HttpGet("{officeId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetAccountByOffice(int officeId)
        {
            var orders = _mapper.Map<List<OrderDTO>>(_orderRepository.GetOrderSentTo(officeId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(orders);
        }
    }
}
