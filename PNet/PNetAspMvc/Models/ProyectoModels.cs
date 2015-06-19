using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PNet.Dominio.Modelo;
using System.Collections;
using PNet.DTO;
using PNet.Gestores;
using System.Web.Mvc;
using System.ComponentModel;

namespace PNetAspMvc.Models
{
    public class ProyectoModels : Proyecto
    {
        private GestorGerente _gGerentes= new GestorGerente();
        
        public ProyectoModels():base()
        {
            //cargo el dropdown de gerentes
           //this.DropGerentes=(SelectList)_gGerentes.Listar();
        }

        [DisplayName("Gerentes")]
        public SelectList DropGerentes { get; set; }

        [DisplayName("Nombre del gerente")]
        public String nombreGerente { get; set; }
       
    }
}