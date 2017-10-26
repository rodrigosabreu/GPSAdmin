<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FiliaisEscolheCliente.aspx.cs" Inherits="GPSAdminVIEW.FiliaisEscolheCliente" %>
<%@ Register src="UCEscolheCliente.ascx" tagname="UCEscolheCliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <table align="center" class="auto-style1">          

            <tr>
                <td colspan="3">
                    <strong>Cadastro de Filiais</strong></td>
            </tr>
            <tr>
                <td colspan="3">
                   <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style4" style="text-align: right"><strong>Cliente:</strong></td>
                <td class="auto-style3">&nbsp;</td>
                <td style="text-align: left">    <div id="div1" runat="server">
                    <uc1:UCEscolheCliente ID="UCEscolheCliente" runat="server" />
        </div></td>
            </tr>
            <tr>
                <td class="auto-style4" style="text-align: right">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="3">
                       <asp:Button ID="Button1" runat="server" Text="Prosseguir" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    
    
    
    
    
    
    
   
    
 


</asp:Content>
