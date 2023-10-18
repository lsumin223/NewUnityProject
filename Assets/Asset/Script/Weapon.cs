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


    private bool isGas;
    private bool isMes;
    private float timer;
    private float mesTimer;
    private PlayerController player;



    void Awake()
    {
        player = GameManager.instance.player;
        isGas = false;
        isMes = false;

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

            case 2:
                if (!isGas)
                {
                    StartCoroutine(SpawnAttacks(count));
                    isGas = true;
                }
                timer += Time.deltaTime;
                if (timer >= speed)
                {
                    StartCoroutine(SpawnAttacks(count));
                    timer = 0;
                }
                break;
            case 3:
                if (!isMes)
                {
                    Mes();
                    isMes = true;
                }
                mesTimer += Time.deltaTime;
                if (mesTimer >= speed)
                {
                    Debug.Log("½ÇÇà");
                    Mes();
                    mesTimer = 0;
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
        player.BroadcastMessage("ApplyPassive", SendMessageOptions.DontRequireReceiver);
    }


    public void Init(ItemData data)
    {

        name = "Weapon" + data.id;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        id = data.id;
        damage = data.baseDamage;
        count = data.baseCount;

        for (int index = 0; index < GameManager.instance.pool.prefabs.Length; index++)
        {
            if (data.projectile == GameManager.instance.pool.prefabs[index])
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
            case 2:
                speed = 15f;
                break;
            case 3:
                speed = 20f;
                break;
            default:
                break;

        }

        player.BroadcastMessage("ApplyPassive", SendMessageOptions.DontRequireReceiver);
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
        AudioManager.instance.Playsfx(AudioManager.Sfx.bullet1);

    }

    IEnumerator SpawnAttacks(int count)
    {

        for (int index = 0; index < count; index++)
        {
            Transform attack = GameManager.instance.pool.Get(prefabId).transform;
            attack.parent = transform;

            attack.localPosition = Vector3.zero;
            attack.localRotation = Quaternion.identity;

            Debug.Log(player.inputVec.x);
            Debug.Log(player.inputVec.y);

            if (player.inputVec.x == 0.0f && player.inputVec.y == 0.0f)
            {

                if (!player.GetComponent<SpriteRenderer>().flipX)
                {
                    attack.position += new Vector3(3, 0, 0);
                    attack.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (player.GetComponent<SpriteRenderer>().flipX)
                {
                    attack.position += new Vector3(-3, 0, 0);
                    attack.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else
            {
                attack.position += AdjustAttackXPosition(attack, player.inputVec);
                attack.position += AdjustAttackYPosition(attack, player.inputVec);
            }

            attack.GetComponent<Attack>().Init(damage, -100, Vector3.zero);
            AudioManager.instance.Playsfx(AudioManager.Sfx.bubble);


            yield return StartCoroutine(WaitTime(attack));
            attack.GetComponent<SpriteRenderer>().flipX = false;
            attack.GetComponent<SpriteRenderer>().flipY = false;
        }

    }
    private Vector3 AdjustAttackXPosition(Transform attack, Vector3 direction)
    {
        Vector3 attackPos = new Vector3(0, 0, 0);

        if (direction.x > 0f)
        {
            attackPos += new Vector3(3, 0, 0);
            attack.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (direction.x < 0f)
        {
            attackPos += new Vector3(-3, 0, 0);
            attack.GetComponent<SpriteRenderer>().flipX = true;
        }

        return attackPos;
    }

    private Vector3 AdjustAttackYPosition(Transform attack, Vector3 direction)
    {
        Vector3 attackPos = new Vector3(0, 0, 0);

        if (direction.y > 0f)
        {
            attackPos += new Vector3(0, 3, 0);
            attack.GetComponent<SpriteRenderer>().flipY = false;
        }
        else if (direction.y < 0f)
        {
            attackPos += new Vector3(0, -3, 0);
            attack.GetComponent<SpriteRenderer>().flipY = true;
        }

        return attackPos;
    }


    private void Mes()
    {
        for (int index = 0; index < 5; index++)
        {
            Transform attack = GameManager.instance.pool.Get(prefabId).transform;
            

            attack.parent = transform;

            attack.transform.position = transform.position;
            attack.transform.rotation = Quaternion.identity;

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * index / 5), Mathf.Sin(Mathf.PI * 2 * index / 5));

            Vector3 rotVec = Vector3.forward * 360 * index / 5;
            attack.Rotate(rotVec);
            attack.Translate(attack.up * 2.5f, Space.World);

            attack.GetComponent<Rigidbody2D>().angularVelocity = 720f;
            attack.GetComponent<Attack>().Init(damage, count, dirVec);

        }
    }

    IEnumerator WaitTime(Transform attack)
    {

        yield return new WaitForSeconds(0.5f);
        attack.gameObject.SetActive(false);
    }

}