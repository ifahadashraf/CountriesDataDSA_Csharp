using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class MyNode
    {
        public String countryName { get; set; }
        public double gdpGrowth { get; set; }
        public double inflation { get; set; }
        public double tradeBalance { get; set; }
        public int ranking { get; set; }
        public List<String> tradePartners { get; set; }
        public MyNode left { get; set; }
        public MyNode right { get; set; }
        public int nodeHeight { get; set; }

        public MyNode()
        {
            this.tradePartners = new List<string>();
            this.nodeHeight = 1;
        }
    }
}
