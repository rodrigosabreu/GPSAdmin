<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="GPSAdminVIEW.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    





    <style type="text/css">
        .style3
        {
            width: 800px;            
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
            width: 136px;
            font-weight: bold;
        }
        .auto-style1 {
            width: 136px;
            font-weight: bold;
            text-align: right;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="style3">
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lbl_titulo" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Label ID="lbl_msg" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Status:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:DropDownList ID="ddl_status" runat="server" Width="200px">
                    <asp:ListItem Value="-1">Selecione o status</asp:ListItem>
                    <asp:ListItem Value="1">Ativo</asp:ListItem>
                    <asp:ListItem Value="0">Inativo</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="hf_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Tipo do Cliente:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                
                

                <asp:RadioButton ID="rb_pj" runat="server" AutoPostBack="True" Checked="True" 
                    GroupName="tipo_cliente" oncheckedchanged="rb_pj_CheckedChanged" 
                    Text="Pessoa Jurídica" />
                <asp:RadioButton ID="rb_pf" runat="server" AutoPostBack="True" 
                    GroupName="tipo_cliente" oncheckedchanged="rb_pf_CheckedChanged" 
                    Text="Pessoa Física" />
                
                

            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Nome do Cliente:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_razaosocial" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Nome do Contato:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_nomecontato" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                RG:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_rg" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Orgão Emissor:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_orgaoemissor" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Orgão Emissor UF:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_orgaoemissoruf" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Data de Nascimento:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_datanascimento" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Telefone:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_telefone" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Fax/Outros:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_faxoutros" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                E-mail:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_email" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Endereço:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_endereco" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Número:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_numero" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Complemento:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_complemento" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Bairro:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_bairro" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Cidade:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_cidade" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Estado:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_estado" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Cep:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_cep" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr id="tr_cnpj" runat=server>
            <td class="auto-style1">
                CNPJ:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_cnpj" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr id="tr_cpf" runat=server visible=false>
            <td class="auto-style1">
                CPF:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="auto-style2">
                <asp:TextBox ID="txt_cpf" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="3">
                <asp:Button ID="bt_cadastrar" runat="server" onclick="bt_cadastrar_Click" 
                    Text="Cadastrar" />
                <asp:Button ID="bt_atualizar" runat="server" onclick="bt_atualizar_Click" 
                    Text="Atualizar" />
            &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Limpar" />
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
    </table>
</asp:Content>
