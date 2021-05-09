using System.Collections.Generic;

namespace Assets.Scripts.Model
{
    public class BranchesFiller
    {
        private static Dictionary<string, List<ChoiceBranch>> branches;
        private static DateTimeInfo dateTimeInfo = DateTimeInfo.Instance;
        private static Player player = Player.Instance;

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
                        CheckSucces = () => player.KnowledgeLevel >= 1,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.KnowledgeXP += 2;
                                player.Study += 5;
                                player.Mood += 10;
                                player.Energy -= 10;
                            }

                            else
                            {
                                player.KnowledgeXP += 7;
                                player.Study -= 5;
                                player.Mood -= 5;
                                player.Energy -= 15;
                            }

                            dateTimeInfo.Hour += 6; //Типа на парах он сидел шесть часов. Таже можно отельно минуты крутить, в общем можешь посмотреть в этом классе что там еще есть.
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
