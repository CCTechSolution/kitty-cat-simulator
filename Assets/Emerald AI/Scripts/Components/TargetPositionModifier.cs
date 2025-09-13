using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmeraldAI.Utility
{
    public class TargetPositionModifier : MonoBehaviour
    {
        public float PositionModifier = 0;
        public float GizmoRadius = 0.5f;
        public Color GizmoColor = new Color(1f, 0, 0, 0.8f);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position + (transform.up * PositionModifier), GizmoRadius);
        }
    }
}