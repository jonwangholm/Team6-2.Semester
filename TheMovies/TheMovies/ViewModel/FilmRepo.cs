using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.ViewModel
{
    public class FilmRepo
    {
        

        public void CreateFilm()
        {

        }

        public void UpdateFilm() 
        {

        }

        public void DeleteFilm() 
        {
            
        }

        public void ReadFilm()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("Files/Ex38-TheMovies.CSV"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] film = line.Split(';');
                        Console.WriteLine(film[3], film[4], film[5], film[6], film[7]);
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


    }
}
