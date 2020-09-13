using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ParavarejoApp1.Models;
using Xamarin.Forms;

namespace ParavarejoApp1.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {

        private Item _item;
        private string _itemId;
        private string _id;
        private string _text;
        private string _description;
        private double _value;
        private double _calculatedValue;


        public ItemDetailViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string Id { get { return _item.Id; } set { _item.Id = value; OnPropertyChanged(); } }

        public string Text
        {
            get => _item.Text;
            set => SetProperty(ref _item.Text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public double Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value, "Value");
            }
        }

        public double CalculatedValue
        {
            get => calculatedValue;
            set => SetProperty(ref calculatedValue, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description,
                Value = Value,
                
            };
            await DataStore.UpdateItemAsync(newItem);

            var itemss = await DataStore.GetItemsAsync();

            //ParavarejoApp1.Services.ParavarejoServices.GetInstance().LucroReal.Calculate(itemss.ToList());

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

    }
}
