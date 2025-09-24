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
// users.Add(new User("u1", "fatima"));


List<Item> items = new List<Item>();

Console.WriteLine("------- Trading System -------");
Console.WriteLine();
Console.WriteLine("What do you want to do: ");
Console.WriteLine();
Console.WriteLine("1. Register an account. ");
Console.WriteLine("2. Log in ");

string input = Console.ReadLine();

bool running = true;

User? active_user = null;

while (running)
{
  switch (input)
  {
    case "1": // regester an account


      break;

    case "2": // Log in

      if (active_user == null)
      {
        Console.Write("Username: ");
        string useremail = Console.ReadLine();

        Console.Clear();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        users.Add(new User(username, password));

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
        string user_choice = Console.ReadLine();
        switch (user_choice)
        {
          case "1": // Upload an item


            break;


          case "2":



            break;

          case "3":


            break;


          case "4":



            break;

          case "5":


            break;


          case "6":



            break;

          case "7":


            break;


          case "8":



            break;

          default:

            break;

        }



      }


      break;

    default:
      running = false;

      break;
  }



}





Console.WriteLine("You do not have an account with us!");

Console.WriteLine("The programe is done!");