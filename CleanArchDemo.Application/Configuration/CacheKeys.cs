using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchDemo.Application.Configuration
{
    public static class CacheKeys
    {
        public const string Products = "products:all";
        public const string Orders = "orders:all";
        
        public static string Customers => "customers:all";
        public static string CustomerById(Guid id)
            => $"customers:{id}";
    }

}
