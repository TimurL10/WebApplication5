using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.DAL
{
    public interface IDbRepository
    {
        public int GetNoEndStatus(string a, string b);
        public int GetStoresCount(string a, string b);
        public int GetOrderCount();
        public int GetSoldOrdersCount();
        public int GetTimeOutCanceledCount();
        public int CustomerCanceledOrdersCount();
        public int GetCanceledOrdCount();
        public int GetNoReceiveStatusOrd();
        public void PostNetSettings(UserSettings userSettings);
        public List<MarketNames> GetStoreNames();
        public List<MarketNames> GetEachStoreOrdersCount();
        public List<MarketNames> GetEachStoreCancelOrdersCount();



    }
}
