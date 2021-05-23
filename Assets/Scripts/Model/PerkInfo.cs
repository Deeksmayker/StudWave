using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Model
{
    public class PerkInfo : MonoBehaviour
    {
        private Dictionary<string, string> infoDictionary;

        [SerializeField] private Text perkInfoText;

        void Start()
        {
            infoDictionary = new Dictionary<string, string>();

            FillInfoDictionary();
        }

        private void FillInfoDictionary()
        {
            var knowledge = "Энциклопедические знания - являются общими познаниями из многих областей, вроде математики, физики, истории и т.д. \n Прокачивается, например, при попытках ответить на паре.";
            var studWave = "Студенческая волна - ";
            
            infoDictionary.Add("Энциклопедические знания", knowledge);
            infoDictionary.Add("Студенческая волна", studWave);
        }

        public void GetPerkInfo(string perkName)
        {
            perkInfoText.text = infoDictionary[perkName];
        }
    }
}
