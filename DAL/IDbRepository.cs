using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.DAL
{
    public interface IDbRepository
    {
        public int GetNoEndStatus();
        public int GetStoresCount();
        public int GetOrderCount();
        public int GetSoldOrdersCount();
        public int GetTimeOutCanceledCount();
        public int CustomerCanceledOrdersCount();
        public int GetCanceledOrdCount();
        public int GetNoReceiveStatusOrd();


    }
}
