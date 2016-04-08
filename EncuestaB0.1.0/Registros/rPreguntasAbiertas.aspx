<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rPreguntasAbiertas.aspx.cs" Inherits="EncuestaB0._1._0.Registros.rPreguntasAbiertas1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Regitros</h3>
        <div class="panel panel-primary">
            <div class="panel-heading">Registro de preguntas abiertas</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <%--PreguntaAbiertaId--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Preguna Abierta Id</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="PreguntaAbiertaIdTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                            <asp:RangeValidator ID="PreguntaAbiertaIdRangeValidator" runat="server" ControlToValidate="PreguntaAbiertaIdTextBox" ErrorMessage="Ingrese numero entero solamente " ForeColor="Red" MaximumValue="99999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                            <asp:RequiredFieldValidator ID="IdRequiredFieldValidator" runat="server" ControlToValidate="PreguntaAbiertaIdTextBox" ErrorMessage="Ingrese un id" ForeColor="Red" ValidationGroup="B"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-sm-2 col-xs-2">
                            <asp:Button ID="BuscarButton" CssClass="btn btn-primary btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" ValidationGroup="B" />
                        </div>
                    </div>
                    <%--Descricpcion--%>
                    <div class="form-group">
                        <label class="col-sm-3 col-xs-3 control-label input-sm">Descripcion</label>
                        <div class="col-sm-6 col-xs-6">
                            <asp:TextBox ID="DescricpionTextBox" CssClass="form-control input-sm" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </div>
                        <div class="col-sm-3 col-xs-3">
                        </div>
                        <asp:RequiredFieldValidator ID="DescricpionRequiredFieldValidator" runat="server" ControlToValidate="DescricpionTextBox" ErrorMessage="Ingrese la descripcion" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    </div>

                </div>
            </div>
            <div class="page-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button ID="NuevoButton" CssClass="btn btn-default btn-sm" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" CssClass="btn btn-success btn-sm" runat="server" Text="Guardar" OnClick="GuardarButton_Click" ValidationGroup="A" />
                        <asp:Button ID="EliminarButton" CssClass="btn btn-danger btn-sm" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" ValidationGroup="B" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
