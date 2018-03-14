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
    [MetadataType(typeof(Producto.MetaData))]
    [DisplayName("Bicicleta")]
    public partial class Producto
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID Producto"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Tipo del Producto")]
            public Tipo Tipo { get; set; }

            [Required, DisplayName("Código Producto"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Descripcion Producto"), StringLength(200)]
            public String Descripcion { get; set; }

            [Required, DisplayName("Estatus")]
            public int Estatus { get; set; }

            [Required, DisplayName("Marca del Producto")]
            public Marca Marca { get; set; }

            [Required, DisplayName("Modelo del Producto")]
            public Modelo Modelo { get; set; }

            [Required, DisplayName("Categoria del Producto")]
            public Categoria Categoria { get; set; }
        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().ProductoSet.ToList(), "ID", "Descripcion");
        }

        public Tipo TipoLoad()
        {
            return Utility.Entity<Tipo>.LoadReference(this.TipoReference);
        }

        public Marca MarcaLoad()
        {
            return Utility.Entity<Marca>.LoadReference(this.MarcaReference);
        }

        public Modelo ModeloLoad()
        {
            return Utility.Entity<Modelo>.LoadReference(this.ModeloReference);
        }

        public Categoria CategoriaLoad()
        {
            return Utility.Entity<Categoria>.LoadReference(this.CategoriaReference);
        }

        #endregion
    }
}