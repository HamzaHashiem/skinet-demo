using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericRepository<BasketItem> _basketItemRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IGenericRepository<BasketItem> basketItemRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(int id)
        {
            var basket = await _basketRepository.GetByIdAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {

            if (basket.Id != null)
            {
                var customerBasket = _mapper.Map<CustomerBasket>(basket);
                await _basketRepository.Update(customerBasket);
                var newBasket = await _basketRepository.GetByIdAsync(customerBasket.Id);
                return Ok(newBasket);
            }
            else
            {
                var customerBasket = _mapper.Map<CustomerBasket>(new CustomerBasket());
                _basketRepository.Add(customerBasket);
                var newBasket = await _basketRepository.GetByIdAsync(customerBasket.Id);
                return Ok(newBasket);
            }
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(int id)
        {
            var basket = await _basketRepository.GetByIdAsync(id);
            if (basket != null)
            {
                _basketRepository.DeleteAsync(basket);
            }
        }
    }
}