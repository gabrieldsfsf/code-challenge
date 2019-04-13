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
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using System;

namespace CodeChallenge.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(new MovieService(), this);

            MoviesListView.ItemTapped += MoviesListView_ItemTapped;
            MoviesListView.ItemAppearing += MoviesListView_ItemAppearing;
        }

        private async void MoviesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var movieItemViewModel = e.Item as MovieItemViewModel;
            await Navigation.PushAsync(new MovieDetailPage(movieItemViewModel));
        }

        private async void MoviesListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var movieItemViewModel = e.Item as MovieItemViewModel;
            if (BindingContext is HomePageViewModel viewModel)
            {
                if (!viewModel.PaginationEndReached && !viewModel.IsLoadingMoreMovies && movieItemViewModel == viewModel.Movies.Last())
                {
                    PaginationLoadingIndicator.IsVisible = true;
                    await viewModel.GetUpcomingMoviesPaginated();
                }
            }
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

        public void OnMoviesLoaded()
        {
            LoadingIndicator.IsVisible = false;
            MoviesSearchBar.IsVisible = true;
        }

        public void HidePaginationLoadingIndicator()
        {
            PaginationLoadingIndicator.IsVisible = false;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is HomePageViewModel viewModel)
            {
                if (String.IsNullOrEmpty(MoviesSearchBar.Text))
                {
                    MoviesListView.ItemsSource = viewModel.Movies;
                } else
                {
                    MoviesListView.ItemsSource = viewModel.GetMoviesBySearch(MoviesSearchBar.Text);
                }
            }
        }
    }
}
