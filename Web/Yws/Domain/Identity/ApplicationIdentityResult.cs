namespace Domain.Identity
{
    public class ApplicationIdentityResult
    {
        public ApplicationIdentityResult(IEnumerable<string> errors, bool succeeded)
        {
            Errors = errors;
            Succeeded = succeeded;
        }

        public IEnumerable<string> Errors { get; private set; }

        public bool Succeeded { get; private set; }
    }
}
