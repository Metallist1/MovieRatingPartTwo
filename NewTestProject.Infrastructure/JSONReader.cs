using NewTestProject.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewTestProject.Infrastructure
{
    public class JSONReader
    {
        public List<MovieRatings> LoadData()
        {
            using (StreamReader r = new StreamReader("../../../../NewTestProject.Infrastructure/ratings.json"))
            {
                string json = r.ReadToEnd();
                List<MovieRatings> items = JsonConvert.DeserializeObject<List<MovieRatings>>(json);
                return items;
            }
        }
    }
}
