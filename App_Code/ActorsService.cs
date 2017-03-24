using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ActorsService
/// </summary>
public class ActorsService
{
    protected OleDbConnection myConn;
    OleDbParameter objParam;

    public ActorsService()
    {
        myConn = new OleDbConnection(Connect.getConnectionString());

    }

    public void InsertActor(ActorsDetails actor)
    {

    }
}