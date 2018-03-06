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

    public Sell_Transaction(int game_id, int user_id_seller, string status, DateTime date, int user_id_buyer = 0, int id = 0)
    {
      _id = id;
      _gameId = game_id;
      _userIdSeller = user_id_seller;
      _userIdBuyer = user_id_buyer;
      _date = date;
      _status = status;
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

    public void Save()
    {
      //save game to database
    }

    public static List<Sell_Transaction> GetAll()
    {
      //update - get all games from database
      List<Sell_Transaction> allSell_Transaction = new List<Sell_Transaction>{};
      return allSell_Transaction;
    }

    //public void Edit(string newTitle, etc.)
    //edit title / other options in database
  }
}
