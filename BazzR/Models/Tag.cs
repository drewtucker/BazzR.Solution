using System;
using System.Collections.Generic;
using Bazzr;
using MySql.Data.MySqlClient;

namespace Bazzr.Models
{
  public class Tag
  {
    private int _id;
    private string _name;

    public Tag(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

  }
}
