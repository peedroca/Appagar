using Appagar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appagar.ViewModels
{
    public class AppViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AppViewModel()
        {
            CreateDatabase();
        }

        /// <summary>
        /// Gera o banco de dados SQLite
        /// </summary>
        private void CreateDatabase()
        {
            try
            {
                App.SQLiteConnection.CreateTable<Bill>();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Ocorreu um erro...", "Não foi possível gerar o banco de dados.", "OK");
            }
        }
    }
}
