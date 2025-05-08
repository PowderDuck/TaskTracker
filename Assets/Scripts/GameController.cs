using TaskTracker.Scripts.Destructibles;
using UnityEngine;

namespace TaskTracker.Scripts
{
    public class GameController : MonoBehaviour
    {
        private RaycastHit _hitInfo = new();

        private void Update()
        {
            ClickHandler();
        }

        private void ClickHandler()
        {
            if (Input.GetMouseButtonDown(0)
                && Physics.Raycast(
                    Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo))
            {
                if (_hitInfo.collider
                    .TryGetComponent<Destructible>(out var destructible))
                {
                    destructible.Destroy();
                }
            }
        }
    }
}