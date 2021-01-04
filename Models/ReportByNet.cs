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
        public int StoresCount { get; set; }

        public int OrdersCount { get; set; }

        public int SoldOrders { get; set; }

        public int TimeOutCanceled { get; set; }

        public int CustomerCanceledOrders { get; set; }

        public int NoEndStatusOrd { get; set; }

        public int CanceledOrd { get; set; }

        public int NoReceiveStatusOrd { get; set; }

        public ReportByNet(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public int GetReoptData()
        {
            return _dbRepository.GetStoresCount();
        }

    }
}
