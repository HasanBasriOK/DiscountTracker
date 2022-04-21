using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.DataAccess.MongoDB
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
