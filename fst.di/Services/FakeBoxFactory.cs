using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fst.di.Models;

namespace fst.di.Services
{
    public class FakeBoxFactory : IBoxFactory
    {
        public Box CreateBox()
        {
            return new Box(1,1,1);
        }
    }
}
