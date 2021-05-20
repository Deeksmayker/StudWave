using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts.Model
{
    public class ChoiceBranches : MonoBehaviour
    {
        public ChoiceBranches(GameObject choicePanel, string key)
        {
            ChoicePanel = choicePanel;
            Key = key;
        }

        public Dictionary<string, List<ChoiceBranch>> Branches;
        public string Key;

        public GameObject ChoicePanel;
        public GameObject AfterChoicePanel;

        private Text messageText;
        public Button FirstChoiceButton;
        public Button SecondChoiceButton;
        public Button ThirdChoiceButton;

        private Text firstText;
        private Text secondText;
        private Text thirdText;

        private Text afterChoiceText;

        private Random random;

        private ChoiceBranch branch;

        void Start()
        {
            random = new Random();

            Branches = BranchesFiller.FillBranches();

            messageText = ChoicePanel.GetComponentInChildren<Text>();
            firstText = FirstChoiceButton.GetComponentInChildren<Text>();
            secondText = SecondChoiceButton.GetComponentInChildren<Text>();
            thirdText = ThirdChoiceButton.GetComponentInChildren<Text>();

            afterChoiceText = AfterChoicePanel.GetComponentInChildren<Text>();
            FirstChoiceButton = FirstChoiceButton.GetComponent<Button>();

            branch = Branches[Key][random.Next(Count)];
        }

        void OnTriggerEnter()
        {
            if (Key == "RTF")
                DateTimeInfo.Instance.IsWentToPairs = true;
           
            messageText.text = branch.Message;
            firstText.text = branch.FirstChoice.Answer;
            secondText.text = branch.SecondChoice.Answer;
            thirdText.text = branch.ThirdChoice.Answer;
            ShowClosePanel.LayoutInteract(ChoicePanel);
        }

        public void AfterChoice(int buttonIndex)
        {
            switch (buttonIndex)
            {
                case 1:
                    afterChoiceText.text = branch.FirstChoice.CheckSucces()
                        ? branch.FirstChoice.SuccesAfterAnswer
                        : branch.FirstChoice.FailAfterAnswer;
                    branch.FirstChoice.PlayerInteract(branch.FirstChoice.CheckSucces());
                    break;
                case 2:
                    afterChoiceText.text = branch.SecondChoice.CheckSucces()
                        ? branch.SecondChoice.SuccesAfterAnswer
                        : branch.SecondChoice.FailAfterAnswer;
                    branch.SecondChoice.PlayerInteract(branch.SecondChoice.CheckSucces());
                    break;
                case 3:
                    afterChoiceText.text = branch.ThirdChoice.CheckSucces()
                        ? branch.ThirdChoice.SuccesAfterAnswer
                        : branch.ThirdChoice.FailAfterAnswer;
                    branch.ThirdChoice.PlayerInteract(branch.ThirdChoice.CheckSucces());
                    break;
            }
            ShowClosePanel.LayoutInteract(ChoicePanel);
            ShowClosePanel.LayoutInteract(AfterChoicePanel);
        }

        public int Count
        {
            get => Branches[Key].Count;
        }
    }
}
