using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    public Color[] Colors;
    public Material material;
    
	public void ChangeToColor(int index) {
        material.color = Colors[index];
    }
}
