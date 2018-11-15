using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

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

    public BidderList() {
      this.users = Bank.users;
    }

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
        Stopwatch stopwatch = new Stopwatch();
        string lastBidder = "";

      for (int i = 0; i < items.Count; i++) {
        int bid = 0;
        int higherBid = 0;
        User[] bidders = getBidders();
        bool Sale = false;
        Console.WriteLine(items[i] + " is up for sale");
          while (Sale!=true)
          {
            for (int j = 0; j < users.Count; ++j) {
              higherBid = bidders[j].capital / 10; if (higherBid > 5 && (bid + higherBid) <(bidders[j].capital * 0.6) && bidders[j].name != lastBidder)
              {
                  bid = bid + higherBid;
                  lastBidder = bidders[j].name;
                  Console.WriteLine(bidders[j].name + " has bid: " + bid);
                  Bank.Saldo(bidders[j].name, bid);
                  stopwatch.Start();
                  Thread.Sleep(500);
              }
              if (stopwatch.Elapsed.TotalSeconds > 2) {
                stopwatch.Restart();
                Console.WriteLine("sold");
                Sale = true;
                break;
              }
              else{
                continue;
              }
            }
          }
      }
    }
  }

} // Lottas_Flea_Market
