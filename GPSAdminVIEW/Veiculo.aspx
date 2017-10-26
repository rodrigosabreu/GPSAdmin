<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Veiculo.aspx.cs" Inherits="GPSAdminVIEW.Veiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3 {
            width: 600px;            
        }
        .style4
        {            text-align: center;
        }
        .style5
        {            text-align: center;
        }
        .style6
        {
            width: 32px;
        }
        .style7
        {
            width: 88px;
            font-weight: bold;
        }
        .style8
        {
            width: 376px;
        }
        .auto-style1 {
            width: 376px;
            text-align: left;
        }
        .auto-style2 {
            width: 88px;
            font-weight: bold;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style3" align=center>
        <tr>
            <td colspan="3" style="text-align: center">
                <strong>Cadastro de Veículos</strong></td>
        </tr>
        <tr>
            <td class="style5" colspan="3">
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Cod. Veículo:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_cod" runat="server" Width="200px"></asp:TextBox>
&nbsp;
                <asp:Button ID="bt_buscar" runat="server" onclick="Button3_Click" 
                    Text="Buscar" Width="60px" />
                <asp:Button ID="bt_limpar" runat="server" onclick="Button4_Click" Text="Limpar" 
                    Visible="False" Width="60px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Veículo:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_veiculo" runat="server" Width="200px"></asp:TextBox>
            &nbsp;EX: 111-AAA1111</td>
        </tr>
        <tr>
            <td class="auto-style2">
                Descrição:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_descricao" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Imagem:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_imagem" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Tipo Veículo:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddl_tipoveiculo" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Status:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddl_status" runat="server" Width="200px">
                    <asp:ListItem Value="1">Ativo</asp:ListItem>
                    <asp:ListItem Value="0">Inativo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                Filial:</td>
            <td class="style6">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:DropDownList ID="ddl_filial" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                <asp:Button ID="bt_salvar" runat="server" Text="Salvar" 
                    onclick="Button1_Click" />
                <asp:Button ID="bt_atualizar" runat="server" onclick="bt_atualizar_Click" 
                    Text="Atualizar" Visible="False" />
            </td>
        </tr>
    </table>
</asp:Content>
