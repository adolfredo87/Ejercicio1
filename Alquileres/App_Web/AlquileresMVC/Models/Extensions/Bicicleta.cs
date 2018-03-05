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
    [MetadataType(typeof(Bicicleta.MetaData))]
    [DisplayName("Bicicletas")]
    public partial class Bicicleta
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Bicicleta"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Marca Bicicleta"), StringLength(200)]
            public String Marca { get; set; }

            [Required, DisplayName("Modelo Bicicleta"), StringLength(200)]
            public String Modelo { get; set; }

            [Required, DisplayName("Categoria Bicicleta")]
            public CategoriaBicicleta CategoriaBici { get; set; }
        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().BicicletaSet.ToList(), "ID", "Marca");
        }

        public CategoriaBicicleta CategoriaBicicletaLoad()
        {
            return Utility.Entity<CategoriaBicicleta>.LoadReference(this.CategoriaBiciReference);
        }

        #endregion
    }
}