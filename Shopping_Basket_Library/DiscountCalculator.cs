using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Basket_Library
{
    public class DiscountCalculator : IDiscountCalculator
    {

        public void CalculateDiscount(BasketModel Basket)
        {

            ProductModel MilkProduct = Basket.ProductList.Where(x => x.Id == 1).FirstOrDefault();
            ProductModel BreadProduct = Basket.ProductList.Where(x => x.Id == 2).FirstOrDefault();
            ProductModel ButterProduct = Basket.ProductList.Where(x => x.Id == 3).FirstOrDefault();

            int ButterQuantity = ButterProduct == null ?   0 : ButterProduct.Quantity;
            int MilkQuantity = MilkProduct == null ?   0 :  MilkProduct.Quantity;
            int BreadQuantity = BreadProduct == null ?   0 : BreadProduct.Quantity;

            int MilkDisQ = 0;
            int ButterDisQ = 0;            
            double MilkDisP = 0;
            double ButterDisP = 0;
            if (MilkQuantity > 3)
            {
                int MilkDisCunt = MilkQuantity % 4;
                if (MilkDisCunt > 0)
                {
                    MilkDisQ = (MilkQuantity - MilkDisCunt) / 4;

                }
                else
                {
                    MilkDisQ = MilkQuantity / 4;
                }
            }

            

            if (MilkDisQ > 0)
            {

                MilkDisP = Math.Round((1.15 * MilkDisQ), 2);
                Basket.BasketPrice = Math.Round(Basket.BasketPrice - MilkDisP, 2);
            }

            if (ButterQuantity > 1)
            {
                int ButterDisCunt = ButterQuantity % 2;

                if (ButterDisCunt == 0)
                {
                    ButterDisQ = ButterQuantity  / 2;
                }
                else
                {
                    ButterDisQ = (ButterQuantity - ButterDisCunt) / 2;
                }
            }

            if (ButterDisQ > 0)
            {
                if (BreadQuantity < ButterDisQ)
                {
                    ButterDisQ = BreadQuantity;
                }
                ButterDisP = Math.Round((0.5 * ButterDisQ), 2);
                Basket.BasketPrice = Math.Round(Basket.BasketPrice - ButterDisP, 2);
            }


            Basket.BreadDiscountSumQuantity = ButterDisQ;
            Basket.BreadDiscountSumPrice = ButterDisP;
            Basket.MilkDiscountSumQuantity = MilkDisQ;
            Basket.MilkDiscountSumPrice = MilkDisP;

        }
    }
}
