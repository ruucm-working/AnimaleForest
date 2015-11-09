using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

public class UnityClipCursor : MonoBehaviour
{
	
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ClipCursor(ref RECT rcClip);
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetClipCursor(out RECT rcClip);
	[DllImport("user32.dll")]
	static extern int GetForegroundWindow();
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	static extern bool GetWindowRect(int hWnd, ref RECT lpRect);
	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern int SetCursorPos(int x, int y);
	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCursorPos(out POINT point);
	[DllImport("user32.dll")]
	static extern int GetWindowText(System.IntPtr hWnd, StringBuilder text, int count);
	[DllImport("user32.dll")]
	static extern int ShowCursor(bool bShow);
	
	private delegate bool EnumWindowProc(System.IntPtr hwnd, System.IntPtr lParam);
	
	[DllImport("user32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumChildWindows(System.IntPtr window, EnumWindowProc callback, System.IntPtr lParam);
	
	private static RECT currentClippingRect;
	private static RECT originalClippingRect = new RECT();
	private static bool isClipped = false;
	
	public static int centerX;
	public static int centerY;
	
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int Left;
		public int Top;
		public int Right;
		public int Bottom;
		public RECT(int left, int top, int right, int bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}
	}
	
	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int x;
		public int y;
		public POINT(int X, int Y)
		{
			x = X;
			y = Y;
		}
	}
	
	static void SaveOriginal()
	{
		CursorLockMode mode = Cursor.lockState;
		Cursor.lockState = CursorLockMode.None;
		GetClipCursor(out originalClippingRect);
		centerX = originalClippingRect.Left + (originalClippingRect.Right - originalClippingRect.Left) / 2;
		centerY = originalClippingRect.Top + (originalClippingRect.Bottom - originalClippingRect.Top) / 2;
	}
	
	public static void StartClipping()
	{
		if (isClipped) return;
		
		SaveOriginal();
		
		var hndl = GetForegroundWindow();
		
		var allChildWindows = GetAllChildHandles((System.IntPtr)hndl);
		foreach (var child in allChildWindows)
		{
			const int nChars = 256;
			StringBuilder Buff = new StringBuilder(nChars);
			if (GetWindowText(child, Buff, nChars) > 0)
			{
				if (Buff.ToString().Trim() == "UnityEditor.GameView")
				{
					hndl = (int)child;
				}
			}
		}
		
		GetWindowRect(hndl, ref currentClippingRect);
		ClipCursor(ref currentClippingRect);
		
		#if UNITY_EDITOR
		centerX = Screen.width / 2;
		centerY = Screen.height / 2;
		#else
		centerX = currentClippingRect.Left + (currentClippingRect.Right - currentClippingRect.Left) / 2;
		centerY = currentClippingRect.Top + (currentClippingRect.Bottom - currentClippingRect.Top) / 2;
		#endif
		ShowCursor(false);
		isClipped = true;
		CenterCursor();
	}
	
	static public void CenterCursor()
	{
		SetCursorPos(centerX, centerY);
	}
	
	void OnApplicationQuit()
	{
		StopClipping();
	}
	public static void StopClipping()
	{
		if (isClipped)
		{
			CenterCursor();
			isClipped = false;
			ClipCursor(ref originalClippingRect);
			ShowCursor(true);
		}
	}
	
	
	
	public static List<System.IntPtr> GetAllChildHandles(System.IntPtr mainHandle)
	{
		List<System.IntPtr> childHandles = new List<System.IntPtr>();
		
		GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
		System.IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);
		
		try
		{
			EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
			EnumChildWindows(mainHandle, childProc, pointerChildHandlesList);
		}
		finally
		{
			gcChildhandlesList.Free();
		}
		
		return childHandles;
	}
	
	private static bool EnumWindow(System.IntPtr hWnd, System.IntPtr lParam)
	{
		GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);
		
		if (gcChildhandlesList == null || gcChildhandlesList.Target == null)
		{
			return false;
		}
		
		List<System.IntPtr> childHandles = gcChildhandlesList.Target as List<System.IntPtr>;
		childHandles.Add(hWnd);
		
		return true;
	}
}