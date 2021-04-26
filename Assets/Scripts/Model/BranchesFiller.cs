using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Experimental.AI;

namespace Assets.Scripts.Model
{
    public class BranchesFiller
    {
        private static Dictionary<string, List<ChoiceBranch>> branches;
        public static Dictionary<string, List<ChoiceBranch>> FillBranches()
        {
            var RTFlist = new List<ChoiceBranch>
            {
                new ChoiceBranch
                {
                    Message = "Прилетел ты наконец то на математику, думал отсидишься, но не тут то было. Тебя вызвали к доске, задание вроде не особо тяжелое, твои действия:",
                    FirstChoice = new Choice
                    {
                        Answer = "Сыграть честно, то есть попробовать ответить",
                        SuccesAfterAnswer = "Вышел и филигранно порешал этот пример без шансов",
                        FailAfterAnswer = "Ну ты постоял у доски, потупил и ушел, бывает, хотя бы попытался",
                        CheckSucces = () => Player.KnowledgeLevel >= 1,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                Player.KnowledgeXP += 2;
                                Player.Study += 5;
                                Player.Mood += 10;
                                Player.Energy -= 10;
                            }

                            else
                            { 
                                Player.KnowledgeXP += 7;
                                Player.Study -= 5;
                                Player.Mood -= 5;
                                Player.Energy -= 15;
                            }
                        }
                    },
                    SecondChoice = new Choice {Answer = "йоойой"},
                    ThirdChoice = new Choice {Answer = "эээээээ"}
                },
                //new ChoiceBranch
                //{
                //    Message = "asdf",
                //    FirstChoice = new Choice
                //    {
                //        Answer = "SDF",
                //        SuccesAfterAnswer = "adrfgg",
                //        FailAfterAnswer = "SDF",
                //        CheckSucces = () => Player.CharismaLevel >= 2,
                //        PlayerInteract = (checkSucces) =>
                //        {
                //            if (checkSucces)
                //            {
                //                Player.Hunger += 123;
                //            }
                //            else
                //            {
                                
                //            }
                //        }
                //    }
                //}
            };

            var HOMElist = new List<ChoiceBranch>
            {
                new ChoiceBranch
                {
                    Message = "Салам пополам",
                    FirstChoice = new Choice {Answer = "SDF"},
                    SecondChoice = new Choice {Answer = "SFDSDF"},
                    ThirdChoice = new Choice {Answer = "QWER"}
                }
            };

            branches = new Dictionary<string, List<ChoiceBranch>>();
            branches.Add("RTF", RTFlist);
            branches.Add("HOME", HOMElist);
            return branches;
        }
    }
}
