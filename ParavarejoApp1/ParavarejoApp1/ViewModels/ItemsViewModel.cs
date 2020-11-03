using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using ParavarejoApp1.Models;
using ParavarejoApp1.Views;
using System.Linq;

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

        public double PreçoDeCompraValue
        {
            get { return PreçoDeCompra.Value; }
            set
            {
                PreçoDeCompra.Value = value;
                OnPropertyChanged(nameof(PreçoDeCompraValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }
        public Item CreditoICMS { get; set; }

        public double CreditoICMSValue
        {
            get { return CreditoICMS.Value; }
            set
            {
                CreditoICMS.Value = value;
                OnPropertyChanged(nameof(CreditoICMSValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item CreditoPISCofins { get; set; }

        public double CreditoPISCofinsValue
        {
            get { return CreditoPISCofins.Value; }
            set
            {
                CreditoPISCofins.Value = value;
                OnPropertyChanged(nameof(CreditoPISCofinsValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item AcrescimoIPI { get; set; }

        public double AcrescimoIPIValue
        {
            get { return AcrescimoIPI.Value; }
            set
            {
                AcrescimoIPI.Value = value;
                OnPropertyChanged(nameof(AcrescimoIPIValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item PreçoDeCusto { get; set; }

        public Item PreçoDeVenda { get; set; }

        public double PreçoDeVendaValue
        {
            get { return PreçoDeVenda.Value; }
            set
            {
                PreçoDeVenda.Value = value;
                OnPropertyChanged(nameof(PreçoDeVendaValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item DebitoICMS { get; set; }

        public double DebitoICMSValue
        {
            get { return DebitoICMS.Value; }
            set
            {
                DebitoICMS.Value = value;
                OnPropertyChanged(nameof(DebitoICMSValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item DebitoPISCofins { get; set; }

        public double DebitoPISCofinsValue
        {
            get { return DebitoPISCofins.Value; }
            set
            {
                DebitoPISCofins.Value = value;
                OnPropertyChanged(nameof(DebitoPISCofinsValue));
                //Services.ParavarejoServices.GetInstance().LucroReal.Calculate(Items.ToList());
            }
        }

        public Item LucroBruto { get; set; }

        public ItemsViewModel()
        {
            Title = "Cálculo do Lucro Bruto";
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