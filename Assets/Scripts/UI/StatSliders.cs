using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class StatSliders : MonoBehaviour
    {
        private Player player;

        [SerializeField] private Slider sliderHunger;
        [SerializeField] private Slider sliderEnergy;
        [SerializeField] private Slider sliderHealth;
        [SerializeField] private Slider sliderMood;
        [SerializeField] private Slider sliderStudy;
        [SerializeField] private Text moneyText;

        // Start is called before the first frame update
        void Start()
        {
            player = Player.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            sliderHunger.value = player.Hunger;
            sliderEnergy.value = player.Energy;
            sliderHealth.value = player.Health;
            sliderMood.value = player.Mood;
            sliderStudy.value = player.Study;
            moneyText.text = "₽ " + player.Money;
        }
    }
}
