using System;
using System.Collections.Generic;
using Bazzr;
using MySql.Data.MySqlClient;

namespace Bazzr.Models
{
    public class Game
    {
        private int _id;
        private string _title;
        private string _platform;
        private string _description;
        private string _photopath;
        private int _metascore;

        public Game(string title, string platform, string description, string photopath, int metascore, int id = 0)
        {
            _id = id;
            _title = title;
            _platform = platform;
            _description = description;
            _photopath = photopath;
            _metascore = metascore;
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

        public int GetId()
        {
            return _id;
        }

        public void SetId(int newId)
        {
            _id = newId;
        }

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string newTitle)
        {
            _title = newTitle;
        }

        public string GetPlatform()
        {
            return _platform;
        }

        public void SetPlatform(string newPlatform)
        {
            _platform = newPlatform;
        }

        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string newDescription)
        {
            _description = newDescription;
        }

        public string GetPhotoPath()
        {
            return _photopath;
        }

        public void SetPhotoPath(string newPhotopath)
        {
            _photopath = newPhotopath;
        }

        public int GetMetaScore()
        {
            return _metascore;
        }

        public void SetMetascore(int newMetascore)
        {
            _metascore = newMetascore;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO games (title, platform, description, photopath, metascore)
            VALUES (@title, @platform, @description, @photopath, @metascore);";

            MySqlParameter title = new MySqlParameter("@title", _title);
            cmd.Parameters.Add(title);

            MySqlParameter platform = new MySqlParameter("@platform", _platform);
            cmd.Parameters.Add(platform);

            MySqlParameter description = new MySqlParameter("@description", _description);
            cmd.Parameters.Add(description);

            MySqlParameter photopath = new MySqlParameter("@photopath", _photopath);
            cmd.Parameters.Add(photopath);

            MySqlParameter metascore = new MySqlParameter("@metascore", _metascore);
            cmd.Parameters.Add(metascore);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Game Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter("@searchId", id);
            cmd.Parameters.Add(searchId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int gameId = 0;
            string gameTitle = "";
            string gamePlatform = "";
            string gameDescription = "";
            string gamePhotopath = "";
            int gameMetascore = 0;

            while(rdr.Read())
            {
                gameId = rdr.GetInt32(0);
                gameTitle = rdr.GetString(1);
                gamePlatform = rdr.GetString(2);
                gameDescription = rdr.GetString(3);
                gamePhotopath = rdr.GetString(4);
                gameMetascore = rdr.GetInt32(5);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            Game myGame = new Game(gameTitle, gamePlatform, gameDescription, gamePhotopath, gameMetascore, gameId);
            return myGame;
        }

        public static List<Game> GetAll()
        {
            List<Game> allGames = new List<Game>{};
            MySqlConnection conn = DB.Connection();

            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int gameId = 0;
            string gameTitle = "";
            string gamePlatform = "";
            string gameDescription = "";
            string gamePhotopath = "";
            int gameMetascore = 0;

            while(rdr.Read())
            {
                gameId = rdr.GetInt32(0);
                gameTitle = rdr.GetString(1);
                gamePlatform = rdr.GetString(2);
                gameDescription = rdr.GetString(3);
                gamePhotopath = rdr.GetString(4);
                gameMetascore = rdr.GetInt32(5);
                Game newGame = new Game(gameTitle, gamePlatform, gameDescription, gamePhotopath, gameMetascore, gameId);
                allGames.Add(newGame);
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return allGames;
        }

        public void Edit(string newTitle, string newPlatform, string newDescription, string newPhotopath, int newMetascore)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE games SET title = @newTitle, platform = @newPlatform, description = @newDescription, photopath = @newPhotopath, metascore = @newMetascore WHERE id=@id;";

            MySqlParameter updateTitle = new MySqlParameter("@newTitle", newTitle);
            MySqlParameter updatePlatform = new MySqlParameter("@newPlatform", newPlatform);
            MySqlParameter updateDescription = new MySqlParameter("@newDescription", newDescription);
            MySqlParameter updatePhotopath = new MySqlParameter("@newPhotopath", newPhotopath);
            MySqlParameter updateMetascore = new MySqlParameter("@newMetascore", newMetascore);
            cmd.Parameters.Add(updateTitle);
            cmd.Parameters.Add(updatePlatform);
            cmd.Parameters.Add(updateDescription);
            cmd.Parameters.Add(updatePhotopath);
            cmd.Parameters.Add(updateMetascore);

            cmd.ExecuteNonQuery();
            _title = newTitle;
            _platform = newPlatform;
            _description = newDescription;
            _photopath = newPhotopath;
            _metascore = newMetascore;

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public void AddTag(Tag newTag)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO games_tags (game_id, tag_id) VALUES (@gameId, @tagId);";

          MySqlParameter gameId = new MySqlParameter("@gameId", _id);
          MySqlParameter tagId = new MySqlParameter("@tagId", newTag.GetId());
          cmd.Parameters.Add(gameId);
          cmd.Parameters.Add(tagId);

          cmd.ExecuteNonQuery();

          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }
        }

        public List<Tag> GetTags()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT tags.* FROM games
            JOIN games_tags ON (games.id = games_tags.game_id)
            JOIN tags ON (games_tags.tag_id = tags.id)
            WHERE games.id = @gameId;";

          MySqlParameter gameId = new MySqlParameter("@gameId", _id);
          cmd.Parameters.Add(gameId);

          List<Tag> relatedTags = new List<Tag>{};

          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int tagId = rdr.GetInt32(0);
            string tagName = rdr.GetString(1);
            Tag newTag = new Tag(tagName, tagId);
            relatedTags.Add(newTag);
          }

          conn.Close();
          if(conn != null)
          {
              conn.Dispose();
          }

          return relatedTags;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM games WHERE id = @thisId;";

            MySqlParameter searchId = new MySqlParameter ("@thisId", _id);
            cmd.Parameters.Add(searchId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM games;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
