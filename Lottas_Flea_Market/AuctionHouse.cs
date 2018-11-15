using System;
using System.Collections.Generic;

namespace Lottas_Flea_Market {

  static class RandomExtensions {
    public static void Shuffle<T> (this Random rng, T[] array) {
      int n = array.Length;
      while (n > 1) 
      {
        int k = rng.Next(n--);
        T temp = array[n];
        array[n] = array[k];
        array[k] = temp;
      }
    }
  }

  public class BidderList {
    public List<string> items { set; get; }
    public List<User> users { set; get; }

    public User[] getBidders() {
      Random rd = new Random();
      int bidders = rd.Next(3, 7);
      List<User> random_bidders = new List<User>();

      User[] array = users.ToArray();
      new Random().Shuffle(array);
      return array;
    }

    public void Auction()
    {
        int bid = 0;
        int higherBid = 0;


      for (int i = 0; i < items.Count; i++) {
        User[] bidders = getBidders();
        boolean Sale = false;
          while (Sale!=True)
          {
              higherBid = bidders(i).capital / 10;
              if (higherBid > 5 && (bid + higherBid)<(bidders(i).capital * 0.6))
              {
                bid = bid + higherBid;
                  Console.WriteLine(bidders(i) + " has bid: " + bid);
              }else{
                continue;
              }
          }
      }
    }
  }

} // Lottas_Flea_Market
