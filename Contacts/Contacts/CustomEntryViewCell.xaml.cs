using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomEntryViewCell : ViewCell
    {
        BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(CustomEntryViewCell));
        BindableProperty EntryProperty = BindableProperty.Create("Entry", typeof(string), typeof(CustomEntryViewCell));
        BindableProperty EntryPlaceholderProperty = BindableProperty.Create("EntryPlaceholder", typeof(string), typeof(CustomEntryViewCell));
        BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(CustomEntryViewCell));

        public string Label { 
            get
            {
                return (string)GetValue(LabelProperty);
            }
            set 
            {
                SetValue(LabelProperty, value);
            }
        }
        public string Entry {
            get
            {
                return (string)GetValue(EntryProperty);
            }
            set
            {
                SetValue(EntryProperty, value);
            }
        }
        public string EntryPlaceholder
        {
            get
            {
                return (string)GetValue(EntryPlaceholderProperty);
            }
            set
            {
                SetValue(EntryPlaceholderProperty, value);
            }
        }

        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }
        public CustomEntryViewCell()
        {
            InitializeComponent();

            this.BindingContext = this;
        }
    }
}