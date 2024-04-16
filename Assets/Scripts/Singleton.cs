using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    static T _instance;
    public static T instance
    {
        get
        {
            if (_instance != null)
                return _instance; 

            _instance = FindAnyObjectByType<T>();

            if (_instance != null)
                return _instance;

            _instance = new GameObject("Singleton").AddComponent<T>();
            return _instance;
        }
    }
}
