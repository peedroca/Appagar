using Appagar.ViewModels;
using Appagar.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace Appagar
{
    public partial class App : Application
    {
        /// <summary>
        /// Conexão com Banco Interno
        /// </summary>
        public static SQLiteConnection SQLiteConnection { get; private set; }

        public static AppViewModel AppViewModel { get; set; }

        public App()
        {
            InitializeComponent();
            SQLiteConnection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                , "appagar.db3"));

            AppViewModel = new AppViewModel();
            BindingContext = AppViewModel;

            MainPage = new MasterTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
