using System;
using System.Collections.Generic;
using Bazzr;
using MySql.Data.MySqlClient;
using System.Data;

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

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public override bool Equals(System.Object otherTag)
        {
            if(!(otherTag is Tag))
            {
                return false;
            }
            else
            {
                Tag newTag = (Tag) otherTag;
                return this.GetId().Equals(newTag.GetId());
            }
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO tags (name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = _name;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public static Tag Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM tags WHERE id = @id;";

            MySqlParameter searchTagId = new MySqlParameter();
            searchTagId.ParameterName = "@id";
            searchTagId.Value = id;
            cmd.Parameters.Add(searchTagId);

            int tagId = 0;
            string tagName = "";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                tagId = rdr.GetInt32(0);
                tagName = rdr.GetString(1);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }

            Tag myTag = new Tag(tagName, tagId);
            return myTag;
        }

        public static List<Tag> GetAll()
        {
            List<Tag> allTags = new List<Tag>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM tags;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int tagId = rdr.GetInt32(0);
                string tagName = rdr.GetString(1);
                Tag newTag = new Tag(tagName, tagId);
                allTags.Add(newTag);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allTags;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd =  conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM tags WHERE id = @thisId";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@thisId";
            searchId.Value = _id;
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

            var cmd =  conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM tags";
            cmd.ExecuteNonQuery();

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }

        public void Edit(string newName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE tags SET name = @newTagName WHERE id = @id;";

            MySqlParameter newTagName = new MySqlParameter();
            newTagName.ParameterName = "@newTagName";
            newTagName.Value = newName;
            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@newTagName";
            id.Value = _id;

            cmd.Parameters.Add(newTagName);
            cmd.Parameters.Add(id);

            cmd.ExecuteNonQuery();
            _name = newName;

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
