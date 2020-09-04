using Appagar.Models;
using System.Collections.Generic;
using System.Linq;

namespace Appagar.Repositories
{
    /// <summary>
    /// Repositório de Contas
    /// </summary>
    public static class BillRepository
    {
        /// <summary>
        /// Deletar por Id
        /// </summary>
        /// <param name="id">Identificação</param>
        public static void Delete(long id) =>
            App.SQLiteConnection.Delete<Bill>(id);

        /// <summary>
        /// Deletar todos
        /// </summary>
        public static void Delete() =>
            App.SQLiteConnection.DeleteAll<Bill>();

        /// <summary>
        /// Consultar
        /// </summary>
        /// <param name="sender">Chave primária</param>
        /// <returns>Conta</returns>
        public static Bill Get(object sender) =>
            App.SQLiteConnection.Get<Bill>(sender);

        /// <summary>
        /// Listar
        /// </summary>
        /// <returns>Lista de contas</returns>
        public static IEnumerable<Bill> Get() =>
            App.SQLiteConnection.Table<Bill>()?.ToList() ?? new List<Bill>();

        /// <summary>
        /// Gravar
        /// </summary>
        /// <param name="obj">Objeto a ser gravado</param>
        /// <returns>Id da última inserção</returns>
        public static long Save(Bill obj)
        {
            if (obj.Id != 0)
                App.SQLiteConnection.Update(obj);
            else
                App.SQLiteConnection.Insert(obj);

            return App.SQLiteConnection.Table<Bill>().Last().Id;
        }
    }
}
