using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TheMovies.Model;

namespace TheMovies.ViewModel.Persistence
{
    public class FilmRepo
    {
        #region Singleton Pattern
        // Implementation of Singleton pattern, to ensure there only exists one single instance of this class!
        private static FilmRepo _instance;
        public static FilmRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FilmRepo();
                    return _instance;
                }

                return _instance;
            }
        }

        private FilmRepo()
        {

        }
        #endregion

        private string filePath = Path.GetFullPath("../../../Files/RegisteredFilms.csv");

        List<Film> films = new();

        #region CRUD
        public Film CreateFilm(string title, string genre, int duration, string director, DateTime premiereDate)
        {
            Film newFilm = new Film(title, genre, duration, director, premiereDate);

            films.Add(newFilm);

            return newFilm;
        }

        public List<Film> RetrieveAll()
        {
            return films;
        }

        public void UpdateFilm()
        {

        }

        public void DeleteFilm()
        {

        }
        #endregion

        public void Load()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] film = line.Split(';');

                        string title = film[0];
                        string genre = film[1];
                        int duration = int.Parse(film[2]);
                        string director = film[3];
                        DateTime premiereDate = DateTime.Parse(film[4]);

                        Film newFilm = new Film(title, genre, duration, director, premiereDate);

                        films.Add(newFilm);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void Save()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Film film in films)
                {
                    sw.WriteLine(film);
                }


            }
        }
    }
}
