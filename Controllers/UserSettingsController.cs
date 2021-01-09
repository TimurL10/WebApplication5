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
    public class UserSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post( UserSettings userSettings)
        {
            if (ModelState.IsValid)
            {
                return Ok(userSettings);
            }

            return BadRequest(ModelState);

        }
    }
}
