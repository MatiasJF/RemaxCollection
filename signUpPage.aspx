<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUpPage.aspx.cs" Inherits="RemaxWebsite.signUpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RE/MAX&nbsp;•&nbsp;Sign up</title>
    <link rel="stylesheet" href="style.css">
   <style>
        @import url(https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;600&display=swap);body{background:#fefefe;font-family:'Poppins',sans-serif;margin:0}section{height:var(--main-height);width:100%;display:grid;place-content:center}.form-box{max-width:330px;background:#f1f7fef0;overflow:hidden;border-radius:16px;color:#010101;box-shadow:0 0 3px rgba(0,0,0,.01),0 2px 5px rgba(0,0,0,.02),0 4px 10px rgba(0,0,0,.03),0 8px 15px rgba(0,0,0,.03),0 24px 30px rgba(0,0,0,.04),0 50px 60px rgba(0,0,0,.12)}.loginForm{position:relative;display:flex;flex-direction:column;padding:32px 24px 24px;gap:16px;text-align:center}.title{font-weight:700;font-size:1.6rem}.subtitle{font-size:1rem;color:#666}.form-container{overflow:hidden;border-radius:8px;background-color:#fff;margin:1rem 0 .5rem;width:100%}.input{background:none;border:0;outline:0;height:40px;width:100%;border-bottom:1px solid #eee;font-size:.9rem;padding:8px 15px}.form-section{padding:16px;font-size:.85rem;background-color:#e0ecfb;box-shadow:rgb(0 0 0 / 8%) 0 -1px}.form-section a{font-weight:700;color:#06f;transition:color .3s ease}.form-section a:hover{color:#005ce6;text-decoration:underline}.loginForm button,[type="submit"]{background-color:#007acc;color:#fff;border:0;border-radius:24px;padding:10px 16px;font-size:1rem;font-weight:600;cursor:pointer;transition:background-color .3s ease}.loginForm button:hover,[type="submit"]:hover{background-color:#005ce6}
    </style>
</head>
<body>
    <header>
        <nav>
            <a href="">
                <img src="./Assets/rmx_logo.png" alt="Remax|Logo" />
            </a>
            <a href="">
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
    <section>
        <div class="form-box">
            <form id="form1" class="loginForm" runat="server">
                <span class="title">Sign up</span>
                <span class="subtitle">Create a free account with your email.</span>
                <div class="form-container">
                    <asp:TextBox runat="server" CssClass="input" ID="TXT_FirstName" placeholder="First Name" />
                    <asp:TextBox runat="server" CssClass="input" ID="TXT_LastName" placeholder="Last Name" />
                    <asp:TextBox runat="server" CssClass="input" ID="TXT_Email" placeholder="Email" />
                    <asp:TextBox TextMode="Password" runat="server" CssClass="input" ID="TXT_Password" placeholder="Password" />
                    <asp:TextBox runat="server" CssClass="input" ID="TXT_Phone" placeholder="Phone" />
                </div>
                <asp:Button runat="server" ID="BTN_SignUp" Text="Sign up" OnClick="BTN_SignUp_Click" />
            </form>
            <div class="form-section">
                <p>Have an account? <a href="./loginPage.aspx">Sign in</a> </p>
            </div>
        </div>
    </section>
</body>
</html>
