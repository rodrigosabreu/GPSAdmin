<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Filiais.aspx.cs" Inherits="GPSAdminVIEW.Filiais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: right;
            width: 123px;
            font-weight: bold;
        }
        .auto-style4 {
            text-align: center;
            }
        .auto-style5 {
            width: 46px;
        }
        .auto-style6 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td colspan="3">
                <asp:Label ID="lbl_titulo" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Cliente:</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:Label ID="lbl_cliente" runat="server"></asp:Label>
                <asp:HiddenField ID="hf_clienteID" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Status:</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddl_status" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Selecione o Status</asp:ListItem>
                    <asp:ListItem Value="1">Ativo</asp:ListItem>
                    <asp:ListItem Value="0">Inativo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Nome da Filial:</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:TextBox ID="txt_nome_filial" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Descrição:</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:TextBox ID="txt_descricao" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Email:</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:TextBox ID="txt_email" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="3">
                <asp:Button ID="bt_cadastrar" runat="server" Text="Cadastrar" OnClick="bt_cadastrar_Click" />
                <asp:Button ID="bt_atualizar" runat="server" Text="Atualizar" OnClick="bt_atualizar_Click" />
&nbsp;
                <asp:Button ID="bt_limpar" runat="server" Text="Limpar" OnClick="bt_limpar_Click" />
            </td>
        </tr>
        </table>
</asp:Content>
