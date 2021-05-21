using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pharmacy_Online.Modulos
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) MultiView1.ActiveViewIndex = 0;
        }

        protected void BtnCrearCuenta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void BtnTengoCuenta_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        #region metodos
        /// <summary>
        /// Metodo ejecutado al presionar el boton de iniciar sesion
        /// se verifica en la base de datos que el usuario y la 
        /// contraseña coincidad y lo redirige  a la pagina principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnIniciar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = txtUsuario.Text;
            Session["contraseña"] = txtContraseña;

            if (Session["usuario"].Equals("juanc"))
            {
                Response.Redirect("../Modulos/Principal.aspx");
            }
        }
        /// <summary>
        /// Metodo ejecutado al presionar el boton de Registar
        /// un usuario nuevo, guarda los dtos de los campos de texto
        /// en la base de datos y lo redirije a iniciar sesion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnRegistro_Click(object sender, EventArgs e)
        {

            Session["nombre"] = tbNombre.Text;
            Session["apellido"] = tbApellidos;
            Session["telefono"] = tbDireccion.Text;
            Session["direccion"] = tbCorreo.Text;
            Session["correo"] = txtUsuario.Text;
            Session["usuario"] = tbUsuario;
            Session["contraseña"] = tbContraseña.Text;
            MultiView1.ActiveViewIndex = 0;
        }
        #endregion
    }
}
