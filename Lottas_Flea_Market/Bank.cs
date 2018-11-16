using System;
using System.Collections.Generic;

namespace Lottas_Flea_Market {

  public class Bank {

    private Bank() { }

    public static List<User> users { set; get; }

    public static void Saldo(string username, int bid) {
      foreach (User user in users) {
        if (user.name == username) {
          user.capital -= bid;
          break;
        }
      }
    }
  }
  
} // Lottas_Flea_Market
