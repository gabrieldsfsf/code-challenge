// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomePageViewModel.cs" company="ArcTouch LLC">
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
//   Defines the HomePageViewModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Services;
using CodeChallenge.Views;

namespace CodeChallenge.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private readonly MovieService movieService;
        private ObservableCollection<MovieItemViewModel> movies;
        private HomePage view;
        private int currentPage = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel(MovieService movieService, HomePage view)
        {
            this.movieService = movieService;
            this.movies = new ObservableCollection<MovieItemViewModel>();
            this.view = view;
        }

        public ObservableCollection<MovieItemViewModel> Movies
        {
            get => this.movies;
            set => SetProperty(ref this.movies, value);
        }

        public bool PaginationEndReached { get; set; }

        public bool IsLoadingMoreMovies { get; set; }

        public async Task OnAppearing()
        {
            await this.GetUpcomingMoviesPaginated();
            view.OnMoviesLoaded();
        }

        public Task OnDisappearing() => Task.CompletedTask;

        public async Task GetUpcomingMoviesPaginated()
        {
            IsLoadingMoreMovies = true;
            UpcomingMoviesResponse upcomingMoviesResponse = await this.movieService.UpcomingMovies(currentPage);
            this.PaginationEndReached = upcomingMoviesResponse.Results.Count == 0;
            foreach (var movie in upcomingMoviesResponse.Results)
            {
                Movies.Add(ToMovieItemViewModel(movie));
            }
            currentPage++;
            view.HidePaginationLoadingIndicator();
            IsLoadingMoreMovies = false;
        }

        public MovieItemViewModel ToMovieItemViewModel(Movie result) => new MovieItemViewModel(result);

        public IEnumerable<MovieItemViewModel> GetMoviesBySearch(string searchText)
        {
            return movies.Where(movie => movie.Title.ToLower().Contains(searchText.ToLower()));
        }

        private bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
