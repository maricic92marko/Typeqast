using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public interface IBasketActions
    {
        /// <summary>
        /// Method for adding products to basket
        /// </summary>
        /// <param name="Product">Product for adding to basket</param>
        /// <param name="Basket">Basket for editing</param>
        public void AddProductToBasket(ProductModel Product,  BasketModel Basket);
        
        /// <summary>
        /// Method for removing product from basket
        /// </summary>
        /// <param name="Id">Unique product number</param>
        /// <param name="Basket">Basket for editing</param>
        public void RemoveProductFromBasket(int Id,  BasketModel Basket);
        
        /// <summary>
        /// Mehtod for changing product quantity in a basket
        /// </summary>
        /// <param name="Product">Product for editing</param>
        /// <param name="Basket">Basket for editing</param>
        public void EditBasket(ProductModel Product,  BasketModel Basket);

        /// <summary>
        /// Method for confirming order
        /// </summary>
        /// <param name="Basket">Basket za kupovinu</param>
        /// <param name="PopustiKalkulator">Method for calculating discount</param>
        public void ConfirmOrder(BasketModel Basket, IDiscountCalculator PopustiKalkulator);

        /// <summary>
        /// Method for calculating basket sum
        /// </summary>
        /// <param name="Basket">Basket for calculation</param>
        public void CalculateBasketSum( BasketModel Basket);
    }
}
