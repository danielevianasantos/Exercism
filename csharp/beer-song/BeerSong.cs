using System;
using System.Collections.Generic;
using System.Linq;

public static class BeerSong
{
    static string[] verses =
    {"No more bottles of beer on the wall, no more bottles of beer.\n",
     "Go to the store and buy some more, 99 bottles of beer on the wall.",
     "* bottles of beer on the wall, * bottles of beer.\n",
     "1 bottle of beer on the wall, 1 bottle of beer.\n",
     "Take one down and pass it around, # bottles of beer on the wall.",
     "Take one down and pass it around, 1 bottle of beer on the wall.",
     "Take it down and pass it around, no more bottles of beer on the wall."
    };
    public static string Recite(int startBottles, int takeDown)
    {
        var song_part = new List<string>();
        var song_T = "";
        if((startBottles < takeDown) && startBottles < 2)
        {
            return verses[0] + verses[1];
        }
        else if(takeDown == 1)
        {
            if(startBottles == 1)
                 return verses[3]+ verses[6];

             else if (startBottles == 2)
                return verses[2].Replace("*", startBottles.ToString()) + verses[5];

             else if(startBottles>2)
                 return (verses[2].Replace("*", startBottles.ToString()))+
                     (verses[4].Replace("#", (startBottles - 1).ToString()));

        }
        else if (takeDown > 1)
        {
            int j = 0;
            while (j < takeDown)
            {
                if((startBottles - j) <= 0)
                    song_part.Add( verses[0] + verses[1]);
                else if ((startBottles - j)==1)
                    song_part.Add(verses[3] + verses[6]);

                else if ((startBottles - j) == 2)
                    song_part.Add(verses[2].Replace("*", (startBottles-j).ToString())
                        + verses[5]);

                else if ((startBottles - j) > 2)
                    song_part.Add(verses[2].Replace("*", (startBottles - j).ToString())
                        + verses[4].Replace("#", (startBottles - j-1).ToString()));
                j++;
                if(j < takeDown)
                    song_part.Add("\n\n");
            }

        }

        foreach (var item in song_part)
        {
            song_T += item;
        }

        return song_T;

    }
}