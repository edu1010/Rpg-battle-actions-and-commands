using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    int counterAllies;
    int counterEnemies;

    // Update is called once per frame
    void Update()
    {
        counterAllies = 0;
        counterEnemies = 0;
        foreach (Entity e in EntityManager.GetEntitiesAlive())
        {
            if (e.team == Team.Allies)
            {
                counterAllies++;
            }
            else
            {
                counterEnemies++;
            }
        }

        if (counterEnemies == 0)
        {
            SceneLoader.Instance.LoadLevel(5); // wins the left team
        }
        else if (counterAllies == 0)
        {
            SceneLoader.Instance.LoadLevel(6); // wins the right team
        }
    }
}
