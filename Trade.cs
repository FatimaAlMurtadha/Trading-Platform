namespace App; // Link or gather this class file with the rest of the classes and the executing file "program.cs".

public class Trade // This class is to link a sender, a receiver with a specifi item that will be on the trade.
{
  // all strings values marked as null able ? in order to tell the compiler or the system that those values are not allowed to have a null value at all.
  // I used even Private by defualt in order to protect emails addresses and status.
  // I used even Private by defualt in order to protect the user's email address and password information from outside access.
   string? SenderEmail; // Not a sender name in order to make it easy for the receiver to contact the sender.

   string? ReciverEmail; // Easy to contact.
  public Item TradeItem; // the specific item depending on the users input.
   public Trade_Status Status; // Check the item status on the trade

  // a constructor to take input of the class fields
  public Trade(string? senderemail, string? reciveremail, Item tradeitem, Trade_Status status)
  {
    SenderEmail = senderemail; // Assign
    ReciverEmail = reciveremail; // Assign
    TradeItem = tradeitem; // Assign
    Status = status; // Assign
  }

  // a method to get the sender email
  public string? GetSenderEmail()
  {
    return SenderEmail;
  }

  // a method to get the receiver email
  public string? GetReceiverEmail()
  {
    return ReciverEmail;
  }

  // a method to get the specific item on the trade
  public Item GetItemName()
  {
    return TradeItem;
  }

  // a method too check the trade status
  public Trade_Status GetStatus()
  {
    return Status;
  }

  // a method to be appllied when accepting an item on the trade
  public void Accept()
  {
    Status = Trade_Status.Accepted;
  }

  // a method to be appllied when denyeding an item on the trade
  public void Deny()
  {
    Status = Trade_Status.Denied;
  }

  // // a method to show the pending items on the trade
  public void Pending()
  {
    Status = Trade_Status.Pending;
  }

}

// permenent values on the trade's status.
public enum Trade_Status
{
  Pending,
  Denied,
  Accepted,
}
