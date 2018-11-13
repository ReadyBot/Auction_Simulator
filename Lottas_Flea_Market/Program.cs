using System;
using System.Collections.Generic;

namespace Lottas_Flea_Market {

class Program {

  static Random rnd = new Random();

  // TODO: List<User> / Dictionary<int, User>

  static String getItem(string[] des, string[] item) {
    string it = des[rnd.Next(0, des.Length)] + " " + item[rnd.Next(0, item.Length)];
    return it;
  }

  static List<string> GenerateItems(int items) {
    string []desc = System.IO.File.ReadAllLines(@"../Descriptive.txt");
    string []item = System.IO.File.ReadAllLines(@"../Items.txt");

    List<string> l = new List<string>();
    for (int i = 0; i < items; ++i)
      l.Add(getItem(desc, item));
    return l;
  }

  static Dictionary<string, int> GenerateUsers(int users, int startCapital) {
    string []fn = System.IO.File.ReadAllLines(@"../FirstName.txt");
    string []ln = System.IO.File.ReadAllLines(@"../SurName.txt");

    var map = new Dictionary<string, int>();
    for (int i = 0; i < users; ++i)
      map.Add(getItem(fn, ln), startCapital);
    return map;
  }

  static void Main(string[] args) { 
    int items = 0, users = 0, startCapital = 1500;
    Console.WriteLine("How many users? ");
    int.TryParse(Console.ReadLine(), out users);

    Console.WriteLine("How many objects for sale? ");
    int.TryParse(Console.ReadLine(), out items);

    var itemList = GenerateItems(items);
    var userList = GenerateUsers(users, startCapital);

    foreach (KeyValuePair<string, int> entry in userList)
      Console.WriteLine(entry.Key + "\t" + entry.Value);

    // TODO: create a List<User> or Dictionary<int, User>
    // or Dictionary<int, Tuple<name,credit>>
    // and add users to it
  }
}

} // namespace Lottas_Flea_Market
