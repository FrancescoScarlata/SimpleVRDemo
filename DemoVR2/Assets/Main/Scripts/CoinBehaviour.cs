using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;

/// <summary>
/// Script used for the interactions of the coin
/// </summary>
public class CoinBehaviour : MonoBehaviour
{
    public GameObject myGameObject;

    public void OnCoinBeginHover()
    {
        myGameObject.transform.localScale = Vector3.one * 1.5f;
    }

    public void OnCoinEndHover()
    {
        myGameObject.transform.localScale = Vector3.one;
    }


    public void OnCoinSelect()
    {
        myGameObject.transform.Rotate(Vector3.up * 45f);
    }


}
