using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InfoPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        dateTimeInfo = DateTimeInfo.Instance;

        knowledgeLevelText = KnowledgeButton.GetComponentInChildren<Text>();
        knowledgeXpSlider = KnowledgeButton.GetComponentInChildren<Slider>();
        knowledgeXpText = knowledgeXpSlider.GetComponentInChildren<Text>();

        StaticPerkIncreaseInfoLayout = PerkIncreaseInfoLayout;
    }

    private Player player;
    private DateTimeInfo dateTimeInfo;

    public Button KnowledgeButton;
    private Text knowledgeLevelText;
    private Slider knowledgeXpSlider;
    private Text knowledgeXpText;

    [SerializeField] private Text majorDateText;

    public GameObject PerkIncreaseInfoLayout;
    public static GameObject StaticPerkIncreaseInfoLayout;

    public void PerkRefresh()
    {
        knowledgeLevelText.text = player.KnowledgeLevel.ToString();
        knowledgeXpSlider.value = player.KnowledgeXP;
        knowledgeXpText.text = player.KnowledgeXP % 5 + " / 5";

        majorDateText.text = String.Format("{0} год. {1} курс", dateTimeInfo.Year, dateTimeInfo.Course);
    }

    async public static void PerkIncreaseInfo(string perkName, int newPerkLevel)
    {
        var text = StaticPerkIncreaseInfoLayout.GetComponentInChildren<Text>();
        text.text = "Перк " + perkName + " улучшился, теперь он равен " + newPerkLevel;
        StaticPerkIncreaseInfoLayout.SetActive(true);

        var sleep = new Task(() => Thread.Sleep(5000));
        sleep.Start();
        await sleep;
        StaticPerkIncreaseInfoLayout.SetActive(false);
    }
}
