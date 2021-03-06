﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vPreguntas.aspx.cs" Inherits="EncuestaB0._1._0.Vistas_reportes.rEPreguntas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Reportes</h3>
        <div class="panel panel-primary text-center">
            <div class="panel-heading">Reporte de preguntas</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <asp:ScriptManager ID="PreguntasScriptManager" runat="server"></asp:ScriptManager>

                    <rsweb:ReportViewer ID="PreguntasReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="Reportes\PreguntasReport.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="PreguntasObjectDataSource" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                    <asp:ObjectDataSource ID="PreguntasObjectDataSource" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PreguntasDataSetTableAdapters.Preguntas1TableAdapter">
                        <InsertParameters>
                            <asp:Parameter Name="Descripcion" Type="String" />
                            <asp:Parameter Name="TipoDePregunta" Type="Int32" />
                            <asp:Parameter Name="subTipoDePregunta" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
