using UnityEngine;

namespace LightsaberParry.Gameplay
{
    public class SaberStateDto
    {
        public readonly Transform Pivot;
        public readonly Transform PivotFinalPositionAnchor;
        public readonly Transform BladeStart;
        public readonly Transform BladeEnd;

        public SaberStateDto(Transform pivot, Transform pivotFinalPositionAnchor, Transform bladeStart, Transform bladeEnd)
        {
            Pivot = pivot;
            PivotFinalPositionAnchor = pivotFinalPositionAnchor;
            BladeStart = bladeStart;
            BladeEnd = bladeEnd;
        }
    }
}