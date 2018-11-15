using System;

namespace Lottas_Flea_Market {

  public class User {
    public string name { set; get; }
    public int capital { set; get; }
    public int id      { set; get; }
    
    public User(int id, string name, int capital) {
      this.id      = id;
      this.name    = name;
      this.capital = capital;
    }
    
    // bid
    public void Bid(string item) {

    }
    
    // add bought items to list
    public void AddBoughtItems() {

    }
  }
}
