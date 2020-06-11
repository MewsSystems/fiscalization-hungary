using System;

namespace Mews.Fiscalization.Hungary.Dto
{
    public class RequestMetadata
    {
        public RequestMetadata(TechnicalUser user, SoftwareIdentification identification, string additionalSignatureData = null)
        {
            var requestId = RequestId.CreateRandom();
            var timestamp = DateTime.UtcNow;

            Header = new Header
            {
                RequestId = requestId,
                TimeStamp = timestamp.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };
            User = new User
            {
                Login = user.Login,
                PasswordHash = user.PasswordHash,
                TaxNumber = user.TaxNumber,
                RequestSignature = GetRequestSignature(user, requestId, timestamp, additionalSignatureData)
            };
            Software = new Software
            {
                Id = identification.Id,
                Name = identification.Name,
                Operation = identification.Operation,
                MainVersion = identification.MainVersion,
                DeveloperName = identification.DeveloperName,
                DeveloperContact = identification.DeveloperContact,
                DeveloperCountry = identification.DeveloperCountry,
                DeveloperTaxNumber = identification.DeveloperTaxNumber
            };
        }

        public Header Header { get; }

        public User User { get; }

        public Software Software { get; }

        private string GetRequestSignature(TechnicalUser user, string requestId, DateTime timestamp, string additionalSignatureData = null)
        {
            var formattedTimestamp = timestamp.ToString("yyyyMMddHHmmss");
            var signatureData = $"{requestId}{formattedTimestamp}{user.XmlSigningKey}{additionalSignatureData}";
            return Sha512.GetSha3Hash(signatureData);
        }
    }
}