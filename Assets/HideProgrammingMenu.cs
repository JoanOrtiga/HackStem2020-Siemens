using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideProgrammingMenu : MonoBehaviour
{
    public CanvasGroup cGroup;

    public void HideAndShow()
    {
        if (cGroup.interactable)
        {
            cGroup.interactable = false;
            cGroup.blocksRaycasts = false;
            cGroup.alpha = 0;

        }
        else
        {
            cGroup.interactable = true;
            cGroup.blocksRaycasts = true;
            cGroup.alpha = 1;
        }
    }

    
}
