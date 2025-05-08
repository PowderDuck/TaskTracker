using UnityEngine;

namespace TaskTracker.Scripts.Destructibles
{
    public class FerociousCube : Destructible
    {
        [SerializeField] private float _shapeChangingDuration = 2f;
        [SerializeField] private Vector3 _shapeBoundaries = new(0.1f, 0.1f, 0.1f);

        private float _currentShapeTime { get; set; } = 0;

        private Vector3 _destinationShape { get; set; } = Vector3.one;
        private Vector3 _currentShape { get; set; } = Vector3.one;

        private bool IsChanging => _currentShapeTime < _shapeChangingDuration;

        private void Awake()
        {
            _currentShape = transform.localScale;
            _destinationShape = RandomizeVector(_shapeBoundaries);
        }

        private void Update()
        {
            ChangeShape();
        }

        private void ChangeShape()
        {
            if (IsChanging)
            {
                _currentShapeTime += Time.deltaTime;

                var percentage = Mathf.Min(
                    _currentShapeTime / _shapeChangingDuration, 1f);

                transform.localScale = Vector3.Lerp(
                    _currentShape, _destinationShape, percentage);

                if (!IsChanging)
                {
                    _currentShapeTime = 0;
                    _currentShape = transform.localScale;
                    _destinationShape = RandomizeVector(_shapeBoundaries);
                }
            }
        }

        public override void Destroy()
        {
            base.Destroy();
            Destroy(gameObject);
        }

        private static Vector3 RandomizeVector(Vector3 boundaries)
        {
            return new(
                Random.Range(boundaries.x, 1f),
                Random.Range(boundaries.y, 1f),
                Random.Range(boundaries.z, 1f));
        }
    }
}
