using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	private void Awake()
	{
		// Don't destroy when switching scenes
		DontDestroyOnLoad(this.gameObject);
	}
}
