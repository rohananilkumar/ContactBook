using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contacts.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContact : ContentPage
    {
        private Contact _contact;

        public EditContact(Contact contact)
        {

            InitializeComponent();

            if (contact == null)
            {
                _contact = new Contact();
                DeleteContact.IsEnabled = false;
            }
             
            else
            {
                _contact = contact;
                DeleteContact.IsEnabled = true;
                Title = "Edit Contact";

            }


        }

        protected override void OnAppearing()
        {
            if (_contact != null)
            {
                FirstName.Entry = _contact.FirstName;
                LastName.Entry = _contact.LastName;
                Phone.Entry = _contact.Phone;
                Email.Entry = _contact.Email;
                Company.Entry = _contact.Company;
                JobTitle.Entry = _contact.JobTitle;
                Street.Entry = _contact.Street;
                City.Entry = _contact.City;
                State.Entry = _contact.State;
                Zip.Entry = _contact.Zip;

            }
            //base.OnAppearing();
        }

        private async void SaveContact_Clicked(object sender, EventArgs e)
        {

            if(String.IsNullOrWhiteSpace(FirstName.Entry) || String.IsNullOrWhiteSpace(Phone.Entry))
            {
                await DisplayAlert("Error", "First Name and Phone number cannot be empty","OK");
                return;
            }

            _contact.FirstName = FirstName.Entry;
            _contact.LastName = LastName.Entry;
            _contact.Phone = Phone.Entry;
            _contact.Email = Email.Entry;

            _contact.Company = Company.Entry;
            _contact.JobTitle = JobTitle.Entry;
            _contact.Street = Street.Entry;
            _contact.City = City.Entry;
            _contact.State = State.Entry;
            _contact.Zip = Zip.Entry;

            if (_contact.Id == 0)
                ContactService.InsertContact(_contact);
            else
                ContactService.UpdateContact(_contact);

            await Navigation.PopAsync();
        }

        private async void DeleteContact_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Delete","This contact is going to be deleted. Are you sure?", "OK", "Cancel")){
                await ContactService.DeleteContact(_contact);
                await Navigation.PopAsync();
            }
        }
    }
}