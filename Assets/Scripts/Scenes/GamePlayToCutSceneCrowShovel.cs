using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GamePlayToCutSceneCrowShovel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ChangeTheScene();
        }
    }
    void ChangeTheScene()
    {
        SceneManager.LoadScene("CutSceneCrow1");
    }
}
