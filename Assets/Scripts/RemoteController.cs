using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoteController : MonoBehaviour
{
    private bool tvOn;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private RawImage tv;
    public void OnRemoteClick(ActivateEventArgs args)
    {
        Debug.Log("CLICK");
        if (tvOn)
        {
            TurnOffTv();
        }
        else
        {
            tvOn = true;
            tv.enabled = true;
            StartCoroutine(PlayVideo());
        }

    }

    public IEnumerator PlayVideo()
    {
        _videoPlayer.Play();
        yield return new WaitUntil(() => _videoPlayer.isPlaying);
        while (_videoPlayer.isPlaying)
        {
            yield return null;
        }
        TurnOffTv();

        
    }

    private void TurnOffTv()
    {
        _videoPlayer.Pause();
        _videoPlayer.frame = 0;
        tv.enabled = false;
        tvOn = false;
    }
}
