namespace App; // Link or gather this class file with the rest of the classes and the executing file "program.cs".


// a user class to manage logning in and loggning out.
class User 
{
  // all strings values marked as null able ? in order to tell the copiler or the system that those values are not allowed to have a null value at all.
  // I used even Private by defualt in order to protect the user's email address and password information from outside access.
  string? UserEmail; // a field to store the user's emailadress. 
  string? _password; // // a field to store the user's password. 

  public User(string? useremail, string? password) // a constructor to be called when ever we need to creat a new user object.
  {
    UserEmail = useremail; // assign the input email to the useremail's field.
    _password = password; // assign the input password to the userpassword's field.
  }

  // a method to be called when ever we need to read and use the useremail In order to link a useremail with a specific person. So it will return the useremail as a string value.
  public string GetUserEmail()
  {
    return UserEmail;
  }
  public bool TryLogin(string? useremail, string? password) // a boolean verification method to be called when ever we want to check if the useremail and password are true. 
                                                            // In order to just let the users who has an account to access the system if the method return true.
   // it will retorn true just if both stored useremail and password are true.
  {
    return useremail == UserEmail && password == _password;
  }

}


