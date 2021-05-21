using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public class BasketActions : IBasketActions
    {
        public void AddProductToBasket(ProductModel Product,  BasketModel Basket)
        {
            try
            {
                Basket.ProductList.Add(Product);
                CalculateBasketSum( Basket);
            }
            catch (Exception)
            {
                throw new Exception("Dodavanje Producta nije uspelo.");
            }
        }

        public void EditBasket(ProductModel Product,  BasketModel Basket)
        {
            try
            {
                Basket.ProductList.Where(x => x.Id == Product.Id).FirstOrDefault().Quantity = Product.Quantity;
                CalculateBasketSum( Basket);
            }
            catch (Exception)
            {
                throw new Exception("Izmena Producta nije uspela.");
            }
        }

        public void RemoveProductFromBasket(int Id,  BasketModel Basket)
        {
            try
            {
                Basket.ProductList = Basket.ProductList.Where(x => x.Id != Id).ToHashSet();
                CalculateBasketSum( Basket);
            }
            catch (Exception)
            {
                throw new Exception("Brisanje Producta nije uspelo.");
            }
        }

        public void ConfirmOrder(BasketModel Basket, IDiscountCalculator PopustiKalkulator)
        {
            try
            { 
                PopustiKalkulator.CalculateDiscount(Basket);

                BasketLog(Basket);
 

            }
            catch (Exception e)
            {
                throw new Exception("Potvrda korpe nije uspla.");
            }
        }

        public void CalculateBasketSum( BasketModel Basket)
        {
            Basket.BasketPrice = Math.Round( Basket.ProductList.Sum(x => x.Price * x.Quantity), 2);
            Basket.BasketQuantity = Basket.ProductList.Sum(x => x.Quantity);
        }


        public void BasketLog(BasketModel Basket)
        {
            string PrathStr = @"..\..\..\..\TestResults\BasketLogFile.txt";
            if (File.Exists(PrathStr))
            {
                using (StreamWriter sw = File.AppendText(PrathStr))
                {
                    sw.WriteLine("-------**********-------");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine("Bread quantity on discount: "+Basket.BreadDiscountSumQuantity.ToString());
                    sw.WriteLine("Bread sum price on discount: "+Basket.BreadDiscountSumPrice.ToString());
                    sw.WriteLine("Milk quantity on discount: "+Basket.MilkDiscountSumQuantity.ToString());
                    sw.WriteLine("Milk sum price on discount: " + Basket.MilkDiscountSumPrice.ToString());
                    sw.WriteLine("Basket on sum quantity: " + Basket.BasketQuantity.ToString());
                    sw.WriteLine("Basket sum price: " + Basket.BasketPrice.ToString());
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(PrathStr))
                {
                    sw.WriteLine("-------**********-------");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine("Bread quantity on discount: " + Basket.BreadDiscountSumQuantity.ToString());
                    sw.WriteLine("Bread sum price on discount: " + Basket.BreadDiscountSumPrice.ToString());
                    sw.WriteLine("Milk quantity on discount: " + Basket.MilkDiscountSumQuantity.ToString());
                    sw.WriteLine("Milk sum price on discount: " + Basket.MilkDiscountSumPrice.ToString());
                    sw.WriteLine("Basket on discount: " + Basket.BasketQuantity.ToString());
                    sw.WriteLine("Basket sum price on discount: " + Basket.BasketPrice.ToString());
                }
            }
        }
    }
}
