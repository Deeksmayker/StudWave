using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Model
{
    public class TimeFlow : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Rigidbody rb;
        private DateTimeInfo dateTimeInfo;

        void Start()
        {
            rb = player.GetComponent<Rigidbody>();
            dateTimeInfo = DateTimeInfo.Instance;
        }

        void Update()
        {
            Timer();
        }

        private void Timer()
        {
            if (!rb.IsSleeping())
            {
                dateTimeInfo.MinuteF += Time.deltaTime * 10;
            }
        }
    }
}
