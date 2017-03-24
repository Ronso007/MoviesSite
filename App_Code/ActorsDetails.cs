using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Actors
/// </summary>
public class Actors
{
        private string name;

    public Actors(string Name)
    {
        name = Name;
    }
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
}