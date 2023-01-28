using UnityEngine;

namespace AutumnForest
{
    public class FlipperByTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private bool asPlayer;

        private void Start()
        {
            if (asPlayer)
                target = GameObject.FindGameObjectWithTag(TagHelper.PlayerTag).transform;
        }

        private void Update() => Flip();
        private void Flip()
        {
            if (target.position.x < transform.position.x && transform.localScale.x == -1)
                transform.localScale = new Vector3(1, 1, 1);
            else if (target.position.x > transform.position.x && transform.localScale.x == 1)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}