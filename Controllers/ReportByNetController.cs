using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportByNetController : Controller
    {
        private IReportByNet _reportByNet;
        public ReportByNetController(IReportByNet reportByNet)
        {
            _reportByNet = reportByNet;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ReportByNet Get(string start, string end)
        {
            start = InsertQuotes(ParseDate(start));
            end = InsertQuotes(ParseDate(end));

            ReportByNet report = new ReportByNet(
                _reportByNet.GetStoresCount(start, end),
                _reportByNet.GetOrderCount(),
                _reportByNet.GetSoldOrdersCount(),
                _reportByNet.GetTimeOutCanceledCount(),
                _reportByNet.CustomerCanceledOrdersCount(),
                _reportByNet.GetNoEndStatus(start, end),
                _reportByNet.GetCanceledOrdCount(),
                _reportByNet.GetNoReceiveStatusOrd());
            Debug.WriteLine( $" ====={report.NoEndStatusOrd} + { report.NoReceiveStatusOrd} + {report.OrdersCount} + {report.SoldOrders} + {report.TimeOutCanceled} + {report.TimeOutCanceled}=====");
            return report;
        }

        public string ParseDate(string date)
        {
            var ParseDate = DateTime.Parse(date.Remove(15));
            ParseDate = new DateTime(ParseDate.Year, ParseDate.Month, ParseDate.Day);
            var formattedDate = ParseDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);            
            return formattedDate;
        }

        public string InsertQuotes(string stringToShift)
        {
            if (stringToShift != null)
            {
                stringToShift = stringToShift.Insert(0, "'");
                stringToShift = stringToShift.Insert(stringToShift.Length, "'");
                return stringToShift;
            }
            return null;
        }

        [HttpGet]
        public void GetReportForStores(string start, string end)
        {
            start = InsertQuotes(ParseDate(start));
            end = InsertQuotes(ParseDate(end));
            var stores = _reportByNet.GetStoreNames();
            var orders = _reportByNet.GetEachStoreOrdersCount();
            var canceledOrderd = _reportByNet.GetEachStoreCancelOrdersCount();

            //var p = tupleList.GroupJoin(tupleList, orders.Where(orders => orders.NameFull == ""));

            var result = (from t in stores
                          join o in orders on t.NameFull equals o.NameFull
                          join c in canceledOrderd on t.TableRowGUID equals c.TableRowGUID
                         select new { NameFull = t.NameFull, OrdersCount = o.Count, CanceledOrders = c.Count });


            var canceledOrders = _reportByNet.GetEachStoreCancelOrdersCount();
        }


        


    }
}
