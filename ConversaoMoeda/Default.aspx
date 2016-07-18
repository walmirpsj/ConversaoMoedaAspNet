<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConversaoMoeda.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Conversor de Moedas</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Conversor de Moedas</h2><br/>
        <label>Valor a converter:</label>
        <asp:TextBox ID="txtValor" runat="server" Columns="10"></asp:TextBox><br/>
        <label>De:</label>
        <asp:DropDownList ID="ddlMoedaOrigem" runat="server" OnSelectedIndexChanged="ddlMoedaOrigem_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <label>Para:</label>
        <asp:DropDownList ID="ddlMoedaDestino" runat="server" OnSelectedIndexChanged="ddlMoedaDestino_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button ID="btnConverter" runat="server" Text="Converter" OnClick="btnConverter_Click" /><br /><br />
        <label>Valor Convertido:</label>        
        <asp:Label ID="lblConvertido" runat="server" ForeColor="Blue" Font-Bold="True" Text=""></asp:Label><br/><br/>
        <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
