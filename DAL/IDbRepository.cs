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
    }
}
