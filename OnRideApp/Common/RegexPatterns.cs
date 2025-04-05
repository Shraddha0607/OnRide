namespace OnRideApp.Common
{
    public static class RegexPatterns
    {
        public const string PhoneNumberPattern = @"^\+91[789]\d{9}$|^[789]\d{9}$";
        public const string PanNumber = @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$";
    }
}
