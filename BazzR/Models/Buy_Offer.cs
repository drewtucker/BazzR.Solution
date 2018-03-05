using System;
﻿using System;
using System.Collections.Generic;
using BazzrApp;
using MySql.Data.MySqlClient;

namespace BazzrApp.Models
{

  public class Buy_Offer
  {
    private int _id;
    private int _gameId;
    private int _userIdBuyer;
    private int _transaction_SellId;
    private DateTime _date;

    public Buy_Offer(int game_id, DateTime date, int user_id_buyer, int transaction_Sell_id = 0, int id = 0)
    {
      _id = id;
      _gameId = game_id;
      _userIdBuyer = user_id_buyer;
      _date = date;
      _transaction_SellId = transaction_Sell_id;
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
      return _userIdBuyer;
    }
    public DateTime GetDate()
    {
      return _date;
    }
    public int GetTransaction_SellId()
    {
      return _transaction_SellId;
    }

    public void Save()
    {
      //save game to database
    }

    public static List<Buy_Offer> GetAll()
    {
      //update - get all games from database
      List<Buy_Offer> allBuy_Offer = new List<Buy_Offer>{};
      return allBuy_Offer;
    }

    //public void Edit(string newTitle, etc.)
    //edit title / other options in database
  }
}
=======
	public class Buy_Offer
	{
		private int _id;
		private int _gameId;
		private int _userIdBuyer;
		private int _transaction_SellId;
		private DateTime _date;

		public Buy_Offer(int game_id, DateTime date, int user_id_buyer, int transaction_Sell_id = 0, int id = 0)
		{
			_id = id;
			_gameId = game_id;
			_userIdBuyer = user_id_buyer;
			_date = date;
			_transaction_SellId = transaction_Sell_id;
		}

		public override bool Equals(System.Object otherBuy_Offer)
		{
			if (!(otherBuy_Offer is Buy_Offer))
			{
				return false;
			}
			else
			{
				Buy_Offer newBuy_Offer = (Buy_Offer)otherBuy_Offer;
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
			return _userIdBuyer;
		}
		public DateTime GetDate()
		{
			return _date;
		}
		public int GetTransaction_SellId()
		{
			return _transaction_SellId;
		}

		public void Save()
		{
			//save game to database
		}

		public static List<Buy_Offer> GetAll()
		{
			//update - get all games from database
			List<Buy_Offer> allBuy_Offer = new List<Buy_Offer> { };
			return allBuy_Offer;
		}

		//public void Edit(string newTitle, etc.)
		//edit title / other options in database
	}
}
>>>>>>> Stashed changes
