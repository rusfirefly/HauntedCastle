using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


[Serializable]
public struct ScareTexture2D
{
    [field:SerializeField] public Texture FaceTexture2D { get; private set; }
    [field: SerializeField] public Texture BackTexture2D { get; private set; }
}

public class Scare : MonoBehaviour
{
    [SerializeField] private List<ScareTexture2D> _scareTexture2D;
    [SerializeField] private MeshRenderer _faceMeshRenderer;
    [SerializeField] private MeshRenderer _backMeshRenderer;
    [SerializeField] private ScareView _scareView; 
    
    private Material _faceMaterial;
    private Material _backMaterial;
    private Random _random;
    private SoundHandler _sound;
    private bool _isShowScare;

    private void Awake()
    {
        _random = new Random();
        _faceMaterial = _faceMeshRenderer.material;
        _backMaterial = _backMeshRenderer.material;

        SelectRandomScare();

       _scareView.Hide();
        _sound = GetComponent<SoundHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isShowScare) return;

       _scareView.Show();
       _sound.Play();

        _isShowScare = true;
    }

    private void SelectRandomScare()
    {
        if(_scareTexture2D.Count > 0)
        {
            int index = _random.Next(0, _scareTexture2D.Count + 1);
           
            Texture faceTexture = _scareTexture2D[index].FaceTexture2D;
            Texture backTexture = _scareTexture2D[index].BackTexture2D;
            
            _faceMaterial.SetTexture("_MainTex", faceTexture);
            _backMaterial.SetTexture("_MainTex", backTexture);

        }
    }
}
