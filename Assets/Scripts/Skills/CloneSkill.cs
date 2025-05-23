using MyGameNamespace.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
namespace MyGameNamespace.Skills
{
    public class CloneSkill : Skill
    {


        [Header("Clone info")]
        [SerializeField] private GameObject clonePrefab;
        [SerializeField] private float cloneDuration;
        [Space]
        [SerializeField] private bool canAttack;

        [SerializeField] private bool creatCloneOnDashStart;
        [SerializeField] private bool createCloneOnDashOver;
        [SerializeField] private bool canCreateCloneOnCounterAttack;
        [Header("Clone can duplicate")]
        [SerializeField] private bool canDuplicateClone;
        [SerializeField] private float chanceToDuplicate;
        [Header("Crystal instead of clone")]
        public bool crystalInseadOfClone;


        public void CreateClone(Transform _clonePosition, Vector3 _offset)
        {
            if (crystalInseadOfClone)
            {
                SkillManager.instance.crystal.CreateCrystal();
                return;
            }

            GameObject newClone = Instantiate(clonePrefab);

            newClone.GetComponent<CloneSkillController>().
                SetupClone(_clonePosition, cloneDuration, canAttack, _offset, FindClosestEnemy(newClone.transform), canDuplicateClone, chanceToDuplicate, player);
        }

        public void CreateCloneOnDashStart()
        {
            if (creatCloneOnDashStart)
                CreateClone(player.transform, Vector3.zero);
        }

        public void CreateCloneOnDashOver()
        {
            if (createCloneOnDashOver)
                CreateClone(player.transform, Vector3.zero);
        }

        public void CreateCloneOnCounterAttack(Transform _enemyTransform)
        {
            if (canCreateCloneOnCounterAttack)
                StartCoroutine(CreateCloneWithDelay(_enemyTransform, new Vector3(2 * player.facingDir, 0)));
        }

        private IEnumerator CreateCloneWithDelay(Transform _trasnform, Vector3 _offset)
        {
            yield return new WaitForSeconds(.4f);
            CreateClone(_trasnform, _offset);
        }
    }
}