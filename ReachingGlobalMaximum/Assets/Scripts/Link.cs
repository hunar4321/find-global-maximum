using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public void OpenYouTubeLink()
	{
#if !UNITY_EDITOR
		openWindow("https://youtu.be/1p11-oggW1E");
#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}