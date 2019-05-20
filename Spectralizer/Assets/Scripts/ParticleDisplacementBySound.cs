using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleDisplacementBySound : MonoBehaviour
{
	private ParticleSystem _psys;
	public float VelocityScaleFactor = 1.0f;
	// Start is called before the first frame update
	void Start()
    {
		_psys = this.GetComponent<ParticleSystem>();
	}

    // Update is called once per frame
    void Update()
    {
		Vector3 vel = ComputeVelocityBySound();
		ParticleSystem.Particle[] p = new ParticleSystem.Particle[_psys.particleCount];
		_psys.GetParticles(p);
		for(int i = 0; i < _psys.particleCount; ++i)
		{
			p[i].velocity += vel * VelocityScaleFactor;
		}
		_psys.SetParticles(p);
		//ParticleSystem.Particle p = _psys.GetParticles();
	}

	Vector3 ComputeVelocityBySound()
	{
		Vector3 dir = new Vector3();

		for(int i = 0; i < 8; ++i)
		{
			float xdir = (float)((i & 1) != 0 ? 1.0 : -1.0);
			float ydir = (float)((i & 2) != 0 ? 1.0 : -1.0);
			float zdir = (float)((i & 4) != 0 ? 1.0 : -1.0);
			Vector3 v = new Vector3(xdir * Spectralizer._freqBands[i],
									ydir * Spectralizer._freqBands[i],
									zdir * Spectralizer._freqBands[i]);
			dir += v;
		}

		return dir;
	}
}
