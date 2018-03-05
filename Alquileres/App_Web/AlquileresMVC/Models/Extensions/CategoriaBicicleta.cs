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
    [MetadataType(typeof(CategoriaBicicleta.MetaData))]
    [DisplayName("Categoria de Bicicleta")]
    public partial class CategoriaBicicleta
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID"), StringLength(50)]
            public int ID { get; set; }

            [Required, DisplayName("Codigo"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Categoria Bicicleta"), StringLength(100)]
            public String Categoria { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().CategoriaBicicletaSet.ToList(), "ID", "Categoria");
        }

        #endregion
    }
}