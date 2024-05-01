using System.Globalization;

namespace Domain.Identity
{
    public class ApplicationAuthenticationDescription
    {
        private const string CaptionPropertyKey = "Caption";
        private const string AuthenticationTypePropertyKey = "AuthenticationType";

        public ApplicationAuthenticationDescription()
        {
            Properties = new Dictionary<string, object>(StringComparer.Ordinal);
        }

        public ApplicationAuthenticationDescription(IDictionary<string, object> properties)
        {
            Properties = properties ?? throw new ArgumentNullException("properties");
        }

        public IDictionary<string, object> Properties { get; private set; }

        public string? AuthenticationType
        {
            get => GetString(AuthenticationTypePropertyKey);
            set => Properties[AuthenticationTypePropertyKey] = value;
        }

        public string? Caption
        {
            get => GetString(CaptionPropertyKey);
            set => Properties[CaptionPropertyKey] = value;
        }

        private string? GetString(string name)
        {
            return Properties.TryGetValue(name, out var value)
                ? Convert.ToString(value, CultureInfo.InvariantCulture)
                : null;
        }
    }
}
