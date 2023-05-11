using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;


namespace Repositories
{
    public class StocksRepository : IStocksRepository
    {
        //private field
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Constructor of StocksRepository class that executes when a new object is created for the class
        /// </summary>
        public StocksRepository(ApplicationDbContext stockMarketDbContext)
        {
            _dbContext = stockMarketDbContext;
        }

        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            //add buy order object to buy orders list
            _dbContext.BuyOrders.Add(buyOrder);
            await _dbContext.SaveChangesAsync();

            return buyOrder;
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {
            //add sell order object to sell orders list
            _dbContext.SellOrders.Add(sellOrder);
            await _dbContext.SaveChangesAsync();

            return sellOrder;
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            //get BuyOrder objects
            List<BuyOrder> buyOrders = await _dbContext.BuyOrders
             .OrderByDescending(temp => temp.DateAndTimeOfOrder)
             .ToListAsync();

            return buyOrders;
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {
            //get SellOrder objects
            List<SellOrder> sellOrders = await _dbContext.SellOrders
             .OrderByDescending(temp => temp.DateAndTimeOfOrder)
             .ToListAsync();

            return sellOrders;
        }
    }
}

