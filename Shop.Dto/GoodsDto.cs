using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Dto
{
    public class GoodsDto
    {
        public int GoodsId { get; set; }
        public string GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public int GoodsPrice { get; set; }
        public int BuyCount { get; set; }
    }
}
