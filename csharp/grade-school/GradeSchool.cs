using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    public Dictionary<string,int > students = new Dictionary<string, int>();
    public GradeSchool()
    {
        students = new Dictionary<string, int>();
    }
    public void Add(string student, int grade) => students.Add(student,grade);
    public IEnumerable<string> Roster()
    {
        var classes = new List<string>();
        IEnumerable<string> all_classes = (IEnumerable<string>)students
            .OrderBy(student => student.Value)
            .ThenBy(student =>student.Key)
            .Select(student => student.Key);
        foreach (var student in all_classes)
        {
            classes.Add(student);
        }
        return classes;
    }

    public IEnumerable<string> Grade(int grade)
    {
        List<string> classes = new List<string>();
        foreach (var student in students)
        {
            if(student.Value==grade)
                classes.Add(student.Key);
        }

        return classes.OrderBy(name => name);
    }
    
}