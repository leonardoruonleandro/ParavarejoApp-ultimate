using System.ComponentModel;
using Xamarin.Forms;
using ParavarejoApp1.ViewModels;

namespace ParavarejoApp1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}