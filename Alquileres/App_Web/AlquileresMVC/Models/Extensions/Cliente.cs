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
    [MetadataType(typeof(Cliente.MetaData))]
    [DisplayName("Clientes")]
    public partial class Cliente
    {
        private sealed class MetaData
        {
            [Required, DisplayName("Código Cliente"), StringLength(50)]
            public String ID { get; set; }

            [Required, DisplayName("Nombre del Cliente"), StringLength(200)]
            public String Nombre { get; set; }

            [Required, DisplayName("Telefono del Cliente"), StringLength(200)]
            public String Telefono { get; set; }

            [DisplayName("Correo del Cliente"), StringLength(200)]
            public String Correo { get; set; }

        }

        #region Metodos Extendidos del Entities Framework

        public SelectList ToEntitySelectList()
        {
            return ToSelectList();
        }

        public static SelectList ToSelectList()
        {
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().ClienteSet.ToList(), "ID", "Nombre");
        }

        #endregion
    }
}