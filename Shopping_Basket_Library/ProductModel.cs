using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public class ProductModel
    {
        /// <summary>
        /// Represents unique product number
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Represents product price
        /// </summary>
        public double Price { get; set; }
        
        /// <summary>
        /// Represents product quantity in basket
        /// </summary>
        public int Quantity  { get; set; }

        /// <summary>
        /// ProductModel constructor
        /// </summary>
        /// <param name="Id">Represents unique product number</param>
        /// <param name="Name">Represents product name</param>
        /// <param name="Price">Represents product price</param>
        /// <param name="Quantity">Represents quantity of a product</param>
        public ProductModel(int Id, string Name, double Price,int Quantity )
        {
            this.Price = Price;
            this.Name = Name;
            this.Quantity  = Quantity ;
            this.Id = Id;


        }
    }
}
