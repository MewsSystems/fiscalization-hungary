using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TechnicalUser
    {
        public TechnicalUser(string login, string password, string xmlSigningKey, string taxNumber, string encryptionKey)
        {
            Login = Check.NotNull(login, nameof(login));
            PasswordHash = Sha512.GetHash(Check.NotNull(password, nameof(password)));
            XmlSigningKey = Check.NotNull(xmlSigningKey, nameof(xmlSigningKey));
            TaxNumber = Check.NotNull(taxNumber, nameof(taxNumber));
            EncryptionKey = Check.NotNull(encryptionKey, nameof(encryptionKey));
        }

        public string Login { get; }

        public string PasswordHash { get; }

        public string XmlSigningKey { get; }

        public string TaxNumber { get; }

        public string EncryptionKey { get; }
    }
}