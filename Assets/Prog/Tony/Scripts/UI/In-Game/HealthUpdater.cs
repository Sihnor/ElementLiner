using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthUpdater : MonoBehaviour
{
    public int health;
    public int numOfPotions;
    public Image[] potions;
    public Sprite fullPotion;
    public Sprite emptyHeart;

    private bool isInvincible = false;

    private void Start()
    {
        StartCoroutine(AutoHealCoroutine());
    }

    private void Update()
    {
        if (health > numOfPotions)
        {
            health = numOfPotions;
        }

        for (int i = 0; i < potions.Length; i++)
        {
            if (i < health)
            {
                potions[i].sprite = fullPotion;
            }
            else
            {
                potions[i].sprite = emptyHeart;
            }

            if (i < numOfPotions)
            {
                potions[i].enabled = true;
            }
            else
            {
                potions[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
            if (health == 0)
            {
                LoadScene(3); // Lädt die Szene mit dem Index 0, z.B. die Game Over Szene
            }
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    public void Heal(int amount)
    {
        health += amount;
        if (health > numOfPotions)
        {
            health = numOfPotions;
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(2);
        isInvincible = false;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator AutoHealCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(120); // Warte 2 Minuten
            Heal(1); // Heile 1 Leben
        }
    }
}
