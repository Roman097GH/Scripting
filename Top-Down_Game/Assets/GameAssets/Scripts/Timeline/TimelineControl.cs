using UnityEngine;
using UnityEngine.Playables;

namespace TopDown
{
    public class TimelineControl : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private GameObject _camera;
        [SerializeField] private GameObject _cameraCutscene;

        private void Awake()
        {
            _playableDirector.Play();
        }

        private void Update()
        {
            if (_playableDirector.time >= _playableDirector.duration)
            {
                _camera.gameObject.SetActive(true);
                _cameraCutscene.gameObject.SetActive(false);
            }
        }
    }
}