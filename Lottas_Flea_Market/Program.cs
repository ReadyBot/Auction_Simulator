using System;
using System.Collections.Generic;

namespace Lottas_Flea_Market {

class Program {

  static Random rnd = new Random();

  static String concatRandom(string[] des, string[] item) {
    string it = des[rnd.Next(0, des.Length)] + " " + item[rnd.Next(0, item.Length)];
    return it;
  }

  static List<string> GenerateItems(int items) {
    string []desc = System.IO.File.ReadAllLines(@"../Descriptive.txt");
    string []item = System.IO.File.ReadAllLines(@"../Items.txt");

    List<string> l = new List<string>();
    for (int i = 0; i < items; ++i)
      l.Add(concatRandom(desc, item));
    return l;
  }

  public static List<User> GenerateUsers(int users, int startCapital) {
    string []fn = System.IO.File.ReadAllLines(@"../FirstName.txt");
    string []ln = System.IO.File.ReadAllLines(@"../SurName.txt");

    List<User> clients = new List<User>();
    for (int i = 0; i < users; ++i)
      clients.Add(new User(i, concatRandom(fn, ln), startCapital));

    return clients;
  }

  public static int promptItems() {
    int items = 0;
    Console.WriteLine("How many objects for sale? ");
    int.TryParse(Console.ReadLine(), out items);
    return items;
  }

  public static int promptCapital() {
    int capital = 0;
    Console.WriteLine("What is the buyers start capital?");
    int.TryParse(Console.ReadLine(), out capital);
    return capital;
  }

  public static int promptUsers() {
    int users = 0;
    Console.WriteLine("How many users? ");
    int.TryParse(Console.ReadLine(), out users);
    return users;
  } 

  public static bool isParticipating() {
    Console.WriteLine("Do you want to create an account in order to participate in the bidding? (y/n)");
    string answer = Console.ReadLine();
    if (answer.Equals("y") ||answer.Equals("Y"))
      return true;
    else
      return false;
  }

  public static User createCustomUser(int max) {
    int cap;
    Console.WriteLine("How much do you want to deposit: ");
    int.TryParse(Console.ReadLine(), out cap);
    Console.WriteLine("Enter your name: ");
    string name = Console.ReadLine();

    int id = max;
    return new User(id, name, cap);
  }

  static void Main(string[] args) { 
    var users        = promptUsers();
    var items        = promptItems();
    var startCapital = promptCapital();
    var itemList     = GenerateItems(items);
    var userList     = GenerateUsers(users, startCapital);
    var participate  = isParticipating();


    Bank.users    = userList;
    AuctionHouse ah = new AuctionHouse();
    User customUser;

    if (participate) {
      customUser    = createCustomUser(users);
      ah.customUser = customUser;
    }

    ah.users      = userList;
    ah.items      = itemList;
    User[] l      = ah.getBidders();

    ah.Auction(participate);
  }
}

} // namespace Lottas_Flea_Market
