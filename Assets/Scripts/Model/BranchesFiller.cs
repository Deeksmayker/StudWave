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
                    FirstChoice = "Каво?",
                    SecondChoice = "Шо?",
                    ThirdChoice = "эээ"
                }
            };

            branches = new Dictionary<string, List<ChoiceBranch>>();
            branches.Add("RTF", RTFlist);
            return branches;
        }
    }
}
