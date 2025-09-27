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

/*while (running)
{
  Console.Clear();
  Console.WriteLine("------- Trading System -------");
  Console.WriteLine();
  Console.WriteLine("Chose one of the following:");
  Console.WriteLine();
  Console.WriteLine("1. Register an account.");
  Console.WriteLine("2. log in ");
  Console.WriteLine("f. Close ");

  string input = Console.ReadLine();

  switch (input)
  {
    case "1":
      Console.WriteLine("Enter an email to register: ");
      string useremail = Console.ReadLine();
      Console.WriteLine("Enter a password to register: ");
      string password = Console.ReadLine();
      users.Add(new User(useremail, password));

      Console.WriteLine("Congragelations. Your account is registered seccussfully.");
      break;

    case "2":
      Console.Clear();
      if (active_user == null)
      {
        Console.WriteLine("User email");
        useremail = Console.ReadLine();
        Console.Clear();
        Console.Write("Password: ");
        password = Console.ReadLine();

        Console.Clear();
        users.Add(new User(useremail, password));

        Console.WriteLine("------- Trading System -------");
        Console.WriteLine("Welcome to our trade system!");
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
          case "1": // add an item
            Console.Clear();
            Console.WriteLine("Item's name: ");
            string? itemname = Console.ReadLine();

            Console.WriteLine("Item's describtion: ");
            string? itemdescription = Console.ReadLine();

            Console.WriteLine("Your email: ");
            string? owneremail = Console.ReadLine();

            items.Add(new Item(itemname, itemdescription, owneremail));
            Console.WriteLine("Your item is successfully uploaded. ");

            break;

          case "2": // show other's items
            Console.Clear();
            Console.WriteLine("Here are all user's items: ");
            Console.WriteLine();
            foreach (Item item in items)
            {
              if (item.GetOwnerEmail() != "")
              {
                Console.WriteLine($"Item's name:  {item.GetItemName()}, \nDescription: {item.GetItemDescription()}, \nThe owner: {item.GetOwnerEmail}");

              }

            }

            break;

          case "3": //send a request

            Console.Clear();
            Console.WriteLine("Enter the email address of the owner:  ");
            string reciveremail = Console.ReadLine();

            Console.WriteLine("Which item would you like to request: ");
             itemname = Console.ReadLine();

            Item selected_item = null;

            foreach (Item item in items)
            {
              if (item.GetOwnerEmail() == reciveremail && item.GetItemName() == itemname)
              {
                selected_item = item;
                break; 
              }
            }
            if (selected_item != null)
            {
              //trades.Add(active_user, reciveremail, selected_item);

              
            }

            break;

          case "f":

            break;

          default: break;
        }
    

        break;
      }

      break;

    case "f":
      running = false;

      break;

    default: break;

      
  }  

}*/


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
          if (user.GetUserEmail() == useremail && users.CheckPassword(password))
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
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "3": // add an item

      Console.Clear();

      if (active_user == null)
      {
        Console.WriteLine("You should first log in, ");

        Console.WriteLine("User email");
        useremail = Console.ReadLine();
        Console.Clear();
        Console.Write("Password: ");
        password = Console.ReadLine();

        Console.Clear();
        users.Add(new User(useremail, password));
        break;
      }
      else if (active_user != null)
      {
        Console.WriteLine("Item's name: ");
        string? itemname = Console.ReadLine();

        Console.WriteLine("Item's describtion: ");
        string? itemdescription = Console.ReadLine();

        Console.WriteLine("Your email: ");
        string? owneremail = Console.ReadLine();

        items.Add(new Item(itemname, itemdescription, owneremail));
        Console.WriteLine("Your item is successfully uploaded. ");
        Console.WriteLine();

      }
      
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "4": // show others items

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");
      input = Console.ReadLine();

      break;

    case "5": //send requests

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");

      input = Console.ReadLine();

      break;

    case "6": // show request

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");


      input = Console.ReadLine();
      break;

    case "7": // accept trade requests

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");


      input = Console.ReadLine();
      break;
    case "8": // deny


      input = Console.ReadLine();
      break;

    case "9": // show completed requests

      Console.WriteLine();
      Console.WriteLine("Pres ENTER to continue.");


      input = Console.ReadLine();
      break;

    case "10": // log out

      active_user = null;

      Console.WriteLine("You are successfully loged out.");

      Console.WriteLine();
      Console.WriteLine("Thank you for using our system.");

      running = false;
      break;

    case "f":

      running = false;
      break;

    default: break;
  }
}


Console.WriteLine("The programe is done!");