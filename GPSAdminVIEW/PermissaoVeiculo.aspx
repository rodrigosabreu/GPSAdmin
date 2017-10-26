<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PermissaoVeiculo.aspx.cs" Inherits="GPSAdminVIEW.PermissaoVeiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 410px;
            text-align: left;
        }
        .auto-style2 {
            width: 64px;
        }
        .auto-style4 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <center>

        <table>
            <tr>
            <td colspan="2"><center><strong>Relação Usuário / Veículo</strong></center></td>
            </tr>


    


            <tr>
            <td class="auto-style2" colspan="2">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
    
    

            </tr>   
    

    


            <tr>
            <td class="auto-style4"><strong>Usuários:</strong></td>
    
    

            <td class="auto-style1"><asp:DropDownList ID="ddl_usuarios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_usuarios_SelectedIndexChanged">
            </asp:DropDownList></td>
            </tr>   
    
            <tr>
            <td class="auto-style4"><strong>Veículos:</strong></td>
    
    

            <td class="auto-style1">
                <asp:CheckBoxList ID="cbl_veiculos" runat="server">
                </asp:CheckBoxList>
        </td>
            </tr>   
    
            <tr>
            <td class="auto-style4">&nbsp;</td>
    
    

            <td class="auto-style1">
                &nbsp;</td>
            </tr>   
    
            <tr>
            <td class="auto-style4" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Salvar" />
                </td>
    
    

            </tr>   
    
            </table>

    </center>

</asp:Content>
