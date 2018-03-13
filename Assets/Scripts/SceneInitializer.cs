using UnityEngine;
using System.Collections.Generic;

public class SceneInitializer : MonoBehaviour {

	public const int MAP_SIZE_X = 30;
	public const int MAP_SIZE_Y = 20;

	public const int MAX_ROOM_NUMBER = 6;

	public GameObject _player;

	private GameObject floorPrefab;
	private GameObject wallPrefab;

	private int[,] map;

	// Use this for initialization
	void Start () {

		GenerateMap();

		SponePlayer();

	}

	private void GenerateMap() {
		map = new MapGenerator().GenerateMap(MAP_SIZE_X, MAP_SIZE_Y, MAX_ROOM_NUMBER);

		string log = "";
		for (int y = 0; y < MAP_SIZE_Y; y++) {
			for (int x = 0; x < MAP_SIZE_X; x++) {
				log += map[x, y] == 0 ? " " : "1";
			}
			log += "\n";
		}
		Debug.Log(log);

		floorPrefab = Resources.Load("Prefabs/Floor") as GameObject;
		wallPrefab = Resources.Load("Prefabs/Wall") as GameObject;

		var floorList = new List<Vector3>();
		var wallList = new List<Vector3>();

		for (int y = 0; y < MAP_SIZE_Y; y++) {
			for (int x = 0; x < MAP_SIZE_X; x++) {
				if (map[x, y] == 1) {
					Instantiate(floorPrefab, new Vector3(x, 0, y), new Quaternion());
				} else {
					Instantiate(wallPrefab, new Vector3(x, 0, y), new Quaternion());
				}
			}
		}

	}

	private void SponePlayer() {
		if (!_player) {
			return;
		}

		Position position;
		do {
			var x = RogueUtils.GetRandomInt(0, 	MAP_SIZE_X - 1);
			var y = RogueUtils.GetRandomInt(0, 	MAP_SIZE_Y - 1);
			position = new Position(x, y);
		} while (map[position.X, position.Y] != 1);

		_player.transform.position = new Vector3(position.X, 0, position.Y);
	}

}
