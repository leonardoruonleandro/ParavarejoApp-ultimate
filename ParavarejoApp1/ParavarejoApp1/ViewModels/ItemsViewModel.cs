using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ParavarejoApp1.Models;
using ParavarejoApp1.Views;

namespace ParavarejoApp1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public Item PreçoDeCompra { get; set; }
        public Item CreditoICMS { get; set; }

        public Item CreditoPISCofins { get; set; }

        public Item AcrescimoIPI { get; set; }

        public Item PreçoDeCusto { get; set; }

        public Item PreçoDeVenda { get; set; }

        public Item DebitoICMS { get; set; }

        public Item DebitoPISCofins { get; set; }

        public Item LucroBruto { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadItems();

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        private async void LoadItems()
        {
            var items = await DataStore.GetItemsAsync();

            foreach (var item in items)
            {
                switch (item.Variavel)
                {
                    case LucroRealVariavel.PreçoDeCompra:
                        PreçoDeCompra = item;
                        break;
                    case LucroRealVariavel.CreditoICMS:
                        CreditoICMS = item;
                        break;
                    case LucroRealVariavel.CreditoPISCofins:
                        CreditoPISCofins = item;
                        break;
                    case LucroRealVariavel.AcrescimoIPI:
                        AcrescimoIPI = item;
                        break;
                    case LucroRealVariavel.PreçoDeCusto:
                        PreçoDeCusto = item;
                        break;
                    case LucroRealVariavel.PreçoDeVenda:
                        PreçoDeVenda = item;
                        break;
                    case LucroRealVariavel.DebitoICMS:
                        DebitoICMS = item;
                        break;
                    case LucroRealVariavel.DebitoPISCofins:
                        DebitoPISCofins = item;
                        break;
                    case LucroRealVariavel.LucroBruto:
                        LucroBruto = item;
                        break;
                    default:
                        throw new ArgumentException($"Variable '{item.Variavel}' is not expected. Item: {item}");
                }
            }

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                //OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            //await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}