using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public class BranchesFiller
    {
        private static Dictionary<string, List<ChoiceBranch>> branches;
        public static Dictionary<string, List<ChoiceBranch>> FillBranches()
        {
            var RTFlist = new List<ChoiceBranch>
            {
                new ChoiceBranch()
                {
                    Message = "Тебя спросили на паре математики, что будешь делать",
                    FirstChoice = new Choice(){Answer = "Дадада", AfterAnswer = "Ну вот песенка и спета"},
                    SecondChoice = new Choice(){Answer = "йоойой", AfterAnswer = "Бывает"},
                    ThirdChoice = new Choice(){Answer = "эээээээ", AfterAnswer = "Допрыгался мальчик"},
                }
            };

            branches = new Dictionary<string, List<ChoiceBranch>>();
            branches.Add("RTF", RTFlist);
            return branches;
        }
    }
}
