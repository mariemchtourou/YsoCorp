using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class UndergroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (!Game.isGameover)
        {
            if (tag.Equals("Object"))
            {
                Level.Instance.objectsInScene--;
                UIManager.Instance.UpdateLevelProgress();
                Destroy(other.gameObject);
                //avoir fait tombé tous les objets
                if(Level.Instance.objectsInScene == 0)
                {
                    //Level.Instance.loadNextLevel();
                }
            }
        }
        
        if (tag.Equals("Obstacle"))
        {
            Game.isGameover = true;
            //shake camera on lose
            Camera.main.transform.DOShakePosition(1f, .2f, 20, 90f)
                .OnComplete(() =>{
                Level.Instance.RestartLevel();
            });
        }

    }
}
