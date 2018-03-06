using System;
using System.Collections.Generic;
using Bazzr;
using MySql.Data.MySqlClient;

namespace Bazzr.Models
{
    public class Buy_Offer
    {
        private int _id;
        private int _gameId;
        private int _offererId;
        private int _sellTransactionId;
        private DateTime _date;

        public Buy_Offer(int game_id, DateTime date, int offerer_id, int sell_transaction_id = 0, int id = 0)
        {
            _id = id;
            _gameId = game_id;
            _offererId = offerer_id;
            _date = date;
            _sellTransactionId = sell_transaction_id;
        }

        public override bool Equals(System.Object otherBuy_Offer)
        {
            if (!(otherBuy_Offer is Buy_Offer))
            {
                return false;
            }
            else
            {
                Buy_Offer newBuy_Offer = (Buy_Offer) otherBuy_Offer;
                return this.GetId().Equals(newBuy_Offer.GetId());
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

        public int GetGameId()
        {
            return _gameId;
        }
        public int GetUserIdBuyer()
        {
            return _offererId;
        }
        public DateTime GetDate()
        {
            return _date;
        }
        public int GetSell_TransactionId()
        {
            return _sellTransactionId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO buy_offer (offerer_id, game_id, sell_transaction_id, date)
                VALUES (@OId, @GId, @STId, @Date);";

            MySqlParameter offerer_id = new MySqlParameter();
            offerer_id.ParameterName = "@OId";
            offerer_id.Value = _offererId;
            cmd.Parameters.Add(offerer_id);
            MySqlParameter game_id = new MySqlParameter();
            game_id.ParameterName = "@GId";
            game_id.Value = _gameId;
            cmd.Parameters.Add(game_id);
            MySqlParameter sell_transaction_id = new MySqlParameter();
            sell_transaction_id.ParameterName = "@STId";
            sell_transaction_id.Value = _sellTransactionId;
            cmd.Parameters.Add(sell_transaction_id);
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@Date";
            date.Value = _date;
            cmd.Parameters.Add(date);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Buy_Offer> GetAll()
        {
            List<Buy_Offer> allBuy_Offer = new List<Buy_Offer> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM buy_offer;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                int offererId = rdr.GetInt32(1);
                int gameId = rdr.GetInt32(2);
                int transaction_sell_id = rdr.GetInt32(3);
                DateTime date = rdr.GetDateTime(4);

                Buy_Offer newBuy_Offer = new Buy_Offer(gameId, date, offererId, transaction_sell_id, id);
                allBuy_Offer.Add(newBuy_Offer);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allBuy_Offer;
        }
        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM buy_offer;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Buy_Offer Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM buy_offer WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int foundid = 0;
            int offererId = 0;
            int gameId = 0;
            int transaction_sell_id = 0;
            DateTime date = new DateTime (2000, 1, 1, 1, 0, 0);

            while (rdr.Read())
            {
                foundid = rdr.GetInt32(0);
                offererId = rdr.GetInt32(1);
                gameId = rdr.GetInt32(2);
                transaction_sell_id = rdr.GetInt32(3);
                date = rdr.GetDateTime(4);
            }
            Buy_Offer foundBuy_Offer = new Buy_Offer(gameId, date, offererId, transaction_sell_id, foundid);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundBuy_Offer;
        }


      //public void Edit(string newTitle, etc.)
      //edit title / other options in database
    }
}
