using GifsXamarin.Models;
using GifsXamarin.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(WebDataService))]

namespace GifsXamarin.Services
{
    public  class WebDataService : IDataService
    {
        HttpClient httpClient;

        HttpClient Client => httpClient ?? (httpClient = new HttpClient());
      

        async Task<IEnumerable<Movies>> IDataService.GetMoviesAsync()
        {
            var json = await Client.GetStringAsync("https://raw.githubusercontent.com/BryanOroxon/GifInMotion/master/GifInMotion/GifInMotion/Data/movie.json");
            var all = Movies.FromJson(json);
            return all; 
        }
    }
}
