﻿namespace Mews.Fiscalization.Hungary.Models
{
   public sealed class SigningKey : ValidatedString
    {
        private static readonly string regexValidation = "^[0-9A-Za-z]{2}[-]{1}[0-9A-Za-z]{4}[-]{1}[0-9A-Za-z]{24}$";

        public SigningKey(string value)
            : base(value, 32, 32, regexValidation)
        {
        }

        public static bool IsValid(string value)
        {
            return IsValid(value, 32, 32, regexValidation);
        }
    }
}
