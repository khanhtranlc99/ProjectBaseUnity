using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopUp : MonoBehaviour
{
    public void Next()
    {
        GameManager_Base.instance.NextLevel();
    }
}
