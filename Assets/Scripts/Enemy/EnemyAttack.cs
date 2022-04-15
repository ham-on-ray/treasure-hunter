using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 4f;
    [SerializeField] GameObject _damagePanel;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        if (_damagePanel) { _damagePanel.SetActive(false); }
    }

    private void AttackHitEvent()
    {
        if (target == null) { return; }
        if (_damagePanel) StartCoroutine(ShowImageRoutine());
        target.ReduceHealth(damage);
    }

    IEnumerator ShowImageRoutine()
    {
        _damagePanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _damagePanel.SetActive(false);

    }
}
