using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model
{
    public class MyDbContext: DbContext
    {
        public MyDbContext()
            :base("name=MyDbContext")
        {

        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderGoods> OrderGoods { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
