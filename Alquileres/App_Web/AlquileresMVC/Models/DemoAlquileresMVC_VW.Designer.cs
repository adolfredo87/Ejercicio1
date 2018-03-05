﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace AlquileresMVC.Models
{
    #region Contextos
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    public partial class DemoAlquileresMVC_VWEntities : ObjectContext
    {
        #region Constructores
    
        /// <summary>
        /// Inicializa un nuevo objeto DemoAlquileresMVC_VWEntities usando la cadena de conexión encontrada en la sección 'DemoAlquileresMVC_VWEntities' del archivo de configuración de la aplicación.
        /// </summary>
        public DemoAlquileresMVC_VWEntities() : base("name=DemoAlquileresMVC_VWEntities", "DemoAlquileresMVC_VWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto DemoAlquileresMVC_VWEntities.
        /// </summary>
        public DemoAlquileresMVC_VWEntities(string connectionString) : base(connectionString, "DemoAlquileresMVC_VWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Inicializar un nuevo objeto DemoAlquileresMVC_VWEntities.
        /// </summary>
        public DemoAlquileresMVC_VWEntities(EntityConnection connection) : base(connection, "DemoAlquileresMVC_VWEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Métodos parciales
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Propiedades de ObjectSet
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Alquileres_Pagados_VW> Alquileres_Pagados_VW_Set
        {
            get
            {
                if ((_Alquileres_Pagados_VW_Set == null))
                {
                    _Alquileres_Pagados_VW_Set = base.CreateObjectSet<Alquileres_Pagados_VW>("Alquileres_Pagados_VW_Set");
                }
                return _Alquileres_Pagados_VW_Set;
            }
        }
        private ObjectSet<Alquileres_Pagados_VW> _Alquileres_Pagados_VW_Set;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Alquileres_Por_Pagar_VW> Alquileres_Por_Pagar_VW_Set
        {
            get
            {
                if ((_Alquileres_Por_Pagar_VW_Set == null))
                {
                    _Alquileres_Por_Pagar_VW_Set = base.CreateObjectSet<Alquileres_Por_Pagar_VW>("Alquileres_Por_Pagar_VW_Set");
                }
                return _Alquileres_Por_Pagar_VW_Set;
            }
        }
        private ObjectSet<Alquileres_Por_Pagar_VW> _Alquileres_Por_Pagar_VW_Set;
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        public ObjectSet<Cantidad_Alquileres_Por_Pagar_VW> Cantidad_Alquileres_Por_Pagar_VW_Set
        {
            get
            {
                if ((_Cantidad_Alquileres_Por_Pagar_VW_Set == null))
                {
                    _Cantidad_Alquileres_Por_Pagar_VW_Set = base.CreateObjectSet<Cantidad_Alquileres_Por_Pagar_VW>("Cantidad_Alquileres_Por_Pagar_VW_Set");
                }
                return _Cantidad_Alquileres_Por_Pagar_VW_Set;
            }
        }
        private ObjectSet<Cantidad_Alquileres_Por_Pagar_VW> _Cantidad_Alquileres_Por_Pagar_VW_Set;

        #endregion
        #region Métodos AddTo
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Alquileres_Pagados_VW_Set. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToAlquileres_Pagados_VW_Set(Alquileres_Pagados_VW alquileres_Pagados_VW)
        {
            base.AddObject("Alquileres_Pagados_VW_Set", alquileres_Pagados_VW);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Alquileres_Por_Pagar_VW_Set. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToAlquileres_Por_Pagar_VW_Set(Alquileres_Por_Pagar_VW alquileres_Por_Pagar_VW)
        {
            base.AddObject("Alquileres_Por_Pagar_VW_Set", alquileres_Por_Pagar_VW);
        }
    
        /// <summary>
        /// Método desusado para agregar un nuevo objeto al EntitySet Cantidad_Alquileres_Por_Pagar_VW_Set. Considere la posibilidad de usar el método .Add de la propiedad ObjectSet&lt;T&gt; asociada.
        /// </summary>
        public void AddToCantidad_Alquileres_Por_Pagar_VW_Set(Cantidad_Alquileres_Por_Pagar_VW cantidad_Alquileres_Por_Pagar_VW)
        {
            base.AddObject("Cantidad_Alquileres_Por_Pagar_VW_Set", cantidad_Alquileres_Por_Pagar_VW);
        }

        #endregion
    }
    

    #endregion
    
    #region Entidades
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DemoAlquileresMVC_VWModel", Name="Alquileres_Pagados_VW")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Alquileres_Pagados_VW : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Alquileres_Pagados_VW.
        /// </summary>
        /// <param name="id">Valor inicial de la propiedad ID.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="marca">Valor inicial de la propiedad Marca.</param>
        /// <param name="modelo">Valor inicial de la propiedad Modelo.</param>
        /// <param name="fechaDesde">Valor inicial de la propiedad FechaDesde.</param>
        /// <param name="fechaHasta">Valor inicial de la propiedad FechaHasta.</param>
        /// <param name="estatus">Valor inicial de la propiedad Estatus.</param>
        public static Alquileres_Pagados_VW CreateAlquileres_Pagados_VW(global::System.Int32 id, global::System.String nombre, global::System.String marca, global::System.String modelo, global::System.DateTime fechaDesde, global::System.DateTime fechaHasta, global::System.Int32 estatus)
        {
            Alquileres_Pagados_VW alquileres_Pagados_VW = new Alquileres_Pagados_VW();
            alquileres_Pagados_VW.ID = id;
            alquileres_Pagados_VW.Nombre = nombre;
            alquileres_Pagados_VW.Marca = marca;
            alquileres_Pagados_VW.Modelo = modelo;
            alquileres_Pagados_VW.FechaDesde = fechaDesde;
            alquileres_Pagados_VW.FechaHasta = fechaHasta;
            alquileres_Pagados_VW.Estatus = estatus;
            return alquileres_Pagados_VW;
        }

        #endregion
        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                if (_Nombre != value)
                {
                    OnNombreChanging(value);
                    ReportPropertyChanging("Nombre");
                    _Nombre = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Nombre");
                    OnNombreChanged();
                }
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                OnTelefonoChanging(value);
                ReportPropertyChanging("Telefono");
                _Telefono = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Telefono");
                OnTelefonoChanged();
            }
        }
        private global::System.String _Telefono;
        partial void OnTelefonoChanging(global::System.String value);
        partial void OnTelefonoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Correo
        {
            get
            {
                return _Correo;
            }
            set
            {
                OnCorreoChanging(value);
                ReportPropertyChanging("Correo");
                _Correo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Correo");
                OnCorreoChanged();
            }
        }
        private global::System.String _Correo;
        partial void OnCorreoChanging(global::System.String value);
        partial void OnCorreoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Marca
        {
            get
            {
                return _Marca;
            }
            set
            {
                if (_Marca != value)
                {
                    OnMarcaChanging(value);
                    ReportPropertyChanging("Marca");
                    _Marca = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Marca");
                    OnMarcaChanged();
                }
            }
        }
        private global::System.String _Marca;
        partial void OnMarcaChanging(global::System.String value);
        partial void OnMarcaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Modelo
        {
            get
            {
                return _Modelo;
            }
            set
            {
                if (_Modelo != value)
                {
                    OnModeloChanging(value);
                    ReportPropertyChanging("Modelo");
                    _Modelo = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Modelo");
                    OnModeloChanged();
                }
            }
        }
        private global::System.String _Modelo;
        partial void OnModeloChanging(global::System.String value);
        partial void OnModeloChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaDesde
        {
            get
            {
                return _FechaDesde;
            }
            set
            {
                if (_FechaDesde != value)
                {
                    OnFechaDesdeChanging(value);
                    ReportPropertyChanging("FechaDesde");
                    _FechaDesde = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("FechaDesde");
                    OnFechaDesdeChanged();
                }
            }
        }
        private global::System.DateTime _FechaDesde;
        partial void OnFechaDesdeChanging(global::System.DateTime value);
        partial void OnFechaDesdeChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaHasta
        {
            get
            {
                return _FechaHasta;
            }
            set
            {
                if (_FechaHasta != value)
                {
                    OnFechaHastaChanging(value);
                    ReportPropertyChanging("FechaHasta");
                    _FechaHasta = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("FechaHasta");
                    OnFechaHastaChanged();
                }
            }
        }
        private global::System.DateTime _FechaHasta;
        partial void OnFechaHastaChanging(global::System.DateTime value);
        partial void OnFechaHastaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoHora
        {
            get
            {
                return _TiempoHora;
            }
            set
            {
                OnTiempoHoraChanging(value);
                ReportPropertyChanging("TiempoHora");
                _TiempoHora = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoHora");
                OnTiempoHoraChanged();
            }
        }
        private global::System.String _TiempoHora;
        partial void OnTiempoHoraChanging(global::System.String value);
        partial void OnTiempoHoraChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoDia
        {
            get
            {
                return _TiempoDia;
            }
            set
            {
                OnTiempoDiaChanging(value);
                ReportPropertyChanging("TiempoDia");
                _TiempoDia = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoDia");
                OnTiempoDiaChanged();
            }
        }
        private global::System.String _TiempoDia;
        partial void OnTiempoDiaChanging(global::System.String value);
        partial void OnTiempoDiaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoSemana
        {
            get
            {
                return _TiempoSemana;
            }
            set
            {
                OnTiempoSemanaChanging(value);
                ReportPropertyChanging("TiempoSemana");
                _TiempoSemana = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoSemana");
                OnTiempoSemanaChanged();
            }
        }
        private global::System.String _TiempoSemana;
        partial void OnTiempoSemanaChanging(global::System.String value);
        partial void OnTiempoSemanaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> PrecioEstimado
        {
            get
            {
                return _PrecioEstimado;
            }
            set
            {
                OnPrecioEstimadoChanging(value);
                ReportPropertyChanging("PrecioEstimado");
                _PrecioEstimado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PrecioEstimado");
                OnPrecioEstimadoChanged();
            }
        }
        private Nullable<global::System.Double> _PrecioEstimado;
        partial void OnPrecioEstimadoChanging(Nullable<global::System.Double> value);
        partial void OnPrecioEstimadoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Estatus
        {
            get
            {
                return _Estatus;
            }
            set
            {
                if (_Estatus != value)
                {
                    OnEstatusChanging(value);
                    ReportPropertyChanging("Estatus");
                    _Estatus = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Estatus");
                    OnEstatusChanged();
                }
            }
        }
        private global::System.Int32 _Estatus;
        partial void OnEstatusChanging(global::System.Int32 value);
        partial void OnEstatusChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DemoAlquileresMVC_VWModel", Name="Alquileres_Por_Pagar_VW")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Alquileres_Por_Pagar_VW : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Alquileres_Por_Pagar_VW.
        /// </summary>
        /// <param name="id">Valor inicial de la propiedad ID.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="marca">Valor inicial de la propiedad Marca.</param>
        /// <param name="modelo">Valor inicial de la propiedad Modelo.</param>
        /// <param name="fechaDesde">Valor inicial de la propiedad FechaDesde.</param>
        /// <param name="fechaHasta">Valor inicial de la propiedad FechaHasta.</param>
        /// <param name="estatus">Valor inicial de la propiedad Estatus.</param>
        public static Alquileres_Por_Pagar_VW CreateAlquileres_Por_Pagar_VW(global::System.Int32 id, global::System.String nombre, global::System.String marca, global::System.String modelo, global::System.DateTime fechaDesde, global::System.DateTime fechaHasta, global::System.Int32 estatus)
        {
            Alquileres_Por_Pagar_VW alquileres_Por_Pagar_VW = new Alquileres_Por_Pagar_VW();
            alquileres_Por_Pagar_VW.ID = id;
            alquileres_Por_Pagar_VW.Nombre = nombre;
            alquileres_Por_Pagar_VW.Marca = marca;
            alquileres_Por_Pagar_VW.Modelo = modelo;
            alquileres_Por_Pagar_VW.FechaDesde = fechaDesde;
            alquileres_Por_Pagar_VW.FechaHasta = fechaHasta;
            alquileres_Por_Pagar_VW.Estatus = estatus;
            return alquileres_Por_Pagar_VW;
        }

        #endregion
        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                if (_Nombre != value)
                {
                    OnNombreChanging(value);
                    ReportPropertyChanging("Nombre");
                    _Nombre = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Nombre");
                    OnNombreChanged();
                }
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                OnTelefonoChanging(value);
                ReportPropertyChanging("Telefono");
                _Telefono = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Telefono");
                OnTelefonoChanged();
            }
        }
        private global::System.String _Telefono;
        partial void OnTelefonoChanging(global::System.String value);
        partial void OnTelefonoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Correo
        {
            get
            {
                return _Correo;
            }
            set
            {
                OnCorreoChanging(value);
                ReportPropertyChanging("Correo");
                _Correo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Correo");
                OnCorreoChanged();
            }
        }
        private global::System.String _Correo;
        partial void OnCorreoChanging(global::System.String value);
        partial void OnCorreoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Marca
        {
            get
            {
                return _Marca;
            }
            set
            {
                if (_Marca != value)
                {
                    OnMarcaChanging(value);
                    ReportPropertyChanging("Marca");
                    _Marca = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Marca");
                    OnMarcaChanged();
                }
            }
        }
        private global::System.String _Marca;
        partial void OnMarcaChanging(global::System.String value);
        partial void OnMarcaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Modelo
        {
            get
            {
                return _Modelo;
            }
            set
            {
                if (_Modelo != value)
                {
                    OnModeloChanging(value);
                    ReportPropertyChanging("Modelo");
                    _Modelo = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Modelo");
                    OnModeloChanged();
                }
            }
        }
        private global::System.String _Modelo;
        partial void OnModeloChanging(global::System.String value);
        partial void OnModeloChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaDesde
        {
            get
            {
                return _FechaDesde;
            }
            set
            {
                if (_FechaDesde != value)
                {
                    OnFechaDesdeChanging(value);
                    ReportPropertyChanging("FechaDesde");
                    _FechaDesde = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("FechaDesde");
                    OnFechaDesdeChanged();
                }
            }
        }
        private global::System.DateTime _FechaDesde;
        partial void OnFechaDesdeChanging(global::System.DateTime value);
        partial void OnFechaDesdeChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime FechaHasta
        {
            get
            {
                return _FechaHasta;
            }
            set
            {
                if (_FechaHasta != value)
                {
                    OnFechaHastaChanging(value);
                    ReportPropertyChanging("FechaHasta");
                    _FechaHasta = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("FechaHasta");
                    OnFechaHastaChanged();
                }
            }
        }
        private global::System.DateTime _FechaHasta;
        partial void OnFechaHastaChanging(global::System.DateTime value);
        partial void OnFechaHastaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoHora
        {
            get
            {
                return _TiempoHora;
            }
            set
            {
                OnTiempoHoraChanging(value);
                ReportPropertyChanging("TiempoHora");
                _TiempoHora = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoHora");
                OnTiempoHoraChanged();
            }
        }
        private global::System.String _TiempoHora;
        partial void OnTiempoHoraChanging(global::System.String value);
        partial void OnTiempoHoraChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoDia
        {
            get
            {
                return _TiempoDia;
            }
            set
            {
                OnTiempoDiaChanging(value);
                ReportPropertyChanging("TiempoDia");
                _TiempoDia = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoDia");
                OnTiempoDiaChanged();
            }
        }
        private global::System.String _TiempoDia;
        partial void OnTiempoDiaChanging(global::System.String value);
        partial void OnTiempoDiaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TiempoSemana
        {
            get
            {
                return _TiempoSemana;
            }
            set
            {
                OnTiempoSemanaChanging(value);
                ReportPropertyChanging("TiempoSemana");
                _TiempoSemana = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TiempoSemana");
                OnTiempoSemanaChanged();
            }
        }
        private global::System.String _TiempoSemana;
        partial void OnTiempoSemanaChanging(global::System.String value);
        partial void OnTiempoSemanaChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Double> PrecioEstimado
        {
            get
            {
                return _PrecioEstimado;
            }
            set
            {
                OnPrecioEstimadoChanging(value);
                ReportPropertyChanging("PrecioEstimado");
                _PrecioEstimado = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PrecioEstimado");
                OnPrecioEstimadoChanged();
            }
        }
        private Nullable<global::System.Double> _PrecioEstimado;
        partial void OnPrecioEstimadoChanging(Nullable<global::System.Double> value);
        partial void OnPrecioEstimadoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Estatus
        {
            get
            {
                return _Estatus;
            }
            set
            {
                if (_Estatus != value)
                {
                    OnEstatusChanging(value);
                    ReportPropertyChanging("Estatus");
                    _Estatus = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Estatus");
                    OnEstatusChanged();
                }
            }
        }
        private global::System.Int32 _Estatus;
        partial void OnEstatusChanging(global::System.Int32 value);
        partial void OnEstatusChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No hay documentación de metadatos disponible.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DemoAlquileresMVC_VWModel", Name="Cantidad_Alquileres_Por_Pagar_VW")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Cantidad_Alquileres_Por_Pagar_VW : EntityObject
    {
        #region Método de generador
    
        /// <summary>
        /// Crear un nuevo objeto Cantidad_Alquileres_Por_Pagar_VW.
        /// </summary>
        /// <param name="iDCliente">Valor inicial de la propiedad IDCliente.</param>
        /// <param name="nombre">Valor inicial de la propiedad Nombre.</param>
        /// <param name="estatus">Valor inicial de la propiedad Estatus.</param>
        public static Cantidad_Alquileres_Por_Pagar_VW CreateCantidad_Alquileres_Por_Pagar_VW(global::System.Int32 iDCliente, global::System.String nombre, global::System.Int32 estatus)
        {
            Cantidad_Alquileres_Por_Pagar_VW cantidad_Alquileres_Por_Pagar_VW = new Cantidad_Alquileres_Por_Pagar_VW();
            cantidad_Alquileres_Por_Pagar_VW.IDCliente = iDCliente;
            cantidad_Alquileres_Por_Pagar_VW.Nombre = nombre;
            cantidad_Alquileres_Por_Pagar_VW.Estatus = estatus;
            return cantidad_Alquileres_Por_Pagar_VW;
        }

        #endregion
        #region Propiedades primitivas
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 IDCliente
        {
            get
            {
                return _IDCliente;
            }
            set
            {
                if (_IDCliente != value)
                {
                    OnIDClienteChanging(value);
                    ReportPropertyChanging("IDCliente");
                    _IDCliente = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("IDCliente");
                    OnIDClienteChanged();
                }
            }
        }
        private global::System.Int32 _IDCliente;
        partial void OnIDClienteChanging(global::System.Int32 value);
        partial void OnIDClienteChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Nombre
        {
            get
            {
                return _Nombre;
            }
            set
            {
                if (_Nombre != value)
                {
                    OnNombreChanging(value);
                    ReportPropertyChanging("Nombre");
                    _Nombre = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Nombre");
                    OnNombreChanged();
                }
            }
        }
        private global::System.String _Nombre;
        partial void OnNombreChanging(global::System.String value);
        partial void OnNombreChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                OnTelefonoChanging(value);
                ReportPropertyChanging("Telefono");
                _Telefono = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Telefono");
                OnTelefonoChanged();
            }
        }
        private global::System.String _Telefono;
        partial void OnTelefonoChanging(global::System.String value);
        partial void OnTelefonoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Correo
        {
            get
            {
                return _Correo;
            }
            set
            {
                OnCorreoChanging(value);
                ReportPropertyChanging("Correo");
                _Correo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Correo");
                OnCorreoChanged();
            }
        }
        private global::System.String _Correo;
        partial void OnCorreoChanging(global::System.String value);
        partial void OnCorreoChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> NumAlquiler
        {
            get
            {
                return _NumAlquiler;
            }
            set
            {
                OnNumAlquilerChanging(value);
                ReportPropertyChanging("NumAlquiler");
                _NumAlquiler = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NumAlquiler");
                OnNumAlquilerChanged();
            }
        }
        private Nullable<global::System.Int32> _NumAlquiler;
        partial void OnNumAlquilerChanging(Nullable<global::System.Int32> value);
        partial void OnNumAlquilerChanged();
    
        /// <summary>
        /// No hay documentación de metadatos disponible.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Estatus
        {
            get
            {
                return _Estatus;
            }
            set
            {
                if (_Estatus != value)
                {
                    OnEstatusChanging(value);
                    ReportPropertyChanging("Estatus");
                    _Estatus = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Estatus");
                    OnEstatusChanged();
                }
            }
        }
        private global::System.Int32 _Estatus;
        partial void OnEstatusChanging(global::System.Int32 value);
        partial void OnEstatusChanged();

        #endregion
    
    }

    #endregion
    
}