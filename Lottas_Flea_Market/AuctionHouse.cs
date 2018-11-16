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
      int k    = rng.Next(n--);
      T temp   = array[n];
      array[n] = array[k];
      array[k] = temp;
    }
  }
}

public class AuctionHouse {
  public List<string> items { set; get; }
  public List<User>   users { set; get; }
  public User customUser { set; get; }

  public AuctionHouse() {
    this.users = Bank.users;
  }

  // TODO: change to a more meaningful name
  public User[] getBidders() {
    Random     rd             = new Random();
    int        bidders        = rd.Next(3, 7);
    List<User> random_bidders = new List<User>();
    User[]     array          = users.ToArray();

    new Random().Shuffle(array);
    return array;
  }

  public void Auction(bool participant) {
    Stopwatch stopwatch = new Stopwatch();
    string lastBidder   = "";

    for (int i = 0; i < items.Count; i++) {
      int bid        = 0;
      int higherBid  = 0;
      User[] bidders = getBidders();
      bool Sale      = false;
      Console.WriteLine(items[i] + " is up for sale: ");

      while (Sale!=true) {
        for (int j = 0; j < users.Count; ++j) {
          higherBid = bidders[j].capital / 10; 

          if (stopwatch.Elapsed.TotalSeconds > 4) {
            stopwatch.Restart();
            Console.WriteLine("Sold!");
            Bank.Saldo(bidders[j].name, bid);
            Sale = true;
            break;
          }

          if (stopwatch.Elapsed.TotalSeconds > 2 && participant) {
            stopwatch.Restart();
            Console.WriteLine("Do you want to bid on this item? (y/n)");
            string bidAnswer = Console.ReadLine();

            if (bidAnswer.Equals("y") || bidAnswer.Equals("Y")) {
              Console.WriteLine("Input bid: ");
              int inputbid;
              int.TryParse(Console.ReadLine(), out inputbid);

              if (inputbid < customUser.capital && inputbid > 0) {
                lastBidder = customUser.name;
                Console.WriteLine("                         " + customUser.name + " has bid: " + inputbid);

                Bank.Saldo(customUser.name, inputbid);

                stopwatch.Start();
              }
            }
          }

          if (higherBid > 5 && (bid + higherBid) < (bidders[j].capital * 0.6) && (bidders[j].name != lastBidder)) {
            bid        = bid + higherBid;
            lastBidder = bidders[j].name;
            Console.WriteLine("                         " + bidders[j].name + " has bid: " + bid);
            stopwatch.Start();
            Thread.Sleep(500);
          }
          else {
            continue;
          }
        }
      }
    }
  }
}

} // Lottas_Flea_Market
