namespace Mvp.Passive.View.Base2.Commands
{
    internal class RemoveDefaultCredential : DefaultCredentialCommand
    {
        public RemoveDefaultCredential()
        {
            this.IsCommand("remove-credential", "This command removes the credential information in the user settings.");
        }

        public override int Run(string[] remainingArguments)
        {
            return 0;
        }
    }
}
