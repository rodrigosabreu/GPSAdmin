<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClientesBuscaLista.aspx.cs" Inherits="GPSAdminVIEW.ClientesBuscaLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 700px;            
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            width: 54px;
        }
        .auto-style1 {
            text-align: center;
            width: 193px;
        }
        .auto-style2 {
            text-align: right;
            width: 193px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="style3">
        <tr>
            <td colspan="3" style="text-align: center">
                <strong>Busca de Clientes</strong></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <strong style="text-align: right">Razão Social/CNPJ/CPF:</strong></td>
            <td class="style5">
                &nbsp;</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" style="text-align: left"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                <asp:Button ID="Button1" runat="server" Text="Buscar" onclick="Button1_Click" />
            </td>
        </tr>
    </table>

    <br><br>

    <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" EnableModelValidation="True" ForeColor="#333333" 
            GridLines="None" Width="620px" onrowdatabound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="razaosocial" HeaderText="Razão Social" />
                <asp:BoundField DataField="email" HeaderText="E-mail" />
                <asp:BoundField DataField="cnpj" HeaderText="CNPJ" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                <asp:BoundField DataField="status" HeaderText="Status" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </center>

</asp:Content>
