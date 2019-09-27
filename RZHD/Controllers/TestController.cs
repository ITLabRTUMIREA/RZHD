using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZHD.Controllers
{
    [Route("api/test")]
    public class TestController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Content("Hello world");
        }
    }
}
