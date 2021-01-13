﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.DAL;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportByNetController : Controller
    {
        private IDbRepository _dbRepository;
        public ReportByNetController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
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
                _dbRepository.GetStoresCount(start, end),
                _dbRepository.GetOrderCount(start, end),
                _dbRepository.GetSoldOrdersCount(start, end),
                _dbRepository.GetTimeOutCanceledCount(start, end),
                _dbRepository.CustomerCanceledOrdersCount(start, end),
                _dbRepository.GetNoEndStatus(start, end),
                _dbRepository.GetCanceledOrdCount(start, end),
                _dbRepository.GetNoReceiveStatusOrd(start, end));
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
        public List<ReportByNet> GetReportForStores(string start, string end)
        {
            List<ReportByNet> reportByNets = new List<ReportByNet>();
            start = InsertQuotes(ParseDate(start));
            end = InsertQuotes(ParseDate(end));
            var stores = _dbRepository.GetStoreNames();
            var orders = _dbRepository.GetEachStoreOrdersCount(start, end);
            var canceledOrderd = _dbRepository.GetEachStoreCancelOrdersCount(start, end);
            var soldOrders = _dbRepository.GetEachStoreSoldOrdersCount(start, end);
            var noEndStatus = _dbRepository.GetEachStoreNoEndStatus(start, end);
            var timeoutCanceledOrders = _dbRepository.GetEachStoreTimeOutCanceledCount(start, end);
            var customerCancelesOrders = _dbRepository.CustomerGetEachStoreCanceledOrdersCount(start, end);
            var noReceiveStatusOrd = _dbRepository.GetEachStoreNoReceiveStatusOrd(start, end);


            var result = (from t in stores
                          join o in orders on t.NameFull equals o.NameFull
                          join c in canceledOrderd on t.TableRowGUID equals c.TableRowGUID
                          join s in soldOrders on t.TableRowGUID equals s.TableRowGUID
                          join n in noEndStatus on t.TableRowGUID equals n.TableRowGUID
                          join ti in timeoutCanceledOrders on t.TableRowGUID equals ti.TableRowGUID
                          join cu in customerCancelesOrders on t.TableRowGUID equals cu.TableRowGUID
                          join no in noReceiveStatusOrd on t.TableRowGUID equals no.TableRowGUID
                          select new
                          {
                              NameFull = t.NameFull,
                              OrdersCount = o.Count,
                              CanceledOrders = c.Count,
                              SoldOrders = s.Count,
                              NoEndStatus = n.Count,
                              TimeOutCanceledOrders = ti.Count,
                              CusCanceledOrd = cu.Count,
                              noRecieveOrdStatus = no.Count
                          });

            foreach (var r in result)
            {
                ReportByNet reportByNet = new ReportByNet(r.NameFull,r.OrdersCount, r.SoldOrders,
                   r.TimeOutCanceledOrders,r.CusCanceledOrd,r.NoEndStatus, r.CanceledOrders,r.noRecieveOrdStatus);
                reportByNets.Add(reportByNet);
            }
            return reportByNets;

        }      


    }
}
