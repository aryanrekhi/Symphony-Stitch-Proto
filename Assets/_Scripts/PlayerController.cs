using Photon.Pun;
using UnityEngine;

namespace Assets._Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 5f;

        private PhotonView _photonView;
        private Health _health;

        private void Start()
        {
            _health = FindObjectOfType<Health>();
            _photonView = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (!_photonView.IsMine) return;
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var direction = new Vector3(horizontal, 0, vertical).normalized;
            _controller.Move((_speed * Time.deltaTime) * direction);
        }

        public void TakeDamage()
        {
            if (!_photonView.IsMine) return;

            _health.TakeDamage();
        }
    }
}