using System;
using System.Collections.Generic;
using System.Text;
using PCLStorage;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using Contacts.Model;
using System.Collections.ObjectModel;


namespace Contacts
{
    static class ContactService
    {
        public static ObservableCollection<Contact> Contacts { get; set; }

        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string DBPath = PortablePath.Combine(root, "Contacts.db3");
        public static SQLiteAsyncConnection Con = new SQLiteAsyncConnection(DBPath);

        public static async Task<bool> CreateContactsTable()
        {
            try
            {
                await Con.CreateTableAsync<Contact>();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async static Task<int> LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(await GetContacts());
            return 0;
        }

        public static async void InsertContact(Contact contact)
        {
            //await Con.CreateTableAsync<Contact>();
            await Con.InsertAsync(contact);
            Contacts?.Add(contact);
            
            
        }

        public static async Task<List<Contact>> GetContacts()
        {
            //await Con.CreateTableAsync<Contact>();

            List<Contact> contacts = await Con.Table<Contact>().ToListAsync();
            return contacts.OrderBy(c => c.Name).ToList();
            
        }

        public static async Task<Contact> GetContact(int id)
        {
            var contact = await Con.Table<Contact>().FirstOrDefaultAsync(c => c.Id == id);

            return contact;
        }

        public static async void UpdateContact(Contact contact)
        {
            Contact old = await Con.Table<Contact>().FirstOrDefaultAsync(c => c.Id == contact.Id);

            old.FirstName = contact.FirstName;
            old.LastName = contact.LastName;
            old.Email = contact.Email;
            old.Phone = contact.Phone;
            old.Company = contact.Company;
            old.JobTitle = contact.JobTitle;
            old.Street = contact.Street;
            old.City = contact.City;
            old.State = contact.State;
            old.Zip = contact.Zip;

            Contacts?.Remove(Contacts?.Single(c => c.Id == contact.Id));
            Contacts?.Add(old);

            await Con.UpdateAsync(old);
        }

        public static async Task<bool> DeleteContact(Contact contact)
        {
            Contact ContactInDb = await Con.Table<Contact>().FirstOrDefaultAsync(c => c.Id == contact.Id);

            await Con.DeleteAsync(ContactInDb);

            Contacts?.Remove(Contacts?.Single(c => c.Id == contact.Id));

            return true;
        }

        public static async void DropDatabase()
        {
            await Con.DropTableAsync<Contact>();
        }

    }
}
