namespace App;


public class TradeActions
{

  List<User> users = new List<User>();
  //users.Add(new User("u1", "fatima"));

  List<Item> items = new List<Item>();

  List<Trade> trades = new List<Trade>();

  User? active_user = null;
  string? useremail;
  string? password;
  public void Registration()
  {
    Console.Clear();
    Console.WriteLine("Enter an email to register: ");
    string useremail = Console.ReadLine();
    Console.WriteLine("Enter a password to register: ");
    string password = Console.ReadLine();
    users.Add(new User(useremail, password));

    Console.WriteLine("Congragelations. Your account is registered seccussfully.");
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();
  }

  public void LogIn()
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("Your email");
      useremail = Console.ReadLine();
      Console.Clear();

      Console.Write("Password: ");
      password = Console.ReadLine();

      User found_user = null;

      foreach (User user in users)
      {
        if (user.TryLogin(useremail, password))
        {
          found_user = user;
          break;
        }
      }
      if (found_user != null)
      {
        active_user = found_user;
        Console.WriteLine($"Welcom to the trade system, {active_user.GetUserEmail()}");
      }
      else
      {
        Console.WriteLine("Invalid email or password!");
      }

    }
    else
    {
      Console.WriteLine("You are already logged in.");
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void AddItem()
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Item's name: ");
      string? itemname = Console.ReadLine();

      Console.WriteLine("Item's describtion: ");
      string? itemdescription = Console.ReadLine();

      string? owneremail = active_user.GetUserEmail();

      items.Add(new Item(itemname, itemdescription, owneremail));
      Console.WriteLine("Your item is successfully uploaded. ");
      Console.WriteLine();

    }
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine();

  }

  public void ShowOthersItems() // show others items
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in ...");
    }
    else
    {
      Console.WriteLine("Items of other users: ");

      foreach (Item item in items)
      {
        if (item.GetOwnerEmail() != active_user.GetUserEmail())
        {
          Console.WriteLine($"Item: {item.GetItemName()}, Description: {item.GetItemDescription()}, Owner: {item.GetOwnerEmail()}.");

          Console.WriteLine("---------------------------------");
        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void SendRequest()
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in...");
    }
    else
    {
      Console.WriteLine("Enter the item's name: ");
      string? itemname = Console.ReadLine();

      Console.WriteLine("Enter the email of the item's owner: ");
      string? reciveremail = Console.ReadLine();

      Item? requested_item = null; // Check if the item is there

      foreach (Item item in items)
      {
        if (item.GetItemName() == itemname && item.GetOwnerEmail() == reciveremail)
        {
          requested_item = item;
          break;
        }
      }
      if (requested_item != null)
      {
        trades.Add(new Trade(active_user.GetUserEmail(), reciveremail,
        requested_item, Trade_Status.Pending));

        Console.WriteLine("Your request is successfully sent.");
      }
      else
      {
        Console.WriteLine("Item's name or owner's email adress is wrong.....");
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void ShowRequests()   // show request
  {
    Console.Clear();
    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
    }
    else
    {
      Console.WriteLine("You received the following requests: ");

      foreach (Trade trade in trades)
      {
        if (trade.GetReceiverEmail() == active_user.GetUserEmail()
        && trade.GetStatus() == Trade_Status.Pending)
        {
          Console.WriteLine($"a request from: {trade.GetSenderEmail()} , for item: {trade.GetItem()}, status: {trade.GetStatus()}");
          Console.WriteLine("-------------------------------");

        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void AcceptRequests() // accept trade requests
  {

    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in......");
    }
    else
    {
      Console.WriteLine("Enter the sender's email address: ");
      string? senderemail = Console.ReadLine();

      foreach (Trade trade in trades)
      {
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetSenderEmail() == senderemail
        && trade.GetStatus() == Trade_Status.Pending)
        {
          trade.Accept();
          Console.WriteLine("Trade requests accepted.");
        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void DenyRequest()
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in.....");
    }
    else
    {
      Console.WriteLine("Enter the sender's email address: ");
      string? senderemail = Console.ReadLine();

      foreach (Trade trade in trades)
      {
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetSenderEmail() == senderemail
        && trade.GetStatus() == Trade_Status.Pending)
        {
          trade.Deny();
          Console.WriteLine("Trade requests denied.");
        }
      }

    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void ShowCompleted()
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
    }
    else
    {
      foreach (Trade trade in trades)
      {
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetStatus() == Trade_Status.Accepted)
        {
          Console.WriteLine($"You have the following completed trade: from: {trade.GetSenderEmail()} \nItem: {trade.GetItem().GetItemName()} \nDescription: {trade.GetItem().GetItemDescription()} \nStatus: {trade.GetStatus()}");
          Console.WriteLine("---------------------------");
        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();


  }

  public void LogOut()
  {
    Console.Clear();

    active_user = null;

    Console.WriteLine("You are successfully loged out.");
    Console.WriteLine("Thank you for using our system.");
    Console.WriteLine();

  }
}
