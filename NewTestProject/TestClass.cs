using NewTestProject.Core.ApplicationService;
using NewTestProject.Core.ApplicationService.ImplService;
using NewTestProject.Core.Entity;
using NewTestProject.Infrastructure;
using System;
using System.Collections.Generic;
using Xunit;

namespace NewTestProject.Test
{
    public class TestClass
    {

        [Theory]
        [InlineData(5, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public void GetNumberOfReviewsFromReviewer_ValidArguments(int reviewer, int reviews)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 2, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.getNumberOfReviewsFromReviewer(reviewer);

            Assert.Equal(reviews, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void GetAverageRateGivenByReviewer_ValidArguments(int reviewer, double average)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 1, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(3, 4, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(3, 5, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.getAverageRateGivenByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        public void GetAverageRateGivenByReviewer_ValidArguments_ReturnZero(int reviewer, double average)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 4, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.getAverageRateGivenByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(2, 3, 3)]
        public void GetCountOfGradesGivenByReviewer_ValidArguments(int reviewer, int grade, int count)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(3, 3, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(3, 4, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 1, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, grade, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.getCountOfGradesGivenByReviewer(reviewer, grade);

            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void GetCountOfMovieReviewers_ValidArguments(int movie, int count)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 3, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 1, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.getCountOfMovieReviewers(movie);

            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void AverageRatingRecievedByMovie_ValidArguments(int movie, double average)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 1, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.averageRatingRecievedByMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(6, 0)]
        [InlineData(7, 0)]
        public void AverageRatingRecievedByMovie_ValidArguments_ReturnZero(int movie, double average)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 1, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.averageRatingRecievedByMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(9, 1, 0)]
        [InlineData(2, 4, 1)]
        [InlineData(3, 3, 4)]
        public void GetCountOfGradesGottenByMovie_ValidArgumentse(int movie, int grade, int count)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.getCountOfGradesGottenByMovie(movie, grade);

            Assert.Equal(count, actual);
        }

        [Fact]
        public void GetTopGradedMovies_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 4, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 5, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 1, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 6, 5, 4, 3, 2, 1 };
            List<int> actual = movieRatingService.getIdOfTopGradedMovies();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopReviewers_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 5, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 4, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 1, 2, 3 };
            List<int> actual = movieRatingService.getTopReviewers();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMoviesByAverageGrader_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(1, 7, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 6, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 6, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(1, 5, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 4, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 7, 6, 5, 3, 4 };
            List<int> actual = movieRatingService.getTopMoviesByAverageGrade(5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMoviesByReviewer_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            MovieRatings movieRating1 = new MovieRatings(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRatings movieRating2 = new MovieRatings(2, 1, 5, DateTime.Now.AddYears(3));
            MovieRatings movieRating3 = new MovieRatings(3, 1, 4, DateTime.Now.AddYears(3));
            MovieRatings movieRating4 = new MovieRatings(4, 1, 3, DateTime.Now.AddYears(2));
            MovieRatings movieRating5 = new MovieRatings(3, 2, 1, DateTime.Now);
            movieRatingRepository.Add(movieRating1);
            movieRatingRepository.Add(movieRating2);
            movieRatingRepository.Add(movieRating3);
            movieRatingRepository.Add(movieRating4);
            movieRatingRepository.Add(movieRating5);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<MovieRatings> expected = new List<MovieRatings>() { movieRating1 };
            List<MovieRatings> actual = movieRatingService.getAllMoviesByReviewer(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllReviewersFromMovie_ValidArguments()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            MovieRatings movieRating1 = new MovieRatings(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRatings movieRating2 = new MovieRatings(2, 1, 5, DateTime.Now.AddYears(3));
            MovieRatings movieRating3 = new MovieRatings(3, 1, 4, DateTime.Now.AddYears(3));
            MovieRatings movieRating4 = new MovieRatings(4, 1, 3, DateTime.Now.AddYears(2));
            MovieRatings movieRating5 = new MovieRatings(3, 2, 1, DateTime.Now);
            movieRatingRepository.Add(movieRating1);
            movieRatingRepository.Add(movieRating2);
            movieRatingRepository.Add(movieRating3);
            movieRatingRepository.Add(movieRating4);
            movieRatingRepository.Add(movieRating5);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<MovieRatings> expected = new List<MovieRatings>() { movieRating1, movieRating2, movieRating3, movieRating4 };
            List<MovieRatings> actual = movieRatingService.getAllReviewersFromMovie(1);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(4, 0)]
        [InlineData(5, 6)]
        [InlineData(0, 1)]
        public void InvalidGrade_ThrowsArgumentException(int movie, int grade)
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            movieRatingRepository.Add(new MovieRatings(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRatings(2, 3, 3, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.getCountOfGradesGottenByMovie(movie, grade);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void InvalidReviewerID_ThrowsArgumentException()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.getNumberOfReviewsFromReviewer(-1);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void InvalidMovieID_ThrowsArgumentException()
        {
            MovieReviewRepository movieRatingRepository = new MovieReviewRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.getCountOfMovieReviewers(-1);

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
