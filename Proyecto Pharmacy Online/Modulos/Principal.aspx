<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Proyecto_Pharmacy_Online.Modulos.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-4.0.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-4.0.0-dist/js/jquery-3.6.0.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/popper.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/bootstrap.min.js"></script>
    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
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
                                <asp:Button ID="Button1" runat="server" Text="Productos " OnClick="Button1_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Carrito-->
                            <li class="nav-item">
                                <asp:Button ID="Button2" runat="server" Text="Carrito" OnClick="Button2_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Usuario-->
                            <li class="nav-item">
                                <asp:Button ID="Button3" runat="server" Text="Usuario" OnClick="Button3_Click" class="btn btn-link btn-menu" />
                            </li>
                            <!--Boton ventana de Informacion-->
                            <li class="nav-item">
                                <asp:Button ID="Button4" runat="server" Text="Acerca de" OnClick="Button4_Click" class="btn btn-link btn-menu" />
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
            <h1>productos</h1>
            <div class="container col-12">
            </div>
        </asp:View>
        <!--Ventana de Carrito-->
        <asp:View ID="View2" runat="server">
            <h1>Carrito</h1>
            <div class="container col-12">
            </div>
        </asp:View>
        <!--Ventana de Usuario-->
        <asp:View ID="View3" runat="server">
            <h1>Usuario</h1>
            <div class="container col-12">
            </div>
        </asp:View>
        <!--Ventana de Informacion-->
        <asp:View ID="View4" runat="server">
            <div class="row">
                <div class="col-lg-1 col-sm-12"></div>
                <div class="col-lg-6 col-sm-12">
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
                    <div class="py-5 text-center container">
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
            <div class="row pt-5">
                <div class="col-lg-12 px-5 text-center">
                    <p class="titulo-informacion px-5">Valores Corporativos</p>
                </div>
            </div>
            <div class="row mx-5 px-5 text-center mb-5">
                    <div class="col-lg-4 col-sm-12 mt-5">
                        <p class="subtitulo-informacion py-4">Integridad</p>
                        <p class="parrafo-informacion px-4">Ser completamente claros con nuestros clientes y nuestros productos para cuidar y mejorar nuestra sociedad.</p>
                        <img src="../imagenes/integridad.png" class="imagen-valores pt-4"/>
                    </div>
                     <div class="col-lg-4 col-sm-12 mt-5">
                          <p class="subtitulo-informacion py-4">Responsabilidad</p>
                          <p class="parrafo-informacion px-4">Siempre ser fieles con nuestras metas propuesta para con nuestros clientes y productores.</p>
                         <img src="../imagenes/responsabilidad.png" class="imagen-valores pt-4"/>
                    </div>
                     <div class="col-lg-4 col-sm-12 mt-5">
                          <p class="subtitulo-informacion py-4">Calidad</p>
                          <p class="parrafo-informacion px-4">Énfasis en que nuestro servicio debe ser el mejor que podamos brindar a todas las personas sin importar quien sea.</p>
                         <img src="../imagenes/certificado.png" class="imagen-valores pt-4"/>
                    </div>
                </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
