using UnityEngine;

/// <summary>
/// This class is a singleton. Only one instance of this class can exist.
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component {
	private static T mInstance;
	private static bool mIsCreated = false;

	/// <summary>
	/// The singleton instance of this class.
	/// </summary>
	public static T Instance {
		get
		{
			if (mInstance == null)
			{
				mInstance = (T)FindObjectOfType (typeof(T));
				if (mInstance == null)
				{
					mInstance = CreateSingletonInstance ();
				}
			}
			
			return mInstance;
		}
	}
	
	/// <summary>
	/// Create a gameobject with itself attached.
	/// </summary>
	/// <returns>Return an instance of itself.</returns>
	private static T CreateSingletonInstance ()
	{
		GameObject gameObject = new GameObject (typeof(T).ToString());
		Debug.LogWarning("Could not find " + gameObject.name + ", creating");
		return gameObject.AddComponent<T> ();
	}
	
	public virtual void Awake()
	{
		if (!mIsCreated)
		{
			DontDestroyOnLoad(this);
			mIsCreated = true;
		}
		else
		{
			Destroy(this.gameObject);
			return;
		}
	}

	/// <summary>
	/// Destroys the singleton. Important for cleaning up the static reference.
	/// </summary>
	public virtual void OnDestroy ()
	{
		mInstance = null;
	}
	
	void onApplicationQuit()
	{
		mInstance = null;
	}
}
