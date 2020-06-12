namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class SoftwareIdentification
    {
        public SoftwareIdentification(string id, string name, SoftwareType type, string mainVersion, string developerName, string developerContact, string developerCountry = null, string developerTaxNumber = null)
        {
            Id = id;
            Name = name;
            Type = type;
            MainVersion = mainVersion;
            DeveloperName = developerName;
            DeveloperContact = developerContact;
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