using App;


List<User> users = new List<User>();
users.Add(new User("u1", "fatima"));
users.Add(new User("u2", "lina"));
users.Add(new User("u3", "kiven"));
users.Add(new User("u4", "joel"));
users.Add(new User("u5", "jenjera"));

List<Item> items = new List<Item>();

User? active_user = null; 


bool running = true;

while (running)
{
  Console.Clear();

  if (active_user == null)
  {
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Clear();
    Console.Write("Password: ");
    string password = Console.ReadLine();

    Console.Clear();
    foreach (User user in users)
    {
      if (user.TryLogin(username, password))
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
    Console.WriteLine("Welcome user");
    Console.WriteLine("1. ");
    Console.WriteLine("2. ");
    Console.WriteLine("3. ");
    Console.WriteLine("4. ");



  }




  }

running = false;

}

Console.WriteLine("You do not have an account with us!");

Console.WriteLine("The programe is done!");