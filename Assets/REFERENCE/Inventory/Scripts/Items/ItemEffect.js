#pragma strict

//This script allows you to insert code when the Item is used (clicked on in the inventory).

var deleteOnUse = true;

private var playersInv : Inventory;
private var item : Inventory_GET;

@script AddComponentMenu ("Inventory/Items/Item Effect")
@script RequireComponent(Inventory_GET)

//This is where we find the components we need
function Awake ()
{
	playersInv = FindObjectOfType(Inventory); //finding the players inv.
	if (playersInv == null)
	{
		Debug.LogWarning("No 'Inventory' found in game. The Item " + transform.name + " has been disabled for pickup (canGet = false).");
	}
	item = GetComponent(Inventory_GET);
}

//This is called when the object should be used.
function UseEffect () 
{
	Debug.LogWarning("<INSERT CUSTOM ACTION HERE>"); //INSERT CUSTOM CODE HERE!
	
	//Play a sound
	playersInv.gameObject.SendMessage("PlayDropItemSound", SendMessageOptions.DontRequireReceiver);
	
	//This will delete the item on use or remove 1 from the stack (if stackable).
	if (deleteOnUse == true)
	{
		DeleteUsedItem();
	}
}

//This takes care of deletion
function DeleteUsedItem()
{
	if (item.stack == 1) //Remove item
	{
		playersInv.RemoveItem(this.gameObject.transform);
	}
	else //Remove from stack
	{
		item.stack -= 1;
	}
	Debug.Log(item.name + " has been deleted on use");
}