namespace App;

class Item
{
  string? ItemName;
  string? ItemDescription;

  public Item(string? itemname, string? itemdescription)
  {
    ItemName = itemname;
    ItemDescription = itemdescription;
  }
  public string? GetItemName()
  {
    return ItemName;
  }
  public string? GetItemDescription()
  {
    return ItemDescription;
  }

}

