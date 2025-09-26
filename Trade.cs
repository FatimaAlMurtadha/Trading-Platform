namespace App;

class Trade
{
  string? SenderEmail; // Not a sender name in order to make it easy for the receiver to contact the sender.

  string? ReciverEmail; // Easy to contact.
  Item TradeItem; // the specific item depending on the users input of the name and description of the item
  Trade_Status Status; // Check the item status on the trade

  // a constructor to take input of the class fields
  public Trade(string? senderemail, string? reciveremail, Item tradeitem, Trade_Status status)
  {
    SenderEmail = senderemail;
    ReciverEmail = reciveremail;
    Status = status;
  }

  // a method to get the sender email
  public string GetSenderEmail()
  {
    return SenderEmail;
  }

  // a method to get the receiver email
  public string GetReceiverEmail()
  {
    return ReciverEmail;
  }

  // a method to get the specific item on the trade
  public Item GetItem()
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

// permenent values on the trade
enum Trade_Status
{
  Pending,
  Denied,
  Accepted,
}
