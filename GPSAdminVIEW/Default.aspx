<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GPSAdminVIEW.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="CSS/Estilo.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
       
        .style2
        {
            width: 179px;
        }
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
        }
        .auto-style3 {            text-align: center;
        }
        .auto-style4 {
            width: 49px;
        }
        .auto-style5 {
            text-align: right;
        }
        </style>
    
</head>
<body>
    <form id="form1" runat="server">
    
    
    <table border=0 cellpadding=0 cellspacing=0 width=100%>
    <tr><td>
        
        <div id="topo">
        <br />
        <br />
        <br />
        </div>
        
        </td></tr>    
        
       
    </table>


        <br><br><br><br><br><br>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="3"><center><strong>Autenticação</strong></center></td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="3">
                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"><strong style="text-align: right">Usuário:</strong></td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"><strong style="text-align: right">Senha:</strong></td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="3">
                    <center><asp:Button ID="Button1" runat="server" style="text-align: center" Text="Entrar" OnClick="Button1_Click" /></center>
                </td>
            </tr>
        </table>



    </form>
</body>
</html>