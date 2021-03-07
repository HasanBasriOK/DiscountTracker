using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public interface IEntity
    {

    }
    public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
    {
    }
}
