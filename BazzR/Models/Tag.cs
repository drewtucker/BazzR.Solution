using System;
using System.Collections.Generic;
using BazzrApp;
using MySql.Data.MySqlClient;

namespace BazzrApp.Models
{
  public class Tag
  {
    private int _id;
    private string _name;

    public Tag(string name, int id = 0)
    {
      _int = int;
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
