using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.DataAccess.MongoDB
{
    public class MongoDbSettings
    {
        public string ConnectionString;
        public string Database;

        //Configuration için kullanılacak
        #region Const Values

        public const string ConnectionStringValue = "mongodb://localhost:27017";
        public const string DatabaseValue = "DiscountTracker";

        #endregion
    }
}
