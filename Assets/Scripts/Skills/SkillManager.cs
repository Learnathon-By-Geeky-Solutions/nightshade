using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Skills
{
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager instance;


        public DashSkill dash { get; private set; }
        public CloneSkill clone { get; private set; }
        public SwordSkill sword { get; private set; }
        public BlackholeSkill blackhole { get; private set; }
        public CrystalSkill crystal { get; private set; }

        private void Awake()
        {
            if (instance != null)
                Destroy(instance.gameObject);
            else
                instance = this;
        }

        private void Start()
        {
            dash = GetComponent<DashSkill>();
            clone = GetComponent<CloneSkill>();
            sword = GetComponent<SwordSkill>();
            blackhole = GetComponent<BlackholeSkill>();
            crystal = GetComponent<CrystalSkill>();
        }
    }
}