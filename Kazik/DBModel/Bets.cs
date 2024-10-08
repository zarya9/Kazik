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
    
    public partial class Bets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bets()
        {
            this.GameHistory = new HashSet<GameHistory>();
        }
    
        public int BetId { get; set; }
        public int SessionId { get; set; }
        public int UserID { get; set; }
        public Nullable<int> Amount { get; set; }
        public string BetType { get; set; }
        public string BetValue { get; set; }
        public Nullable<System.DateTime> PlacedAt { get; set; }
        public string Outcome { get; set; }
        public Nullable<int> Payout { get; set; }
    
        public virtual GameSessions GameSessions { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameHistory> GameHistory { get; set; }
    }
}
