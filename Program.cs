
/*
--- A user needs to be able to register an account
--- A user needs to be able to log out.
--- A user needs to be able to log in.
--- A user needs to be able to upload information about the item they wish to trade.
--- A user needs to be able to browse a list of other users items.
--- A user needs to be able to request a trade for other users items.
--- A user needs to be able to browse trade requests.
--- A user needs to be able to accept a trade request.
--- A user needs to be able to deny a trade request.
--- A user needs to be able to browse completed requests.
*/

// Without Classes

/*List<User> users = new List<User>();
//users.Add(new User("u1", "fatima"));

List<Item> items = new List<Item>();

List<Trade> trades = new List<Trade>();

bool running = true;

User? active_user = null;


while (running)
{
  Console.Clear();
  Console.WriteLine("------- Trading System -------");
  Console.WriteLine();
  Console.WriteLine("Welcome to our trade system!");
  Console.WriteLine();
  Console.WriteLine("Chose one of the following:");
  Console.WriteLine();
  Console.WriteLine("1. Register an account.");
  Console.WriteLine("2. log in ");
  Console.WriteLine("3. Upload an item to start your trade. ");
  Console.WriteLine("4. Show other users items");
  Console.WriteLine("5. Request a trade for other users items. ");
  Console.WriteLine("6. Show trade requests.");
  Console.WriteLine("7. Accept a trade requests.");
  Console.WriteLine("8. Deny a trade requests.");
  Console.WriteLine("9. Show a completed requests.");
  Console.WriteLine("10. Log out.");
  Console.WriteLine("f. Close.");

  string input = Console.ReadLine();

  switch (input)
  {
    case "1": // registration
      Console.WriteLine("Enter an email to register: ");
      string useremail = Console.ReadLine();
      Console.WriteLine("Enter a password to register: ");
      string password = Console.ReadLine();
      users.Add(new User(useremail, password));

      Console.WriteLine("Congragelations. Your account is registered seccussfully.");
      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "2": // log in

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

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.....");
      input = Console.ReadLine();

      break;

    case "3": // add an item

      Console.Clear();

      if (active_user == null)
      {
        Console.WriteLine("You should first log in, press ENTER to continue....");
        input = Console.ReadLine();
        break;
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

      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "4": // show others items

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
            Console.WriteLine($"Item: {item.GetItemName()}. \nDescription: {item.GetItemDescription()}. \nOwner: {item.GetOwnerEmail()}.");

            Console.WriteLine("---------------------------------");
          }
        }
      }
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "5": //send requests

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

      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "6": // show request
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

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");


      input = Console.ReadLine();
      break;

    case "7": // accept trade requests
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

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");


      input = Console.ReadLine();
      break;
    case "8": // deny
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

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();
      break;

    case "9": // show completed requests
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

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");

      input = Console.ReadLine();
      break;

    case "10": // log out
      Console.Clear();

      active_user = null;

      Console.WriteLine("You are successfully loged out.");
      Console.WriteLine("Thank you for using our system.");
      Console.WriteLine();
      Console.WriteLine("Press Enter to continue");
      input = Console.ReadLine();
      break;

    case "f":
      Console.Clear();

      running = false;
      break;

    default: break;
  }
}*/


// With Classes

using App;

TradeActions actions = new TradeActions();
bool running = true;

while (running)
{
  Console.Clear();
  Console.WriteLine("------- Trading System -------");
  Console.WriteLine();
  Console.WriteLine("Welcome to our trade system!");
  Console.WriteLine();
  Console.WriteLine("Chose one of the following:");
  Console.WriteLine();
  Console.WriteLine("1. Register an account.");
  Console.WriteLine("2. log in ");
  Console.WriteLine("3. Upload an item to start your trade. ");
  Console.WriteLine("4. Show other users items");
  Console.WriteLine("5. Request a trade for other users items. ");
  Console.WriteLine("6. Show trade requests.");
  Console.WriteLine("7. Accept a trade requests.");
  Console.WriteLine("8. Deny a trade requests.");
  Console.WriteLine("9. Show a completed requests.");
  Console.WriteLine("10. Log out.");
  Console.WriteLine("f. Close.");

  string input = Console.ReadLine();

  switch (input)
  {
    case "1":
      actions.Registration();

      break;

    case "2":
      actions.LogIn();

      break;

    case "3":
      actions.AddItem();

      break;

    case "4":
      actions.ShowOthersItems();

      break;

    case "5":
      actions.SendRequest();

      break;

    case "6":
      actions.ShowRequests();

      break;

    case "7":
      actions.AcceptRequests();

      break;

    case "8":
      actions.DenyRequest();

      break;

    case "9":
      actions.ShowCompleted();

      break;

    case "10":
      actions.LogOut();

      break;

    case "f":
      Console.Clear();
      running = false;

      break;

    default: break;
  }


}




Console.WriteLine("The programe is done!");