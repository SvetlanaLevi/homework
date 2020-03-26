using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema
{
    class FilmNode : Film, IComparable<FilmNode>
    {
        public int TimeLeft { get; set; }
        public FilmNode PreviousFilm { get; set; }

        public List<FilmNode> NextFilms { get; set; }


        public int CompareTo(FilmNode? obj)
        {
            return this.TimeLeft.CompareTo(obj.TimeLeft);
        }
    }
}
