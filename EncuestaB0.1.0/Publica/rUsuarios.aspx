<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="EncuestaB0._1._0.Registros.rUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="/css/bootstrap.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="../vendor/bootstrap/css/bootstrap.css" />
    <link rel="stylesheet" href="../dist1/css/bootstrapValidator.css" />
    <script type="text/javascript" src="../vendor/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../dist1/js/bootstrapValidator.js"></script>
</head>
<body>
    <form id="Usuarioform" runat="server">
        
        <div class="right_col" role="main">
            <div class="clearfix"></div>
            <div class="row">
                <div class="panel panel-primary">
                    <div class="panel-heading">Registro de usuarios</div>
                    <div class="panel-body">
                        <div class="form-horizontal " role="form">
                            <%--NombreUsuario--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Nombre Usuario</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control input-sm" placeholder="Juan24" MaxLength="50"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--Nombres--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Nombres</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="NombresTextBox" runat="server" CssClass="form-control input-sm" placeholder="Juan" MaxLength="70"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--Apellidos--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Apellidos</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="ApellidosTextBox" runat="server" CssClass="form-control input-sm" placeholder="Perez" MaxLength="70"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--EmailTextBox--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Email</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control input-sm" placeholder="Ejemplo@hotmai.com"  MaxLength="70"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--Contrasena--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Contraseña</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control input-sm" TextMode="Password" MaxLength="40"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--ConfirmarContrasena--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Confirmar Contraseña</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="ConfirmarContrasenaTextBox" runat="server" CssClass="form-control input-sm"  TextMode="Password" MaxLength="40"></asp:TextBox>
                                </div>
                            </div>

                            <%--Telefono--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Telefono</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control input-sm" placeholder="809-290-1111" MaxLength="15"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>

                            <%--FechaIncio--%>
                            <div class="form-group">
                                <label class="col-sm-3 col-xs-3 control-label input-sm">Fecha Inicio</label>
                                <div class="col-sm-7 col-xs-7">
                                    <asp:TextBox ID="FechaInicioTextBox" runat="server" CssClass="glyphicon-time form-control input-sm"  data-format="dd/MM/yyyy"></asp:TextBox>
                                </div>
                                <div class="col-sm-2 col-xs-2">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="page-footer">
                        <div class="text-center">
                            <div class="form-group" style="display: inline-block">
                                <asp:Button ID="RegistrarseButton" CssClass="btn btn-success btn-sm" runat="server" Text="Registrarse" OnClick="RegistrarseButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#Usuarioform')
                .bootstrapValidator({
                    message: 'This value is not valid',
                    container: 'tooltip',
                    feedbackIcons: {
                        valid: 'glyphicon glyphicon-ok',
                        invalid: 'glyphicon glyphicon-remove',
                        validating: 'glyphicon glyphicon-refresh'
                    },
                    fields: {
                        NombresTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese sus nombres'
                                }
                            }
                        },
                        ApellidosTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese sus apellidos'
                                }
                            }
                        },
                        TelefonoTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese su telefono'
                                }
                            }
                        },
                        NombreUsuarioTextBox: {
                            message: 'El nombre del usuario no es válido',
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese su nombre de usuario'
                                },
                                stringLength: {
                                    min: 6,
                                    max: 30,
                                    message: 'El nombre del usuario debe tener más de 6 y menos de 30 carácteres'
                                },
                                regexp: {
                                    regexp: /^[a-zA-Z0-9_\.]+$/,
                                    message: 'El nombre del usuario sólo puede contener caracteres del alfabeto, numeros entre otros'
                                },
                                different: {
                                    field: 'ContrasenaTextBox',
                                    message: 'El nombre del usuario y contraseña no pueden estar iguales'
                                }
                            }
                        },
                        EmailTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese su email'
                                },
                                emailAddress: {
                                    message: 'El email no es valido'
                                }
                            }
                        },
                        ContrasenaTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Ingrese su contraseña'
                                },
                                identical: {
                                    field: 'ConfirmarContrasenaTextBox',
                                    message: 'Las contraseñas son diferentes'
                                },
                                different: {
                                    field: 'NombreUsuarioTextBox',
                                    message: 'La contraseña no puede estar igual que el nombre del usuario'
                                }
                            }
                        }, callback: {
                            callback: function (value, validator) {
                                // Check the password strength
                                if (value.length < 6) {
                                    return {
                                        valid: false,
                                        message: 'La contraseña debe tener más de 6 carácteres'
                                    }
                                }

                                if (value === value.toLowerCase()) {
                                    return {
                                        valid: false,
                                        message: 'La contraseña debe contener un carácter del mayúsculo por lo menos'
                                    }
                                }
                                if (value === value.toUpperCase()) {
                                    return {
                                        valid: false,
                                        message: 'La contraseña debe contener un carácter minúscula por lo menos'
                                    }
                                }
                                if (value.search(/[0-9]/) < 0) {
                                    return {
                                        valid: false,
                                        message: 'La contraseña debe contener un digito por lo menos '
                                    }
                                }

                                return true;
                            }
                        },
                        ConfirmarContrasenaTextBox: {
                            validators: {
                                notEmpty: {
                                    message: 'Debe confirmar su contraseña'
                                },
                                identical: {
                                    field: 'ContrasenaTextBox'
                                },
                                different: {
                                    field: 'NombreUsuarioTextBox',
                                    message: 'La contraseña no puede estar igual que el nombre del usuario'
                                }
                            }
                        },
                        gender: {
                            validators: {
                                notEmpty: {
                                    message: 'El género se requiere'
                                }
                            }
                        }
                    }
                })
                .on('error.field.bv', function (e, data) {
                    var messages = data.bv.getMessages(data.field);
                    $('#errors').find('li[data-bv-for="' + data.field + '"]').remove();
                    for (var i in messages) {
                        $('<li/>').attr('data-bv-for', data.field).html(messages[i]).appendTo('#errors');
                    }
                    $('#errors').parents('.form-group').removeClass('hide');
                })
                .on('success.field.bv', function (e, data) {
                    $('#errors').find('li[data-bv-for="' + data.field + '"]').remove();
                })
                .on('success.form.bv', function (e) {
                    $('#errors')
                        .html('')
                        .parents('.form-group').addClass('hide');
                });
        });
</script>
</body>
</html>
