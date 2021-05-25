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

        studWaveLevelText = StudWaveButton.GetComponentInChildren<Text>();
        studWaveXpSlider = StudWaveButton.GetComponentInChildren<Slider>();
        studWaveXpText = studWaveXpSlider.GetComponentInChildren<Text>();

        physicalLevelText = PhysicalButton.GetComponentInChildren<Text>();
        physicalXpSlider = PhysicalButton.GetComponentInChildren<Slider>();
        physicalXpText = physicalXpSlider.GetComponentInChildren<Text>();

        charismaLevelText = CharismaButton.GetComponentInChildren<Text>();
        charismaXpSlider = CharismaButton.GetComponentInChildren<Slider>();
        charismaXpText = charismaXpSlider.GetComponentInChildren<Text>();

        StaticPerkIncreaseInfoLayout = PerkIncreaseInfoLayout;
    }

    private Player player;
    private DateTimeInfo dateTimeInfo;

    public Button KnowledgeButton;
    private Text knowledgeLevelText;
    private Slider knowledgeXpSlider;
    private Text knowledgeXpText;

    public Button StudWaveButton;
    private Text studWaveLevelText;
    private Slider studWaveXpSlider;
    private Text studWaveXpText;

    public Button PhysicalButton;
    private Text physicalLevelText;
    private Slider physicalXpSlider;
    private Text physicalXpText;

    public Button CharismaButton;
    private Text charismaLevelText;
    private Slider charismaXpSlider;
    private Text charismaXpText;

    [SerializeField] private Text majorDateText;

    public GameObject PerkIncreaseInfoLayout;
    public static GameObject StaticPerkIncreaseInfoLayout;

    public void PerkRefresh()
    {
        knowledgeLevelText.text = player.KnowledgeLevel.ToString();
        knowledgeXpSlider.value = player.KnowledgeXP % 5;
        knowledgeXpText.text = player.KnowledgeXP % 5 + " / 5";

        studWaveLevelText.text = player.StudWaveLevel.ToString();
        studWaveXpSlider.value = player.StudWaveXP % 5;
        studWaveXpText.text = player.StudWaveXP % 5 + " / 5";

        physicalLevelText.text = player.PhysicalLevel.ToString();
        physicalXpSlider.value = player.PhysicalXP % 5;
        physicalXpText.text = player.PhysicalXP % 5 + " / 5";

        charismaLevelText.text = player.CharismaLevel.ToString();
        charismaXpSlider.value = player.CharismaXP % 5;
        charismaXpText.text = player.CharismaXP % 5 + " / 5";

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
