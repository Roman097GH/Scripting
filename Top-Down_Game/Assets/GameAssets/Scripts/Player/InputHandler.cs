using UniRx;
using UnityEngine;
using Zenject;

namespace TopDown
{
    public class InputHandler : ITickable
    {
        private readonly Camera _camera;

        public ReactiveCommand<Vector3> OnClicked = new ();

        private const string LayerName = "Ground";

        public InputHandler([Inject(Id = BaseIds.GameCameraId)] Camera camera)
        {
            _camera = camera;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                var mask = LayerMask.GetMask(LayerName);

                if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000, mask))
                {
                    OnClicked.Execute(hitInfo.point);
                }
            }
        }
    }
}