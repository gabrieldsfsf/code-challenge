// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITmdbApi.cs" company="ArcTouch LLC">
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
//   Defines the ITmdbApi type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using CodeChallenge.Models;
using Refit;

namespace CodeChallenge.Services
{
    public interface ITmdbApi
    {
        [Get("/genre/movie/list?api_key={apiKey}&language={language}")]
        Task<GenreResponse> GetGenres(string apiKey, string language);

        [Get("/movie/upcoming?api_key={apiKey}&language={language}&page={page}&region={region}")]
        Task<UpcomingMoviesResponse> UpcomingMovies(string apiKey, string language, int page, string region);

        [Get("/movie/{id}?api_key={apiKey}&language={language}")]
        Task<Movie> GetMovie(string apiKey, string language, [AliasAs("id")]int movieId);
    }
}