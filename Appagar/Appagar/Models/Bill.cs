using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appagar.Models
{
    /// <summary>
    /// Conta
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// Identificação
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// É mensal
        /// </summary>
        public bool IsMonthly { get; set; } = false;
    }
}
