using System.Diagnostics;

namespace App;

// a class to store all the system data
class SaveData
{
  // save users
  public static void SaveUsers(List<User> users)
  {
    using (StreamWriter writer = new StreamWriter("users.txt", append: false))
    {
      foreach (User user in users)
      {
        writer.WriteLine(user.GetUserEmail() + ',' + user.GetPassword());
      }

    }
  }
   // load users
 public static List<User> LoadUsers()
 {
    List<User> users = new List<User>();
     using (StreamReader reader = new StreamReader("users.txt"))
    {
       string line;
    while ((line = reader.ReadLine()) != null)
     {
       string[] parts = line.Split(',');
        if (parts.Length == 2)
        {
         users.Add(new User(parts[0], parts[1]));

      }

     }

  }
    return users;
 }


  // save items
  public static void SaveItems(List<Item> items)
  {
    using (StreamWriter writer = new StreamWriter("items.txt", append: false))
    {
      foreach (Item item in items)
      {
        writer.WriteLine(item.GetItemName() + ',' + item.GetItemDescription() + ',' + item.GetOwnerEmail());
      }

    }
  }
  // load items
  public static List<Item> LoadItems()
  {

    List<Item> items = new List<Item>();
    using (StreamReader reader = new StreamReader("items.txt"))
    {
      string line;
      while ((line = reader.ReadLine()) != null)
      {
        string[] parts = line.Split(',');
        if (parts.Length == 3)
        {
          items.Add(new Item(parts[0], parts[1], parts[2]));

        }

      }

    }
    return items;

  }

  // save trades
  public static void SaveTrades(List<Trade> trades)
  {
    using (StreamWriter writer = new StreamWriter("trades.txt", append: false))
    {
      foreach (Trade trade in trades)
      {
        Item item = trade.GetItemName();
        writer.WriteLine($"{trade.GetReceiverEmail()},{trade.GetSenderEmail()},{item.GetItemName()},{item.GetItemDescription()},{item.GetOwnerEmail()},{trade.GetStatus()}");
      }
    }
  }

  // load trades
  public static List<Trade> LoadTrades()
  { List<Trade> trades = new List<Trade>();
    if (!File.Exists("trades.txt")) return trades;
    using (StreamReader reader = new StreamReader("trades.txt"))
    {
      string? line;
      while ((line = reader.ReadLine()) != null)
      {
        string[] parts = line.Split(',');
        if (parts.Length == 6)
        {
          string receiverEmail = parts[0];
          string senderEmail = parts[1];

          Item item = new Item(parts[2], parts[3], parts[4]);

          Trade_Status status = (Trade_Status)Enum.Parse(typeof(Trade_Status), parts[5]);

          trades.Add(new Trade(senderEmail, receiverEmail, item, status));
        }
      }
    }
    return trades;
  }


}



