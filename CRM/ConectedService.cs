//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConectedService
    {
        public int IDConnected { get; set; }
        public int Service { get; set; }
        public Nullable<System.DateTime> DateConnected { get; set; }
        public int ConnectedUser { get; set; }
    
        public virtual Service Service1 { get; set; }
        public virtual Subsriber Subsriber { get; set; }
    }
}
