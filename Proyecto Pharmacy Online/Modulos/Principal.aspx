<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Proyecto_Pharmacy_Online.Modulos.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../bootstrap-4.0.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-4.0.0-dist/js/jquery-3.6.0.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/bootstrap.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/popper.min.js"></script>
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <script src="../JavaScript/JavaScript.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Barra de navegacion-->
    <div class="bg-success m-0 p-0 fijado-arriba">
        <div class="row">
            <div class="col-lg-8 col-sm-0"></div>
            <div class="col-lg-4 col-sm-12">
                <!--Barra de navegación-->
                <nav class="navbar navbar-expand-lg navbar-light bg-success py-0">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav">
                            <!--Boton ventana de Productos-->
                            <li class="nav-item">
                                <asp:Button ID="BtnProductos" runat="server" Text="Productos " OnClick="BtnProductos_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Carrito-->
                            <li class="nav-item">
                                <asp:Button ID="BtnCarrito" runat="server" Text="Carrito" OnClick="BtnCarrito_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Usuario-->
                            <li class="nav-item">
                                <asp:Button ID="BtnUsuario" runat="server" Text="Usuario" OnClick="BtnUsuario_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Informacion-->
                            <li class="nav-item">
                                <asp:Button ID="BtnInformcion" runat="server" Text="Acerca de" OnClick="BtnInformcion_Click" class="btn btn-link btn-menu" />
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
        </div>
    </div>
    <!--Ventana Multiple-->
    <asp:MultiView ID="MultiView1" runat="server">
        <!--Ventana de Productos-->
        <asp:View ID="View1" runat="server">
            <div class="col-12 mt-5 px-5">
                <div class="row text-center">
                    <div class="col-12">
                        <p class="subtitulo-informacion">Productos</p>
                    </div>
                </div>
                <!--Busuqeda de Productos-->
                <asp:MultiView ID="MultiView2" runat="server">
                    <!--Ventana de Usuarios-->
                    <asp:View ID="View5" runat="server">
                        <div class="mt-3 text-center">
                            <div class="row align-content-center mb-5">
                                <div class="col-lg-2 col-sm-1"></div>
                                <div class="col-lg-8 col-sm-10">
                                    <div class="row">
                                        <div class="col-6">
                                            <div class="row">
                                                <div class="col-3">
                                                    <p class="subtitulo-registro d-inline">Buscar:</p>
                                                </div>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtBusquedaProductos" runat="server" class="form-control textbox-inicio d-inline"></asp:TextBox>

                                                </div>
                                                <div class="col-2">
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-6">
                                            <p class="subtitulo-registro d-inline">Categoria:</p>
                                            <asp:RadioButton ID="rbVentaLibre" runat="server" Text="Venta Libre" GroupName="Categoria" class="subtitulo-registro ml-3" />
                                            <asp:RadioButton ID="rbPrescripcion" runat="server" Text="Prescripcion" GroupName="Categoria" class="subtitulo-registro ml-3" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-sm-1"></div>
                            </div>
                        </div>
                        <div class="mx-5 px-5">
                            <div class="row">
                                <div class="bg-success px-3">
                                    <asp:DataList ID="DataList1" runat="server" RepeatColumns="2">
                                        <ItemTemplate>
                                            <div class="subtitulo-registro d-inline">
                                                <asp:Label ID="Label11" runat="server" Text="Nombre:"></asp:Label>
                                            </div>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("NombreP") %>'></asp:Label>
                                            <div class="subtitulo-registro">
                                                <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
                                            </div>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                            <div class="subtitulo-registro">
                                                <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
                                            </div>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                                            <div class="subtitulo-registro">
                                                <asp:Label ID="Label4" runat="server" Text="precio:"></asp:Label>
                                            </div>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Precio") %>'></asp:Label>
                                            <div class="subtitulo-registro">
                                                <asp:Label ID="Label5" runat="server" Text="Categoria:"></asp:Label>
                                            </div>
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Categoria") %>'></asp:Label>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Foto") %>' class="imagen-productos" />
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <!--Ventana de Administrador-->
                    <asp:View ID="View6" runat="server">
                        <div>
                            <div class="row text-center">
                                <div class="col-12">
                                    <p class="subtitulo-informacion">Agregar Productos</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="">
                                    <asp:TextBox ID="txtNombreProducto" runat="server" placeholder="nombre"></asp:TextBox>
                                    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="descripción"></asp:TextBox>
                                    <asp:TextBox ID="txtPrecio" runat="server" placeholder="precio"></asp:TextBox>
                                    <asp:TextBox ID="txtCantidad" runat="server" placeholder="cantidad"></asp:TextBox>
                                    <p>En venta</p>
                                    <asp:RadioButton ID="rbPrescripcionregistro" runat="server" GroupName="EnVenta" Text="Si" />
                                    <asp:RadioButton ID="rbVentaLibreregistro" runat="server" GroupName="EnVenta" Text="No" />
                                    <asp:FileUpload ID="FileUploadImagen" runat="server" />
                                    <asp:Button ID="btnSubir" runat="server" Text="subir producto" OnClick="BtnSubir_Click" />
                                    <asp:Image ID="imgVistaPrevia" runat="server" css="imagen" />
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </asp:View>
        <!--Ventana de Carrito-->
        <asp:View ID="View2" runat="server">
            <div class="container col-12">
                <p>productos seleccionados</p>
                <p>realizar compra</p>
            </div>
        </asp:View>
        <!--Ventana de Usuario-->
        <asp:View ID="View3" runat="server">
            <div class="container col-12 mt-5 px-5">
                <!--Informacion del Usuario-->
                <div class="mt-5 text-center">
                    <div class="row mb-5 text-center">
                        <div class="col-12">
                            <p class="subtitulo-informacion">Informacion del Usuario</p>
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <div class="col-lg-5 col-sm-10">
                            <div class="text-left px-auto">
                                <asp:GridView ID="gvInfoUsuario" runat="server" AutoGenerateColumns="False" ShowHeader="False" class="col-12" BorderWidth="0">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="text-center">
                                                    <div class="row">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label12" runat="server" Text="Nombre : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("nombre") %> ' CssClass="datos-usuario"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row py-2">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label1" runat="server" Text="Apellido : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("apellido") %> ' CssClass="datos-usuario"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row py-2">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label15" runat="server" Text="Telefono : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label16" runat="server" Text='<%# Eval("telefono") %>' CssClass="datos-usuario"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row py-2">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label17" runat="server" Text="Direccion : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("direccion") %> ' CssClass="datos-usuario"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row py-2">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label19" runat="server" Text="Usuario : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("usuario") %> ' CssClass="datos-usuario"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row py-2">
                                                        <div class="col-6">
                                                            <asp:Label ID="Label21" runat="server" Text="Correo : " CssClass="subtitulo-usuario"></asp:Label>
                                                        </div>
                                                        <div class="col-6">
                                                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("correo") %> ' CssClass="datos-usuario"></asp:Label>
                                                        </div>

                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Historial de Compras-->
                <div class="mt-5 text-center">
                    <div class="row">
                        <div class="col-12">
                            <p class="subtitulo-informacion">Historial de compras</p>
                        </div>
                        <div class=""></div>
                    </div>
                </div>
                <!--Ingresar Sugerencias-->
                <div class="mt-5 text-center">
                    <div class="row">
                        <div class="col-12">
                            <p class="subtitulo-informacion">Peticiones - Quejas - Reclamos</p>
                        </div>
                        <div class=" col-12">
                            <!--Ventana multiple PQR-->
                            <asp:MultiView ID="MultiView3" runat="server">
                                <!--Ventana Usuario-->
                                <asp:View ID="View7" runat="server">
                                    <asp:GridView ID="gvVerPQR" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="Label23" runat="server" Text="Nombre"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="Label24" runat="server" Text='<%# Eval("NombrePQR") %>'></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="Label25" runat="server" Text="Descripcion"></asp:Label>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="Label26" runat="server" Text='<%# Eval("DescripcionPQR") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <!---Ventana Administrador-->
                                <asp:View ID="View8" runat="server" >
                                    <div class="mt-5">
                                        <div class="row">
                                            <div class="col-1"></div>
                                            <div class="col-10 text-center">
                                                <div class="row">
                                                    <div class="col-4">
                                                        <p>Buscar:</p>
                                                    </div>
                                                    <div class="col-6">
                                                        <asp:TextBox ID="txtBuscarPQR" runat="server" placeholder="Inserte Usuario"></asp:TextBox>
                                                    </div>
                                                    <div class="col-2">
                                                        <asp:Button ID="BtnBuscarPQR" runat="server" Text="Buscar" OnClick="BtnBuscarPQR_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-1"></div>
                                        </div>
                                        <div class="row justify-content-center">
                                            <div class="col-8">
                                                <asp:GridView ID="gvBuscarPQR" runat="server"></asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <!--Ventana de Informacion-->
        <asp:View ID="View4" runat="server">
            <div>
                <div class="row">
                    <div class="col-lg-1 col-sm-12"></div>
                    <div class="col-lg-6 col-sm-12 aparicion-derecha">
                        <div class="container container-informacion text-center py-5">
                            <!--Mision y Vision-->
                            <div class="row">
                                <div class="col-12 mb-5">
                                    <p class="titulo-informacion">Acerca de Nosotros</p>
                                </div>
                            </div>
                            <!--Mision-->
                            <div class="row">
                                <div class="col-lg-3 col-sm-12 align-self-center">
                                    <p class="subtitulo-informacion">Mision</p>
                                </div>
                                <div class="col-lg-9 col-sm-12 pr-5">
                                    <p class="parrafo-informacion">
                                        " Ser una droguería comprometida con nuestros clientes para brindar medicamentos de manera rápida y segura en la ciudad de cali  para tener una comunidad  sana y segura en todo los aspectos de la vida actual. "
                                    </p>
                                </div>
                            </div>
                            <!--Vision-->
                            <div class="row my-5">
                                <div class="col-lg-3 col-sm-12 align-self-center">
                                    <p class="subtitulo-informacion">Vision</p>
                                </div>
                                <div class="col-lg-9 col-sm-12 pr-5">
                                    <p class="parrafo-informacion">
                                        " MEDICAL-EXPRESS irá a la cabeza en el mercado de los medicamentos  por su servicio rápidoy eficaz en toda la ciudad de cali con una amplia selección de productos para cubrir todaslas necesidades médicas de nuestros clientes. "
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-5 col-sm-12 pt-5">
                        <div class="py-5 text-center container aparicion-izquierda">
                            <img src="../imagenes/doctore.png" class="imagen-info" />
                        </div>
                    </div>
                </div>
                <!--Separador pag-->
                <div class="row">
                    <div class="col-12 px-5 my-5">
                        <div class="separador bg-success"></div>
                    </div>
                </div>
                <!--Valores corporativos-->
                <div class="my-5">
                    <div class="">
                        <div class="row pt-5">
                            <div class="col-lg-12 px-5 text-center animacion-abajo">
                                <p class="titulo-informacion px-5">Valores Corporativos</p>
                            </div>
                        </div>
                        <div class="row mx-5 px-5 text-center mb-5 animacion-abajo">
                            <div class="col-lg-4 col-sm-12 mt-5">
                                <p class="subtitulo-informacion py-4">Integridad</p>
                                <p class="parrafo-informacion px-4">Ser completamente claros con nuestros clientes y nuestros productos para cuidar y mejorar nuestra sociedad.</p>
                                <img src="../imagenes/integridad.png" class="imagen-valores pt-4" />
                            </div>
                            <div class="col-lg-4 col-sm-12 mt-5">
                                <p class="subtitulo-informacion py-4">Responsabilidad</p>
                                <p class="parrafo-informacion px-4">Siempre ser fieles con nuestras metas propuesta para con nuestros clientes y productores.</p>
                                <img src="../imagenes/responsabilidad.png" class="imagen-valores pt-4" />
                            </div>
                            <div class="col-lg-4 col-sm-12 mt-5">
                                <p class="subtitulo-informacion py-4">Calidad</p>
                                <p class="parrafo-informacion px-4">Énfasis en que nuestro servicio debe ser el mejor que podamos brindar a todas las personas sin importar quien sea.</p>
                                <img src="../imagenes/certificado.png" class="imagen-valores pt-4" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
