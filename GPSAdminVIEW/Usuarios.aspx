<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="GPSAdminVIEW.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 818px;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            width: 32px;
        }
        .style6
        {
            width: 120px;
            font-weight: bold;
            text-align: left;
        }
        .style7
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">   
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    

    
    <table class="style3" align=center>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lbl_titulo" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lbl_msg" runat="server" style="color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Cliente:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:Label ID="lbl_cliente" runat="server"></asp:Label>
                <asp:HiddenField ID="hf_clienteID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                Filial:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:DropDownList ID="ddl_filial" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <strong>Nome Completo:</strong></td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:TextBox ID="txt_nome_completo" runat="server" Width="200px"></asp:TextBox>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Login:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:TextBox ID="txt_login" runat="server" Width="200px"></asp:TextBox>
                <asp:HiddenField ID="hf_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style6">
                E-mail:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:TextBox ID="txt_email" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Senha:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:TextBox ID="txt_senha" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Confirma
                Senha:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:TextBox ID="txt_confirma_senha" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <strong>Visualiza todos Veículos da Filial:</strong></td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:DropDownList ID="ddl_ctrl_veiculo" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Selecione</asp:ListItem>
                    <asp:ListItem Value="0">Sim</asp:ListItem>
                    <asp:ListItem Value="1">Não</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Status:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style7">
                <asp:DropDownList ID="ddl_status" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Selecione o status</asp:ListItem>
                    <asp:ListItem Value="1">Ativo</asp:ListItem>
                    <asp:ListItem Value="0">Inativo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr id="tr_grupo" runat="server">
            <td class="style6">Grupo:</td>
            <td class="style5">&nbsp;</td>
            <td class="style7">
                <asp:DropDownList ID="ddl_grupo" runat="server" Width="200px">
                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                    <asp:ListItem Value="2">Usuário</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                <asp:Button ID="bt_salvar" runat="server" Text="Salvar" 
                    onclick="bt_salvar_Click" Width="80px" />
                <asp:Button ID="bt_atualizar" runat="server" Text="Atualizar" Width="80px" 
                    onclick="bt_atualizar_Click" />
            </td>
        </tr>
        </table>

        <br><br>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
