// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tests.cs" company="ArcTouch LLC">
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
//   Defines the Tests type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CodeChallenge.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private IApp app;
        private readonly Platform platform;

        public Tests(Platform platform) => this.platform = platform;

        [SetUp]
        public void BeforeEachTest()
        {
            this.app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = this.app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            this.app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }
    }
}
