namespace App;

class Item
{
  string? ItemName;
  string? ItemDescription;
  string? OwnerEmail;

  public Item(string? itemname, string? itemdescription, string? owneremail)
  {
    ItemName = itemname;
    ItemDescription = itemdescription;
    OwnerEmail = owneremail;
  }
  public string? GetItemName()
  {
    return ItemName;
  }
  public string? GetItemDescription()
  {
    return ItemDescription;
  }
  public string? GetOwnerEmail()
  {
    return OwnerEmail;
  }

}

