using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5Angular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Integration : Controller
    {
        
        [HttpGet]
        public int Get()
        {
            return 123;
        }
    }
}
