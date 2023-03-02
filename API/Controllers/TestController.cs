using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")] //localhost.5000
    public class TestController
    {
        [HttpGet(Name = "hfrkjvhvhkfldgi")]
        public int GetNapis()
        {
            return 44;
        }
    }
}