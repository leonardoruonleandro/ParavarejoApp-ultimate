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
        private string _text;
        private string _description;
        private string _value;
        private double _calculatedValue;

        public ItemDetailViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public string Id { get; set; }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Value
        {
            get => _value;
            set
            {
                SetProperty(ref _value, value);
            }
        }

        public double CalculatedValue
        {
            get => _calculatedValue;
            set => SetProperty(ref _calculatedValue, value);
        }

        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public bool IsReadOnly
        {
            get
            {
                bool isReadOnly = false;
                if (_item != null)
                {
                    switch (_item.Variavel)
                    {
                        case LucroRealVariavel.PreçoDeCusto:
                        case LucroRealVariavel.LucroBruto:
                            isReadOnly = true;
                            break;
                        default:
                            break;
                    }
                }
                return isReadOnly;
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
                Value = Convert.ToString(item.Value);
                CalculatedValue = item.CalculatedValue;

                _item = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }

            UpdateView();

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
            _item.Value = Convert.ToDouble(Value);

            await DataStore.UpdateItemAsync(_item);

            var items = await DataStore.GetItemsAsync();

            Services.ParavarejoServices.GetInstance().LucroReal.Calculate(items.ToList());

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_text)
                && !String.IsNullOrWhiteSpace(_description);
        }

        private void UpdateView()
        {
            OnPropertyChanged(nameof(IsReadOnly));
        }

    }
}
