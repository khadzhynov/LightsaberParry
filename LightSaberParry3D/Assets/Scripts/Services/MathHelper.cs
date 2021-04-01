using UnityEngine;

namespace LightsaberParry.Services
{
	/// <summary>
	/// Code copied from 
	/// https://wiki.unity3d.com/index.php/3d_Math_functions
	/// </summary>
	public class MathHelper
	{
		//Two non-parallel lines which may or may not touch each other have a point on each line which are closest
		//to each other. This function finds those two points. If the lines are not parallel, the function 
		//outputs true, otherwise false.
		public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
		{

			closestPointLine1 = Vector3.zero;
			closestPointLine2 = Vector3.zero;

			float a = Vector3.Dot(lineVec1, lineVec1);
			float b = Vector3.Dot(lineVec1, lineVec2);
			float e = Vector3.Dot(lineVec2, lineVec2);

			float d = a * e - b * b;

			//lines are not parallel
			if (d != 0.0f)
			{

				Vector3 r = linePoint1 - linePoint2;
				float c = Vector3.Dot(lineVec1, r);
				float f = Vector3.Dot(lineVec2, r);

				float s = (b * f - c * e) / d;
				float t = (a * f - c * b) / d;

				closestPointLine1 = linePoint1 + lineVec1 * s;
				closestPointLine2 = linePoint2 + lineVec2 * t;

				return true;
			}

			else
			{
				return false;
			}
		}

		//This function finds out on which side of a line segment the point is located.
		//The point is assumed to be on a line created by linePoint1 and linePoint2. If the point is not on
		//the line segment, project it on the line using ProjectPointOnLine() first.
		//Returns 0 if point is on the line segment.
		//Returns 1 if point is outside of the line segment and located on the side of linePoint1.
		//Returns 2 if point is outside of the line segment and located on the side of linePoint2.
		public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
		{

			Vector3 lineVec = linePoint2 - linePoint1;
			Vector3 pointVec = point - linePoint1;

			float dot = Vector3.Dot(pointVec, lineVec);

			//point is on side of linePoint2, compared to linePoint1
			if (dot > 0)
			{

				//point is on the line segment
				if (pointVec.magnitude <= lineVec.magnitude)
				{
					return 0;
				}

				//point is not on the line segment and it is on the side of linePoint2
				else
				{
					return 2;
				}
			}

			//Point is not on side of linePoint2, compared to linePoint1.
			//Point is not on the line segment and it is on the side of linePoint1.
			else
			{
				return 1;
			}
		}
	}
}