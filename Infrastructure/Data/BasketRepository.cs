using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BasketRepository : GenericRepository<CustomerBasket>, IBasketRepository
    {
        private readonly StoreContext _context;

        public BasketRepository(StoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task Update(CustomerBasket basket)
        {
            CustomerBasket basketInDB = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == basket.Id);
            if (basketInDB != null)
            {
                basketInDB.Items = basket.Items;
                basketInDB.DeliveryMethodId = basket.DeliveryMethodId;
                basketInDB.ClientSecret = basket.ClientSecret;
                basketInDB.PaymentIntentId = basket.PaymentIntentId;
                basketInDB.ShippingPrice = basket.ShippingPrice;
            }
        }
    }
}