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
    
    public partial class ApplicationCRM
    {
        public int ID { get; set; }
        public string NumberApplication { get; set; }
        public System.DateTime DateCreate { get; set; }
        public int Sub { get; set; }
        public int Service { get; set; }
        public int KindService { get; set; }
        public int TypeService { get; set; }
        public int StatusApplication { get; set; }
        public Nullable<int> DescriptionProblem { get; set; }
        public Nullable<System.DateTime> ClosingDate { get; set; }
        public int TypeProblem { get; set; }
    
        public virtual KindServise KindServise { get; set; }
        public virtual Service Service1 { get; set; }
        public virtual Status Status { get; set; }
        public virtual Subsriber Subsriber { get; set; }
        public virtual TypeOfProblem TypeOfProblem { get; set; }
        public virtual TypeService TypeService1 { get; set; }
    }
}