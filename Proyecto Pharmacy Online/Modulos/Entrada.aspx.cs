using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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

            string strUsuario, strContraseña;

            strUsuario = txtUsuario.Text;
            strContraseña = txtContraseña.Text;

            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var sqlQuery = "SELECT * from[dbo].[USUARIOS] where usuario = '" + strUsuario + "' And contraseña = '" + strContraseña + "'";

            var cmd = new SqlCommand(sqlQuery, sqlcon);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            sqlcon.Open();
            da.Fill(ds, "USUARIOS");
            sqlcon.Close();


            if (ds.Tables[0].Rows.Count > 0)
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



            string strNombre, strApellido, strTelefono, strDireccion, strEmail, strUsuario, strContraseña, strRepContraseña;

            strNombre = tbNombre.Text;
            strApellido = tbApellidos.Text;
            strTelefono = tbTelefono.Text;
            strDireccion = tbDireccion.Text;
            strEmail = tbCorreo.Text;
            strUsuario = tbUsuario.Text;
            strContraseña = tbContraseña.Text;
            strRepContraseña = tbRepContraseña.Text;


            if (strContraseña.Equals(strRepContraseña))
            {
                var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
                var sqlQuery = "INSERT INTO [dbo].[Usuarios]" +
                                "([nombre],[apellido],[telefono]" +
                                ",[direccion],[correo],[usuario],[contraseña],[Usuarioid])" +
                                "VALUES('" + strNombre + "','" + strApellido + "','" + strTelefono + "','" +
                                strDireccion + "','" + strEmail + "','" + strUsuario + "','" + strContraseña + "',NEWID())";

                var cmd = new SqlCommand(sqlQuery, sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();

                Response.Redirect("../Modulos/Principal.aspx");
            }
            else
            {
                tbRepContraseña.Text = string.Empty;
                tbContraseña.Text = string.Empty;
            }


        }
        #endregion
    }
}
