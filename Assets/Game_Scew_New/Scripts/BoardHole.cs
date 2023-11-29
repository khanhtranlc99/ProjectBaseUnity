using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHole : MonoBehaviour
{
    public bool Locked;
    public bool Reward;
    LayerMask collisionLayer;



    private void Start()
    {
        string[] layers = { "Bolt", "Bar1", "Bar2", "Bar3", "Bar4", "Bar5", "Bar6", "Bar7" };
        collisionLayer = LayerMask.GetMask(layers);
        if (Locked)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public bool checkIfCollidingWithBars()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, 0.4f, collisionLayer);
        if (hitCollider != null) return true;
        else return false;
    }
    public void Unlock()
    {
        Locked = false;
        transform.GetChild(1).gameObject.SetActive(false);
    }


    public void RewardHole()
    {

        Advertisements.Instance.ShowRewardedVideo(CompleteMethod);
    }

    private void CompleteMethod(bool completed, string advertiser)
    {
        Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        if (completed == true)
        {
            Reward = false;
            transform.GetChild(2).gameObject.SetActive(false);

        }
        else
        {
            //no reward
        }
    }


}