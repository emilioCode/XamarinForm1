using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForm1.Models;

namespace XamarinForm1
{
    public partial class MainPage : ContentPage
    {
        private string url = "https://jsonplaceholder.typicode.com/posts";
        public MainPage()
        {
            InitializeComponent();
        }

        //Viene de Page
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var posts = new List<Post>();
            //posts.Add(new Post
            //{
            //    id = 1,
            //    userId = 1,
            //    title = "This is the title",
            //    body = "This is a simple text into body"
            //});

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
            string response = await httpResponse.Content.ReadAsStringAsync();

            posts = JsonConvert.DeserializeObject<List<Post>>(response);

            listView.ItemsSource = posts;
        }
    }
}
