using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contacts.Model
{
    public class Contact : INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;
        private string _phone;
        private string _email;
        private string _company;
        private string _jobTitle;
        private string _street;
        private string _city;
        private string _state;
        private string _zip;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged();
                };
            }
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    OnPropertyChanged();
                };
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                if (_company != value)
                {
                    _company = value;
                    OnPropertyChanged();
                }
            }
        }

        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }
            set
            {
                if (_jobTitle != value)
                {
                    _jobTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Zip
        {
            get
            {
                return _zip;
            }
            set
            {
                if (_zip != value)
                {
                    _zip= value;
                    OnPropertyChanged();
                }
            }
        }


        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
