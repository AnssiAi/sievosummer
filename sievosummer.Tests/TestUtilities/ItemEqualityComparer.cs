using sievosummer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sievosummer.Tests.TestUtilities
{
    internal class ItemEqualityComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item? x, Item? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;

            return x.ItemId == y.ItemId && x.Name == y.Name && x.Value == y.Value;
        }

        public int GetHashCode([DisallowNull] Item obj)
        {
            return obj.ItemId.GetHashCode();
        }
    }
}
