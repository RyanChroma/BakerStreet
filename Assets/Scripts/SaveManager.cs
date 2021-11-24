using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
    [SerializeField] private PlayerData playerData;

    private void Awake()
	{
		if (instance != null)
		{
			Destroy(instance);
		}

		instance = this;
	}

    public void ResetData()
    {
        playerData.health = playerData.maxHealth;
    }

}
