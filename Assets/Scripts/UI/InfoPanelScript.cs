using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        knowledgeLevelText = KnowledgeButton.GetComponentInChildren<Text>();
        knowledgeXpSlider = KnowledgeButton.GetComponentInChildren<Slider>();
        knowledgeXpText = knowledgeXpSlider.GetComponentInChildren<Text>();

        StaticPerkIncreaseInfoLayout = PerkIncreaseInfoLayout;
    }

    public Button KnowledgeButton;
    private Text knowledgeLevelText;
    private Slider knowledgeXpSlider;
    private Text knowledgeXpText;

    public GameObject PerkIncreaseInfoLayout;
    public static GameObject StaticPerkIncreaseInfoLayout;

    public void PerkRefresh()
    {
        knowledgeLevelText.text = Player.KnowledgeLevel.ToString();
        knowledgeXpSlider.value = Player.KnowledgeXP;
        knowledgeXpText.text = Player.KnowledgeXP % 5 + " / 5";
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
