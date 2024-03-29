using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveWeapons : MonoBehaviour, IArmas
{
    [SerializeField] GameObject weaponsInCharacter;
    [SerializeField] GameObject weaponsCollectible;

    public float rotationSpeed = 25f; // Velocidad de rotación en grados por segundo

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider col)
    {
        weaponsInCharacter.SetActive(true);
        weaponsCollectible.SetActive(false);
    }
}
