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
    
    public partial class GameHistory
    {
        public int HistoryID { get; set; }
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string GameType { get; set; }
        public int BetID { get; set; }
        public string Result { get; set; }
        public Nullable<System.DateTime> PlayedAt { get; set; }
    
        public virtual Bets Bets { get; set; }
        public virtual GameSessions GameSessions { get; set; }
        public virtual Users Users { get; set; }
    }
}
