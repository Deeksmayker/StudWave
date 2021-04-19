using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Model
{
    public class ChoiceBranches : MonoBehaviour
    {
        public ChoiceBranches(GameObject panel, string key)
        {
            Panel = panel;
            Key = key;
        }

        public Dictionary<string, List<ChoiceBranch>> Branches;
        public string Key;

        public GameObject Panel;


        private Text messageText;
        public Button FirstChoiceButton;
        public Button SecondChoiceButton;
        public Button ThirdChoiceButton;

        private Text firstText;
        private Text secondText;
        private Text thirdText;

        void Start()
        {
            Branches = BranchesFiller.FillBranches();

            messageText = Panel.GetComponentInChildren<Text>();
            firstText = FirstChoiceButton.GetComponentInChildren<Text>();
            secondText = SecondChoiceButton.GetComponentInChildren<Text>();
            thirdText = ThirdChoiceButton.GetComponentInChildren<Text>();
        }

        void OnTriggerEnter()
        {
             messageText.text = Branches[Key][0].Message;
             firstText.text = Branches[Key][0].FirstChoice.Answer;
             secondText.text = Branches[Key][0].SecondChoice.Answer;
             thirdText.text = Branches[Key][0].ThirdChoice.Answer;
             ShowClosePanel.LayoutInteract(Panel);
        }
    }
}
