using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectShadowExecutor : MonoBehaviour
{
    public static void activateShadow()
    {
        desactivateShadows();
        EntityManager.ExecutorEntity.transform.Find("shadow").gameObject.SetActive(true);
    }
   public static void desactivateShadows()
    {
        Entity[] entities = EntityManager.GetEntitiesAlive();
        foreach(Entity entity in entities)
        {
            Transform shadow = entity.transform.Find("shadow");
            shadow.gameObject.SetActive(false);
        }
    }
}
