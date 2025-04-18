using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Player;

namespace SkillControllers
{
    public class SwordSkillController : MonoBehaviour
    {
        private Animator anim;
        private Rigidbody2D rb;
        private CircleCollider2D cd;
        private Player.Player player;

        private bool canRotate = true;
        private bool isReturning;

        private float freezeTimeDuration;
        private float returnSpeed = 12;

        [Header("Pierce info")]
        private float pierceAmount;

        [Header("Bounce info")]
        private float bounceSpeed;
        private bool isBouncing;
        private int bounceAmount;
        private List<Transform> enemyTarget;
        private int targetIndex;

        [Header("Spin info")]
        private float maxTravelDistance;
        private float spinDuration;
        private float spinTimer;
        private bool wasStopped;
        private bool isSpinning;

        private float hitTimer;
        private float hitCooldown;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
            cd = GetComponent<CircleCollider2D>();
        }

        private void DestroyMe()
        {
            Destroy(gameObject);
        }

        public void SetupSword(Vector2 _dir, float _gravityScale, Player.Player _player, float _freezeTimeDuration, float _returnSpeed)
        {
            player = _player;
            freezeTimeDuration = _freezeTimeDuration;
            returnSpeed = _returnSpeed;

            rb.velocity = _dir;
            rb.gravityScale = _gravityScale;

            if (pierceAmount <= 0)
                anim.SetBool("Rotation", true);

            Invoke("DestroyMe", 7);
        }

        public void SetupBounce(bool _isBouncing, int _amountOfBounces, float _bounceSpeed)
        {
            isBouncing = _isBouncing;
            bounceAmount = _amountOfBounces;
            bounceSpeed = _bounceSpeed;

            enemyTarget = new List<Transform>();
        }

        public void SetupPierce(int _pierceAmount)
        {
            pierceAmount = _pierceAmount;
        }

        public void SetupSpin(bool _isSpinning, float _maxTravelDistance, float _spinDuration, float _hitCooldown)
        {
            isSpinning = _isSpinning;
            maxTravelDistance = _maxTravelDistance;
            spinDuration = _spinDuration;
            hitCooldown = _hitCooldown;
        }

        public void ReturnSword()
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.parent = null;
            isReturning = true;
        }

        private void Update()
        {
            if (canRotate)
                transform.right = rb.velocity;

            if (isReturning)
                HandleReturn();

            BounceLogic();
            SpinLogic();
        }

        private void HandleReturn()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, returnSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, player.transform.position) < 1)
                player.CatchTheSword();
        }

        private void SpinLogic()
        {
            if (!isSpinning) return;

            if (Vector2.Distance(player.transform.position, transform.position) > maxTravelDistance && !wasStopped)
            {
                StopWhenSpinning();
            }

            if (wasStopped)
            {
                spinTimer -= Time.deltaTime;
                HandleSpinMovement();
                HandleSpinDamage();
            }
        }

        private void HandleSpinMovement()
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + 1, transform.position.y), 2.4f * Time.deltaTime);

            if (spinTimer < 0)
            {
                isReturning = true;
                isSpinning = false;
            }
        }

        private void HandleSpinDamage()
        {
            hitTimer -= Time.deltaTime;

            if (hitTimer < 0)
            {
                hitTimer = hitCooldown;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1);

                foreach (var hit in colliders)
                {
                    var enemy = hit.GetComponent<Enemy.Enemy>();
                    if (enemy != null)
                        SwordSkillDamage(enemy);
                }
            }
        }

        private void StopWhenSpinning()
        {
            wasStopped = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            spinTimer = spinDuration;
        }

        private void BounceLogic()
        {
            if (!isBouncing || enemyTarget.Count <= 0) return;

            transform.position = Vector2.MoveTowards(transform.position, enemyTarget[targetIndex].position, bounceSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, enemyTarget[targetIndex].position) < 0.1f)
            {
                SwordSkillDamage(enemyTarget[targetIndex].GetComponent<Enemy.Enemy>());

                targetIndex++;
                bounceAmount--;

                if (bounceAmount <= 0)
                {
                    isBouncing = false;
                    isReturning = true;
                }

                if (targetIndex >= enemyTarget.Count)
                    targetIndex = 0;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isReturning)
                return;

            var enemy = collision.GetComponent<Enemy.Enemy>();
            if (enemy != null)
            {
                SwordSkillDamage(enemy);
            }

            SetupTargetsForBounce(collision);
            StuckInto(collision);
        }

        private void SwordSkillDamage(Enemy.Enemy enemy)
        {
            enemy.Damage();
            enemy.StartCoroutine("FreezeTimerFor", freezeTimeDuration);
        }

        private void SetupTargetsForBounce(Collider2D collision)
        {
            if (collision.GetComponent<Enemy.Enemy>() == null || !isBouncing || enemyTarget.Count > 0) return;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10);
            foreach (var hit in colliders)
            {
                if (hit.GetComponent<Enemy.Enemy>() != null)
                    enemyTarget.Add(hit.transform);
            }
        }

        private void StuckInto(Collider2D collision)
        {
            if (pierceAmount > 0 && collision.GetComponent<Enemy.Enemy>() != null)
            {
                pierceAmount--;
                return;
            }

            if (isSpinning)
            {
                StopWhenSpinning();
                return;
            }

            canRotate = false;
            cd.enabled = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (isBouncing && enemyTarget.Count > 0)
                return;

            anim.SetBool("Rotation", false);
            transform.parent = collision.transform;
        }
    }
}
