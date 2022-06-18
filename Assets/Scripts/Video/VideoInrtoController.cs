using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoInrtoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private VideoClip _videoClip;
    //[SerializeField] private string _pathName;
    [SerializeField] private string _nextSceneName;
    [SerializeField] private int _nextSceneIndex;

    private MiniGamesAction _inputActions;
    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        //_videoPlayer.clip = Resources.Load<VideoClip>(_pathName);
        _videoPlayer.clip = _videoClip;
        
        _videoPlayer.loopPointReached += EndReached;

        _inputActions = new MiniGamesAction();
        _inputActions.MiniGames.Enable();
        _inputActions.MiniGames.SkipVideo.performed += perf => FinishVideo();
    }
    private void OnEnable()
    {
        _videoPlayer.Play();
    }
    private void FinishVideo()
    {
        if (_videoPlayer != null)
        {
            _videoPlayer.Stop();
            EndReached(_videoPlayer);
        }
    }
    private void EndReached(VideoPlayer videoPlayer)
    {
        Debug.Log("VideoEnd");
        SceneManager.LoadScene(_nextSceneIndex);
    }
}
