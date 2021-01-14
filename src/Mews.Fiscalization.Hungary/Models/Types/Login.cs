using FuncSharp;
using Mews.Fiscalization.Core.Model;
using System.Text.RegularExpressions;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class Login
    {
        private Login(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static ITry<Login, INonEmptyEnumerable<Error>> Create(string value)
        {
            return ValidationExtensions.ValidateString(value, 1, 15, new Regex("^[0-9A-Za-z]{15}$"), v => new Login(v));
        }
    }
}
