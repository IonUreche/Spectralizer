using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleDisplacementBySound : MonoBehaviour
{
	private ParticleSystem _psys;
	public float VelocityScaleFactor = 1.0f;
    public float ColorScaleFactor = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
		_psys = this.GetComponent<ParticleSystem>();
	}

    // Update is called once per frame
    void Update()
    {
        //Vector3 vel = ComputeVelocityBySound();
        //ParticleSystem.Particle[] p = new ParticleSystem.Particle[_psys.particleCount];
        //_psys.GetParticles(p);
        //for(int i = 0; i < _psys.particleCount; ++i)
        //{
        //	p[i].velocity += vel * VelocityScaleFactor;
        //}
        //_psys.SetParticles(p);
        ////ParticleSystem.Particle p = _psys.GetParticles();
        ParticleSystem.Particle[] p = new ParticleSystem.Particle[_psys.particleCount];
        _psys.GetParticles(p);
        for (int i = 0; i < _psys.particleCount; ++i)
        {
            int j = (i/* + Random.Range(0, 1000)*/) % 8;
            float xdir = (float)((j & 1) != 0 ? 1.0 : -1.0);
            float ydir = (float)((j & 2) != 0 ? 1.0 : -1.0);
            float zdir = (float)((j & 4) != 0 ? 1.0 : -1.0);
            Vector3 v = new Vector3(xdir * Spectralizer._freqBands[j],
                                    ydir * Spectralizer._freqBands[j],
                                    zdir * Spectralizer._freqBands[j]);
            p[i].velocity = v * VelocityScaleFactor;
            p[i].startColor = new Color32((byte)((j >= 0 && j <= 1 ? (j+1)*0.5f : 0.0f) * Spectralizer._freqBands[j] * ColorScaleFactor * 255.0f),
                                          (byte)((j >= 2 && j <= 4 ? (j-1)*0.333f : 0.0f) * Spectralizer._freqBands[j] * ColorScaleFactor * 255.0f),
                                          (byte)((j >= 5 && j <= 7 ? (j-4)*0.333f : 0.0f) * Spectralizer._freqBands[j] * ColorScaleFactor * 255.0f), 255);
        }
        _psys.SetParticles(p);
    }

    //Vector3 ComputeVelocityBySound()
    //{
    //	Vector3 dir = new Vector3();

    //	for(int i = 0; i < 8; ++i)
    //	{
    //		float xdir = (float)((i & 1) != 0 ? 1.0 : -1.0);
    //		float ydir = (float)((i & 2) != 0 ? 1.0 : -1.0);
    //		float zdir = (float)((i & 4) != 0 ? 1.0 : -1.0);
    //		Vector3 v = new Vector3(xdir * Spectralizer._freqBands[i],
    //								ydir * Spectralizer._freqBands[i],
    //								zdir * Spectralizer._freqBands[i]);
    //		dir += v;
    //	}

    //	return dir;
    //}
}
