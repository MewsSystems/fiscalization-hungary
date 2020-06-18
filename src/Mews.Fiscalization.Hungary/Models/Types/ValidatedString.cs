﻿using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public abstract class ValidatedString
    {
        public ValidatedString(string value, int? minLength = null, int? maxLength = null, string regexValidation = null, bool isNullable = false)
        {
            Value = value;

            if (!isNullable)
            {
                Check.NotNull(value, nameof(value));
            }

            if (value != null)
            {
                Check.InRange(value, minLength, maxLength);

                if (regexValidation != null)
                {
                    Check.Regex(value, regexValidation);
                }
            }
        }

        public string Value { get; }

        protected static bool IsValid(string value, int? minLength = null, int? maxLength = null, string regexValidation = null, bool isNullable = false)
        {
            if (value == null)
            {
                return isNullable;
            }

            var matchesRegex = regexValidation == null || value.MatchesRegex(regexValidation);
            return value.LengthIsInRange(minLength, maxLength) && matchesRegex;
        }
    }
}
