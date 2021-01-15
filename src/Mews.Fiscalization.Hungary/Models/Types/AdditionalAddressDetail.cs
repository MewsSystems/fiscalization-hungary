﻿using FuncSharp;
using Mews.Fiscalization.Core.Model;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class AdditionalAddressDetail
    {
        private AdditionalAddressDetail(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<AdditionalAddressDetail, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 255, ".*[^\\s].*").Map(v => new AdditionalAddressDetail(v));
        }
    }
}
