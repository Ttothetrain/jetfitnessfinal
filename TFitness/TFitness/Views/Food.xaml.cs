using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TFitness.Nutritionix;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Food : ContentPage
	{
		public Food ()
		{
			InitializeComponent ();
		}

        public async void UpdateList(string searchFoodItem)
        {
            // First, encode the food item to URL query string (basically replace invalid characters with their encoded value (like "space" with %20)
            var encodedFood = HttpUtility.UrlEncode(searchFoodItem);

            // Next, we establish our API request. This will pull the list of food items based on the search text specified, returning the name of the item, brand, calories, etc.
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.nutritionix.com/v1_1/search/{encodedFood}?&appId=049af4f4&appKey=6336d69f8f994b5e0d2bad53becd2419&fields=item_id,item_name,brand_name,nf_calories&results=0:10");

            // Deserialize that JSon list to our object that we created.
            var rootObject = JsonConvert.DeserializeObject<RootObject>(response);

            // Now we can populate the list view with the results we parsed.
            MyListView.ItemsSource = rootObject.hits;
        }

   

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // This is where we would want to add each food item to our database. We would take the resulting item and cast the Hit object to it, and use the fields.item_id to get full food item details and add it to our local db.
            MyListView.SelectedItem = null;
        }
       
        // next button
        private void Button_OnClicked(object sender, EventArgs e)
        {
            // To-do: pagination system between results by incrementing the current url variable &results=0:10, &results=11,20, etc.
        }

        // search bar text changes
        void OnSearchBarTextChanged(object sender, TextChangedEventArgs args)
        {
            // this might run too frequently.. might not want to do this
            // var findFood = foodSearch.Text;
        }


        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            // When someone clicks on the search button, we want to reach out to the API to load the requested food item.
            var findFood = foodSearch.Text;
            UpdateList(findFood);
        }
    }
}