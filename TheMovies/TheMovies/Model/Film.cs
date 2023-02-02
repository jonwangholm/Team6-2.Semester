using System;

namespace TheMovies.Model
{
    public class Film
    {
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public DateTime PremiereDate { get; set; }
        public string Title { get; set; }
    }
}
