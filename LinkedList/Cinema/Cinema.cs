using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema
{
    class Cinema
    {
        public Cinema()
        {
            Films = new List<Film>(){
                new Film()
                {
                    Title = "Рапунцель",
                    Duration = 120
                },
                new Film()
                {
                    Title = "1+1",
                    Duration = 140,
                },
                new Film()
                {
                    Title = "Джентельмены удачи",
                    Duration = 80
                },
                new Film()
                {
                    Title = "Брат",
                    Duration = 90
                },
                new Film()
                {
                    Title = "Леон",
                    Duration = 75
                },

            };
            lastFilms = new List<FilmNode>();
            AllFilms = new Queue<Film>();

        }

        // public List<Step> Steps { get; set; }


        private FilmNode prevTimeTable; //последнее найденное рассписание с минимальным временем
        public List<Film> Films { get; set; }

        private List<FilmNode> lastFilms;

        public Queue<Film> AllFilms;
        public int Count { get; set; }


        public void Creator(int workTime)
        {
            FilmNode film = new FilmNode();
            AllFilms = new Queue<Film>(Films);
            CreateSchedule(workTime, film);
        }

        private void CreateSchedule(int currentTime, FilmNode film)
        {
            if (currentTime - film.Duration > 0)
            {
                if (AllFilms.Count > 0)
                {
                    var newFilm = AllFilms.Dequeue();
                    CreateSchedule(currentTime - film.Duration, new FilmNode
                    {
                        Title = newFilm.Title,
                        Duration = newFilm.Duration,
                        PreviousFilm = film,
                        NextFilms = null,
                        TimeLeft = currentTime - film.Duration,
                    });
                }
                else
                {
                    foreach (var varible in Films)
                    {
                        CreateSchedule(currentTime - film.Duration, new FilmNode
                        {
                            Title = varible.Title,
                            Duration = varible.Duration,
                            PreviousFilm = film,
                            NextFilms = null,
                            TimeLeft = currentTime - film.Duration
                        });
                    }
                }
            }
            else

            {
                lastFilms.Add(film);
            }
        }

        public void Write()
        {

            for (int i = 1; i <= Count; i++)
            {
                List<FilmNode> timeTable = new List<FilmNode>();
                Console.WriteLine($"---------ЗАЛ {i}----------");
                var film = Find();

                while (film != null && film.PreviousFilm != null)
                {
                    timeTable.Add(film);
                    film = film.PreviousFilm;
                }

                WriteTimeTable(timeTable);
            }

        }
        public FilmNode Find()
        {
            if (lastFilms.Count == 0) return prevTimeTable;
            var minTimeTable = lastFilms.Min();
            prevTimeTable = minTimeTable;
            lastFilms.Remove(minTimeTable);
            return minTimeTable;
        }


        public void WriteTimeTable(List<FilmNode> films)
        {
            var workEnd = DateTime.Today.AddHours(22);

            var time = DateTime.Today;
            time = time.AddHours(8);
            films.RemoveAt(films.Count - 1);
            foreach (var varible in films)
            {

                var next = time.AddMinutes((double)varible.Duration);
                Console.WriteLine($"{time.Hour}:{time.Minute}-" +
                                  $"{next.Hour}:{next.Minute}\t" +
                                  $"{varible.Title} ");

                time = next;
            }

            Console.WriteLine($"Осталось {workEnd.Subtract(time).Hours}:{workEnd.Subtract(time).Minutes}(минут)");
        }
    }
}
