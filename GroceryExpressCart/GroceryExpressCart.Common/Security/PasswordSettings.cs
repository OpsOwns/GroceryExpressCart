﻿namespace GroceryExpressCart.Common.Security
{
    public class PasswordSettings
    {
        public string SecretKey { get; set; }
        public bool GenerateSalt { get; set; }
    }
}
