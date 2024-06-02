using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
        videoPlayer.loopPointReached += VideoEnded;
    }

    private void VideoEnded(VideoPlayer vp)
    {
        GameManager.Instance.SetGameState(GameManager.GameState.FridgeLayout);
    }
}
