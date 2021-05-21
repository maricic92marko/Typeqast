using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public interface IDiscountCalculator
    {
        /// <summary>
        /// Method for calculating discounts
        /// </summary>
        /// <param name="Basket">Basket for calculating discounts</param>
        public void CalculateDiscount(BasketModel Basket);
    }
}
