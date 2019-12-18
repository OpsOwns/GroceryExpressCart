using System;

namespace GroceryExpressCart.Infrastructure.DTO
{
    public class JwtDTO
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
