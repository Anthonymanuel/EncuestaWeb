<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuestar.aspx.cs" Inherits="EncuestaB0._1._0.Encuestar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Encuesta Burgos | Encuestar</title>
    <link href="/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-primary">
            <div class="panel-heading">Encuesta</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">

                    <asp:Repeater ID="TituloRepeater" runat="server">
                        <ItemTemplate>
                            <h1><%#Eval("Descripcion")%></h1>
                            <h1><%#Eval("Entidad")%></h1>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:Repeater ID="PreguntasRepeater" runat="server" OnItemDataBound="PreguntasRepeater_ItemDataBound">
                        <ItemTemplate>
                            <asp:Label ID="PreguntaIdLabel" runat="server" Text='<%#Eval("PreguntaId") %>' Visible="False"></asp:Label>
                            <asp:Label ID="TipoDePreguntaLabel" runat="server" Text='<%#Eval("TipoDePregunta") %>' Visible="False"></asp:Label>
                            <asp:Label ID="SubTipoDePreguntaLabel" runat="server" Text='<%#Eval("SubTipoDePregunta") %>' Visible="False"></asp:Label>
                            <table cellspacing="2" border=" 0">
                                <tr>
                                    <td style="width: 100px;" align="center"><b><%#Eval("Descripcion")%></b></td>
                                </tr>
                                <br />
                                <tr>
                                    <td>
                                        <asp:RadioButtonList runat="server" ID="RespuestasRadioButtonList">
                                        </asp:RadioButtonList>
                                        <asp:CheckBoxList ID="RespuestasCheckBoxList" runat="server">
                                        </asp:CheckBoxList>
                                        <asp:TextBox ID="RespuestasTextBox" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RespuestasRegularExpressionValidator" runat="server" ErrorMessage="Debe de llenar la pregunta" ValidationGroup="A" ForeColor="Red" ControlToValidate="RespuestasTextBox"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <hr />
                            </table>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="page-footer">
                <div class="text-center">
                    <div class="form-group" style="display: inline-block">
                        <asp:Button ID="LlenarButton" CssClass="btn btn-success btn-block" runat="server" Text="Enviar" ValidationGroup="A" OnClick="LlenarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>

