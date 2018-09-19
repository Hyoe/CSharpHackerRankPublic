using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fst.di.Models
{
    public class Box
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public string env { get; set; }

        public Box()
        {
            
        }

        public Box(int height, int width, int depth)
        {
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }
    }
}
