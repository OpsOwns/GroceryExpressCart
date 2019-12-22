namespace GroceryExpressCart.Common.Extension
{
    public static class RegexPatterns
    {
        public static string NAME_REGEX = "[a-zA-Z]+";
        public static string LOGIN_REGEX = "^[a-z0-9_-]{3,16}$";
        public static string PASSWORD_REGEX = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,32}$";
    }
}
