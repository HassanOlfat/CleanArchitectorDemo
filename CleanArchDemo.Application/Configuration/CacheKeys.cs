using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Application.Configuration
{
    public static class CacheKeys
    {
        public static string Customers => "customers:all";
        public static string CustomerById(Guid id)
            => $"customers:{id}";
    }

}
