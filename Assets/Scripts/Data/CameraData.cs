using UnityEngine;

namespace NOX.Maga.Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Controller/Camera")]
    public class CameraData : ScriptableObject
    {
        [Header("Zoom")]
        public float CurrentZoom;
        public float ZoomSpeed;
        [Space] public float MinZoom;
        public float MaxZoom;

        [Header("Rotation")]
        public float RotationTime;
        [Space] public float RotationHSpeed;
        public float RotationVSpeed;
        [Space] public float CurrentVAngle;
        public float CurrentHAngle;
        public float MinVAngle;
        public float MaxVAngle;
    }
}
