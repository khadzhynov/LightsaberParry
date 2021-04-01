using LightsaberParry.Gameplay;
using UnityEngine;

namespace LightsaberParry.Services
{
	public class CollisionPredictionService : IPredictionService
	{
		protected CollisionPredictionSettings _settings;

		public CollisionPredictionService(CollisionPredictionSettings settings)
		{
			_settings = settings;
		}

		protected struct LineSegment
		{
			public Vector3 Vector;
			public Vector3 StartPoint;
			public Vector3 EndPoint;

			public LineSegment(SaberStateDto playerState)
			{
				StartPoint = playerState.BladeStart.position;
				EndPoint = playerState.BladeEnd.position;
				Vector = EndPoint - StartPoint;
			}
		}

		public PredictionResult PredictCollision(SaberStateDto saber1, SaberStateDto saber2)
		{
			Vector3 intersectionPoint = Vector3.zero;

			Quaternion initialRotation1 = saber1.Pivot.rotation;
			Quaternion initialRotation2 = saber2.Pivot.rotation;

			Quaternion finalRotation1 = saber1.PivotFinalPositionAnchor.rotation;
			Quaternion finalRotation2 = saber2.PivotFinalPositionAnchor.rotation;

			bool collide = false;

			for (int i = 0; i < _settings.InterpolationSteps; ++i)
			{
				saber1.Pivot.rotation = Quaternion.Slerp(initialRotation1, saber1.PivotFinalPositionAnchor.rotation, (float)i / _settings.InterpolationSteps);
				saber2.Pivot.rotation = Quaternion.Slerp(initialRotation2, saber2.PivotFinalPositionAnchor.rotation, (float)i / _settings.InterpolationSteps);

				if (DoesSabersIntersects(new LineSegment(saber1), new LineSegment(saber2), out Vector3 newIntersectionPoint))
				{
					intersectionPoint = newIntersectionPoint;
					collide = true;
					finalRotation1 = saber1.Pivot.rotation;
					finalRotation2 = saber2.Pivot.rotation;
				}
			}

			saber1.Pivot.rotation = initialRotation1;
			saber2.Pivot.rotation = initialRotation2;

			return new PredictionResult(collide, intersectionPoint, finalRotation1, finalRotation2);
		}

		protected virtual bool DoesSabersIntersects(LineSegment saber1Line, LineSegment saber2Line, out Vector3 intersectionPoint)
		{
			Vector3 pointOnSaber1 = Vector3.zero;
			Vector3 pointOnSaber2 = Vector3.zero;

			if (MathHelper.ClosestPointsOnTwoLines(
				out pointOnSaber1,
				out pointOnSaber2,
				saber1Line.StartPoint,
				saber1Line.Vector,
				saber2Line.StartPoint,
				saber2Line.Vector))
			{
				if (MathHelper.PointOnWhichSideOfLineSegment(saber1Line.StartPoint, saber1Line.EndPoint, pointOnSaber1) == 0)
				{
					if (MathHelper.PointOnWhichSideOfLineSegment(saber2Line.StartPoint, saber2Line.EndPoint, pointOnSaber2) == 0)
					{
						if (Vector3.Distance(pointOnSaber1, pointOnSaber2) <= _settings.SaberWidth)
						{
							intersectionPoint = (pointOnSaber1 + pointOnSaber2) / 2f;
							return true;
						}
					}
				}
			}

			intersectionPoint = Vector3.zero;
			return false;
		}
	}
}