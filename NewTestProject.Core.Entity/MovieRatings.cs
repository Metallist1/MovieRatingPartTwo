using System;
using System.Collections.Generic;
using System.Text;

namespace NewTestProject.Core.Entity
{
    public class MovieRatings
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; private set; }

        public MovieRatings(int reviewer, int movie, int grade, DateTime date)
        {
            this.Reviewer = reviewer;
            this.Movie = movie;
            this.Grade = grade;
            this.Date = date;
        }
    }
}
