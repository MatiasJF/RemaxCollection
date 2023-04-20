<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RemaxWebsite.index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="style.css">
    <link href="./Assets/icons8-remax-16.png" rel="icon" type="image/x-icon" />
    <title>RE/MAX&nbsp;•&nbsp;Welcome</title>
</head>

<body>
    <header>
        <nav>
            <a href="">
                <img src="./Assets/rmx_logo.png" alt="Remax|Logo">
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
                <span>Sign In</span>
            </a>
        </nav>
    </header>
    <main>
        <section class="main-search">
            <form class="form" id="search_form" runat="server">
                <button>
                    <svg width="17" height="16" fill="none" xmlns="http://www.w3.org/2000/svg" role="img"
                        aria-labelledby="search">
                        <path d="M7.667 12.667A5.333 5.333 0 107.667 2a5.333 5.333 0 000 10.667zM14.334 14l-2.9-2.9"
                            stroke="currentColor" stroke-width="1.333" stroke-linecap="round" stroke-linejoin="round">
                        </path>
                    </svg>
                </button>
                <input class="input" placeholder="Search properties" required="" type="text" />
                <button class="reset" type="reset">
                    <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24"
                        stroke="currentColor" stroke-width="2">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M6 18L18 6M6 6l12 12"></path>
                    </svg>
                </button>
            </form>
            <div class="search-filters">
                <p style="display: flex;align-items: center;gap: 4px;">
                    Popular searches 
                    <span>
                        <svg width="20" height="20" fill="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                            <path d="M15.755 14.255h-.79l-.28-.27a6.471 6.471 0 0 0 1.57-4.23 6.5 6.5 0 1 0-6.5 6.5c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99 1.49-1.49-4.99-5Zm-6 0c-2.49 0-4.5-2.01-4.5-4.5s2.01-4.5 4.5-4.5 4.5 2.01 4.5 4.5-2.01 4.5-4.5 4.5Z"></path>
                        </svg>
                    </span>
                </p>
                <br />
                <div class="filters">
                    <a href="#" class="btn">New and coming soon</a>
                    <a href="#" class="btn">Montreal listing</a>
                    <a href="#" class="btn">Toronto listing</a>
                    <a href="#" class="btn">Agent of the month</a>
                    <a href="#" class="btn">Montreal Agents</a>
                </div>
            </div>
        </section>
        <div class="result-filters">
            <h2>Explore RE<span style="color:var(--blue); font-weight: bold;">/</span>MAX</h2>
            <div class="grp-btn">
                <button class="btn">All</button>
                <button class="btn">Properties</button>
                <button class="btn">Agents</button>
            </div>
        </div>
        <section class="main-results" id="mainResults" runat="server">
            <!-- FILLED ON SERVER SIDE -->
        </section>
    </main>
    <footer>
        MatanDessaur&copy;<span id="year"></span>
        <script>document.getElementById("year").innerHTML = new Date().getFullYear();</script>
    </footer>
</body>

</html>
