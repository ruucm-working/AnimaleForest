//The Character window (CSheet).


private var associatedInventory : Inventory;
var WeaponSlot : Transform; //This is where the Weapons are going to go (be parented too). In my case it's the "Melee" gameobject.
private var lastUpdate = 0.0; //Last time we updated the display.
var updateListDelay = 9999;//This can be used to update the Inventory with a certain delay rather than updating it every time the OnGUI is called.



private var ArmorSlot : Item[]; //This is the built in Array that stores the Items equipped. You can change this to static if you want to access it from another script.
var ArmorSlotName : String[]; //This determines how many slots the character has (Head, Legs, Weapon and so on) and the text on each slot.
var buttonPositions : Rect[]; //This list will contain where all buttons, equipped or not will be and SHOULD HAVE THE SAME NUMBER OF cells as the ArmorSlot array.


var DicDetails : Sprite[];


var windowSize : Vector2 = Vector2(375,300); //The size of the character window.
var useCustomPosition = false; //Do we want to use the customPosition variable to define where on the screen the Character window will appear.
var customPosition : Vector2 = Vector2 (70, 70); //The custom position of the Character window.
var cSheetSkin : GUISkin; //This is where you can add a custom GUI skin or use the one included (CSheetSkin) under the Resources folder.
var canBeDragged = true; //Can the Character window be dragged?

var onOffButton : KeyCode = KeyCode.I; //The key to toggle the Character window on and of.

var DebugMode = false; //If this is enabled, debug.logs will print out information when something happens (equipping items etc.).

static var csheet = false; //Helps with turning the CharacterSheet on and off.

private var windowRect = Rect(100,100,200,300); //Keeping track of our character window.
// private var windowRect2 = Rect(100,100,200,300); //Keeping track of our character window.


//These are keeping track of components such as equipmentEffects and Audio.
private var playersinv; //Refers to the Inventory script.
private var equipmentEffectIs = false;
private var invAudio : InvAudio;
private var invDispKeyIsSame = false;

@script AddComponentMenu ("Inventory/Character Sheet")
@script RequireComponent(Inventory)

private var DictionaryUpdatedList : Transform[]; //The updated inventory array.
var Offset : Vector2 = Vector2 (7, 12); //This will leave so many pixels between the edge of the window (x = horizontal and y = vertical).
private var cSheetFound = false;
var itemIconSize : Vector2 = Vector2(60.0, 60.0); //The size of the item icons.
static var itemBeingDragged : Item; //This refers to the 'Item' script when dragging.
private var draggedItemPosition : Vector2; //Where on the screen we are dragging our Item.


static var displayInventory = false; //If inv is opened.



//Assign the differnet components to variables and other "behind the scenes" stuff.
function Awake ()
{
	playersinv = GetComponent(Inventory);

	if (useCustomPosition == false)
	{
		windowRect = Rect(Screen.width-windowSize.x-70,Screen.height-windowSize.y-(162.5+70*2),windowSize.x,windowSize.y);
		// windowRect2 = Rect(Screen.width-windowSize.x,Screen.height-windowSize.y-(162.5+70*2),windowSize.x,windowSize.y);

	}
	else
	{
		windowRect = Rect(customPosition.x,customPosition.y,windowSize.x,windowSize.y);
		// windowRect2 = Rect(customPosition.x,customPosition.y,windowSize.x,windowSize.y);
	}
	invAudio = GetComponent(InvAudio);
	if (GetComponent(InventoryDisplay).onOffButton == onOffButton)
	{
		invDispKeyIsSame = true;
	}
	
	
	associatedInventory=GetComponent(Inventory);//keepin track of the inventory script

}


//Take care of the array lengths.
function Start ()
{
	ArmorSlot = new Item [ArmorSlotName.length];
	if (buttonPositions.Length != ArmorSlotName.Length)
	{
		Debug.LogError("The variables on the Character script attached to " + transform.name + " are not set up correctly. There needs to be an equal amount of slots on 'ArmorSlotName' and 'buttonPositions'.");
	}
}



function Update ()
{
	//This will turn the character sheet on and off.
	if (Input.GetKeyDown(onOffButton))
	{
		if (csheet)
		{
			csheet = false;
			displayInventory=false;
			if (invDispKeyIsSame != true)
			{
				gameObject.SendMessage ("ChangedState", false, SendMessageOptions.DontRequireReceiver); //Play sound
				gameObject.SendMessage("PauseGame", false, SendMessageOptions.DontRequireReceiver); //StopPauseGame/EnableMouse/ShowMouse
			}
		}
		else
		{
			csheet = true;
			displayInventory = true;
			if (invDispKeyIsSame != true)
			{
				gameObject.SendMessage ("ChangedState", true, SendMessageOptions.DontRequireReceiver); //Play sound
				gameObject.SendMessage("PauseGame", true, SendMessageOptions.DontRequireReceiver); //PauseGame/DisableMouse/HideMouse
			}
		}
	}
	
	
		//Updating the list by delay
	if(Time.time>lastUpdate){
		lastUpdate=Time.time+updateListDelay;
		UpdateInventoryList();
	}
	
	
}



function UpdateInventoryList()
{
	DictionaryUpdatedList = associatedInventory.DictionaryContents;
	
	Debug.Log("UpdateInventoryList");
	Debug.Log("associatedInventory  :"+associatedInventory);

	Debug.Log("DictionaryContents : "+associatedInventory.DictionaryContents);

}




//Setting up the Inventory window
function DisplayInventoryWindow(windowID:int)
{

	if (canBeDragged == true)
	{
		GUI.DragWindow (Rect (0,0, 10000, 30));  //the window to be able to be dragged
	}
	
	var currentX = 0 + Offset.x; //Where to put the first items.
	var currentY = 18 + Offset.y; //Im setting the start y position to 18 to give room for the title bar on the window.
	
	var currentX2 = 70 + Offset.x; //Where to put the first items.
	var currentY2 = 88 + Offset.y; //Im setting the start y position to 18 to give room for the title bar on the window.
	







	for(var i:Transform in DictionaryUpdatedList) //Start a loop for whats in our list.
	{
		var item=i.GetComponent(Item);
		if (cSheetFound) //CSheet was found (recommended)
		{



				//Draw on Clicked

			// if(GUI.Button(Rect(currentX2,currentY2,itemIconSize.x,itemIconSize.y),item.itemIcon))
			// {

			// }


			if(GUI.Button(Rect(currentX,currentY,itemIconSize.x,itemIconSize.y),item.itemIcon))
			{
				Debug.Log("item : "+item+ "clicked in Dictionary");
 

				 // GUI.DrawTexture(new Rect(0, 0, 64, 64), DicDetails[0]);


				var dragitem=true; //Incase we stop dragging an item we dont want to redrag a new one.
				if(itemBeingDragged == item) //We clicked the item, then clicked it again
				{
					if (cSheetFound)
					{
						GetComponent(Dictionary).UseItem(item,0,true); //We use the item.
					}
//					ClearDraggedItem(); //Stop dragging
					dragitem = false; //Dont redrag
				}
				if (Event.current.button == 0) //Check to see if it was a left click
				{
					if(dragitem)
					{
						if (item.isEquipment == true) //If it's equipment
						{
							itemBeingDragged = item; //Set the item being dragged.
							draggedItemSize=itemIconSize; //We set the dragged icon size to our item button size.
							//We set the position:
							draggedItemPosition.y=Screen.height-Input.mousePosition.y-15;
							draggedItemPosition.x=Input.mousePosition.x+15;
						}
						else
						{
							i.GetComponent(ItemEffect).UseEffect(); //It's not equipment so we just use the effect.
						}
					}
				}
				else if (Event.current.button == 1) //If it was a right click we want to drop the item.
				{
					associatedInventory.DropItem(item);
				}
			}
		}
		else //No CSheet was found (not recommended)
		{
			if(GUI.Button(Rect(currentX,currentY,itemIconSize.x,itemIconSize.y),item.itemIcon))
			{
				if (Event.current.button == 0 && item.isEquipment != true) //Check to see if it was a left click.
				{
					i.GetComponent(ItemEffect).UseEffect(); //Use the effect of the item.
				}
				else if (Event.current.button == 1) //If it was a right click we want to drop the item.
				{
					associatedInventory.DropItem(item);
				}
			}
		}
		
		if(item.stackable) //If the item can be stacked:
		{
			GUI.Label(Rect(currentX, currentY, itemIconSize.x, itemIconSize.y), "" + item.stack, "Stacks"); //Showing the number (if stacked).
		}
		
		currentX += itemIconSize.x;
		if(currentX + itemIconSize.x + Offset.x > windowSize.x) //Make new row
		{
			currentX=Offset.x; //Move it back to its startpoint wich is 0 + offsetX.
			currentY+=itemIconSize.y; //Move it down a row.
			if(currentY + itemIconSize.y + Offset.y > windowSize.y) //If there are no more room for rows we exit the loop.
			{
				return;
			}
		}
	}
}







//Checking if we already have somthing equipped
function CheckSlot(tocheck:int)
{
	var toreturn=false;
	if(ArmorSlot[tocheck]!=null){
		toreturn=true;
	}
	return toreturn;
}

//Using the item. If we assign a slot, we already know where to equip it.
function UseItem(i:Item,slot:int,autoequip:boolean)
{
	if(i.isEquipment){
		//This is in case we dbl click the item, it will auto equip it. REMEMBER TO MAKE THE ITEM TYPE AND THE SLOT YOU WANT IT TO BE EQUIPPED TO HAVE THE SAME NAME.
		if(autoequip)
		{
			var index=0; //Keeping track of where we are in the list.
			var equipto=0; //Keeping track of where we want to be.
			for(var a in ArmorSlotName) //Loop through all the named slots on the armorslots list
			{
				if(a==i.itemType) //if the name is the same as the armor type.
				{
					equipto=index; //We aim for that slot.
				}
				index++; //We move on to the next slot.
			}
			EquipItem(i,equipto);
		}
		else //If we dont auto equip it then it means we must of tried to equip it to a slot so we make sure the item can be equipped to that slot.
		{
			if(i.itemType==ArmorSlotName[slot]) //If types match.
			{
				EquipItem(i,slot); //Equip the item to the slot.
			}
		}
	}
	if (DebugMode)
	{
		Debug.Log(i.name + " has been used");
	}
}

//Equip an item to a slot.
function EquipItem(i:Item,slot:int)
{
	if(i.itemType == ArmorSlotName[slot]) //If the item can be equipped there:
	{
		if(CheckSlot(slot)) //If theres an item equipped to that slot we unequip it first:
		{
			UnequipItem(ArmorSlot[slot]);
			ArmorSlot[slot]=null;
		}
		ArmorSlot[slot]=i; //When we find the slot we set it to the item.
		
		gameObject.SendMessage ("PlayEquipSound", SendMessageOptions.DontRequireReceiver); //Play sound
		
		//We tell the Item to handle EquipmentEffects (if any).
		if (i.GetComponent(EquipmentEffect) != null)
		{
			equipmentEffectIs = true;
			i.GetComponent(EquipmentEffect).EquipmentEffectToggle(equipmentEffectIs);
		}
		
		//If the item is also a weapon we call the PlaceWeapon function.
		if (i.isAlsoWeapon == true)
		{
			if (i.equippedWeaponVersion != null)
			{
				PlaceWeapon(i);
			}
			
			else 
			{
				Debug.LogError("Remember to assign the equip weapon variable!");
			}
		}
		if (DebugMode)
		{
			Debug.Log(i.name + " has been equipped");
		}
		
		playersinv.RemoveItem(i.transform); //We remove the item from the inventory
	}
}

//Unequip an item.
function UnequipItem(i:Item)
{
	gameObject.SendMessage ("PlayPickUpSound", SendMessageOptions.DontRequireReceiver); //Play sound
	
	//We tell the Item to disable EquipmentEffects (if any).
	if (i.equipmentEffect != null)
	{
		equipmentEffectIs = false;
		i.GetComponent(EquipmentEffect).EquipmentEffectToggle(equipmentEffectIs);
	}
	
	//If it's a weapon we call the RemoveWeapon function.
	if (i.itemType == "Weapon")
	{
		RemoveWeapon(i);
	}
	if (DebugMode)
	{
		Debug.Log(i.name + " has been unequipped");
	}
	playersinv.AddItem(i.transform);
}

//Places the weapon in the hand of the Player.
function PlaceWeapon (Item)
{
		var Clone = Instantiate (Item.equippedWeaponVersion, WeaponSlot.position, WeaponSlot.rotation);
		Clone.name = Item.equippedWeaponVersion.name;
		Clone.transform.parent = WeaponSlot;
		if (DebugMode)
		{
			Debug.Log(Item.name + " has been placed as weapon");
		}
}

//Removes the weapon from the hand of the Player.
function RemoveWeapon (Item)
{	if (Item.equippedWeaponVersion != null)
	{
		Destroy(WeaponSlot.FindChild(""+Item.equippedWeaponVersion.name).gameObject);
		if (DebugMode)
		{
			Debug.Log(Item.name + " has been removed as weapon");
		}
	}
}

//Draw the Character Window
function OnGUI()
{
	GUI.skin = cSheetSkin; //Use the cSheetSkin variable.
	
//	if(csheet) //If the csheet is opened up.
//	{
//		//Make a window that shows what's in the csheet called "Character" and update the position and size variables from the window variables.
//		windowRect=GUI.Window (1, windowRect, DisplayCSheetWindow, "");
//	}
	
		//If the inventory is opened up we create the Inventory window:
	if(displayInventory)
	{
		windowRect = GUI.Window (1, windowRect, DisplayInventoryWindow, "");
		// windowRect2 = GUI.Window (2, windowRect2, DisplayInventoryWindow, "");

	}
}

//This will display the character sheet and handle the buttons.
function DisplayCSheetWindow(windowID:int)
{
	if (canBeDragged == true)
	{
		GUI.DragWindow (Rect (0,0, 10000, 30));  //The window is dragable.
	}
	
	var index=0;
	for(var a in ArmorSlot) //Loop through the ArmorSlot array.
	{
		if(a==null)
		{
			if(GUI.Button(buttonPositions[index], ArmorSlotName[index])) //If we click this button (that has no item equipped):
			{
				var id=GetComponent(Dictionary);
				if(id.itemBeingDragged != null) //If we are dragging an item:
				{
					EquipItem(id.itemBeingDragged,index); //Equip the Item.
					id.ClearDraggedItem();//Stop dragging the item.
				}
			}
		}
		else
		{
			if(GUI.Button(buttonPositions[index],ArmorSlot[index].itemIcon)) //If we click this button (that has an item equipped):
			{
				var id2=GetComponent(Dictionary);
				if(id2.itemBeingDragged != null) //If we are dragging an item:
				{
					EquipItem(id2.itemBeingDragged,index); //Equip the Item.
					id2.ClearDraggedItem(); //Stop dragging the item.
				}
				else if (playersinv.Contents.length < playersinv.MaxContent) //If there is room in the inventory:
				{
					UnequipItem(ArmorSlot[index]); //Unequip the Item.
					ArmorSlot[index] = null; //Clear the slot.
					id2.ClearDraggedItem(); //Stop dragging the Item.
				}
				else if (DebugMode)
				{
					Debug.Log("Could not unequip " + ArmorSlot[index].name + " since the inventory is full");
				}
			}
		}
		index++;
	}
}
