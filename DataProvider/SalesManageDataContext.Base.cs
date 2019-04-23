using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{

    public partial class SalesManageDataContext : DbContext
    {
        public SalesManageDataContext()
            : base("SalesManageData")
        {
            Database.SetInitializer<SalesManageDataContext>(null);
        }
        public SalesManageDataContext(String ConnectionString)
            : base(ConnectionString)
        {
            Database.SetInitializer<SalesManageDataContext>(null);
        }

        public List<string> getRetailers()
        {
            return
            Database.SqlQuery<String>("select [name] from [dbo].[deliver_retailer]").ToList();
        }
    }
}