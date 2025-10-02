namespace App; // Link or gather this class file with the rest of the classes and the executing file "program.cs".


// a class to manage the system's items. In order to allow a specific user to set a name and description for his own items.
public class Item
{
  // all strings values marked as null able ? in order to tell the compiler or the system that those values are not allowed to have a null value at all.
  // I used even Public in order to protect the item's name and description information from outside access.
  public string? ItemName; 
  public string? ItemDescription;

  // The owner email is private to allow just the users who are logged in to se it in order to send a request.
  string? OwnerEmail;

  public Item(string? itemname, string? itemdescription, string? owneremail)
  {
    ItemName = itemname; // assign the input item name to the item name field.
    ItemDescription = itemdescription;  // assign the input item description to the item description field.
    OwnerEmail = owneremail;  // assign the input owner email to the owner email field.
  }

  // a method to be called when ever we need to read and use the item's name such as when a user wants to display other's items. 
  public string? GetItemName()
  {
    return ItemName;
  }

  // a method to be called when ever we need to read and use the item's description such as when a user wants to display other's items.
  public string? GetItemDescription()
  {
    return ItemDescription;
  }

  // a method to be called when ever we need to read and use the owner email such as when a user wants to send a request to the owner of the item.
  public string? GetOwnerEmail()
  {
    return OwnerEmail;
  }

}

