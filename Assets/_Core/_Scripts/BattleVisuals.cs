using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleVisuals : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI levelLabel;

    private int _currentHealth;
    private int _maxHealth;
    private int _level;

    private Animator anim;

    private const string LEVEL_ABBRIV = "Lvl: ";

    private const string IS_ATTACK_PARAM = "IsAttack";
    private const string IS_HIT_PARAM = "IsHit";
    private const string IS_DEAD_PARAM = "IsDead";
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void SetStartingValues(int currentHealth, int maxHleath,int level)
    {
        this._currentHealth = currentHealth;
        this._maxHealth = maxHleath;
        this._level = level;
        UpdateLevelLabel();
        UpdateHealthBar();
    }
    
    private void UpdateLevelLabel()
    {
        this.levelLabel.text = LEVEL_ABBRIV + this._level.ToString(); 
    }

    private void UpdateHealthBar()
    {
        this.healthBar.maxValue = this._maxHealth;
        this.healthBar.value = this._currentHealth;
    }

    public void ChangeHealth(int newHealth)
    {
        this._currentHealth = newHealth;

        if (this._currentHealth <= 0)
        {
            PlayDeathAnimation();
            Destroy(gameObject, 2f);
        }

        UpdateHealthBar();
    }

    public void PlayAttackAnimation()
    {
        anim.SetTrigger(IS_ATTACK_PARAM);
    }

    public void PlayHitAnimation()
    {
        anim.SetTrigger(IS_HIT_PARAM);
    }

    public void PlayDeathAnimation()
    {
        anim.SetTrigger(IS_DEAD_PARAM);

    }

}
