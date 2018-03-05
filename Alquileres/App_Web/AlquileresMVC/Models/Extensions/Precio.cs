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
    [MetadataType(typeof(Precio.MetaData))]
    [DisplayName("Precios")]
    public partial class Precio
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID"), StringLength(50)]
            public int ID { get; set; }

            [Required, DisplayName("Codigo del Precio"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Descripcion del Precio"), StringLength(100)]
            public String Descripcion { get; set; }

            [Required, DisplayName("Precio Unitario")]
            public Double PrecioUnitario { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().PrecioSet.ToList(), "ID", "Codigo", "Descripcion");
        }

        #endregion
    }
}