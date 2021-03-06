﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cPreguntas.aspx.cs" Inherits="EncuestaB0._1._0.Consultas.cPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Consultas</h3>
        <div class="panel panel-primary">
            <div class="panel-heading">Consulta de Preguntas</div>
            <div class="panel-body">
                <asp:ScriptManager ID="ConsultaScriptManager" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="ConsultaUpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="form-horizontal" role="form">
                            <%--Campos--%>
                            <label class="col-sm-2 col-xs-2 control-label input-sm ">Filtrar por:</label>
                            <div class="col-sm-3 col-xs-3">
                                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control input-sm" runat="server">
                                    <asp:ListItem>PreguntaId</asp:ListItem>
                                    <asp:ListItem>Descripcion</asp:ListItem>
                                    <asp:ListItem>TipoDePregunta</asp:ListItem>
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
                                <asp:GridView ID="DatoGridView" runat="server" Style="margin-top: 7px; margin-bottom: 0px" Width="580px" CssClass="table table-bordered bs-table input-sm" AllowPaging="true" OnPageIndexChanging="DatoGridView_PageIndexChanging1">
                                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#ffffcc" />
                                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="PreguntaId" DataNavigateUrlFormatString="~/Registros/rPreguntas.aspx?idBuscado={0}" Text="Editar" />
                                    </Columns>
                                    <PagerSettings FirstPageText="Primera" LastPageText="Ultima" Mode="NextPrevious" NextPageText="Siguiente" PreviousPageText="Anterior" LastPageImageUrl="~/Imagenes/1460333907_next_right.png" NextPageImageUrl="~/Imagenes/1460333907_next_right.png" PreviousPageImageUrl="~/Imagenes/1460333926_previous_left.png" />
                                </asp:GridView>
                              </div>
                            <div class="col-sm-3 col-xs-3">
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
