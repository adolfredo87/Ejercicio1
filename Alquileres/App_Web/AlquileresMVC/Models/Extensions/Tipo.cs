﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using AlquileresMVC.Utilitys;

namespace AlquileresMVC.Models
{
    [MetadataType(typeof(Tipo.MetaData))]
    [DisplayName("Tipo")]
    public partial class Tipo
    {
        private sealed class MetaData
        {
            [Required, DisplayName("ID"), StringLength(50)]
            public int ID { get; set; }

            [Required, DisplayName("Codigo"), StringLength(50)]
            public String Codigo { get; set; }

            [Required, DisplayName("Tipo del Producto"), StringLength(100)]
            public String Descripcion { get; set; }

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
            return new SelectList(new AlquileresMVC.Models.DemoAlquileresMVCEntities().TipoSet.ToList(), "ID", "Descripcion");
        }

        #endregion
    }
}