﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rEncuesta.aspx.cs" Inherits="EncuestaB0._1._0.Registros.rEncuesta1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Regitros</h3>
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de encuestas</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <%--EncuestasId--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Encuesta Id</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="EncuestaIdTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="EnucestaIdRangeValidator" runat="server" ControlToValidate="EncuestaIdTextBox" ErrorMessage="Ingrese numeros enteros" ForeColor="Red" Type="Integer" MaximumValue="999999" MinimumValue="1"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="EncuestaIdRequiredFieldValidator" runat="server" ErrorMessage="Debe buscar el id" ForeColor="Red" ValidationGroup="A" ControlToValidate="EncuestaIdTextBox"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <asp:Button ID="BuscarButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Buscar" ValidationGroup="A" OnClick="BuscarButton_Click" />
                        </div>
                    </div>
                    <%--Entidad--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Entidad</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="EntidadTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EntidadRequiredFieldValidator" runat="server" ControlToValidate="EntidadTextBox" ErrorMessage="Debe de ingresar la entidad" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                    </div>
                    <%--Descripcion--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Descripcion</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="DescripcionTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="DescripcionRequiredFieldValidator" runat="server" ControlToValidate="DescripcionTextBox" ErrorMessage="Debe ingresar la descripcion" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                    </div>
                    <%--Fecha--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Fecha</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="FechaTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="FechaRequiredFieldValidator" runat="server" ControlToValidate="FechaTextBox" ErrorMessage="Debe ingresar la fecha" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <%--PreguntasCerrada--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Preguntas cerradas </label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:DropDownList ID="PreguntasCerradasDropDownList" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                    <asp:Button ID="AgregarCButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Agregar" OnClick="AgregarCButton_Click" />
                                </div>
                                <div class="col-sm-1 col-xs-1">
                                </div>
                            </div>
                            <%--PreguntasCerradas--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Preguntas Cerradas</label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:GridView ID="PreguntasCerradasGridView" runat="server" Style="margin-top: 7px; margin-bottom: 0px" Width="580px" CssClass="table table-bordered bs-table input-sm" AllowPaging="true" OnRowDeleting="PreguntasCerradasGridView_RowDeleting1">
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                                <div class="auto-style1">
                                </div>
                            </div>
                            <%--PreguntasAbiertas--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Pregunta Abiertas</label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:DropDownList ID="PreguntasAbiertasDropDownList" CssClass="form-control input-sm" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                    <asp:Button ID="AgregarAButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Agregar" OnClick="AgregarAButton_Click" />
                                </div>
                                <div class="col-sm-1 col-xs-1">
                                </div>
                            </div>
                            <%--PreguntasAbiertas--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Preguntas Abiertas</label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:GridView ID="PreguntasAbiertasGridView" runat="server" Style="margin-top: 7px; margin-bottom: 0px" Width="580px" CssClass="table table-bordered bs-table input-sm" AllowPaging="true" OnRowDeleting="PreguntasAbiertasGridView_RowDeleting">
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                                <div class="col-sm-1 col-xs-1">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="page-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button ID="NuevoButton" CssClass="btn btn-default btn-sm" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" CssClass="btn btn-success btn-sm" runat="server" Text="Guardar" ValidationGroup="B" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" CssClass="btn btn-danger btn-sm" runat="server" Text="Eliminar" ValidationGroup="A" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>