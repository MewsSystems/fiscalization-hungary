using Mews.Fiscalization.Hungary.Models;
using System;

namespace Mews.Fiscalization.Hungary.Tests
{
    public static class TestFixture
    {
        private static readonly Login Login = new Login(Environment.GetEnvironmentVariable("login") ?? "INSERT_LOGIN");
        private static readonly string Password = Environment.GetEnvironmentVariable("password") ?? "INSERT_PASSWORD";
        private static readonly SigningKey SigningKey = new SigningKey(Environment.GetEnvironmentVariable("signing_key") ?? "INSERT_SIGNING_KEY");
        private static readonly TaxPayerId TaxPayerId = new TaxPayerId(Environment.GetEnvironmentVariable("tax_payer_id") ?? "INSERT_TAX_PAYER_ID");
        private static readonly EncryptionKey EncryptionKey = new EncryptionKey(Environment.GetEnvironmentVariable("encryption_key") ?? "INSERT_ENCRYPTION_KEY");

        public static NavClient GetNavClient()
        {
            var technicalUser = new TechnicalUser(
                login: Login,
                password: Password,
                signingKey: SigningKey,
                taxId: TaxPayerId,
                encryptionKey: EncryptionKey
            );
            var softwareIdentification = new SoftwareIdentification(
                id: "123456789123456789",
                name: "Test",
                type: SoftwareType.LocalSoftware,
                mainVersion: "1.0",
                developerName: "Test",
                developerContact: "test@test.com"
            );
            return new NavClient(technicalUser, softwareIdentification, NavEnvironment.Test);
        }
    }
}
