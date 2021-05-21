using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping_Basket_Library;
using Xunit;

namespace Shopping_Basket_Library_Tests
{
    public class Shopping_Basket_Tests
    {
        [Theory]
        [InlineData(1, 2, 3,6,5.55)]
        [InlineData(3, 3, 3,9,8.85)]
        public void AddProductToBasket_Test(int MilkQuantity,int BreadQuantity,int ButterQuantity,
            int BasketSumQuantity, double BasketSumPrice)
        {
            ProductModel Milk = new ProductModel(1, "Milk",1.15, MilkQuantity);
            ProductModel Bread = new ProductModel(2, "Bread",1, BreadQuantity);
            ProductModel Butter = new ProductModel(3, "Butter",0.8, ButterQuantity);
            BasketActions BActions = new BasketActions();
            BasketModel Basket = new BasketModel();
            BActions.AddProductToBasket(Milk, Basket);
            BActions.AddProductToBasket(Bread, Basket);
            BActions.AddProductToBasket(Butter, Basket);
            Assert.Equal(BasketSumQuantity, Basket.BasketQuantity);
            Assert.Equal(BasketSumPrice, Basket.BasketPrice);
            
        }
        [Theory]
        [InlineData(1, 1, 1,  2.95)]
        [InlineData(11, 2, 2,  13.45)]
        [InlineData(4, 0, 0,  3.45)]
        [InlineData(8, 1, 2,  9)]
        [InlineData(100, 1, 2,  88.35)]
        [InlineData(100, 1, 4,  89.95)]
        [InlineData(100, 2, 4,  90.45)]
        [InlineData(0, 0, 4,  3.2)]
        public void CalculateDiscount_Test(int MilkQuantity, int BreadQuantity, int ButterQuantity,
            double BasketSumPrice)
        {
            ProductModel Milk = new ProductModel(1, "Milk", 1.15, MilkQuantity);
            ProductModel Bread = new ProductModel(2, "Bread", 1, BreadQuantity);
            ProductModel Butter = new ProductModel(3, "Butter", 0.8, ButterQuantity);
            BasketActions BActions = new BasketActions();
            BasketModel Basket = new BasketModel();
            BActions.AddProductToBasket(Milk, Basket);
            BActions.AddProductToBasket(Bread, Basket);
            BActions.AddProductToBasket(Butter, Basket);
           
            DiscountCalculator DisCalc = new DiscountCalculator();
            BActions.ConfirmOrder(Basket, DisCalc);
            Assert.Equal(BasketSumPrice, Basket.BasketPrice);

        }


        [Theory]
        [InlineData(1, 1, 2, 8, 9)]
        [InlineData(0, 2, 2, 4, 6.55)]
        [InlineData(4, 0, 0, 16, 13.8)]
        [InlineData(8, 1, 2, 4, 5.55)]

        public void EditBasket_Test(int MilkQuantity, int BreadQuantity, int ButterQuantity,
            int NewQuantity, double BasketSumPrice)
        {
            ProductModel Milk = new ProductModel(1, "Milk", 1.15, MilkQuantity);
            ProductModel Bread = new ProductModel(2, "Bread", 1, BreadQuantity);
            ProductModel Butter = new ProductModel(3, "Butter", 0.8, ButterQuantity);
            BasketActions BActions = new BasketActions();
            BasketModel Basket = new BasketModel();
            BActions.AddProductToBasket(Milk, Basket);
            BActions.AddProductToBasket(Bread, Basket);
            BActions.AddProductToBasket(Butter, Basket);
            Milk.Quantity = NewQuantity;
            BActions.EditBasket(Milk, Basket);
            DiscountCalculator DisCalc = new DiscountCalculator();
            BActions.ConfirmOrder(Basket, DisCalc);
            Assert.Equal(BasketSumPrice, Basket.BasketPrice);
        }

        [Theory]
        [InlineData(1, 1, 1, 1, 1.8)]
        [InlineData(0, 2, 2, 2, 1.6)]
        [InlineData(4, 0, 0, 1, 0)]
        [InlineData(5, 1, 2, 3, 5.6)]
        [InlineData(7, 1, 2, 2, 8.5)]
        public void RemoveProductFromBasket_Test(int MilkQuantity, int BreadQuantity, int ButterQuantity,
        int RemoveID, double BasketSumPrice)
        {
            ProductModel Milk = new ProductModel(1, "Milk", 1.15, MilkQuantity);
            ProductModel Bread = new ProductModel(2, "Bread", 1, BreadQuantity);
            ProductModel Butter = new ProductModel(3, "Butter", 0.8, ButterQuantity);
            BasketActions BActions = new BasketActions();
            BasketModel Basket = new BasketModel();
            BActions.AddProductToBasket(Milk, Basket);
            BActions.AddProductToBasket(Bread, Basket);
            BActions.AddProductToBasket(Butter, Basket);
            BActions.RemoveProductFromBasket(RemoveID, Basket);
            DiscountCalculator DisCalc = new DiscountCalculator();
            BActions.ConfirmOrder(Basket, DisCalc);
            Assert.Equal(BasketSumPrice, Basket.BasketPrice);
        }





    }
}
