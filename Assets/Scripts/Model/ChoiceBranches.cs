using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Button firstChoiceButton;
        private Button secondChoiceButton;
        private Button thirdChoiceButton;

        void Start()
        {
            Branches = BranchesFiller.FillBranches();

            messageText = Panel.GetComponentInChildren<Text>();
            //firstChoiceButton = transform.Find("Button").GetComponent<Button>();
            
        }

        void OnTriggerEnter()
        {
             messageText.text = Branches[Key][0].Message;
        }
    }
}
