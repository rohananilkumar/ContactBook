using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Contacts.Model;

using Xamarin.Forms;
using Xamarin.Essentials;

namespace Contacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //ContactService.DropDatabase();
            await ContactService.CreateContactsTable();
            await ContactService.LoadContacts();

            ContactListView.ItemsSource = ContactService.Contacts;

        }

        private void ContactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            Navigation.PushAsync(new EditContact(e.SelectedItem as Contact));
            (sender as ListView).SelectedItem = null;
        }

        private void NewContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContact(null));
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var contact = button.CommandParameter as Contact;


            PhoneDialer.Open(contact.Phone);

        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var contact = button.CommandParameter as Contact;

            ContactListView.SelectedItem = contact;

        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            if (await DisplayAlert("Delete", "This contact is going to be deleted. Are you sure?", "OK", "Cancel"))
            {
                ContactService.DeleteContact(contact);
            }

        }

        private void SearchContacts_TextChanged(object sender, TextChangedEventArgs e)
        {
            ContactListView.ItemsSource = ContactService.Contacts.Where(c => c.Name.ToLower().StartsWith(e.NewTextValue.ToLower()));
        }
    }
}