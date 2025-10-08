namespace App; // Link or gather this class file with the rest of the classes and the executing file "program.cs".

// This field class is to gather all the logic on the trade system. It will handel all interaction's activities between the system and the user.
// every method on this class should first check lognning in status in order to do sth in the system.
public class TradeActions
{
  // Creat an object list of Users to store all registered users in the system.
  List<User> users = SaveData.LoadUsers(); // an object of the class User with a list.

  // Creat an object list of Items to store all uploaded items in the system.
  List<Item> items = SaveData.LoadItems(); // an object of the class Item with a list.

  // Creat an object list of Trades to store all trade status in the system.
  List<Trade> trades = SaveData.LoadTrades(); // an object of the class User with a list.

  // Creat a variable to check the current logged in user and the value null means none user is logged in at the beganing. In order to check the loggning in status.
  User? active_user = null;
  string? useremail; // a string declaratin of username. In order to store the user input of his own email.
  string? password; // a string declaratin of password. In order to store the user input of his own password.
  public void Registration() // a method to be called when ever a user chooses to regist a new account in the system.
  {
    // Clear the screen when ever the user press Enter
    Console.Clear();
    Console.WriteLine("Enter an email to register: "); // ask for the email.
    string useremail = Console.ReadLine(); // store the input.
    Console.WriteLine("Enter a password to register: "); // ask for the password.
    string password = Console.ReadLine(); // store the input.

    // start if- else sats in order to check that both input are not null and not an empty string

    if (useremail != "" && useremail != null && password != "" && password != null)
    {
      users.Add(new User(useremail, password)); // if the condition is checked store bothe input in the user's list as an object. 
      // Store registration info
      SaveData.SaveUsers(users);

      Console.WriteLine("Congragelations. Your account is registered seccussfully."); // show a message to the user that the account is registered.
      Console.WriteLine(); // an empty line to make the view more orgnized.

    }
    else // when ever if sats is not true do the folloing
    {
      Console.WriteLine("The email or password is empty"); // show a message to tell the user what went wrong
      Console.WriteLine(); // an empty line to make the view more orgnized.
      Console.WriteLine("Press ENTER and try again"); // telling the user what to do.
      Console.ReadLine(); // an empty line to make the view more orgnized.
    }
    Console.WriteLine("Press Enter to continu......"); // telling the user to containue.
    Console.ReadLine(); // store the user input.

  }

  public void LogIn() // a method to be called when ever a user chooses to log in the system.
  {
    Console.Clear(); // clear the screen
    // start if-else sats to check lognning in
    if (active_user == null) // when ever the user inloggning is empty aske the user to log in.
    {
      Console.WriteLine("Your email"); // ask for the registered email.
      useremail = Console.ReadLine(); // store the input.
      Console.Clear(); // clear the screen

      Console.Write("Password: "); // ask for the registered password.
      password = Console.ReadLine(); // store the input

      User found_user = null; // creat a user variable to check if the given information from the user who wants to log in are correct "Are on the system".

      // start foreach-loop to check the information throug the users' list.
      foreach (User user in users)
      {
        if (user.TryLogin(useremail, password)) // call the trylogin method to check if the given information are there do the following
        {
          found_user = user; // if the given information are found set that.
          break; // stop the loop after founding the user.
        }
      }
      // if-else sats to check the searching result on the users' list.
      if (found_user != null) // if we found the input information "are not null".
      {
        active_user = found_user; // set the given information to the active user.
        Console.WriteLine($"Welcom to the trade system, {active_user.GetUserEmail()}"); // greeting the user by calling the getuseremail method.

      }
      else // if we can not find the given information or one of the info is not strored "Not correct".
      {
        Console.WriteLine("Invalid email or password!"); // telling the user that
      }

    }
    else // if the user is already logged in but he choose to log in
    {
      Console.WriteLine("You are already logged in."); // telling the user that
    }
    Console.WriteLine("Press Enter to continue......"); // telling the user to continue
    Console.ReadLine(); // store the input to keep the system running

  }

  public void AddItem() // a method to be called when ever a user chooses to upload a new item in the system.
  {
    Console.Clear();

    // if-else sats to check lognning in....

    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Item's name: "); // ask for item name
      string? itemname = Console.ReadLine(); // store

      Console.WriteLine("Item's describtion: "); //ask 
      string? itemdescription = Console.ReadLine(); // store

      string? owneremail = active_user.GetUserEmail(); // link the item with the active user's email

      items.Add(new Item(itemname, itemdescription, owneremail)); // adding the item on the Items list as a new object.
      // Store items' info
      SaveData.SaveItems(items);
      Console.WriteLine("Your item is successfully uploaded. "); // showing succed
      Console.WriteLine();

    }
    Console.WriteLine("Press Enter to continue");
    Console.ReadLine(); // keep riunning

  }

  public void ShowOthersItems() // a method to be called when ever a user chooses to show others items in the system.
  {
    Console.Clear();

    // start if-else sats to check lognnin in.
    if (active_user == null)
    {
      Console.WriteLine("You should first log in ..."); // a message
    }
    else
    {
      Console.WriteLine("Items of other users: "); // titel
      // foreach-loop to go throug the items list
      foreach (Item item in items)
      { // start if sats to show only other users' items but not the active user's items.
        if (item.GetOwnerEmail() != active_user.GetUserEmail())
        {
          Console.WriteLine($"Item: {item.GetItemName()}, Description: {item.GetItemDescription()}, Owner: {item.GetOwnerEmail()}."); // show items' name, description and owner.

          Console.WriteLine("---------------------------------"); // a line to seprate items to be be orgnized on the screen.
        }
      }
    }
    // keep going
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void SendRequest() // a method to be called when ever a user chooses to send a request for other users.
  {
    Console.Clear();
    // start if-else sats to check logning in
    if (active_user == null)
    {
      Console.WriteLine("You should first log in...");
    }
    else
    {
      ShowOthersItems(); // Call showothersitems method in order to make it easier for the user to choose an item and an owner.
      Console.WriteLine();
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
        // Store trades' info
        SaveData.SaveTrades(trades);

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

  public void ShowRequests()   // a method to be called when ever a user chooses to show requests
  {
    Console.Clear();
    // check log in
    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
    }
    else
    {
      Console.WriteLine("You received the following requests: ");
      // foreach-loop to show all requests 
      foreach (Trade trade in trades)
      {
        if (trade.GetReceiverEmail() == active_user.GetUserEmail()
        && trade.GetStatus() == Trade_Status.Pending)
        {
          Console.WriteLine($"a request from: {trade.GetSenderEmail()} , for item: {trade.TradeItemName.GetItemName()}, status: {trade.GetStatus()}");
          Console.WriteLine("-------------------------------");

        }
       
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void AcceptRequests() // a method to be called when ever a user chooses to accept trade requests
  {

    Console.Clear();
    // check log in
    if (active_user == null)
    {
      Console.WriteLine("You should first log in......");
    }
    else // if inloged
    {
      Console.WriteLine("You have received a request from the following users: ");

      foreach (Trade trade in trades) // start a foreach-loop in order to make it easier for the user to write the email of the requester.
      {
        Console.WriteLine(trade.GetSenderEmail());

      }
      Console.WriteLine();
      Console.WriteLine("Enter the sender's email address: "); // ask for sender email
      string? senderemail = Console.ReadLine(); // store
                                                // foreach-loop to go throug all statuses on the trades list
      foreach (Trade trade in trades)
      {
        // start if-sats to check that all information are correct "receiver, sender, status".
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetSenderEmail() == senderemail
        && trade.GetStatus() == Trade_Status.Pending)
        {
          trade.Accept(); // set the trade status to accept.
          // Store trades' info
          SaveData.SaveTrades(trades);
          Console.WriteLine("Trade requests accepted.");
        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void DenyRequest()  //a method to be called when ever a user chooses to deny a request.
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in.....");
    }
    else
    {
      foreach (Trade trade in trades) // start a foreach-loop in order to make it easier for the user to write the email of the requester's user.
      
        if (trade.GetSenderEmail() != null)
        {
          Console.WriteLine("You have received a request from the following users: ");
          Console.WriteLine(trade.GetSenderEmail());
        }
      
      Console.WriteLine(); 
      Console.WriteLine("Enter the sender's email address: ");
      string? senderemail = Console.ReadLine();
      // foreach-loop to go throug all statuses on the trades list
      foreach (Trade trade in trades)
      { // start if-sats to check that all information are correct "receiver, sender, status".
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetSenderEmail() == senderemail
        && trade.GetStatus() == Trade_Status.Pending)
        {
          trade.Deny();
          // Store trades' info
          SaveData.SaveTrades(trades);
          Console.WriteLine("Trade requests denied.");
        }
      }

    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();

  }

  public void ShowCompleted() // a method to be called when ever a user chooses to show completed trade.
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("You should first log in....");
    }
    else
    {
      // foreach-loop to go throug all statuses on the trades list
      foreach (Trade trade in trades)
      { // start if-sats to check that all information are correct "receiver, user, status".
        if (trade.GetReceiverEmail() == active_user.GetUserEmail() && trade.GetStatus() == Trade_Status.Accepted)
        {
          Console.WriteLine($"You have the following completed trade: \nfrom: {trade.GetSenderEmail()} \nItem: {trade.TradeItemName.GetItemName()} \nDescription: {trade.TradeItemName.GetItemDescription()} \nStatus: {trade.GetStatus()}");
          Console.WriteLine("---------------------------");
        }
      }
    }
    Console.WriteLine("Press Enter to continue......");
    Console.ReadLine();


  }

  public void LogOut() //a method to be called when ever a user chooses to log out of the system.
  {
    Console.Clear();

    active_user = null;

    Console.WriteLine("You are successfully loged out.");
    Console.WriteLine();
    Console.WriteLine("Thank you for using our system.");
    Console.ReadLine();

  }
}
