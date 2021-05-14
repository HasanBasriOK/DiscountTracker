using System;
namespace DiscountTracker.Utilities
{
    public class Constants
    {
        public Constants()
        {
        }

        public const string ClientEncryptionKey = "PssCliKeyDisTrac";
        public const string ServerEncryptionKey = "PssSrvKeyDisTrac";

        public const string ThisEmailIsUsingAlready = "This Email Address is already using!";
        public const string UserAlreadyTrackingThisProduct = "User already tracking this product";
    }
}
