<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuestar.aspx.cs" Inherits="EncuestaB0._1._0.Encuestar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    
                    <asp:Label ID="PreguntaLabel" Text='<%# Eval("Descripcion  ")%>' runat="server"></asp:Label>
                    <asp:RadioButtonList ID="Respuestas" runat="server" DataTextField='<%# Eval("Descripcion  ")%>' DataValueField='<%# Eval("Descripcion")%>' RepeatLayout="table">
                        <asp:ListItem Text=""></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RadioButton ID="RadioButton1" text='<%# Eval("Descripcion  ")%>'  runat="server" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem></asp:ListItem>
        </asp:RadioButtonList>
    </form>
</body>
</html>
