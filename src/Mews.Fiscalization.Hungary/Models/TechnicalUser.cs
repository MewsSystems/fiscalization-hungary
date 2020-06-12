namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class TechnicalUser
    {
        public TechnicalUser(string login, string password, string xmlSigningKey, string taxNumber, string encryptionKey)
        {
            Login = login;
            PasswordHash = Sha512.GetHash(password);
            XmlSigningKey = xmlSigningKey;
            TaxNumber = taxNumber;
            EncryptionKey = encryptionKey;
        }

        public string Login { get; }

        public string PasswordHash { get; }

        public string XmlSigningKey { get; }

        public string TaxNumber { get; }

        public string EncryptionKey { get; }
    }
}