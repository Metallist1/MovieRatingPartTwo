using NewTestProject.Core.DomainService;
using NewTestProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewTestProject.Infrastructure
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        private List<MovieRatings> _movieRatings = new List<MovieRatings>();

        public void AddJSON(List<MovieRatings> newList)
        {
            _movieRatings= newList;
        }
        public void Add(MovieRatings movieRating)
        {
            _movieRatings.Add(movieRating);
        }
        public double averageRatingRecievedByMovie(int movieID)
        {
            return _movieRatings
                .Where(mr => mr.Movie == movieID)
                .Select(mr => mr.Grade)
                .DefaultIfEmpty(0)
                .Average();
        }

        public List<MovieRatings> getAllMoviesByReviewer(int reviewerID)
        {
            return _movieRatings
                .Where(mr => mr.Reviewer == reviewerID)
                .OrderByDescending(mr => mr.Grade)
                .ThenByDescending(mr => mr.Date)
                .ToList();
        }

        public List<MovieRatings> getAllReviewersFromMovie(int movieID)
        {
            return _movieRatings
                .Where(mr => mr.Movie == movieID)
                .OrderByDescending(mr => mr.Grade)
                .ThenByDescending(mr => mr.Date)
                .ToList();
        }

        public double getAverageRateGivenByReviewer(int reviewerID)
        {
            return _movieRatings
                .Where(mr => mr.Reviewer == reviewerID)
                .Select(mr => mr.Grade)
                .DefaultIfEmpty(0)
                .Average();
        }

        public int getCountOfGradesGivenByReviewer(int revieweID, int grade)
        {
            return _movieRatings
                .Where(mr => mr.Reviewer == revieweID && mr.Grade == grade)
                .Count();
        }

        public int getCountOfGradesGottenByMovie(int movieID, int grade)
        {
            return _movieRatings
                .Where(mr => mr.Movie == movieID && mr.Grade == grade)
                .Count();
        }

        public int getCountOfMovieReviewers(int movieID)
        {
            return _movieRatings
                .Where(mr => mr.Movie == movieID)
                .Count();
        }

        public List<int> getIdOfTopGradedMovies()
        {
            return _movieRatings
                .OrderByDescending(mr => mr.Grade)
                .Select(mr => mr.Movie)
                .Distinct()
                .ToList();
        }

        public int getNumberOfReviewsFromReviewer(int reviewerID)
        {
            return _movieRatings
                .Where(mr => mr.Reviewer == reviewerID)
                .Count();
        }

        public List<int> getTopMoviesByAverageGrade(int count)
        {
            return _movieRatings
                 .OrderByDescending(mr => mr.Grade)
                 .Select(mr => mr.Movie)
                 .Distinct()
                 .Take(count)
                 .ToList();
        }

        public List<int> getTopReviewers()
        {
            return _movieRatings.
                GroupBy(mr => mr.Reviewer).
                OrderByDescending(mr => mr.Count()).
                Select(mr => mr.Key).ToList();
        }
    }
}
