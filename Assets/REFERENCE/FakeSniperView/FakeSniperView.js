#pragma strict

// Fake Sniper View (its just a plane & texture with hole..)
// mgear - http://unitycoder.com/blog/
// ** REMEMBER TO DONATE ^, keep free sources coming :)

public var sniperScope:Texture2D;
public var material:Material;

public var sniperMode:boolean = false;

function OnPostRender ()
{
	if (sniperMode)
		Graphics.Blit( sniperScope,null,material); // draw sniper texture on screen..
}

function Update()
{
	// Press S to switch sniper view on/off
    if (Input.GetMouseButtonDown(1))
	{
		sniperMode=!sniperMode; // invert mode		
		Camera.main.fieldOfView = sniperMode ? 20 : 60; // zoom effect while in sniper mode, we adjust FOV
	}
}