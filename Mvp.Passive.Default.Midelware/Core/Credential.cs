using Mvp.Passive.Default.Midelware.Extension;

namespace Mvp.Passive.Default.Midelware.Core
{
    public class Credential
    {
        public long Id { get; set; }

        public string Hostname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual bool IsEncrypted
        {
            get { return this.PasswordInsecure.Length > 0; }
        }

        public virtual string PasswordInsecure
        {
            get { return this.Password.ToDecryptString(); }
        }

        protected bool Equals(Credential obj)
        {
            return Id == obj.Id && string.Equals(Hostname, obj.Hostname) && string.Equals(Username, obj.Username) && string.Equals(Password, obj.Password);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == this.GetType() && Equals((Credential)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Hostname != null ? Hostname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                return hashCode.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Hostname: {0} Username: {1} Password: {2}", this.Hostname, this.Username, this.PasswordInsecure);
        }
    }
}
