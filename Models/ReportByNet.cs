using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.DAL;

namespace WebApplication5.Models
{
    
    public class ReportByNet : IReportByNet
    {
        private IDbRepository _dbRepository;
        public string StoreName { get; set; }

        public int StoresCount { get; set; }

        public int OrdersCount { get; set; }

        public int SoldOrders { get; set; }

        public int TimeOutCanceled { get; set; }

        public int CustomerCanceledOrders { get; set; }

        public int NoEndStatusOrd { get; set; }

        public int CanceledOrd { get; set; }

        public int NoReceiveStatusOrd { get; set; }

        public ReportByNet(int storesCount, int ordersCount, int soldOrders, int timeOutCanceled, int customerCanceledOrders, int noEndStatusOrd, int canceledOrd, int noReceiveStatusOrd)
        {
            StoresCount = storesCount;
            OrdersCount = ordersCount;
            SoldOrders = soldOrders;
            TimeOutCanceled = timeOutCanceled;
            CustomerCanceledOrders = customerCanceledOrders;
            NoEndStatusOrd = noEndStatusOrd;
            CanceledOrd = canceledOrd;
            NoReceiveStatusOrd = noReceiveStatusOrd;
        }

        public ReportByNet(string storeName, int storesCount, int ordersCount, int soldOrders, int timeOutCanceled, int customerCanceledOrders, int noEndStatusOrd, int canceledOrd, int noReceiveStatusOrd)
        {
            StoreName = storeName;
            StoresCount = storesCount;
            OrdersCount = ordersCount;
            SoldOrders = soldOrders;
            TimeOutCanceled = timeOutCanceled;
            CustomerCanceledOrders = customerCanceledOrders;
            NoEndStatusOrd = noEndStatusOrd;
            CanceledOrd = canceledOrd;
            NoReceiveStatusOrd = noReceiveStatusOrd;
        }

        public ReportByNet(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public int GetStoresCount(string a, string b)
        {
            return _dbRepository.GetStoresCount(a, b);
        }

        public int GetOrderCount()
        {
            return _dbRepository.GetOrderCount();
        }

        public int GetNoEndStatus(string a, string b)
        {
            return _dbRepository.GetNoEndStatus(a, b);
        }
        
        public int GetSoldOrdersCount()
        {
            return _dbRepository.GetSoldOrdersCount();
        }

        public int GetTimeOutCanceledCount()
        {
            return _dbRepository.GetTimeOutCanceledCount();
        }

        public int CustomerCanceledOrdersCount()
        {
            return _dbRepository.CustomerCanceledOrdersCount();
        }

        public int GetCanceledOrdCount()
        {
            return _dbRepository.GetCanceledOrdCount();
        }

        public int GetNoReceiveStatusOrd()
        {
            return _dbRepository.GetNoReceiveStatusOrd();
        }

        public List<MarketNames> GetStoreNames()
        {
            return _dbRepository.GetStoreNames();
        }
        public List<Tuple<int, string>> GetEachStoreOrdersCount()
        {
            return _dbRepository.GetEachStoreOrdersCount();
        }
        public List<Tuple<int, string>> GetEachStoreCancelOrdersCount()
        {
            return _dbRepository.GetEachStoreCancelOrdersCount();
        }


    }
}
