using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web.UI.WebControls;

namespace Proyecto_Pharmacy_Online.Modulos
{
    public partial class WebForm3 : System.Web.UI.Page
    {


        static int carrito;
        bool firstTimeSession = false;
        bool canSetValue = true;
        //int noHistorial = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            CapVariablesSession();
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                Session["firstTime"] = true;
                //CapNumeroCarrito();
                AumentarCarrito();
            }
            else
            {
                //CapNumeroCarrito();
                //AumentarCarrito();

            }
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("../Modulos/Entrada.aspx");

                }
                if (Session["usuario"].Equals("admin"))
                {
                    MultiView2.ActiveViewIndex = 1;
                    BtnCarrito.Visible = false;
                    MostrarProductosAdmin();
                }
                else
                {
                    MultiView2.ActiveViewIndex = 0;
                    MostrarProductos();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Tiempo exedido su session se cerro");
            }





            ////easter egg
            if ((bool)Session["firstTime"])
            {
                //AumentarCarrito();
                //Session["firstTime"] = false;
                canSetValue = false;
            }


            //Response.Write(Session["nocarrito"].ToString());
        }

        protected void BtnProductos_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            //CapNumeroCarrito();
            //AumentarCarrito();
            //Response.Write(carrito.ToString());
            //MostrarProductos();

        }
        protected void BtnCarrito_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            MostrarCarrito();
            lbnoproductos.Text = "No se han seleccionado productos";
            if (gvCarrito.Rows.Count == 0)
            {
                btnPedido.Enabled = false;
                lbnoproductos.Visible = true;
            }
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
                //MostrarPQR();
            }
            MostrarInfoUsuario();
            //MostrarHistorial();

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
        /// 
        private void MostrarProductos()
        {
            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "SELECT * FROM [dbo].[PRODUCTOS] where Cantidad > 0";
            var cmd = new SqlCommand(strSQL, SqlConn);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "Productos");
            SqlConn.Close();

            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        private void MostrarProductosAdmin()
        {
            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "SELECT * FROM [dbo].[PRODUCTOS]";
            var cmd = new SqlCommand(strSQL, SqlConn);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "Productos");
            SqlConn.Close();

            dtProductosAdmin.DataSource = ds;
            dtProductosAdmin.DataBind();
        }
        /// <summary>
        /// Metodo encargado de realizar la busqueda de los productos en la base de ddatos 
        /// y mostrarlos en un datalist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string categoria;
            string busqueda = txtBusquedaProductos.Text;

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);

            var strSQL = "";

            //if (busqueda.Equals(""))
            //{
            //    strSQL = "SELECT * FROM [dbo].[PRODUCTOS]";
            //}
            if (rbSinCategoria.Checked && busqueda.Equals(""))
            {
                strSQL = "SELECT * FROM [dbo].[PRODUCTOS]";
            }
            if (rbVentaLibre.Checked && busqueda.Equals(""))
            {
                categoria = "Venta Libre";
                strSQL = "SELECT * FROM [dbo].[PRODUCTOS] Where Categoria = '" + categoria + "'";
            }
            if (rbPrescripcion.Checked && busqueda.Equals(""))
            {
                categoria = "Prescripcion";
                strSQL = "SELECT * FROM [dbo].[PRODUCTOS] Where Categoria = '" + categoria + "'";
            }
            if (rbPrescripcion.Checked && !busqueda.Equals(""))
            {
                categoria = "Prescripcion";
                strSQL = "SELECT * FROM [dbo].[PRODUCTOS] Where NombreP = '" + busqueda + "' and Categoria = '" + categoria + "'";
            }
            if (rbVentaLibre.Checked && !busqueda.Equals(""))
            {
                categoria = "Venta Libre";
                strSQL = "SELECT * FROM [dbo].[PRODUCTOS] Where NombreP = '" + busqueda + "' and Categoria = '" + categoria + "'";
            }

            var cmd = new SqlCommand(strSQL, SqlConn);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            try
            {
                da.Fill(ds, "Productos");
            }
            catch (Exception)
            {

            }
            SqlConn.Close();

            DataList1.DataSource = ds;
            DataList1.DataBind();

            txtBusquedaProductos.Text = "";
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


            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var sqlQuery = "Select NombreP from [dbo].[PRODUCTOS] where nombrep = '" + nombreProducto + "'";

            var cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            string nombre = Convert.ToString(cmd.ExecuteScalar());
            string id = Session["IdUsuario"].ToString();
            cmd.ExecuteNonQuery();
            sqlcon.Close();


            if (!nombreProducto.Equals(nombre))
            {
                var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
                var strSQL = "INSERT INTO [dbo].[PRODUCTOS] VALUES (NEWID(),'" + nombreProducto + "', '" + cantidad + "','" + descripcion + "','" + categoria + "','" + url + "','" + precio + "')";
                cmd = new SqlCommand(strSQL, SqlConn);

                SqlConn.Open();
                cmd.ExecuteNonQuery();
                SqlConn.Close();

                txtNombreProducto.Text = "";
                txtDescripcion.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";
            }
            else
            {
                lbproductoexiste.Visible = true;
            }
            MostrarProductosAdmin();
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
            string id = Session["idUsuario"].ToString();

            var strSQL = "SELECT * from [dbo].[PQR] where KF_Usuarioid = '" + Session["idUsuario"] + "'";
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
        /// <summary>
        /// metodo que le permite l administrador buscar las pqr por nombre el usuario que la
        /// genero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            var strSQL = "";

            if (U_busquedaPQR.Equals(""))
            {
                strSQL = "SELECT* from[dbo].[PQR] INNER JOIN[dbo].[USUARIOS] ON PQR.KF_Usuarioid = USUARIOS.Usuarioid";
            }
            if (!U_busquedaPQR.Equals(""))
            {
                strSQL = "SELECT * from [dbo].[PQR] INNER JOIN  [dbo].[USUARIOS] ON  PQR.KF_Usuarioid = USUARIOS.Usuarioid where Usuarioid = '" + usuarioPQR + "'";
            }
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
        /// <summary>
        /// Metodo encargado de capturar la info de un producto
        /// y añadirlo a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubirPQR_Click(object sender, EventArgs e)
        {
            string MotivoPQR = txtNombrePqr.Text;
            string descripcionPQR = txtDescripcionPQR.Text;

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "INSERT INTO [dbo].[PQR] VALUES (NEWID(),'" + MotivoPQR + "','" + descripcionPQR + "','" + Session["IdUsuario"].ToString() + "')";
            var cmd = new SqlCommand(strSQL, SqlConn);

            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();

            Thread.Sleep(1000);
            txtDescripcionPQR.Text = "";
            txtNombrePqr.Text = "";
        }

        /// <summary>
        /// Metodo encargado de capturar la informacion de que producto y que cantidad añadir al carrrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAñadiralCarrito_Click(object sender, EventArgs e)
        {
            Button agregar = (Button)sender;
            DataListItem fila = (DataListItem)agregar.Parent;

            Label nombreP = (Label)fila.Controls[4];
            Label precio = (Label)fila.Controls[13];
            TextBox cantidad = (TextBox)fila.Controls[21];
            //Response.Write(cantidad.Text);
            if (cantidad.Text.Equals(""))
            {
                cantidad.Text = "1";
            }
            double precioT = double.Parse(precio.Text) * int.Parse(cantidad.Text);

            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var sqlQuery = "Select Productoid from [dbo].[PRODUCTOS] where nombreP = '" + nombreP.Text + "'";

            var cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            Session["productoid"] = Convert.ToString(cmd.ExecuteScalar());
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            sqlQuery = "Select Cantidad from [dbo].[PRODUCTOS] where Productoid = '" + Session["productoid"] + "'";

            cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            int cantdisponible = int.Parse(Convert.ToString(cmd.ExecuteScalar()));
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (cantdisponible > int.Parse(cantidad.Text) && int.Parse(cantidad.Text) > 0)
            {
                sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
                sqlQuery = "Select Productoid from [dbo].[PRODUCTOS] where nombreP = '" + nombreP.Text + "'";

                cmd = new SqlCommand(sqlQuery, sqlcon);
                sqlcon.Open();
                Session["productoid"] = Convert.ToString(cmd.ExecuteScalar());
                cmd.ExecuteNonQuery();
                sqlcon.Close();


                var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
                var strSQL = "INSERT INTO [dbo].[CARRITOS] VALUES (NEWID(),'" + cantidad.Text + "','" + precioT + "','" + (int)Session["nocarrito"] + "','" + Session["productoid"].ToString() + "','" + Session["Idusuario"].ToString() + "')";
                cmd = new SqlCommand(strSQL, SqlConn);

                SqlConn.Open();
                cmd.ExecuteNonQuery();
                SqlConn.Close();

                SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
                strSQL = "DECLARE @residue INT; set @residue = (SELECT(select Cantidad from PRODUCTOS where Productoid = '" + Session["productoid"] + "') - (select CantProductosComprados from CARRITOS where KF_Productosid = '" + Session["productoid"] + "' and NoCarrito = '" + (int)Session["nocarrito"] + "')); UPDATE[dbo].[PRODUCTOS] SET Cantidad = @residue WHERE Productoid = '" + Session["productoid"] + "' ";
                cmd = new SqlCommand(strSQL, SqlConn);

                SqlConn.Open();
                cmd.ExecuteNonQuery();
                SqlConn.Close();
                lbnoproductos.Visible = false;
                btnPedido.Enabled = true;
                cantnodisp.Visible = false;
            }
            else
            {
                cantnodisp.Visible = true;
            }
            MostrarProductos();
        }


        /// <summary>
        /// Metodo encargado de restar en uno el contador de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            Button agregar = (Button)sender;
            DataListItem fila = (DataListItem)agregar.Parent;

            TextBox cantidadP = (TextBox)fila.Controls[22];

            string a = cantidadP.Text;
            int cantidad = 0;
            if (a.Equals("")) cantidadP.Text = "0";

            cantidad = int.Parse(cantidadP.Text);
            cantidad--;
            cantidadP.Text = cantidad + "";
            string x = cantidadP.Text;

        }
        /// <summary>
        /// Metodo encargado de sumar en uno el contador de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAñadirProducto_Click(object sender, EventArgs e)
        {
            string a = DataList1.SelectedItem.FindControl("txtCantidad").ToString();
            int cantidad = 0;
            if (a.Equals("")) txtBusquedaProductos.Text = "0";

            cantidad = int.Parse(txtBusquedaProductos.Text);
            cantidad++;
            txtBusquedaProductos.Text = cantidad + "";
        }

        private void MostrarCarrito()
        {
            double valorcompra = 0;

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            string id = Session["idUsuario"].ToString();

            var strSQL = "SELECT * FROM (([dbo].[CARRITOS] INNER JOIN [dbo].[PRODUCTOS] ON CARRITOS.KF_Productosid = PRODUCTOS.Productoid) INNER JOIN [dbo].[USUARIOS] ON CARRITOS.KF_Usuarioid = USUARIOS.Usuarioid) where KF_Usuarioid = '" + Session["IdUsuario"] + "' AND NoCarrito = '" + (int)Session["nocarrito"] + "'";
            var cmd = new SqlCommand(strSQL, SqlConn);
            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);

            SqlConn.Open();
            da.Fill(ds, "carritos");
            SqlConn.Close();

            gvCarrito.DataSource = ds;
            gvCarrito.DataBind();

            var sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var sqlQuery = "SELECT SUM(PrecioTPdtsComprados) AS TotalItemsOrdered FROM [dbo].[CARRITOS] WHERE NoCarrito = '" + (int)Session["nocarrito"] + "'";
            cmd = new SqlCommand(sqlQuery, sqlcon);
            sqlcon.Open();
            try
            {
                valorcompra = double.Parse(Convert.ToString(cmd.ExecuteScalar()).ToUpper());
            }
            catch (Exception)
            {

            }

            cmd.ExecuteNonQuery();
            sqlcon.Close();
            lbValorcompra.Text = "$" + valorcompra;

        }

        protected void btnEliminarP_Click(object sender, EventArgs e)
        {
            Button agregar = (Button)sender;
            DataControlFieldCell fila = (DataControlFieldCell)agregar.Parent;

            Label producto = (Label)fila.Controls[1];


            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "DECLARE @residue int; set @residue = (SELECT(select Cantidad from PRODUCTOS where Productoid = '" + producto.Text + "') + (select CantProductosComprados from CARRITOS where KF_Productosid = '" + producto.Text + "' and NoCarrito = '" + (int)Session["nocarrito"] + "')); UPDATE[dbo].[PRODUCTOS] SET Cantidad = @residue WHERE Productoid = '" + producto.Text + "'";
            var cmd = new SqlCommand(strSQL, SqlConn);

            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();
            MostrarCarrito();

            SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            strSQL = "DELETE FROM [dbo].[CARRITOS]  WHERE KF_Productosid ='" + producto.Text + "'";
            cmd = new SqlCommand(strSQL, SqlConn);

            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();
            MostrarCarrito();
            if (gvCarrito.Rows.Count == 0)
            {
                btnPedido.Enabled = false;
                lbnoproductos.Visible = true;
            }

        }

        private void AumentarCarrito()
        {
            //carrito++;
            if (!Session["usuario"].ToString().Equals("admin"))
                Session["nocarrito"] = (int)Session["nocarrito"] + 1;
            //Response.Write(carrito.ToString());
        }

        protected void BtnPedido_Click(object sender, EventArgs e)
        {
            //string KF_carritoid = "";
            //DateTime fecha = DateTime.Now;

            //var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            //var strSQL = "INSERT INTO [dbo].[PQR] VALUES (NEWID(),'" + fecha + "','" + noHistorial + "','" + KF_carritoid + " ')";
            //var cmd = new SqlCommand(strSQL, SqlConn);

            //SqlConn.Open();
            //cmd.ExecuteNonQuery();
            //SqlConn.Close();

            //CapNumeroCarrito();

            AumentarCarrito();
            MostrarCarrito();
            lbnoproductos.Text = "Compra Realizada con exito";
            lbnoproductos.Visible = true;
            btnPedido.Enabled = false;
        }

        protected void BtnEliminarstock_Click(object sender, EventArgs e)
        {
            Button agregar = (Button)sender;
            DataListItem fila = (DataListItem)agregar.Parent;

            Label nombreP = (Label)fila.Controls[4];
            Label precio = (Label)fila.Controls[13];

            var SqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString);
            var strSQL = "DELETE FROM [dbo].[PRODUCTOS] WHERE NombreP = '" + nombreP.Text + "'";
            var cmd = new SqlCommand(strSQL, SqlConn);

            SqlConn.Open();
            cmd.ExecuteNonQuery();
            SqlConn.Close();
            MostrarProductosAdmin();
        }

    }
}