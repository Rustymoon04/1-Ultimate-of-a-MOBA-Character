using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LucianUlt : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunEnd;
    public Transform gunEnd2;
    public float fireRate = 0.1f;
    public float UltimateDuration = 2f;

    private bool isUltimateActive = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isUltimateActive)
        {
            StartCoroutine(FireUltimate());
        }
    }

    IEnumerator FireUltimate()
    {
        isUltimateActive = true;
        float endTime = Time.time + UltimateDuration;

        while (Time.time < endTime)
        {
            FireBullet();
            yield return new WaitForSeconds(fireRate);
        }
        isUltimateActive = false;
    }
    void FireBullet()
    {
        Instantiate(bulletPrefab, gunEnd.position, gunEnd.rotation);
        Instantiate(bulletPrefab, gunEnd2.position, gunEnd2.rotation);

    }
}
