using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;

private void Awake()
	{
		if (instance != null)
		{
			Destroy(instance);
		}

		instance = this;
	}

    public void SaveGame()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
