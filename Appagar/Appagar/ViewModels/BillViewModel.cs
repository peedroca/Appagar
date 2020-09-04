using Appagar.Models;
using Appagar.Repositories;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Appagar.ViewModels
{
    public class BillViewModel : BaseViewModel
    {
        private Bill newBill;
        private ObservableRangeCollection<Bill> bills;

        public BillViewModel()
        {
            ClickedButtonCommand = new Command<string>(ClickedButton);
            OrderBillsCommand = new Command(OrderBills);

            NewBill = new Bill();

            ToLoadBills();
        }

        public Bill NewBill
        {
            get { return newBill; }
            set { SetProperty(ref newBill, value); }
        }

        public ObservableRangeCollection<Bill> Bills
        {
            get { return bills; }
            set { SetProperty(ref bills, value); }
        }

        public string SelectedOrder { get; set; }

        public List<string> Orders { get; set; } = new List<string>()
        { 
            "Descrição - Crescente",
            "Descrição - Decrescente",
            "Valor - Crescente",
            "Valor - Decrescente",
        };

        #region Commands

        public ICommand ClickedButtonCommand { get; set; }

        public ICommand OrderBillsCommand { get; set; }

        #endregion Commands

        #region Methods

        void ClickedButton(string sender)
        {
            try
            {
                switch (sender)
                {
                    case "CreateBill":
                        ToCreateBill();
                        break;
                }
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Ocorreu um erro...", e.Message, "Ok");
            }
        }

        void OrderBills()
        {
            try
            {
                ToOrderBills();
            }
            catch (Exception e)
            {
                App.Current.MainPage.DisplayAlert("Ocorreu um erro...", e.Message, "Ok");
            }
        }

        #endregion Methods

        #region Private Methods

        private void ToCreateBill()
        {
            try
            {
                if(NewBill != null)
                {
                    BillRepository.Save(NewBill);
                    App.Current.MainPage.DisplayAlert("Sucesso!!", "Conta criada com sucesso.", "Ok");

                    NewBill = new Bill();
                    ToLoadBills();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ToLoadBills()
        {
            try
            {
                var bills = BillRepository.Get();

                if(bills != null && bills.Count() > 0)
                    Bills = new ObservableRangeCollection<Bill>(bills);
                else
                    Bills = new ObservableRangeCollection<Bill>();

                OnPropertyChanged("Bills");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ToOrderBills()
        {
            try
            {
                IOrderedEnumerable<Bill> bills = null; 

                switch (SelectedOrder)
                {
                    case "Descrição - Crescente":
                        bills = Bills.OrderBy(o => o.Description);
                        break;
                    case "Descrição - Decrescente":
                        bills = Bills.OrderByDescending(o => o.Description);
                        break;
                    default:
                        return;
                }

                Bills = new ObservableRangeCollection<Bill>(bills);
                OnPropertyChanged("Bills");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Methods
    }
}
