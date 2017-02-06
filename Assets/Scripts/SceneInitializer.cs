using UnityEngine;
using System.Collections;

public class SceneInitializer : MonoBehaviour {

	public const int MAP_SIZE_X = 30;
	public const int MAP_SIZE_Y = 20;

	public const int MAX_ROOM_NUMBER = 6;

	// Use this for initialization
	void Start () {

		int[,] map = new MapGenerator().GenerateMap(MAP_SIZE_X, MAP_SIZE_Y, MAX_ROOM_NUMBER);

		string log = "";
		for (int y = 0; y < MAP_SIZE_Y; y++) {
			for (int x = 0; x < MAP_SIZE_X; x++) {
				log += map[x, y] == 0 ? " " : "1";
			}
			log += "\n";
		}
		Debug.Log(log);

	}

}
