using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class MarketNames
    {
        public MarketNames(string tableRowGUID, string namefull)
        {
            this.TableRowGUID = tableRowGUID;
            this.NameFull = namefull;
        }
        public string TableRowGUID { get; set; }
        public string NameFull { get; set; }
    }
}
