<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cEncuestas.aspx.cs" Inherits="EncuestaB0._1._0.Consultas.cEncuestas1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Consultas</h3>
        <div class="panel panel-primary text-center">
            <div class="panel-heading">Consulta de Encuestas</div>
            <div class="panel-body">
                <asp:ScriptManager ID="ConsultaScriptManager" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="ConsultaUpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="form-horizontal" role="form">
                            <%--Campos--%>
                            <label class="col-sm-2 col-xs-2 control-label input-sm ">Filtrar por:</label>
                            <div class="col-sm-3 col-xs-3">
                                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control input-sm" runat="server">
                                    <asp:ListItem>EncuestaId</asp:ListItem>
                                    <asp:ListItem>Entidad</asp:ListItem>
                                    <asp:ListItem>Descripcion</asp:ListItem>
                                    <asp:ListItem>Fecha</asp:ListItem>
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
                            <asp:GridView ID="DatoGridView" runat="server" Style="margin-top: 7px; margin-bottom: 0px" Width="580px" CssClass="table table-bordered bs-table input-sm" AllowPaging="true" EnableSortingAndPagingCallbacks="True" OnPageIndexChanging="DatoGridView_PageIndexChanging">
                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <Columns>
                                    <asp:HyperLinkField DataNavigateUrlFields="EncuestaId" DataNavigateUrlFormatString="~/Publica/Encuestar.aspx?idBuscado={0}" Text="Realizar encuesta" />
                                </Columns>
                                <PagerSettings FirstPageText="Primero" LastPageText="Ultimo" NextPageText="Siguiente" PreviousPageText="Anterior" Mode="NextPrevious" NextPageImageUrl="~/Imagenes/1460333907_next_right.png" PreviousPageImageUrl="~/Imagenes/1460333926_previous_left.png" />
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
