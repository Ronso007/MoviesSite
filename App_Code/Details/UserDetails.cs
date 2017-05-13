using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetails
/// </summary>
public class UserDetails
{
    private string username;
    private string name;
    private string email;
    private string password;
    private DateTime birthday;
    private bool admin;

    public UserDetails()
    {

    }
    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
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

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public DateTime Birthday
    {
        get
        {
            return birthday;
        }

        set
        {
            birthday = value;
        }
    }

    public bool Admin
    {
        get
        {
            return admin;
        }

        set
        {
            admin = value;
        }
    }
}