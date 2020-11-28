using GifsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GifsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesCarosuel : ContentPage
    {
        public MovieViewModel viewModel;
        public MoviesCarosuel()
        {
            InitializeComponent();
            BindingContext = viewModel = new MovieViewModel();
            if (viewModel.Movies.Count == 0)
            {
                viewModel.GetMoviesCommand.Execute("Carousel View");
                movieViewSource.ItemsSource = viewModel.Movies;
            }
        }
    }
}