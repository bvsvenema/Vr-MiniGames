using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingGameUI : MonoBehaviour
{
    public SystemManager SM;

    public GameObject bowlingGameUICanvas;

    public GameObject spawn;
    public GameObject bowlingMiniGame;


    public void HomeButton()
    {
        SM.ResetEveryThingBowling();
        spawn.SetActive(true);
        bowlingMiniGame.SetActive(false);
    }

    public void PlayAgainButton()
    {
        SM.ResetEveryThingBowling();
        bowlingGameUICanvas.SetActive(false);
    }

    public void HighScoresButton()
    {

    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
