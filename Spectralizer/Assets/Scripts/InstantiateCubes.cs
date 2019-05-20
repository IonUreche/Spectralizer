using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
	public GameObject _sampleCubePrefab;
	GameObject[] _sampleCube = new GameObject[512];
	public float _maxScale = 1000;
	// Start is called before the first frame update
	void Start()
    {
        for(int i = 0; i < 512; ++i)
		{
			GameObject _instance = (GameObject)Instantiate(_sampleCubePrefab);
			_instance.transform.position = this.transform.position;
			_instance.transform.parent = this.transform;
			_instance.name = "sampleCube" + i;
			this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
			_instance.transform.position = Vector3.forward * 100;
			_sampleCube[i] = _instance;
		}
    }

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < 512; ++i)
		if(_sampleCube[i] != null)
		{
			_sampleCube[i].transform.localScale = new Vector3(2, Spectralizer._samples[i] * _maxScale, 2);
		}
	}
}
