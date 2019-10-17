using NewTestProject.Core.ApplicationService;
using NewTestProject.Core.ApplicationService.ImplService;
using NewTestProject.Core.Entity;
using NewTestProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace NewTestProject.Test
{
    public class TestClassPerformanceTest
    {
        JSONReader js = new JSONReader();
        List<MovieRatings> movieRatingList = new List<MovieRatings>();
        public TestClassPerformanceTest()
        {
            movieRatingList = js.LoadData();
        }
        //Bait class (Also used to test out if timer function is used. It supposed to fail)
        [Fact]
        public void GetNumberOfReviewsFromReviewer_BaitClass()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.False(Time(() => movieRatingService.getNumberOfReviewsFromReviewer(1))< 0);
        }

        [Fact]
        public void GetNumberOfReviewsFromReviewer_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getNumberOfReviewsFromReviewer(2)) < 4);
        }

        [Fact]
        public void GetAverageRateGivenByReviewer_ValidArguments( )
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getAverageRateGivenByReviewer(5)) < 4);
        }


        [Fact]
        public void GetCountOfGradesGivenByReviewer_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);
            Assert.True(Time(() => movieRatingService.getCountOfGradesGivenByReviewer(1, 2)) < 4);
        }

        [Fact]
        public void GetCountOfMovieReviewers_ValidArguments( )
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getCountOfMovieReviewers(1)) < 4);

        }


        [Fact]
        public void AverageRatingRecievedByMovie_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.averageRatingRecievedByMovie(1)) < 4);
        }

        [Fact]
        public void GetCountOfGradesGottenByMovie_ValidArgumentse()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getCountOfGradesGottenByMovie(9, 1)) < 4);
        }

        [Fact]
        public void GetTopGradedMovies_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getIdOfTopGradedMovies()) < 4);
        }

        [Fact]
        public void GetTopReviewers_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getTopReviewers()) < 4);
        }

       [Fact]
        public void GetTopMoviesByAverageGrade_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getTopMoviesByAverageGrade(5)) < 4);
        }

        [Fact]
        public void GetMoviesByReviewer_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getAllMoviesByReviewer(1)) < 4);
        }

        [Fact]
        public void GetAllReviewersFromMovie_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.AddJSON(movieRatingList);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Assert.True(Time(() => movieRatingService.getAllReviewersFromMovie(1)) < 4);
        }

        private double Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime.Invoke();
            timer.Stop();
            return timer.ElapsedMilliseconds/1000.0;
        }
    }
}
