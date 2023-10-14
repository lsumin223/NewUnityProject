using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    private float timer;
    private PlayerController player;

    void Awake()
    {
        player = GameManager.instance.player;

    }
    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            case 1:
                timer += Time.deltaTime;

                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }

                break;
            default:
                
                break;
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Batch();
        }
    }


    public void Init(ItemData data)
    {

        name = "Weapon" + data.id;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        id = data.id;
        damage = data.baseDamage;
        count = data.baseCount;

        for(int index = 0; index < GameManager.instance.pool.prefabs.Length; index++)
        {
            if(data.projectile == GameManager.instance.pool.prefabs[index])
            {
                prefabId = index;
                break;
            }
        }
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            case 1:
                speed = 0.3f;
                break;
            
        }
    }

    private void Batch()
        {
            for (int index = 0; index < count; index++)
            {
                Transform attack;

                if (index < transform.childCount)
                {
                    attack = transform.GetChild(index);
                }
                else
                {
                    attack = GameManager.instance.pool.Get(prefabId).transform;
                }

                attack.parent = transform;

                attack.localPosition = Vector3.zero;
                attack.localRotation = Quaternion.identity;

                Vector3 rotVec = Vector3.forward * 360 * index / count;
                attack.Rotate(rotVec);
                attack.Translate(attack.up * 2.5f, Space.World);
                attack.GetComponent<Attack>().Init(damage, -100, Vector3.zero);

        }
        }

    private void Fire()
    {
        if (!player.scan.nearestTarget)
            return;

        Vector3 targetPos = player.scan.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform attack = GameManager.instance.pool.Get(prefabId).transform;
        attack.position = transform.position;
        attack.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        attack.GetComponent<Attack>().Init(damage, count, dir);

        AudioManager.instance.Playsfx(AudioManager.Sfx.bullet);
    }
}
