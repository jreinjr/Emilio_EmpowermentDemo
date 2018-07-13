using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RenderHeads.Media.AVProVideo;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System;

public class VCR : MonoBehaviour {

    public MediaPlayer m_mediaPlayer;
    public PlayableDirector m_playableDirector;
 
    public void PlayVideoFile(VideoFile videoFile, PlayableAsset timeline)
    {
        Debug.Log("PlayVideoFile called");
        if (timeline != null)
            m_playableDirector.playableAsset = timeline;
        m_mediaPlayer.OpenVideoFromFile(videoFile.m_fileLocation, videoFile.m_path, autoPlay: false);
        Debug.Log(videoFile.m_path);
        m_mediaPlayer.Events.AddListener(VideoEventListener);
    }

    private void VideoEventListener(MediaPlayer mediaPlayer, MediaPlayerEvent.EventType eventType, ErrorCode errorCode)
    {
        Debug.Log(eventType);
        switch (eventType)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                Play();
                break;
        }
    }

    public void IncreasePlaybackSpeed()
    {
        Debug.Log("IncreasePlaybackSpeed");
    }

    public void DecreasePlaybackSpeed()
    {
        Debug.Log("DecreasePlaybackSpeed");
    }

    public void Pause()
    {
        Debug.Log("Pause");
        m_mediaPlayer.Pause();
        m_playableDirector.Pause();
    }

    public void Play()
    {
        Debug.Log("Play");
        Debug.Log(m_mediaPlayer.name);
        Debug.Log(m_mediaPlayer.m_VideoPath);
        m_mediaPlayer.Play();
        m_playableDirector.Play();
    }
}
