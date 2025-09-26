using App;
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



  List<User> users = new List<User>();
//users.Add(new User("u1", "fatima"));

List<Item> items = new List<Item>();

List<Trade> trades = new List<Trade>();


bool running = true;

User? active_user = null;

Console.Clear();
Console.WriteLine("------- Trading System -------");
Console.WriteLine();
Console.WriteLine("Chose one of the following:");
Console.WriteLine();
Console.WriteLine("1. Register an account.");
Console.WriteLine("2. log in ");

string input = Console.ReadLine();

if (input == "1")
{
  Console.WriteLine("Enter an email to register: ");
  string useremail = Console.ReadLine();
  Console.WriteLine("Enter a password to register: ");
  string password = Console.ReadLine();
  users.Add(new User(useremail, password));

  Console.WriteLine("Congragelations. Your account is registered seccussfully.");
  running = false;
}
else if (input == "2")
{
  while (running)
  {
    Console.Clear();

    if (active_user == null)
    {
      Console.WriteLine("User email");
      string useremail = Console.ReadLine();
      Console.Clear();
      Console.Write("Password: ");
      string password = Console.ReadLine();

      Console.Clear();

      foreach (User user in users)
      {
        if (user.TryLogin(useremail, password))
        {
          active_user = user;
          break;
        }

      }
    }
    else
    {
      Console.Clear();
      Console.WriteLine("------- Trading System -------");
      Console.WriteLine("Welcome to our trade system!");
      Console.WriteLine();
      Console.WriteLine("What do you want to do today: ");
      Console.WriteLine();
      Console.WriteLine("1. Upload an item to start your trade. ");
      Console.WriteLine("2. Show other users items");
      Console.WriteLine("3. Request a trade for other users items. ");
      Console.WriteLine("4. Show trade requests.");
      Console.WriteLine("5. Accept a trade requests.");
      Console.WriteLine("6. Deny a trade requests.");
      Console.WriteLine("7. Accept a trade requests.");
      Console.WriteLine("8. Show a completed requests.");
      Console.WriteLine("9. Log out.");
      Console.WriteLine("f. Close.");
      string user_choice= Console.ReadLine();

      switch (user_choice)
      {
        case "1": // add an item

          break;

        case "f": // close
          running = false;
          break;
        default: break;  

      }
    }
  }

}



    
      
        Console.Clear();
        Console.WriteLine("------- Trading System -------");
        Console.WriteLine("Welcome to our trade system!");
        Console.WriteLine();
        Console.WriteLine("What do you want to do today: ");
        Console.WriteLine();
        Console.WriteLine("1. Upload an item to start your trade. ");
        Console.WriteLine("2. Show other users items");
        Console.WriteLine("3. Request a trade for other users items. ");
        Console.WriteLine("4. Show trade requests.");
        Console.WriteLine("5. Accept a trade requests.");
        Console.WriteLine("6. Deny a trade requests.");
        Console.WriteLine("7. Accept a trade requests.");
        Console.WriteLine("8. Show a completed requests.");
        Console.WriteLine("9. Log out.");
        Console.WriteLine("f. Close.");

        


Console.WriteLine("The programe is done!");