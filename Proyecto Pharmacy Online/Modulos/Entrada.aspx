<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage/masterEntrada.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="Proyecto_Pharmacy_Online.Modulos.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../bootstrap-4.0.0-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap-4.0.0-dist/js/jquery-3.6.0.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/bootstrap.min.js"></script>
    <script src="../bootstrap-4.0.0-dist/js/popper.min.js"></script>

    <link href="../Css/StyleSheet1.css" rel="stylesheet" />
    <script src="../JavaScript/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" p-0 m-0 fondo">
        <div class="row text-center m-0 p-0">
            <div class="col-lg-6 col-sm-12 px-0 aparicion-derecha">
                <!--eslogan-->
                <div class="col-12">
                    <div class="container col-8 text-center mt-5 ">
                        <asp:Label ID="Label1" runat="server" Text="Salud y confianza al alcanze de tus manos" Style="font-size: 60px; font-family: 'Harlow Solid'; color: #3667D1; text-shadow: 2px 12px 12px #ffff;"></asp:Label>
                    </div>
                    <!--Imagen-->
                    <div class="container col-8 text-center">
                        <div class="p-0 m-0">
                            <img src="../imagenes/logo.png" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6  col-sm-12 my-5 px-0 align-content-center">
                <!--Ventana Multiple-->
                <asp:MultiView ID="MultiView1" runat="server">
                    <!--Ventana para Iniciar sesion-->
                    <asp:View ID="View1" runat="server">
                        <div class="col-7 container bg-success container-inicio aparicion">
                            <div class="row">
                                <div class="col-12">
                                    <img src="../imagenes/medicine.png" style="height: 80px" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <p class="display-4 titulo-inicio">Iniciar sesion</p>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-12">
                                    <p class="display-3 subtitulo-inicio m-0">Usuario</p>
                                </div>
                            </div>
                            <!--Entrada Usuario-->
                            <div class="row mb-5">
                                <div class="col-6 mx-auto">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="obligatorios" ControlToValidate="txtUsuario" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtUsuario" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-12">
                                    <p class="display-3 subtitulo-inicio m-0">Contraseña</p>
                                </div>
                            </div>
                            <!--Entrada Contraseña-->
                            <div class="row mb-5">
                                <div class="col-6 mx-auto">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="obligatorios" ControlToValidate="txtcontraseña" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtContraseña" runat="server" type="password" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row my-3 text-center">
                                <div class="col-12">
                                    <asp:Button ID="Button1" runat="server" Text=" Iniciar Sesion" class="btn btn-inicio" OnClick="BtnIniciar_Click" ValidationGroup="obligatorios" />
                                </div>
                            </div>
                            <!--Dirigirse a registrarse-->
                            <div class="row my-3">
                                <div class="col-12">
                                    <asp:Button ID="BtnCrearCuenta" runat="server" Text="No Tienes una cuenta? Registrate" CssClass=" btn btn-link link-inicio" OnClick="BtnCrearCuenta_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <!--Ventana para Registar un nuevo usuario-->
                    <asp:View ID="View2" runat="server">
                        <div class="col-10 container bg-success container-inicio pb-2 aparicion">
                            <div class="row">
                                <div class="col-12">
                                    <img src="../imagenes/medicine.png" style="height: 80px" />
                                </div>
                            </div>
                            <div class="row text-center">
                                <div class="col mb-4">
                                    <h1 class="display-3  titulo-inicio ">Crear Cuenta</h1>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Nombre</p>
                                </div>
                                <!--Entrada Nombre-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbNombre" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbNombre" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Apellido</p>
                                </div>
                                <!--Entrada Apellido-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbApellidos" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbApellidos" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Telefono </p>
                                </div>
                                <!--Entrada Telefono-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="tbTelefono" Display="Dynamic" ErrorMessage="Ingrese un numero de telefono valido" MaximumValue="3500000000" MinimumValue="3000000000" ValidationGroup="Registrar" CssClass="validadores"></asp:RangeValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbTelefono" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbTelefono" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Direccion</p>
                                </div>
                                <!--Entrada Direccion-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbDireccion" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbDireccion" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Correo </p>
                                </div>
                                <!--Entrada Correo-->
                                <div class="col-lg-4 col-md-7 col-12">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TbCorreo" Display="Dynamic" ErrorMessage="Ingrese un Correo Valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Registrar" CssClass="validadores"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbCorreo" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbCorreo" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Usuario</p>
                                </div>
                                <!--Entrada Usuario-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbUsuario" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbUsuario" runat="server" class="form-control textbox-inicio"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">contraseña </p>
                                </div>
                                <!--Entrada Contraseña-->
                                <div class="col-lg-4 col-md-7 col-12">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbContraseña" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbContraseña" runat="server" class="form-control textbox-inicio" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 col-md-5 col-12 text-center">
                                    <p class="subtitulo-registro">Repetir contraseña</p>
                                </div>
                                <!--Entrada RepContraseña-->
                                <div class="col-lg-4 col-md-7 col-12 text-center">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbContraseña" ControlToValidate="tbRepContraseña" ErrorMessage="Las contraseñas no coinciden" ValidationGroup="Registrar" Display="Dynamic" CssClass="validadores"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Campo Obligatorio" ValidationGroup="Registrar" ControlToValidate="tbRepContraseña" Display="Dynamic" CssClass="validadores"></asp:RequiredFieldValidator>
                                    <asp:TextBox ID="tbRepContraseña" runat="server" class="form-control textbox-inicio" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row my-3">
                                <div class="col text-center">

                                    <asp:Button ID="Button2" runat="server" Text="Crear Cuenta" class="btn btn-inicio" OnClick="BtnRegistro_Click" ValidationGroup="Registrar" />
                                </div>
                            </div>
                            <div class="row mb-5">
                                <div class="col text-center">
                                    <asp:Button ID="BtnTengoCuenta" runat="server" Text="Tienes una cuenta? Iniciar Sesion" CssClass=" btn btn-link link-inicio" OnClick="BtnTengoCuenta_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
