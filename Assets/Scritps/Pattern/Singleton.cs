public class Singleton<T> where T : class, new()
{
	private static T mInstance;

	/// <summary>
	/// The singleton instance of this class.
	/// </summary>
	public static T Instance {
		get
		{
			if (mInstance == null)
			{
				mInstance = new T();
			}			
			return mInstance;
		}
	}
}
