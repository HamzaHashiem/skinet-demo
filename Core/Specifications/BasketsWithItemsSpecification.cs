using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class BasketsWithItemsSpecification : BaseSpecification<CustomerBasket>
    {
        public BasketsWithItemsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items);
        }
    }
}