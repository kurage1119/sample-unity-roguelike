using UnityEngine;
using System.Collections;

public class RogueUtils {

	public static int GetRandomInt(int min, int max) {
		return min + Mathf.FloorToInt(Random.value * (max - min + 1));
	}

	public static bool RandomJadge(float rate) {
		return Random.value < rate;
	}

}
