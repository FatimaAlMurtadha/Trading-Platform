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

Console.WriteLine("------- Trading System -------");
Console.WriteLine();
Console.WriteLine("To be abel to see all the item you should   ");
Console.WriteLine();
Console.WriteLine("1. Register an account if you are a new user. ");
Console.WriteLine("2. Or log in ");

string input = Console.ReadLine();

bool running = true;

User? active_user = null;

while (running)
{
  switch (input)
  {
    case "1":
      Console.WriteLine("Enter your email address: ");
      string useremail = Console.ReadLine();

      Console.WriteLine("Enter a password: ");
      string password = Console.ReadLine();

      users.Add(new User(useremail, password));
      Console.WriteLine("Your account have successfully registered.");
      Console.WriteLine("Enter 2 to log in: ");
      Console.Clear();

      break;

    case "2": // Log in
      if (active_user == null)
      {
        Console.Write("User Email: ");
        useremail = Console.ReadLine();
        Console.Clear();
        Console.Write("Password: ");
        password = Console.ReadLine();

        // bool found_user = false;

        Console.Clear();
        foreach (User user in users)
        {
          if (user.TryLogin(useremail, password))
          {
            active_user = user;
            // found_user = true;
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


          case "2": // 



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

          case "9": // log out

            break;

          case "f":

            running = false;
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
 

Console.WriteLine("Enter 2 to log in: ");
string? input_log_in = Console.ReadLine();
//

/*while (running)
{
  switch (input_log_in)
  {
    case "1": // regester an account

      Console.WriteLine("Enter your email address: ");
      string useremail = Console.ReadLine();

      Console.WriteLine("Enter a password: ");
      string password = Console.ReadLine();

      users.Add(new User(useremail, password));
      Console.WriteLine("Your account have successfully registered.");
      Console.WriteLine("Enter 2 to log in: ");
      input = Console.ReadLine();
      break;

    case "2": // Log in
      if (active_user == null)
      {
        Console.Write("User Email: ");
        useremail = Console.ReadLine();
        Console.Clear();
        Console.Write("Password: ");
        password = Console.ReadLine();

        // bool found_user = false;

        Console.Clear();
        foreach (User user in users)
        {
          if (user.TryLogin(useremail, password))
          {
            active_user = user;
            // found_user = true;
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

          case "f":

            running = false;
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



}*/

Console.WriteLine("The programe is done!");