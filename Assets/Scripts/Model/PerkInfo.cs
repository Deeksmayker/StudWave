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
            var knowledge = "Энциклопедические знания - являются общими познаниями из многих областей, вроде математики, физики, истории и так далее. \n Прокачивается, например, при попытках ответить на паре.";
            var studWave = "Студенческая волна - показывает общее социально положение персонажа, как к нему относятся люди и тому подобное.\r\nПрокачивается при взаимодействие с окружающими.";
            var physical = "Физическая подготовка - является мерой общих физических способностей персонажа, обобщенная сила, ловкость и так далее.\r\nПрокачивается занятиями спортом или при любом применении силы.";
            var charisma = "Харизма - как понятно из названия, показывает харизму персонажа, его умение выкрутиться из ситуации, заговорить собеседника и тому подобное.\r\nПрокачивается при использовании харизмы в общении или в действиях.";
            
            infoDictionary.Add("Энциклопедические знания", knowledge);
            infoDictionary.Add("Студенческая волна", studWave);
            infoDictionary.Add("Физическая подготовка", physical);
            infoDictionary.Add("Харизма", charisma);
        }

        public void GetPerkInfo(string perkName)
        {
            perkInfoText.text = infoDictionary[perkName];
        }
    }
}
