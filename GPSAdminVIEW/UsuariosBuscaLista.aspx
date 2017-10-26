<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UsuariosBuscaLista.aspx.cs" Inherits="GPSAdminVIEW.UsuariosBuscaLista" %>
<%@ Register src="UCEscolheCliente.ascx" tagname="UCEscolheCliente" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <table align="center" class="auto-style1">
            <tr>
                <td colspan="3"><strong>Busca de Usuários</strong></td>
            </tr> 
            
       </table>    




    <div runat="server" id="div_cliente">
      <table align="center" class="auto-style1">
           
      

            <tr>
                <td colspan="3">
                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style4" style="text-align: right"><strong>Cliente:</strong></td>
                <td class="auto-style3">&nbsp;</td>
                <td style="text-align: left">    <div id="div1" runat="server">
                    <uc1:ucescolhecliente ID="UCEscolheCliente1" runat="server" />
        </div></td>
            </tr>
            <tr>
                <td class="auto-style4" style="text-align: right">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="3">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>

    <br><br>
    </div>
    <center>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="683px" OnRowDataBound="GridView1_RowDataBound">
          <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:BoundField DataField="id" HeaderText="ID" />
              <asp:BoundField DataField="Nome" HeaderText="Nome" />
              <asp:BoundField DataField="usuario" HeaderText="Login" />
              <asp:BoundField DataField="filial" HeaderText="Filial" />
              <asp:BoundField DataField="nome_grupo" HeaderText="Nivel" />
              <asp:BoundField DataField="status" HeaderText="Status" />
          </Columns>
          <EditRowStyle BackColor="#2461BF" />
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
          <RowStyle BackColor="#EFF3FB" />
          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <SortedAscendingCellStyle BackColor="#F5F7FB" />
          <SortedAscendingHeaderStyle BackColor="#6D95E1" />
          <SortedDescendingCellStyle BackColor="#E9EBEF" />
          <SortedDescendingHeaderStyle BackColor="#4870BE" />
      </asp:GridView>

        </center>
      



</asp:Content>
