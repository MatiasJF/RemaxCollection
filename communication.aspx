<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="communication.aspx.cs" Inherits="RemaxWebsite.communication" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="com-style.css" />
    <link href="./Assets/icons8-remax-16.png" rel="icon" type="image/x-icon" />
    <title>RE/MAX&nbsp;•&nbsp;Communication</title>
</head>
<body>
     <header>
        <nav>
            <a href="./index.aspx">
                <img src="./Assets/rmx_logo.png" alt="Remax|Logo" />
            </a>
            <a href="./loginPage.aspx">
                <i class="user-icon">
                    <svg fill="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                        <path d="M12 3.75a3.75 3.75 0 1 0 0 7.5 3.75 3.75 0 0 0 0-7.5Z"></path>
                        <path
                            d="M8 13.25A3.75 3.75 0 0 0 4.25 17v1.188c0 .754.546 1.396 1.29 1.517 4.278.699 8.642.699 12.92 0a1.537 1.537 0 0 0 1.29-1.517V17A3.75 3.75 0 0 0 16 13.25h-.34c-.185 0-.369.03-.544.086l-.866.283a7.251 7.251 0 0 1-4.5 0l-.866-.283a1.752 1.752 0 0 0-.543-.086H8Z">
                        </path>
                    </svg>
                </i>
                <span runat="server" id="connectedUser">
                    <!-- FILLED ON SERVER -->
                </span>
            </a>
        </nav>
    </header>
    <section class="communication_layout">
        <aside runat="server" id="Messages">
            <!-- FILLED ON SERVER -->
        </aside>
        <main>
             <form id="Form1" runat="server">
                <iframe id="communicationIframe" frameborder="0" runat="server"></iframe>
                <!-- Hidden button to be called by the disconnect script -->
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Style="display: none;" />
             </form>
        </main>
    </section>
     <script type="text/javascript">
        // Script to call the disconnect method
        function confirmDisconnect() {
            if (window.confirm("Are you sure you want to disconnect?")) {
                document.getElementById("<%= btnLogout.ClientID %>").click();
            }
         }
         // Function to update the iframe source when a message thumbnail is clicked
         function handleMessageClick(messageId, contactId) {
             document.getElementById("communicationIframe").src = "message.aspx?id=" + messageId + "&contact=" + contactId;
         }
     </script>
</body>
</html>
