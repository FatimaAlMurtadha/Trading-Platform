namespace App;



class User 
{
  public string? Username;
  string? _password;

  public User(string? username, string? password)
  {
    Username = username;
    _password = password;
  }
  public bool TryLogin(string? username, string? password)
  {
    return username == Username && password == _password;
  }

}


enum Trade_Status
{
  Pending,
  Denied,
  Accepted,
}