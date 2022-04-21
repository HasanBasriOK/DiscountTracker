using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountTracker.Common.Constants
{
    public class EncryptionConstants
    {
        public const string ClientEncryptionKey = "PssCliKeyDisTrac";
        public const string ServerEncryptionKey = "PssSrvKeyDisTrac";
        public const string InitializeVectorStr = "TracDiscountTrac";
    }
}
