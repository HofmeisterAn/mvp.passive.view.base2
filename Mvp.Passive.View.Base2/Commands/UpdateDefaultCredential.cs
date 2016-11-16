namespace Mvp.Passive.View.Base2.Commands
{
    internal class UpdateDefaultCredential : DefaultCredentialCommand
    {
        public UpdateDefaultCredential()
        {
            this.IsCommand("update-credential", "This command updates the credential information in the user settings.");
        }

        public override int Run(string[] remainingArguments)
        {
            return 0;
        }
    }
}
