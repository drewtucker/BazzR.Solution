// using System;
// using System.Collections.Generic;
// using Bazzr;
// //using MySql.Data.MySqlClient;
//
// namespace Bazzr.Models
// {
//   public class Game
//   {
//     private int _id;
//     private string _title;
//     private string _platform;
//     private string _description;
//     private string _photopath;
//     private int _metascore;
//
//     public Game(string title, string platform, string description, string photopath, int metascore, int id = 0)
//     {
//       _id = id;
//       _title = title;
//       _platform = platform;
//       _description = description;
//       _photoPath = photopath;
//       _metaScore = metascore;
//     }
//
//     public override bool Equals(System.Object otherGame)
//     {
//       if (!(otherGame is Game))
//       {
//         return false;
//       }
//       else
//       {
//         Game newGame = (Game) otherGame;
//         return this.GetId().Equals(newGame.GetId());
//       }
//     }
//
//     public override int GetHashCode()
//     {
//       return this.GetId().GetHashCode();
//     }
//
//     //_id getter/setter
//     public int GetId()
//     {
//       return _id;
//     }
//     public void SetId(int newId)
//     {
//       _id = newId;
//     }
//
//     //_title getter/setter
//     public string GetTitle()
//     {
//       return _title;
//     }
//     public void SetTitle(string newTitle)
//     {
//       _title = newTitle;
//     }
//
//     //_platform getter/setter
//     public string GetPlatform()
//     {
//       return _platform;
//     }
//     public void SetPlatform(string newPlatform)
//     {
//       _platform = newPlatform;
//     }
//
//     //_description getter/setter
//     public string GetDescription()
//     {
//       return _description;
//     }
//     public void SetDescription(string newDescription)
//     {
//        MySqlConnection conn = DB.Connection();
//        conn.Open();
//
//        var cmd = conn.CreateCommand() as MySqlCommand;
//        cmd.CommandText = @"INSERT INTO games (title, platform, description, photopath, metascore) VALUES (@title, @platform, @description, @photopath, @metascore);";
//
//        MySqlParameter name = new MySqlParameter("@title, _title);
//        cmd.Parameters.Add(title);
//
//        MySqlParameter platform = new MySqlParameter("@platform, _platform);
//        cmd.Parameters.Add(platform);
//
//        MySqlParameter description = new MySqlParameter("@description, _description);
//        cmd.Parameters.Add(description);
//
//        MySqlParameter photopath = new MySqlParameter("@photopath, _photopath);
//        cmd.Parameters.Add(photopath);
//
//        MySqlParameter metascore = new MySqlParameter("@metascore, _metascore);
//        cmd.Parameters.Add(metascore);
//
//        cmd.ExecuteNonQuery();
//        _id = (int) cmd.LastInsertedId;
//        conn.Close();
//
//        if (conn != null)
//        {
//            conn.Dispose();
//        }
//     }
//
//     //_photopath getter/setter
//     public string GetPhotoPath()
//     {
//       return _photopath;
//     }
//     public void SetPhotoPath(string newPhotoPath)
//     {
//       _photopath = newPhotoPath;
//     }
//
//     //_metascore getter/setter
//     public int GetMetaScore()
//     {
//       return _metascore;
//     }
//     public void SetMetaScore(int newMetaScore)
//     {
//       _metascore = newMetaScore;
//     }
//
//     public void Save()
//   {
// -      //save game to database
// +       MySqlConnection conn = DB.Connection();
// +       conn.Open();
// +
// +       var cmd = conn.CreateCommand() as MySqlCommand;
// +       cmd.CommandText = @"INSERT INTO games (title, platform, description, photopath, metascore)
//         VALUES (@title, @platform, @description, @photopath, @metascore);";
// +
// +       MySqlParameter name = new MySqlParameter("@title", _title);
// +       cmd.Parameters.Add(title);
// +
// +       MySqlParameter platform = new MySqlParameter("@platform", _platform);
// +       cmd.Parameters.Add(platform);
// +
// +       MySqlParameter description = new MySqlParameter("@description", _description);
// +       cmd.Parameters.Add(description);
// +
// +       MySqlParameter photopath = new MySqlParameter("@photopath", _photopath);
// +       cmd.Parameters.Add(photopath);
// +
// +       MySqlParameter metascore = new MySqlParameter("@metascore", _metascore);
// +       cmd.Parameters.Add(metascore);
// +
// +       cmd.ExecuteNonQuery();
// +       _id = (int) cmd.LastInsertedId;
// +       conn.Close();
// +
// +       if (conn != null)
// +       {
// +           conn.Dispose();
// +       }
//   }
//
//
//
//     public static List<Game> GetAll()
//     {
//       //update - get all games from database
//       List<Game> allGames = new List<Game>{};
//       return allGames;
//     }
//
//     //public void Edit(string newTitle, etc.)
//     //edit title / other options in database
//   }
// }
