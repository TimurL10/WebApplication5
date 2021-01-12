using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public interface IReportByNet
    {
        public int GetStoresCount(string a, string b);
        public int GetNoEndStatus(string a, string b);
        public int GetOrderCount();
        public int GetSoldOrdersCount();
        public int GetTimeOutCanceledCount();
        public int CustomerCanceledOrdersCount();
        public int GetCanceledOrdCount();
        public int GetNoReceiveStatusOrd();
        public List<MarketNames> GetStoreNames();
        public List<MarketNames> GetEachStoreOrdersCount();
        public List<MarketNames> GetEachStoreCancelOrdersCount();
    }
}
