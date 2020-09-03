using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appagar.Models
{
    public class Bill
    {
        /// <summary>
        /// Identificação
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
    }
}
