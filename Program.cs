using App;
// using App; is to link all classes with the name App to this executed program.cs

// The system or the code should do the following "OutLines"
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
// With Classes

// creat an object which called "actions" in order to be able to call the TradeSystemClasses.cs's methods.
TradeActions actions = new TradeActions();

// creat a boolean variable in order to oppen a while-loop
bool running = true; // start with true value in order to run the while-loop and stop when ever we want to go out of the while-loop.

// creat a while-loop to be run when ever we run this code or this Trade system.
while (running) // when ever the boolean variable is true "the program is running" 
{
  // Clear the screen when ever the user press Enter and the while-loop runs.
  Console.Clear();

  // Show the titel of the system with options from the start

  Console.WriteLine("------- Trading System -------");
  Console.WriteLine(); // make a space line between the titel and the options
  Console.WriteLine("Welcome to our trade system!"); // Greating the user
  Console.WriteLine(); // a space Line to make it easier to defien the options undernith
  Console.WriteLine("Chose one of the following:"); // telling the user that here is the beganing of the system and here is what you can do by this system.
  Console.WriteLine(); // a spce line

  // all choises are here as an orderd menu with th 11 options to interact withe the system.
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

  // creat a string variable to read the users choise.
  string input = Console.ReadLine();

  // Check the user's choice with a switch case - statments/ switch case-statment is easier and shorter than if-statment
  // in this system "as the choices will be as String numbers"

  switch (input) // put the user's choice in the swich case.
  {
    case "1": // Register a new user to be able to log in and navigate and interreact with the system
      actions.Registration(); // call registration method to be executed or to run here under this choise

      break; // breaks out of the switch block or stop the execution of more code and case testing, When a match is found, and the job is done.

    case "2": // lognning in the registred user to be able to navigate and interact with system.
      actions.LogIn();     // call the lognning in method to be executed.

      break; // stop / break the swich block.

    case "3": // uploud an item to the system in order to start a trade
      actions.AddItem(); // call the adding method to be executed in order to take all item's information from the user.

      break; // break switch code block

    case "4": // Display others' user's items in order to be able to send requests or just to have a look.
      actions.ShowOthersItems(); // call the display method to be executed.

      break; // stop switch code block.

    case "5": // send a request to other users or owners on the system.
      actions.SendRequest(); // call the sending method to be executed

      break; // stop switch code block.

    case "6": // Display requests in order to be able to have a look which requests the user has received. 
      actions.ShowRequests(); // call the display-requests method to be executed.

      break; // stop switch code block.

    case "7": // Accept request
      actions.AcceptRequests(); // call the acception method to be executed.

      break; // stop switch code block.

    case "8": // Deny request
      actions.DenyRequest(); // call the denying method to be executed.

      break; // stop switch code block.

    case "9": // Display completed trade
      actions.ShowCompleted(); // call the display/completed/trade methode to be executed. 

      break; //stop switch code block.

    case "10": // Lognning out
      actions.LogOut(); // call lognning out methode to be executed.

      break; // stop switch code block.

    case "f": // Close the system
      Console.Clear(); // clear the screen in order to delate the previous operation.
      running = false; // stop the while loop using the boolean value "false". 

      break; // stop switch code block.

    default: // if nothing of the above choices have been chosen, this case will be executed.
      Console.Clear(); // To clear the screen
      Console.WriteLine("The choice is wrong or empty!"); // a message to be shown if the input is empty or not on the cases.
      Console.WriteLine("Press ENTER to choose again. "); // telling the user what is the problem and what to do next.
      break; // stop switch code block. 
  } // the end of the switch- case

} // the end of the while-loop


Console.WriteLine("The programe is done! Thankm you for using our Trade System"); // a thankfull message to be shown att the end


