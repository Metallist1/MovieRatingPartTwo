using NewTestProject.Core.DomainService;
using NewTestProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewTestProject.Core.ApplicationService.ImplService
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieReviewRepository _movieReviewRepository;

        public MovieRatingService(IMovieReviewRepository movieReviewRepository)
        {
            _movieReviewRepository = movieReviewRepository;
        }
        public double averageRatingRecievedByMovie(int movieID)
        {
            checkForMovieAndReviewException(movieID);
            return _movieReviewRepository.averageRatingRecievedByMovie(movieID);
        }

        public List<MovieRatings> getAllMoviesByReviewer(int reviewerID)
        {
            checkForMovieAndReviewException(reviewerID);
            return _movieReviewRepository.getAllMoviesByReviewer(reviewerID);
        }

        public List<MovieRatings> getAllReviewersFromMovie(int movieID)
        {
            checkForMovieAndReviewException(movieID);
            return _movieReviewRepository.getAllReviewersFromMovie(movieID);
        }

        public double getAverageRateGivenByReviewer(int reviewerID)
        {
            checkForMovieAndReviewException(reviewerID);
            return _movieReviewRepository.getAverageRateGivenByReviewer(reviewerID);
        }

        public int getCountOfGradesGivenByReviewer(int revieweID, int grade)
        {
            checkForMovieAndReviewException(revieweID);
            checkForGradeException(grade);
            return _movieReviewRepository.getCountOfGradesGivenByReviewer(revieweID, grade);
        }

        public int getCountOfGradesGottenByMovie(int movieID, int grade)
        {
            checkForMovieAndReviewException(movieID);
            checkForGradeException(grade);
            return _movieReviewRepository.getCountOfGradesGottenByMovie(movieID, grade);
        }

        public int getCountOfMovieReviewers(int movieID)
        {
            checkForMovieAndReviewException(movieID);
            return _movieReviewRepository.getCountOfMovieReviewers(movieID);
        }

        public List<int> getIdOfTopGradedMovies()
        {
            return _movieReviewRepository.getIdOfTopGradedMovies();
        }

        public int getNumberOfReviewsFromReviewer(int reviewerID)
        {
            checkForMovieAndReviewException(reviewerID);
            return _movieReviewRepository.getNumberOfReviewsFromReviewer(reviewerID);
        }

        public List<int> getTopMoviesByAverageGrade(int count)
        {

            checkForMovieAndReviewException(count);
            return _movieReviewRepository.getTopMoviesByAverageGrade(count);
        }

        public List<int> getTopReviewers()
        {
            return _movieReviewRepository.getTopReviewers();
        }
        private void checkForGradeException(int checkableGrade)
        {
            if (checkableGrade > 0 && checkableGrade < 6)
            {
                throw new ArgumentException("Invalid Grade");
            }
        }
        private void checkForMovieAndReviewException(int checkableItem)
        {
            if(checkableItem < 1)
            {
                throw new ArgumentException("The item cannot be a negative number");
            }
        }
    }
}
