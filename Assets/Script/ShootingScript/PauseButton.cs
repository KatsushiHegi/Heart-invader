// It's only manners to tackle all out a game that they have gone all out in creating. Pressing the pause button is just rude!
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void TheGameWorld()
    {
        //ゲームが進行中であれば一時停止、ゲームが止まっていれば再生
        Time.timeScale = (Time.timeScale != 0.0f) ? 0.0f : 1.0f;
    }
}