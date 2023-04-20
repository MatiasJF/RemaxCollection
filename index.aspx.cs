using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using RemaxWebsite;


namespace RemaxWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowHousesCards();
            }
        }

        protected void ShowHousesCards()
        {
            // Get all the houses
            HousesList housesList = Datasource.GetAllHouses();
            var houses = housesList.Houses;
            // Loop through the houses and generate HTML code for each card
            foreach (House house in houses)
            {
                string html = $@"
                    <div class='card'>
                        <img src='https://media.istockphoto.com/id/1026205392/photo/beautiful-luxury-home-exterior-at-twilight.jpg?s=612x612&w=0&k=20&c=HOCqYY0noIVxnp5uQf1MJJEVpsH_d4WtVQ6-OwVoeDo=' alt='{house.CivicNumber}' style='width:100%'>
                        <div class='container'>
                            <h4 class='price'>{house.Price:C}</h4>
                            <p class='address'>{house.CivicNumber}</p>
                        </div>
                    </div>
                ";

                // Add the HTML code to the section with class 'main-results'
                mainResults.Controls.Add(new LiteralControl(html));
            }
        }


    }
}