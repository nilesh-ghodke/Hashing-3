using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class Favourite_Genres
    {
        /*
         * T.C: O(NK) + O(MZ) where n is no of songs, k  length of songs, M no of users, z no of songs for users
         * S.C: O(N) where n is no of genere and 
         * 
         */
        public static Dictionary<string, List<string>> favouriteGenere(Dictionary<string, List<string>> userSong, Dictionary<string, List<string>> songGenere)
        {
            Dictionary<string, string> songGenereMap = new Dictionary<string, string>();
            Dictionary<string, List<string>> UserGenere = new Dictionary<string, List<string>>();
           

            foreach(var key in songGenere.Keys)
            {
                List<string> songs = songGenere[key];

                foreach(string song in songs)
                {
                    songGenereMap.Add(song, key);
                }
            }

            int max = 0;

            foreach(var key in userSong.Keys)
            {
                List<string> songs = userSong[key];
                Dictionary<string, int> GenereFrequency = new Dictionary<string, int>();
                List<string> lstGenere = new List<string>();
                foreach (string song in songs)
                {
                    string genere = songGenereMap[song];
                    if(!GenereFrequency.ContainsKey(genere))
                    {
                        GenereFrequency.Add(genere, 1);
                    }
                    else
                    {
                        GenereFrequency[genere]++;
                    }
                    max = Math.Max(max, GenereFrequency[genere]);
                }

                foreach (string gen in GenereFrequency.Keys)
                {
                    if (GenereFrequency[gen] == max)
                    {
                        lstGenere.Add(gen);
                    }
                }

                UserGenere.Add(key, lstGenere);
            }

            return UserGenere;
        }
    }
}
