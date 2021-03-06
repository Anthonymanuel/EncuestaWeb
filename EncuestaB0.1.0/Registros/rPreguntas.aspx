﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rPreguntas.aspx.cs" Inherits="EncuestaB0._1._0.Registros.rPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Regitros</h3>
        <div class=" panel panel-primary">
            <div class="panel-heading">Registro de Preguntas</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">

                    <%--PreguntaId--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">PreguntaId</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="PreguntaIdTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="PreguntaIdRangeValidator" runat="server" ControlToValidate="PreguntaIdTextBox" ErrorMessage="Ingrese numero entero solamente" ForeColor="Red" MaximumValue="99999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="PreguntaIdRequiredFieldValidator" runat="server" ErrorMessage="Debe ingresar un id" ControlToValidate="PreguntaIdTextBox" ForeColor="Red" ValidationGroup="C"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <asp:Button ID="BuscarButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" ValidationGroup="C" />
                        </div>
                        <div class="col-sm-1 col-xs-1">
                        </div>
                    </div>
                    <%--Descripcion--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Descripcion</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="DescripcionTextBox" CssClass="form-control input-sm" runat="server" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                        <asp:RequiredFieldValidator ID="DescripcionRequiredFieldValidator" runat="server" ErrorMessage="Ingrese la descripcion" ControlToValidate="DescripcionTextBox" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </div>
                    <%--TipoDePregunta--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Tipo De Pregunta</label>
                        <div class="col-sm-6 col-xs-3">
                            <asp:DropDownList ID="TipoDePreguntaDropDownList" CssClass="form-control input-sm" AutoPostBack="true" runat="server" OnSelectedIndexChanged="TipoDePreguntaDropDownList_SelectedIndexChanged">
                                <asp:ListItem>Abierta</asp:ListItem>
                                <asp:ListItem>Cerrada</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                    </div>
                    <%--TipoDePreguntaCerrada--%>
                    <div class="form-group">
                        <asp:Label ID="Label3" Visible="false" runat="server" CssClass="col-sm-3 col-xs-3 control-label input-sm">TipoDePreguntaCerrada</asp:Label>
                        <div class="col-sm-6 col-xs-3">
                            <asp:DropDownList ID="TipoPreguntaCerradaDropDownList" Visible="false" CssClass="form-control input-sm" runat="server">
                                <asp:ListItem>Dicotómicas</asp:ListItem>
                                <asp:ListItem>Abanico</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                    </div>

                    <asp:ScriptManager ID="RegistroScriptManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="RegistroUpdatePanel" runat="server">
                        <ContentTemplate>
                            <%--Repuestas--%>
                            <div class="form-group">
                                <asp:Label ID="Label2" Visible="false" runat="server" CssClass="col-sm-3 col-xs-3 control-label input-sm">Repuestas</asp:Label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:TextBox ID="RespuestasTextBox" Visible="false" CssClass="form-control input-sm" runat="server" MaxLength="500"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RespuestasRequiredFieldValidator" runat="server" ControlToValidate="RespuestasTextBox" ErrorMessage="Ingrese la respuesta" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                    <asp:Button ID="AgregarButton" CssClass="btn btn-primary btn-sm" Visible="false" runat="server" Text="Agregar" OnClick="AgregarButton_Click" ValidationGroup="B" />
                                </div>
                                <div class="col-sm-1 col-xs-2">
                                </div>
                            </div>
                            <%--RepuestasPosibles--%>
                            <div class="form-group">
                                <asp:Label ID="Label1" Visible="false" runat="server" CssClass="col-sm-3 col-xs-3 control-label input-group-sm">Repuestas Posibles</asp:Label>
                                <div class="col-sm-6 col-xs-6">
                                    <asp:ListBox ID="RespuestasPosiblesListBox" Visible="false" runat="server" CssClass="form-control"></asp:ListBox>
                                    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                    <asp:Button ID="BorrarButton" CssClass="btn btn-danger btn-sm" Visible="false" runat="server" Text="Eliminar" OnClick="BorrarButton_Click" />
                                </div>
                                <div class="col-sm-1 col-xs-1">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="pager-footer">
                        <div class="text-center">
                            <div class="form-group" style="display: inline-block">
                                <asp:Button ID="NuevoButton" CssClass="btn btn-default btn-sm" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                                <asp:Button ID="GuardarButton" CssClass="btn btn-success btn-sm" runat="server" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="A" />
                                <asp:Button ID="EliminarButton" CssClass="btn btn-danger btn-sm" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" ValidationGroup="C" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
