// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Genre.cs" company="ArcTouch LLC">
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
//   Defines the Genre type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CodeChallenge.Models
{
    public class UpcomingMoviesResponse
    {
        public List<Movie> Results { get; set; }

        public int Page { get; set; }

        public int TotalResults { get; set; }

        public Dates Dates { get; set; }

        public int TotalPages { get; set; }
    }

    public class GenreResponse
    {
        public List<Genre> Genres { get; set; }
    }

    public class Dates
    {
        public DateTimeOffset Maximum { get; set; }

        public DateTimeOffset Minimum { get; set; }
    }

    public class Result
    {
        public int VoteCount { get; set; }

        public int Id { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }

        public string Title { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public List<int> GenreIds { get; set; }

        public string BackdropPath { get; set; }

        public bool Adult { get; set; }

        public string Overview { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }

        public string BackdropPath { get; set; }

        public List<int> GenreIds { get; set; }

        public List<Genre> Genres { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Title { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
