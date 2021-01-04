using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public interface IReportByNet
    {
        public int GetStoresCount();
        public int GetNoEndStatus();
        public int GetOrderCount();
        public int GetSoldOrdersCount();
        public int GetTimeOutCanceledCount();
        public int CustomerCanceledOrdersCount();
        public int GetCanceledOrdCount();
        public int GetNoReceiveStatusOrd();
    }
}
