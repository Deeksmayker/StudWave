using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Choice
    {
        public string Answer;
        public string SuccesAfterAnswer;
        public string FailAfterAnswer;

        public Func<bool> CheckSucces;
        public Action<bool> PlayerInteract;
    }
}
