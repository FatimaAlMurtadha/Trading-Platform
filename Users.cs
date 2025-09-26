namespace App;



class User 
{
  string? UserName;
  string? UserEmail;
  string? _password;

  public User(string? username,string? useremail, string? password)
  {
    UserName = username;
    UserEmail = useremail;
    _password = password;
  }
  public string GetUserName()
  {
    return UserName;
  }
  public string? GetUserEmail()
  {
    return UserEmail;
  }
  public bool TryLogin(string? username,string? useremail, string? password)
  {
    return username==UserName && useremail == UserEmail && password == _password;
  }

}


