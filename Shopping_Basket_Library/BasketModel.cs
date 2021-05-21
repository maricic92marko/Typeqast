using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public class BasketModel
    {
        /// <summary>
        /// Represents all products that are in a basket
        /// </summary>
        public HashSet<ProductModel> ProductList { get; set; }
        /// <summary>
        /// Represents price of a basket
        /// </summary>
        public double BasketPrice { get; set; }

        /// <summary>
        /// Represents sum of products quantities in a basket
        /// </summary>
        public double BasketQuantity { get; set; }

        /// <summary>
        /// Represents sum of all bread discounts in a basket
        /// </summary>
        public double BreadDiscountSumPrice { get; set; }

        /// <summary>
        /// Represents sum fo all bread products that are on discount in a basket
        /// </summary>
        public double BreadDiscountSumQuantity { get; set; }

        /// <summary>
        /// Represents sum of all milk discounts in a basket
        /// </summary>
        public double MilkDiscountSumPrice { get; set; }
        
        /// <summary>
        /// Represents sum fo all milk products that are on discount in a basket
        /// </summary>
        public double MilkDiscountSumQuantity { get; set; }

        public BasketModel()
        {
            this.ProductList = new HashSet<ProductModel>();
        }
    }
}
