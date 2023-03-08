using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    private int maxHp = 3;
    [SerializeField] private bool canDamage;
    private float delayTime = 1f;
    private float time;

    public static PlayerHealth instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        hp = maxHp;
        time = delayTime;
    }

    private void Update()
    {
       CanGetDamage();
    }

    public void GetHeal()
    {
        if(hp < maxHp)
        {
            hp += 1;
            if(hp >= maxHp) { hp = maxHp; }
        }
    }

    public void GetDamage()
    {
        if (hp > 0)
        {
            Debug.Log(hp);
            hp -= 1;
            time = 0;
            if(hp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable") && canDamage)
        {
            GetDamage();
        }
    }
    private void CanGetDamage()
    {
        if(time < delayTime)
        {
            time += Time.deltaTime;
            canDamage = false;
        }
        else
        {
            canDamage =  true;
        }
    }
}
