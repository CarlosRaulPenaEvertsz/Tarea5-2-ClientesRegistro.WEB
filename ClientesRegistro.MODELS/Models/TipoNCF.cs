//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientesRegistro.MODELS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TipoNCF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoNCF()
        {
            this.Clientes = new HashSet<Cliente>();
        }
        [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
        public int TipoNCF_Id { get; set; }
        [Required(ErrorMessage = "El Nombre del NCF es Obligatorio")]
        public string NombreComprobanteFiscal { get; set; }
        [DisplayFormat(DataFormatString = "{0:00000000}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El Numero Actual es Obligatorio")]
        public Nullable<int> NCF_Actual { get; set; }
        [Required(ErrorMessage = "El Ultimo Numero es Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:00000000}", ApplyFormatInEditMode = true)]
        public Nullable<int> NCF_Hasta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
