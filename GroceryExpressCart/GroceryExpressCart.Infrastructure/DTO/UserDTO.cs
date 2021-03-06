﻿namespace GroceryExpressCart.Infrastructure.DTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
    public class LoginUserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserFoundDTO
    {
        public int MemberShipId { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public JwtDTO JwtDTO { get; set; }
    }
}
