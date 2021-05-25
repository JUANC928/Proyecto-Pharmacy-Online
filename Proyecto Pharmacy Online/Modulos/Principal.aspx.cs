using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Threading;

namespace Proyecto_Pharmacy_Online.Modulos
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a;
            if (!IsPostBack) MultiView1.ActiveViewIndex = 0;
            if (Session["usuario"].Equals("admin"))
            {
                MultiView2.ActiveViewIndex = 1;
            }
            else
            {
                MultiView2.ActiveViewIndex = 0;
            }
            CapVariablesSession();
        }

        protected void BtnProductos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
        protected void BtnCarrito_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }
        protected void BtnUsuario_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            if (Session["usuario"].Equals("admin"))
            {
                MultiView3.ActiveViewIndex = 1;
            }
            else
            {
                MultiView3.ActiveViewIndex = 0;
                ///MostrarPQR();
            }
            MostrarInfoUsuario();

        }
        protected void BtnInformcion_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
        }
        /// <summary>
        /// Metdo encargado de realizar la busqueda de los productos y mostrarlos en el gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "SELECT* FROM [dbo].[PRODUCTOS]";
            var cmd = new SqlCommand(strSQL, SqlConn);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "Productos");
            SqlConn.Close();

            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        /// <summary>
        /// Metodo encargado de subir un nuevo producto a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubir_Click(object sender, EventArgs e)
        {
            string nombreProducto, descripcion, categoria;
            double precio;
            int cantidad;

            nombreProducto = txtNombreProducto.Text;
            descripcion = txtDescripcion.Text;
            precio = double.Parse(txtPrecio.Text);
            cantidad = int.Parse(txtCantidad.Text);

            if (rbPrescripcionregistro.Checked)
            {
                categoria = "Prescripcion";
            }
            else
            {
                categoria = "Venta Libre";
            }
            string imgfile = Path.GetFileName(FileUploadImagen.PostedFile.FileName);
            FileUploadImagen.SaveAs("C:/Users/juand/source/repos/Proyecto Pharmacy Online/Proyecto Pharmacy Online/imagenes/" + imgfile);
            string url = "~/imagenes/" + imgfile;
            imgVistaPrevia.ImageUrl = url;

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "INSERT INTO [dbo].[PRODUCTOS] VALUES (NEWID(),'" + nombreProducto + "', '" + cantidad + "','" + descripcion + "','" + categoria + "','" + url + "','" + precio + "')";
            var cmd = new SqlCommand(strSQL, SqlConn);

            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();

            Thread.Sleep(2500);
            txtNombreProducto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            imgVistaPrevia.ImageUrl = "";
        }

        /// <summary>
        /// Metodo encargado de llenar un gridview con la info del usuario con
        /// el que se inicio sesion
        /// </summary>
        private void MostrarInfoUsuario()
        {
            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);

            var strSQL = "SELECT * from[dbo].[USUARIOS] where usuario = '" + Session["usuario"].ToString() + "'";
            var cmd = new SqlCommand(strSQL, SqlConn);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "infoUsuario");
            SqlConn.Close();

            gvInfoUsuario.DataSource = ds;
            gvInfoUsuario.DataBind();
        }

        /// <summary>
        /// metodo encargado de mostrar las pqr realizadas por el usurio con el que
        /// se inicio sesion
        /// </summary>
        private void MostrarPQR()
        {
            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            string id = Session["IdUsuario"].ToString();

            var strSQL = "SELECT * from [dbo].[PQR] where KF_Usuarioid = '" + Session["IdUsuario"] + "'";
            var cmd = new SqlCommand(strSQL, SqlConn);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "pqr");
            SqlConn.Close();

            gvVerPQR.DataSource = ds;
            gvVerPQR.DataBind();
        }

        /// <summary>
        /// metodo encargado de obtener y almacenar en una variable de sesion 
        /// el idUsuario del ususario con el que se inicio sesion
        /// </summary>
        private void CapVariablesSession()
        {
            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var sqlQuery = "Select Usuarioid from [dbo].[USUARIOS] where usuario = '" + Session["usuario"] + "'";

            var cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            Session["IdUsuario"] = Convert.ToString(cmd.ExecuteScalar()).ToUpper();
            string id = Session["IdUsuario"].ToString();
            cmd.ExecuteNonQuery();

            sqlcon.Close();

        }

        protected void BtnBuscarPQR_Click(object sender, EventArgs e)
        {
            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            string U_busquedaPQR = txtBuscarPQR.Text;

            var sqlQuery = "Select Usuarioid from [dbo].[USUARIOS] where usuario = '" + U_busquedaPQR + "'";

            var cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            string usuarioPQR = Convert.ToString(cmd.ExecuteScalar());

            cmd.ExecuteNonQuery();
            sqlcon.Close();

            var strSQL = "SELECT * from [dbo].[PQR] where KF_Usuarioid = '" + usuarioPQR + "'";
            cmd = new SqlCommand(strSQL, sqlcon);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            sqlcon.Open();
            try
            {
                da.Fill(ds, "pqr");
            }
            catch (Exception)
            {
                
            }
            sqlcon.Close();

            gvBuscarPQR.DataSource = ds;
            gvBuscarPQR.DataBind();
        }
    }
}