using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public static class ResourceHelper
    {
        public static IEnumerable<ResourceKind> Except(this IEnumerable<ResourceKind> collection1,
                                                       IEnumerable<ResourceKind> collection2)
        {
            if (collection1 == null)
            {
                throw new ArgumentNullException(nameof(collection1));
            }

            var list2 = collection2.ToList();

            foreach (var item in collection1)
            {
                if (list2.Contains(item))
                {
                    list2.Remove(item);
                }
                else
                {
                    yield return item;
                }

            }
        }
    }
}
