using UnityEngine;

namespace Nox.Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Controller/Camera")]
    public class CameraData : ScriptableObject
    {
        [Header("Default")]
        [Header("Zoom")]
        public float DefaultZoom;
        public float ZoomSpeed;
        [Space] public float MinZoom;
        public float MaxZoom;

        [Header("Rotation")]
        public Vector2 DefaultLookAngle;
        public float RotationTime;
        [Space] public float MinVAngle;
        public float MaxVAngle;
        [Space] public float RotationHSpeed;
        public float RotationVSpeed;

        [Header("In Game Data")]
        [Header("Zoom")]
        public float CurrentZoom;

        [Header("Rotation")]
        public float CurrentVAngle;
        public float CurrentHAngle;
    }
}
