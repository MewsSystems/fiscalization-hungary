using Mews.Fiscalization.Hungary.Models.Types;
using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TechnicalUser
    {
        public TechnicalUser(Login login, string password, SigningKey signingKey, TaxPayerId taxId, string encryptionKey)
        {
            Login = Check.NotNull(login, nameof(login));
            PasswordHash = Sha512.GetHash(Check.NotNull(password, nameof(password)));
            SigningKey = Check.NotNull(signingKey, nameof(signingKey));
            TaxId = Check.NotNull(taxId, nameof(taxId));
            EncryptionKey = Check.NotNull(encryptionKey, nameof(encryptionKey));
        }

        public Login Login { get; }

        public string PasswordHash { get; }

        public SigningKey SigningKey { get; }

        public TaxPayerId TaxId { get; }

        public string EncryptionKey { get; }
    }
}