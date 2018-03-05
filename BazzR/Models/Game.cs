using System;
using System.Collections.Generic;
using Bazzr;
//using MySql.Data.MySqlClient;

namespace Bazzr.Models
{
  public class Game
  {
    private int _id;
    private string _title;
    private string _platform;

    public Game(string title, string platform, int id = 0)
    {
      _id = id;
      _title = title;
      _platform = platform;
    }

    public override bool Equals(System.Object otherGame)
    {
      if (!(otherGame is Game))
      {
        return false;
      }
      else
      {
        Game newGame = (Game) otherGame;
        return this.GetId().Equals(newGame.GetId());
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public string GetTitle()
    {
      return _title;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      //save game to database
    }

    public static List<Game> GetAll()
    {
      //update - get all games from database
      List<Game> allGames = new List<Game>{};
      return allGames;
    }

    //public void Edit(string newTitle, etc.)
    //edit title / other options in database
  }
}
