using CodeChallenge.Models;
using CodeChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeChallenge.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailPage : ContentPage
	{
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        public MovieDetailPage (MovieItemViewModel movieItemViewModel)
		{
			InitializeComponent ();
            BindingContext = new MovieDetailPageViewModel(movieItemViewModel);

        }
	}
}