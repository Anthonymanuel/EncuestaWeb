<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="vEncuestas.aspx.cs" Inherits="EncuestaB0._1._0.VistasReportes.ReEncuestas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="right_col" role="main">
        <h3><i class="fa fa-angle-right"></i>Reportes</h3>
        <div class="panel panel-primary text-center">
            <div class="panel-heading">Reporte de encuesta</div>
            <div class="panel-body">
                <div class="form-horizontal" role="form">
                    <asp:ScriptManager ID="EncuestasScriptManager" runat="server"></asp:ScriptManager>
                    <rsweb:ReportViewer ID="EncuestasReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="100%" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                        <LocalReport ReportPath="Reportes\EncuestasReport.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                   
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="EncuestasDataSetTableAdapters.EncuestasTableAdapter" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_EncuestaId" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Entidad" Type="String" />
                            <asp:Parameter Name="Descripcion" Type="String" />
                            <asp:Parameter Name="Fecha" Type="DateTime" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Entidad" Type="String" />
                            <asp:Parameter Name="Descripcion" Type="String" />
                            <asp:Parameter Name="Fecha" Type="DateTime" />
                            <asp:Parameter Name="Original_EncuestaId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
