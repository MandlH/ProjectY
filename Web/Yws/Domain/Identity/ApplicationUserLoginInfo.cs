namespace Domain.Identity
{
    public class ApplicationUserLoginInfo
    {
        public ApplicationUserLoginInfo(string loginProvider, string providerKey)
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
