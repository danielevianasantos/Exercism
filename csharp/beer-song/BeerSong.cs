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
     "Take one down and pass it around, # bottle of beer on the wall.",
     "Take it down and pass it around, no more bottles of beer on the wall."
    };
    public static string Recite(int startBottles, int takeDown)
    {
        var song_part = new List<string>();
        var song_T = "";
        if(startBottles < takeDown)
        {
            return verses[0] + verses[1];
        }
        else if (((startBottles == 2) ||(startBottles == takeDown)) && (takeDown == 1))
        {
            return verses[3] + verses[6];
        }
        else if(takeDown==1 && startBottles>2)
        {
            return (verses[2].Replace("*", startBottles.ToString()))+
                (verses[4].Replace("#", (startBottles - 1).ToString()));
        }
        var j = startBottles;
        if((startBottles - takeDown )==1)
        {
            do
            {
                song_part.Insert(0, verses[2].Replace("*", startBottles.ToString())+
                    verses[5].Replace("#", (startBottles - takeDown).ToString()));
            } while (j >= takeDown);
        }

        else
        {
            song_part.Add( verses[2].Replace("*", startBottles.ToString()) +
            verses[4].Replace("#", (startBottles - 1).ToString()));
            j =1;
            do
            {
                song_part.Add("\n");
                if (j<=takeDown)
                {
                    song_part.Insert(0, verses[2].Replace("*", startBottles.ToString()) +
                    verses[5].Replace("#", (startBottles - j).ToString()));
                }
                else if ((takeDown - j) == 0 && (startBottles == takeDown)) 
                {
                    song_part.Add(verses[3] + verses[6]);
                    song_part.Add("\n");
                    song_part.Add(verses[0] + verses[1]);
                }
                j++;
            } while (j<= takeDown);
        }
        foreach(var item in song_part)
        {
            song_T += item;
        }

        return song_T;

    }
}