using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace Tests
{
    public class StocksServiceTest
    {
        private readonly IStocksService _stocksService;

        public StocksServiceTest()
        {
            _stocksService = new StocksService();
        }

        #region CreateBuyOrder

        [Fact]
        public void CreateBuyOrder_NullBuyOrder_ToBeArgumentNullException()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = null;

            //Act
            Assert.Throws<ArgumentNullException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }



        [Theory] //Use [Theory] instead of [Fact]; so that, you can pass parameters to the test method
        [InlineData(0)] //passing parameters to the test method
        public void CreateBuyOrder_QuantityIsLessThanMinimum_ToBeArgumentException(uint buyOrderQuantity)
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = buyOrderQuantity };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Theory] //Use [Theory] instead of [Fact]; so that, you can pass parameters to the test method
        [InlineData(100001)] //passing parameters to the test method
        public void CreateBuyOrder_QuantityIsGreaterThanMaximum_ToBeArgumentException(uint buyOrderQuantity)
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = 1, Quantity = buyOrderQuantity };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Theory] //Use [Theory] instead of [Fact]; so that, you can pass parameters to the test method
        [InlineData(0)] //passing parameters to the test method
        public void CreateBuyOrder_PriceIsLessThanMinimum_ToBeArgumentException(uint buyOrderPrice)
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = buyOrderPrice, Quantity = 1 };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Theory] //Use [Theory] instead of [Fact]; so that, you can pass parameters to the test method
        [InlineData(10001)] //passing parameters to the test method
        public void CreateBuyOrder_PriceIsGreaterThanMaximum_ToBeArgumentException(uint buyOrderPrice)
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", Price = buyOrderPrice, Quantity = 1 };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Fact]
        public void CreateBuyOrder_StockSymbolIsNull_ToBeArgumentException()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = null, Price = 1, Quantity = 1 };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Fact]
        public void CreateBuyOrder_DateOfOrderIsLessThanYear2000_ToBeArgumentException()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), Price = 1, Quantity = 1 };

            //Act
            Assert.Throws<ArgumentException>(() =>
            {
                _stocksService.CreateBuyOrder(buyOrderRequest);
            });
        }


        [Fact]
        public void CreateBuyOrder_ValidData_ToBeSuccessful()
        {
            //Arrange
            BuyOrderRequest? buyOrderRequest = new BuyOrderRequest() { StockSymbol = "MSFT", StockName = "Microsoft", DateAndTimeOfOrder = Convert.ToDateTime("2024-12-31"), Price = 1, Quantity = 1 };

            //Act
            BuyOrderResponse buyOrderResponseFromCreate = _stocksService.CreateBuyOrder(buyOrderRequest);

            //Assert
            Assert.NotEqual(Guid.Empty, buyOrderResponseFromCreate.BuyOrderID);
        }


        #endregion

    }
}