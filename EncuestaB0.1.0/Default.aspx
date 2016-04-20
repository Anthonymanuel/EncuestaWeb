<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EncuestaB0._1._0.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="right_col" role="main">
                <div class="panel panel-primary">
                    <h1 class="panel-heading">Encuesta Burgos</h1>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h3 class="panel-title">Encuestas</h3>
                                    </div>
                                    <asp:Repeater ID="DefaultRepeater" runat="server">

                                        <ItemTemplate>
                                            <h5>Descripcion: <%#Eval("Descripcion")%></h5>
                                            <h5>Entidad: <%#Eval("Entidad")%></h5>
                                            <asp:HyperLink ID="lnkDetails" runat="server" NavigateUrl='<%# Eval("EncuestaId", "~/Publica/Encuestar.aspx?idBuscado={0}") %>'>LLenar</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
     


</asp:Content>
