using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using AlquileresMVC.Utilitys;

namespace AlquileresMVC.Models
{
    [MetadataType(typeof(PagoCabecera.MetaData))]
    [DisplayName("Pagos")]
    public partial class PagoCabecera
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Pago Cabecera"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Cliente")]
            public Cliente Cliente { get; set; }

            [Required, DisplayName("Fecha")]
            public DateTime Fecha { get; set; }

            [Required, DisplayName("Monto Exento")]
            public Double MontoExento { get; set; }

            [Required, DisplayName("Descuento")]
            public Double Descuento { get; set; }

            [Required, DisplayName("Monto Total")]
            public Double MontoTotal { get; set; }

            [Required, DisplayName("Estatus")]
            public int Estatus { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().PagoCabeceraSet.ToList(), "ID");
        }

        public Cliente ClienteLoad()
        {
            return Utility.Entity<Cliente>.LoadReference(this.ClienteReference);
        }

        #endregion
    }
}