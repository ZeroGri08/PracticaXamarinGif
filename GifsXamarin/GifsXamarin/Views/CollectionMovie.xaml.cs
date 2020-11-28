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
    public partial class CollectionMovie : ContentPage
    {
        public MovieViewModel viewModel;
        public CollectionMovie()
        {
            InitializeComponent();
            BindingContext = viewModel = new MovieViewModel();
            if (viewModel.Movies.Count == 0)
            {
                viewModel.GetMoviesCommand.Execute("Collection View");
                CollectionViewSource.ItemsSource = viewModel.Movies;
            }
        }

    }
}