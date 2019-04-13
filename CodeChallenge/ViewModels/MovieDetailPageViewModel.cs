using CodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodeChallenge.ViewModels
{
    class MovieDetailPageViewModel : INotifyPropertyChanged
    {
        private MovieItemViewModel movieItemViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MovieDetailPageViewModel(MovieItemViewModel movieItemViewModel)
        {
            this.movieItemViewModel = movieItemViewModel;
            this.MoviePosterPath = movieItemViewModel.PosterPath;
            this.MovieBackdropPath = movieItemViewModel.BackdropPath;
            this.MovieTitle = movieItemViewModel.Title;
            this.MovieOverview = movieItemViewModel.Overview;
            this.MovieGenres = movieItemViewModel.Genres;
            this.MovieReleaseDate = $"Release date: {movieItemViewModel.ReleaseDate.ToString("dd/MM/yyyy")}";
        }

        public String MoviePosterPath { get; set; }

        public String MovieBackdropPath { get; set; }

        public String MovieTitle { get; set; }

        public String MovieOverview { get; set; }

        public String MovieGenres { get; set; }

        public String MovieReleaseDate { get; set; }

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
