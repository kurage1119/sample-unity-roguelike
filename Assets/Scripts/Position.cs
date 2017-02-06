using UnityEngine;
using System.Collections;

public class Position {

	public int X {get; set;}
	public int Y {get; set;}

	public Position(int x, int y) {
		X = x;
		Y = y;
	}

	public Position() : this(0, 0) {}

	public override string ToString() {
		return string.Format("({0}, {1})", X, Y);
	}
}
