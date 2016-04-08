<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EncuestaB0._1._0.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/toastr.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-2.2.0.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div id="login-overlay" class="modal-dialog ">
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-6">
                            <div class="well">

                                <div class="form-group">
                                    <label for="usuario" class="control-label">Usuario</label>
                                    <asp:TextBox ID="EmailTextBox" class="form-control" runat="server" placeholder="example@gmail.com" MaxLength="40"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UsuarioRequiredFieldValidator" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="Debe llenar el nombre usuario" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <span class="help-block"></span>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="control-label">Password</label>
                                    <asp:TextBox ID="ContrasenaTextBox" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContrasenaTextBox" ErrorMessage="Debe introducir su contreña" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <span class="help-block"></span>
                                </div>
                                <div class="checkbox">
                                    <label class="control-label">
                                        <asp:CheckBox ID="RecordarmeCheckBox" runat="server" />Recordarme
                                    </label>
                                </div>
                                <asp:Button ID="LoginButton" class="btn btn-success btn-block" runat="server" Text="Login" OnClick="LoginButton_Click" ValidationGroup="A" />
                                <div class="separator">
                                    <p class="change_link">
                                        
                                        <a href="rUsuarios.aspx" class="to_register">Registrarse </a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#form1').bootstrapValidator({
                message: 'This value is not valid',
                container: 'tooltip',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {


                    EmailTextBox: {
                        container: 'popover',
                        validators: {
                            emailAddress: {
                                message: 'ingrese un email valido'
                            }
                        }
                    },

                    gender: {
                        validators: {
                            notEmpty: {
                                message: 'The gender is required'
                            }
                        }
                    }
                }
            });
        });
</script>
</body>
</html>
