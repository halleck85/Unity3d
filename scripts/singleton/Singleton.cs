using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{

    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance==null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogWarning("necesaria una instancia del tipo " + typeof(T));
                }
            }
            return instance;
        }
    }

	// Use this for initialization
	void Awake () {
        if (Instance!=this)
        {
            Destroy(gameObject);
        }
	}

}
