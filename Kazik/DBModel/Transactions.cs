//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kazik.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transactions
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public string TransactionType { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Status { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
