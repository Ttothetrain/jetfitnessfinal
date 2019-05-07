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
            var encodedFood = HttpUtility.UrlEncode(searchFoodItem);

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://api.nutritionix.com/v1_1/search/{encodedFood}?&appId=049af4f4&appKey=6336d69f8f994b5e0d2bad53becd2419&fields=item_id,item_name,brand_name,nf_calories&results=0:10");

            var rootObject = JsonConvert.DeserializeObject<RootObject>(response);

            MyListView.ItemsSource = rootObject.hits;
        }

   

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MyListView.SelectedItem = null;
        }
       
        // next button
        private void Button_OnClicked(object sender, EventArgs e)
        {
        }

        // search bar text changes
        void OnSearchBarTextChanged(object sender, TextChangedEventArgs args)
        {
            // this might run too frequently.. might not want to do this
            // var findFood = foodSearch.Text;
        }


        void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            var findFood = foodSearch.Text;
            UpdateList(findFood);
        }
    }
}