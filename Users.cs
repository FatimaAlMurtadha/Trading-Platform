namespace App;



class User 
{
  string? UserEmail;
  string? _password;

  public User(string? useremail, string? password)
  {
    UserEmail = useremail;
    _password = password;
  }
  public string GetUserEmail()
  {
    return UserEmail;
  }
  public bool TryLogin(string? useremail, string? password)
  {
    return useremail == UserEmail && password == _password;
  }

}


