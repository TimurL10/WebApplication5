using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public ReportByNet Get()
        {
            ReportByNet report = new ReportByNet(
                _reportByNet.GetStoresCount(),
                _reportByNet.GetOrderCount(),
                _reportByNet.GetSoldOrdersCount(),
                _reportByNet.GetTimeOutCanceledCount(),
                _reportByNet.CustomerCanceledOrdersCount(),
                _reportByNet.GetNoEndStatus(),
                _reportByNet.GetCanceledOrdCount(),
                _reportByNet.GetNoReceiveStatusOrd());
            return report;
        }

    }
}
