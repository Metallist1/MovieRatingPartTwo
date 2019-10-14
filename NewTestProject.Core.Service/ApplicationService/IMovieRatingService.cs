using System;
using System.Collections.Generic;
using NewTestProject.Core.Entity;
using System.Text;

namespace NewTestProject.Core.ApplicationService
{
    public interface IMovieRatingService
    {
        // 1. On input N, what are the number of reviews from reviewer N?
        int getNumberOfReviewsFromReviewer(int reviewerID);
        //2. On input N, what is the average rate that reviewer N had given?
        double getAverageRateGivenByReviewer(int reviewerID);
        //3. On input N and G, how many times has reviewer N given a movie grade G?
        int getCountOfGradesGivenByReviewer(int revieweID, int grade);
        //4. On input N, how many have reviewed movie N?
        int getCountOfMovieReviewers(int movieID);
        //5. On input N, what is the average rate the movie N had received?
        double averageRatingRecievedByMovie(int movieID);
        //6. On input N and G, how many times had movie N received grade G?
        int getCountOfGradesGottenByMovie(int movieID, int grade);
        //7. What is the id(s) of the movie(s) with the highest number of top rates(5)?
        List<int> getIdOfTopGradedMovies();
        //8. What reviewer(s) had done most reviews?
        List<int> getTopReviewers();
        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        List<int> getTopMoviesByAverageGrade(int count);
        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        List<MovieRatings> getAllMoviesByReviewer(int reviewerID);
        //11. On input N, what are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        List<MovieRatings> getAllReviewersFromMovie(int movieID);
    }
}
