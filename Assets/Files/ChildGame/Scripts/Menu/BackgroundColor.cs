using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class BackgroundColor : MonoBehaviour
{
	public Camera mainCamera;
	public Color[] colors;

	void Start()
	{
		mainCamera.backgroundColor = colors[Random.Range(0, colors.Length)];
	}
}
