﻿namespace OnRideApp.Common;

public static class RegexPatterns
{
    public const string PhoneNumberPattern = @"^\+91[789]\d{9}$|^[789]\d{9}$";
    public const string PanNumber = @"^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$";
    public const string AlphaOnly = @"^[A-Za-z]+$";

    public const string NumberOnly = @"^\d+$";

    public const string Alphanumeric = @"^[A-Za-z0-9]+$";

    public const string AlphanumericWithSpecialChar = @"^[A-Za-z0-9\W_]+$";
    public const string AlphanumericWithSpace = @"^[A-Za-z0-9 ]+$";
    public const string AlphanumericWithSpecialCharAndSpace = @"^[A-Za-z0-9\W_ ]+$";
}