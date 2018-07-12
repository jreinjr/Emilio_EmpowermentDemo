using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RenderHeads.Media.AVProVideo;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using TBE;
using System;

public class VCR : MonoBehaviour {

    public MediaPlayer m_mediaPlayer;
    public PlayableDirector m_playableDirector;
    public SpatDecoderFile m_spatDecoderFile;
 
    public void PlayVideoFile(VideoFile videoFile, PlayableAsset timeline = null, string tbePath = "")
    {
        if (timeline != null)
            m_playableDirector.playableAsset = timeline;

        if (tbePath != "")
            m_spatDecoderFile.open(tbePath);

        Debug.Log(videoFile.m_path);

        m_mediaPlayer.OpenVideoFromFile(videoFile.m_fileLocation, videoFile.m_path, autoPlay: false);
        m_mediaPlayer.Events.AddListener(VideoEventListener);
    }

    private void VideoEventListener(MediaPlayer mediaPlayer, MediaPlayerEvent.EventType eventType, ErrorCode errorCode)
    {
        switch (eventType)
        {
            case MediaPlayerEvent.EventType.FirstFrameReady:
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
        m_mediaPlayer.Pause();
        m_playableDirector.Pause();
        m_spatDecoderFile.pause();
    }

    public void Play()
    {
        m_spatDecoderFile.setExternalClockInMs(m_mediaPlayer.Control.GetCurrentTimeMs());
        m_spatDecoderFile.play();
        m_mediaPlayer.Play();
        m_playableDirector.Play();
    }
}
