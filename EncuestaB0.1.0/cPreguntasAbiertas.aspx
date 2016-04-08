<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cPreguntasAbiertas.aspx.cs" Inherits="EncuestaB0._1._0.Consultas.cPreguntasAbiertas1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <h3><i class="fa fa-angle-right"></i>Consultas</h3>
            <div class="panel panel-primary">
                <div class="panel-heading">Consulta de Preguntas abiertas</div>
                <div class="panel-body">
                    <asp:ScriptManager ID="ConsultaScriptManager" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="ConsultaUpdatePanel" runat="server">
                        <ContentTemplate>

                            <div class="form-horizontal" role="form">
                                <%--Campos--%>
                                <label class="col-sm-2 col-xs-2 control-label input-sm ">Filtrar por:</label>
                                <div class="col-sm-3 col-xs-3">
                                    <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control input-sm" runat="server">
                                        <asp:ListItem>PreguntaAbiertaId</asp:ListItem>
                                        <asp:ListItem>Descripcion</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-4 col-xs-4">
                                    <asp:TextBox ID="CampoTextBox" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                    <asp:Button ID="BuscarButton" CssClass="btn btn-primary btn-sm " runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </div>
                                <div class="col-sm-1 col-xs-1">
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-2 col-xs-2">
                                </div>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:GridView ID="DatoGridView" runat="server" Style="margin-top: 7px; margin-bottom: 0px" Width="580px" CssClass="table table-bordered bs-table input-sm" AllowPaging="true">
                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#ffffcc" />
                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="PreguntaAbiertaId" DataNavigateUrlFormatString="~/rPreguntasAbiertas.aspx?idBuscado={0}" Text="Editar" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col-sm-3 col-xs-3">
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>
    </section>
</asp:Content>
