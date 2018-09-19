using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fst.di.Models;
using fst.di.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace fst.di.Controllers
{
    [Route("api/Box")]
    public class BoxController : Controller
    {
        public IBoxFactory BoxFactory { get; }

        public BoxController(IBoxFactory boxFactory)
        {
            BoxFactory = boxFactory;
        }

        // GET api/box
        [HttpGet]
        public Box Get()
        {
            return BoxFactory.CreateBox();
        }

     
    }
}
