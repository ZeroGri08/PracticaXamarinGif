using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

using System.Linq;
using GifsXamarin.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using MvvmHelpers;
using System.Windows.Input;

namespace GifsXamarin.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Movies> Movies { get; }
        public Command<string> GetMoviesCommand { get; }

        public MovieViewModel()
        {
            Movies = new ObservableRangeCollection<Movies>();
            GetMoviesCommand = new Command<string>(async (test) => await GetMoviesAsync(test));
        }

        async Task GetMoviesAsync(string test)
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var movies = await DataService.GetMoviesAsync();

                Movies.ReplaceRange(movies);

                Title = $"{test} ({Movies.Count})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Movies: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
