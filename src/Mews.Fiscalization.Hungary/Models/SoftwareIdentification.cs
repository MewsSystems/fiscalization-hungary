using Mews.Fiscalization.Hungary.Utils;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SoftwareIdentification
    {
        public SoftwareIdentification(string id, string name, SoftwareType type, string mainVersion, string developerName, string developerContact, string developerCountry = null, string developerTaxNumber = null)
        {
            Id = Check.NotNull(id, nameof(id));
            Name = Check.NotNull(name, nameof(name));
            Type = type;
            MainVersion = Check.NotNull(mainVersion, nameof(mainVersion));
            DeveloperName = Check.NotNull(developerName, nameof(developerName));
            DeveloperContact = Check.NotNull(developerContact, nameof(developerContact));
            DeveloperCountry = developerCountry;
            DeveloperTaxNumber = developerTaxNumber;
        }

        public string Id { get; }

        public string Name { get; }

        public SoftwareType Type { get; }

        public string MainVersion { get; }

        public string DeveloperName { get; }

        public string DeveloperContact { get; }

        public string DeveloperCountry { get; }

        public string DeveloperTaxNumber { get; }
    }
}