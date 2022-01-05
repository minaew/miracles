using System;
using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Resource
    {
        private readonly IDictionary<ResourceKind, int> _values =
            new Dictionary<ResourceKind, int>
        {
            { ResourceKind.Wood,  0 },
            { ResourceKind.Brick, 0 },
            { ResourceKind.Stone, 0 },
            { ResourceKind.Glass, 0 },
            { ResourceKind.Paper, 0 },
        };

        public int this[ResourceKind kind]
        {
            get { return _values[kind]; }
            set { _values[kind] = value; }
        }

        public static Resource operator +(Resource r1, Resource r2)
        {
            if (r1 is null)
            {
                throw new ArgumentNullException(nameof(r1));
            }

            if (r2 is null)
            {
                throw new ArgumentNullException(nameof(r2));
            }

            var resource = new Resource();
            foreach (var kind in Enum.GetValues<ResourceKind>())
            {
                resource[kind] = r1[kind] + r2[kind];
            }

            return resource;
        }

        public static Resource operator -(Resource r1, Resource r2)
        {
            if (r1 is null)
            {
                throw new ArgumentNullException(nameof(r1));
            }

            if (r2 is null)
            {
                throw new ArgumentNullException(nameof(r2));
            }

            var resource = new Resource();
            foreach (var kind in Enum.GetValues<ResourceKind>())
            {
                resource[kind] = r1[kind] - r2[kind];
            }

            return resource;
        }
    }

    public static class ResourceHelper
    {
        public static Resource Sum(this IEnumerable<Resource> collection)
        {
            var initial = new Resource();
            foreach (var resource in collection)
            {
                initial += resource;
            }
            return initial;
        }
    }
}
