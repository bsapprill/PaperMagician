using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier{

	public Vector3 squarePoint(float t, Vector3 startPos, Vector3 endPos, Vector3 controlPoint){
		float mt = 1 - t;
		float t2 = t * t;
		float mt2 = mt * mt;

		float x = startPos.x * mt2 + (2 * mt * t * controlPoint.x) + t2 * endPos.x;
		float y = startPos.y * mt2 + (2 * mt * t * controlPoint.y) + t2 * endPos.y;

		return new Vector3 (x, y);
	}
}