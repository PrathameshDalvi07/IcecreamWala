using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartVideoHandler : MonoBehaviour
{
    
    IEnumerator Start()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        yield return new WaitForSeconds(2f);
        videoPlayer.Play();
        yield return new WaitForSeconds((float)videoPlayer.length + 1.2f);
        SceneManager.LoadScene(1);
    }
}
