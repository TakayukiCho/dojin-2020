using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
    UserWait,
    UserAct,
    EnemyWait,
    EnemyAct,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Phase phase = Phase.UserWait;

    void Awake()
    {
        if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
