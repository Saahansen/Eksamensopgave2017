using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensopgave2017
{
    public class User : IComparable<User>
    {
        public int Id { get; set; }

        private string _firstName;
        public string FirstName
        { get
          {
                return _firstName;
          }
          set
          {
                if (value == null)
                { throw new ArgumentNullException(); }
                else
                { _firstName = value; }
          }
        }

        private string _lastName;
        public string  LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == null)
                { throw new ArgumentNullException(); }
                else
                { _lastName = value; }
            }
        }

        public string FullName { get { return $"{FirstName} + {LastName}"; } }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                bool IsValid = value.All(x=> char.IsLower(x) || char.IsDigit(x) || x == '_');
                if (IsValid)
                {
                    _username = value;
                }
                
            }
        }

        private string _localPart;
        private string _domain;
        public string Email
        {
            get
            {
                return $"{_localPart}@{_domain}";
            }
            set
            {
                if (value.All(x => x == '@'))
                { throw new Exception(); }

                _localPart = value.Substring(0, value.IndexOf('@'));
                _domain = value.Substring(value.IndexOf('@') + 1, value.Last());

                bool localPartIsValid = _localPart.All(x => char.IsLetterOrDigit(x) || x == '.' || x == '_' || x == '-');
                bool domainIsValid = _domain.All(x => char.IsLetterOrDigit(x) &&
                                                     !_domain.StartsWith(".") &&
                                                     !_domain.StartsWith("-") &&
                                                     !_domain.EndsWith(".") &&
                                                     !_domain.EndsWith("-") &&
                                                     _domain.Contains("."));
                if (localPartIsValid && domainIsValid)
                {
                    _email = 
                }
            }
        }

        public decimal Balance { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            if (this.GetType() != obj.GetType())
            { return false; }
            return Equals((User)obj);
        }

        public bool Equals(User obj)
        {
            if (obj == null)
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(this.GetHashCode() != obj.GetHashCode())
            {
                return false;
            }
            if(!base.Equals(obj))
            {
                return false;
            }
            return ((Id.Equals(obj.Id)) &&
                   (FirstName.Equals(obj.FirstName)) &&
                   (LastName.Equals(obj.LastName)) &&
                   (Username.Equals(obj.Username)) &&
                   (Email.Equals(obj.Email)) &&
                   (Balance.Equals(obj.Balance)));
        }

        public override int GetHashCode()
        {
            int hashCode = Id.GetHashCode();
            hashCode ^= FirstName.GetHashCode();
            hashCode ^= LastName.GetHashCode();
            hashCode ^= Username.GetHashCode();
            hashCode ^= Email.GetHashCode();
            hashCode ^= Balance.GetHashCode();
            return hashCode;
        }

        public int CompareTo(User user)
        {
            return this.Id.CompareTo(user.Id);
        }


        public User()
        {

        }
      
        public override string ToString()
        {
            return $"First name: {FirstName} Last Name: {LastName} Email: {Email}";
        }
    }
}
