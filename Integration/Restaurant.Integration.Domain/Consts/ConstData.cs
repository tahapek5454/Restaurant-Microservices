using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Integration.Domain.Consts
{
    public static class ConstData
    {
        public const string CouponAPIBase = "https://localhost:7011/api";
        public const string AuthAPIBase = "https://localhost:7160/api";
        public const string ProductAPIBase = "https://localhost:7259/api";
        public const string ShoppingCartApıBase = "https://localhost:7298/api";

        public const string TokenCookie = "JWTToken";

    }
}
