<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="RemaxWebsite.message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="messages-style.css" rel="stylesheet" />
</head>
<body>
    <section>
        <div class="messages_view" id="messages_view" runat="server">
        </div>
        <form id="form1" runat="server" autocomplete="off">
            <asp:TextBox runat="server" ID="txt_messageToSend" TextMode="MultiLine"></asp:TextBox>
            <asp:Button runat="server" ID="btn_send" Text="envoyer" OnClick="btn_send_Click"/>
        </form>
    </section>
</body>
</html>
