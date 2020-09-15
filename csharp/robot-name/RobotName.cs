using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{ 
        private static HashSet<string> _names = new HashSet<string>();
    private readonly Random number = new Random();

    public Robot()
        {
            Reset();
        }
        public string Name { get; private set; }

        public void Reset()
        {
            Name = GetName();
        }

    public string GetName()
        {
        string robotName = "";
        do
        {
            for (int i = 0; i < 5; i++)
            {
                robotName += (i < 2) ? ((char)number.Next(65, 90)).ToString() : number.Next(0, 9).ToString();
            }
        } while (!NewName(robotName));
        return robotName.ToString();
        }

        public bool NewName(string name)
        {
            return _names.Add(name);
        }
    
}