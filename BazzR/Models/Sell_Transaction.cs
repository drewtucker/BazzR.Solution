using System;
using System.Collections.Generic;
using Bazzr;
using MySql.Data.MySqlClient;

namespace Bazzr.Models
{
    public class Sell_Transaction
    {
        private int _id;
        private int _gameId;
        private int _userIdSeller;
        private int _userIdBuyer;
        private string _status;
        private DateTime _date;
        private string _gamePhoto;

        public Sell_Transaction(int game_id, int user_id_seller, string status, DateTime date, string game_photo, int user_id_buyer = 0, int id = 0)
        {
            _id = id;
            _gameId = game_id;
            _userIdSeller = user_id_seller;
            _userIdBuyer = user_id_buyer;
            _date = date;
            _status = status;
            _gamePhoto = game_photo;
        }

        public override bool Equals(System.Object otherSell_Transaction)
        {
            if (!(otherSell_Transaction is Sell_Transaction))
            {
                return false;
            }
            else
            {
                Sell_Transaction newSell_Transaction = (Sell_Transaction) otherSell_Transaction;
                return this.GetId().Equals(newSell_Transaction.GetId());
            }
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetStatus()
        {
            return _status;
        }

        public string GetGamePhoto()
        {
            return _gamePhoto;
        }

        public int GetId()
        {
            return _id;
        }
        public int GetUserIdSeller()
        {
            return _userIdSeller;
        }
        public int GetGameId()
        {
            return _gameId;
        }
        public int GetUserIdBuyer()
        {
            return _userIdBuyer;
        }
        public DateTime GetDate()
        {
            return _date;
        }

        public static List<Sell_Transaction> GetAll()
        {
            List<Sell_Transaction> allSell_Transaction = new List<Sell_Transaction> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM sell_transaction;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                int userseller = rdr.GetInt32(1);
                int userbuyer = rdr.GetInt32(2);
                int gameId = rdr.GetInt32(3);
                string status = rdr.GetString(4);
                string gamePhoto = rdr.GetString(5);
                DateTime date = rdr.GetDateTime(6);

                Sell_Transaction newSell_Transaction = new Sell_Transaction(gameId, userseller, status, date, gamePhoto, userbuyer,id);
                allSell_Transaction.Add(newSell_Transaction);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSell_Transaction;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO sell_transaction (game_id, user_seller, status, date, photo_of_traded_game, user_buyer)
                VALUES (@GId, @UsrS, @stat, @Date, @GamePhoto, @UsrB);";

            MySqlParameter game_id = new MySqlParameter();
            game_id.ParameterName = "@GId";
            game_id.Value = _gameId;
            cmd.Parameters.Add(game_id);
            MySqlParameter user_sell = new MySqlParameter();
            user_sell.ParameterName = "@UsrS";
            user_sell.Value = _userIdSeller;
            cmd.Parameters.Add(user_sell);
            MySqlParameter stat = new MySqlParameter();
            stat.ParameterName = "@stat";
            stat.Value = _status;
            cmd.Parameters.Add(stat);
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = _date;
            cmd.Parameters.Add(date);
            MySqlParameter gphoto = new MySqlParameter();
            gphoto.ParameterName = "@GamePhoto";
            gphoto.Value = _gamePhoto;
            cmd.Parameters.Add(gphoto);
            MySqlParameter user_buy = new MySqlParameter();
            user_buy.ParameterName = "@UsrB";
            user_buy.Value = _userIdBuyer;
            cmd.Parameters.Add(user_buy);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM sell_transaction;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Sell_Transaction Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM sell_transaction WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int foundid = 0;
            int userseller = 0;
            int userbuyer = 0;
            int gameId = 0;
            string status = "";
            string gamePhoto = "";
            DateTime date = new DateTime (2000, 1, 1, 1, 0, 0);

            while (rdr.Read())
            {
                foundid = rdr.GetInt32(0);
                userseller = rdr.GetInt32(1);
                userbuyer = rdr.GetInt32(2);
                gameId = rdr.GetInt32(3);
                status = rdr.GetString(4);
                gamePhoto = rdr.GetString(5);
                date = rdr.GetDateTime(6);
            }

            Sell_Transaction foundSell_Transaction = new Sell_Transaction(gameId, userseller, status, date, gamePhoto, userbuyer, foundid);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundSell_Transaction;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM sell_transaction WHERE id = @searchId;";

            MySqlParameter myid = new MySqlParameter();
            myid.ParameterName = "searchId";
            myid.Value = _id;
            cmd.Parameters.Add(myid);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Edit(int ngame_id, int nuser_id_seller, string nstatus, DateTime ndate, string ngame_photo, int nuser_id_buyer)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE sell_transaction
                SET user_seller = @Usell, user_buyer = @Ubuy, game_id = @GId, status = @stat, photo_of_traded_game = @photo, date = @Date
                WHERE id = @thisId;";

            MySqlParameter myid = new MySqlParameter();
            myid.ParameterName = "thisId";
            myid.Value = _id;
            cmd.Parameters.Add(myid);
            MySqlParameter user_sell = new MySqlParameter();
            user_sell.ParameterName = "@Usell";
            user_sell.Value = nuser_id_seller;
            cmd.Parameters.Add(user_sell);
            MySqlParameter user_buy = new MySqlParameter();
            user_buy.ParameterName = "@UBuy";
            user_buy.Value = nuser_id_buyer;
            cmd.Parameters.Add(user_buy);
            MySqlParameter game_id = new MySqlParameter();
            game_id.ParameterName = "@GId";
            game_id.Value = ngame_id;
            cmd.Parameters.Add(game_id);
            MySqlParameter stat = new MySqlParameter();
            stat.ParameterName = "@stat";
            stat.Value = nstatus;
            cmd.Parameters.Add(stat);
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = ndate;
            cmd.Parameters.Add(date);
            MySqlParameter gphoto = new MySqlParameter();
            gphoto.ParameterName = "@photo";
            gphoto.Value = ngame_photo;
            cmd.Parameters.Add(gphoto);

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
