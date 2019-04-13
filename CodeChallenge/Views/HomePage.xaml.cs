// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.xaml.cs" company="ArcTouch LLC">
//   Copyright 2019 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the MainPage type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using CodeChallenge.Models;
using CodeChallenge.Services;
using CodeChallenge.ViewModels;
using Xamarin.Forms;

namespace CodeChallenge.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(new MovieService(), this);

            MoviesListView.ItemTapped += async (sender, e) =>
            {
                var movieItemViewModel = e.Item as MovieItemViewModel;
                await Navigation.PushAsync(new MovieDetailPage(movieItemViewModel));
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomePageViewModel viewModel)
            {
                await viewModel.OnAppearing();
            }
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is HomePageViewModel viewModel)
            {
                await viewModel.OnDisappearing();
            }
        }

        public void HideLoadingIndicator()
        {
            LoadingIndicator.IsVisible = false;
        }
    }
}
