using UnityEditor;
using UnityEngine;

namespace Codebase.Environment
{
    public class SpawnPoint : MonoBehaviour
    {
        public MovableItemType MovableItemType;

        [SerializeField] private Color _meshColor;
        [SerializeField] private Color _textColor;
#if UNITY_EDITOR
        public void OnDrawGizmos()
        {
            Gizmos.color = _meshColor;
            Gizmos.DrawCube(transform.position, Vector3.one);

            Handles.color = _textColor;
            Vector3 labelPosition = transform.position + Vector3.up * 1.5f;
            Handles.Label(labelPosition, $"{gameObject.name}\nPos: {transform.position}");
        }
#endif
    }

    public enum MovableItemType
    {
        Cube,
        Cylinder
    }
}