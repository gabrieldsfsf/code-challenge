// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieImageUrlBuilder.cs" company="ArcTouch LLC">
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
//   Defines the MovieImageUrlBuilder type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using CodeChallenge.Common;

namespace CodeChallenge.Utils
{
    public static class MovieImageUrlBuilder
    {
        private const string BackdropUrl = "https://image.tmdb.org/t/p/w780";
        private const string PosterUrl = "https://image.tmdb.org/t/p/w154";

        public static string BuildPosterUrl(string posterPath) => $"{PosterUrl}{posterPath}?api_key={Constants.API_KEY}";

        public static string BuildBackdropUrl(string backdropPath) => $"{BackdropUrl }{backdropPath}?api_key={Constants.API_KEY}";
    }
}
