using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Give an object a random scale - used to quickly get a lot a variation out of the same models
/// </summary>
public class RandomScaler : MonoBehaviour 
{
	[Tooltip("The minimum scale value to use for this object")]
	public Vector3 minScale = Vector3.one;
	[Tooltip("The maximum scale value to use for this object")]
	public Vector3 maxScale = Vector3.one;
	public List<Vector3> lsRandom;
	void Start () 
	{
		Vector3 scale;
		if (lsRandom.Count > 0)
        {
			var ran = Random.Range(0, lsRandom.Count);
			scale = lsRandom[ran];
		}
		else
        {
            scale.x = Mathf.Lerp(minScale.x, maxScale.x, Random.value);
            scale.y = Mathf.Lerp(minScale.y, maxScale.y, Random.value);
            scale.z = Mathf.Lerp(minScale.z, maxScale.z, Random.value);
        }


		//var ran = Random.Range(0, lsRandom.Count);
		//scale = lsRandom[ran];
		//scale.x = Mathf.Lerp (minScale.x, maxScale.x, Random.value);
		//scale.y = Mathf.Lerp (minScale.y, maxScale.y, Random.value);
		//scale.z = Mathf.Lerp (minScale.z, maxScale.z, Random.value);
		transform.localScale = scale;
	}	
}
