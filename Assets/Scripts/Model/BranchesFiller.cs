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
                // вызвали к доске на паре
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
                                player.Hunger -= 25;
                            }

                            else
                            {
                                player.KnowledgeXP += 3;
                                player.Study -= 5;
                                player.Mood -= 5;
                                player.Energy -= 15;
                                player.Hunger -= 25;
                            }

                            dateTimeInfo.Hour += 6; //Типа на парах он сидел шесть часов. Таже можно отельно минуты крутить, в общем можешь посмотреть в этом классе что там еще есть.
                        }                                           // Кубик добавляет перки (за рекламу)
                    },
                    SecondChoice = new Choice
                    {
                        Answer = "Попробовать отшутиться, и не пойти к доске.",
                        SuccesAfterAnswer = "Учитель сказал тебе, что на первый раз тебя прощает.",
                        FailAfterAnswer = "Кринжанул по полной, на тебя странно косились до конца пары",
                        CheckSucces = () => player.StudWaveLevel >= 2 || player.CharismaLevel >= 2,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.StudWaveXP += 2;
                                player.Mood += 15;
                                player.Energy -= 10;
                                player.CharismaXP += 2;
                                player.Hunger -= 25;
                            }

                            else
                            {
                                player.StudWaveXP += 1;
                                player.Mood -= 20;
                                player.Energy -= 10;
                                player.CharismaXP += 1;
                                player.Hunger -= 25;
                            }

                            dateTimeInfo.Hour += 6;
                        }

                    },
                    ThirdChoice = new Choice
                    {
                        Answer = "Признаться в том, что ты не знаешь ответа, сказать о том, что подготовишься не следующем занятии",
                        SuccesAfterAnswer = "Учитель оценил твою смелость и дал тебе задание на следующую пару",
                        FailAfterAnswer = "Учитель сказал,что не знать решения на такую простую задачу позор, и поставил тебе 0 баллов",
                        CheckSucces = () => player.CharismaLevel >= 2,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.CharismaXP += 2;
                                player.Mood += 10;
                                player.Energy -= 10;
                                player.Hunger -= 25;
                            }

                            else
                            {
                                player.CharismaXP += 1;
                                player.Mood -= 15;
                                player.Energy -= 10;
                                player.Hunger -= 25;
                            }
                            dateTimeInfo.Hour += 6;
                        }

                    }
                    
                },
                // стало плохо на паре
                new ChoiceBranch()
                {
                    Message = "Тебе стало плохо на паре, что будешь делать?",
                    FirstChoice = new Choice()
                    {
                        Answer = "Попросить у учителя выйти в туалет",
                        SuccesAfterAnswer = "Тебя отпустили и ты посидел в туалете до конца пары, тебе полегчало",
                        FailAfterAnswer = "Учитель сказал, что ты и так не учишься и осталось до конца пары немного, потерпи",
                        CheckSucces = () => player.StudWaveLevel >= 1,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.StudWaveXP -= 1;
                                player.Health += 5;
                                player.Mood += 5;
                                player.Study -= 10;
                                player.Hunger -= 15;
                                player.Energy -= 10;
                            }
                            else
                            {
                                player.StudWaveXP -= 1;
                                player.Health -= 15;
                                player.Mood -= 10;
                                player.Energy -= 10;
                                player.Study += 10;
                                player.Hunger -= 15;
                            }
                            dateTimeInfo.Hour += 3;
                        }
                    },
                    SecondChoice = new Choice()
                    {
                        Answer = "Молча выйти в туалет",
                        SuccesAfterAnswer = "Ты вышел в туалет и просидел там до конца пары, тебе полегчало",
                        CheckSucces = () => true,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.StudWaveXP -= 1;
                                player.Health += 5;
                                player.Mood += 5;
                                player.Study -= 10;
                                player.Hunger -= 15;
                                player.Energy -= 10;
                            }

                            dateTimeInfo.Hour += 3;
                        }
                    },
                    ThirdChoice = new Choice()
                    {
                        Answer = "Попросить платок у соседа и остаться на паре",
                        SuccesAfterAnswer = "Тебе полегчало",
                        FailAfterAnswer = "Тебе стало хуже и учитель сказал тебе выйти",
                        CheckSucces = () => player.StudWaveLevel >= 2,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.StudWaveXP += 1;
                                player.Health += 5;
                                player.Mood += 5;
                                player.Study -= 10;
                                player.Hunger -= 15;
                                player.Energy -= 10;
                            }
                            else
                            {
                                player.StudWaveXP -= 1;
                                player.Health -= 15;
                                player.Mood -= 10;
                                player.Energy -= 10;
                                player.Study += 10;
                                player.Hunger -= 15;
                            }
                            dateTimeInfo.Hour += 3;
                        }
                    }
                },
                // студенческий забыл
                new ChoiceBranch()
                {
                    Message = "Забыл студенческий дома. Твои действия?",
                    FirstChoice = new Choice()
                    {
                        Answer = "Попросить пропустить тебя в первый и последний раз",
                        SuccesAfterAnswer = "Тебя пропустили,но чтобы больше такого не было.",
                        FailAfterAnswer = "Ты не убедил вахтершу и тебя отправили домой.",
                        CheckSucces = () => player.CharismaLevel >= 3,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.CharismaXP += 2;
                                player.Mood += 10;
                                player.StudWaveXP += 2;
                                player.Hunger -= 5;
                                dateTimeInfo.Hour += 5;
                            }
                            else
                            {
                                player.CharismaXP += 1;
                                player.Mood -= 10;
                                player.StudWaveXP += 1;
                                player.Study -= 15;
                                player.Hunger -= 10;
                                dateTimeInfo.Hour += 3;
                            }
                        }
                    },
                    SecondChoice = new Choice()
                    {
                        Answer = "Пойти домой",
                        SuccesAfterAnswer = "Ты пошел домой",
                        CheckSucces = () => true,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Mood -= 15;
                                player.Study -= 15;
                                player.Energy -= 5;
                                player.Hunger -= 5;
                            }

                            dateTimeInfo.Hour += 1;
                        }
                    },
                    ThirdChoice = new Choice()
                    {
                        Answer = "Попробовать незаметоно пройти(затисаться в толпе)",
                        SuccesAfterAnswer = "Тебе помогли друзья, прикрыв тебя.",
                        FailAfterAnswer = "Тебя заметили и выгнали",
                        CheckSucces = () => player.StudWaveLevel >= 3,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Mood += 10;
                                player.StudWaveXP += 2;
                                player.Hunger -= 10;
                                player.Energy -= 10;
                                dateTimeInfo.Hour += 3;
                            }
                            else
                            {
                                player.Mood -= 10;
                                player.StudWaveXP += 1;
                                player.Hunger -= 5;
                                player.Energy -= 5;
                                dateTimeInfo.Hour += 1;
                            }
                        }
                    }
                } 
            };

            var HOMElist = new List<ChoiceBranch>
            {
                // комендша у общаги
                new ChoiceBranch()
                {
                    Message = "После выхода из общажития к тебе подошла комендша и говорит, что на вашем этаже кто-то разбросал мусор, и что это был ты.",
                    FirstChoice = new Choice()
                    {
                        Answer = "Спокойно сказать, что это был не ты, и привести аргументы.",
                        SuccesAfterAnswer = "Она тебе поверила и отпустила, пойдя искать виновного",
                        FailAfterAnswer = "Тебе не поверили и заставили идти прямо сейчас убираться на этаже",
                        CheckSucces = () => player.CharismaLevel >= 2,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.CharismaXP += 3;
                                player.Mood += 10;
                                player.Energy -= 5;
                                player.Hunger -= 5;
                                dateTimeInfo.Hour += 1;
                            }
                            else
                            {
                                player.CharismaXP += 2;
                                player.Mood -= 15;
                                player.Energy -= 15;
                                player.Hunger -= 10;
                                dateTimeInfo.Hour += 2;
                            }

                        }
                    },
                    SecondChoice = new Choice()
                    {
                        Answer = "Агрессивно сказать, что ты нигде не мусорил и ничего убирать не будешь.",
                        SuccesAfterAnswer = "Комендша сказала, что ты слишком агрессивный и отпустила тебя",
                        FailAfterAnswer = "Комендше не понравился твой тон, и она сказала либо ты убираешь этаж, либо тебя выселяют. Выбора не было",
                        CheckSucces = () => player.CharismaLevel >= 3,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.CharismaXP += 1;
                                player.Mood += 5;
                                player.Energy -= 10;
                                player.Hunger -= 5;
                                dateTimeInfo.Hour += 1;
                            }
                            else
                            {
                                player.CharismaXP -= 1;
                                player.Mood -= 15;
                                player.Energy -= 15;
                                player.Hunger -= 10;
                                dateTimeInfo.Hour += 2;
                            }
                        }
                    },
                    ThirdChoice = new Choice()
                    {
                        Answer = "Соврать, что тебя вообще не было в общаге последний день и у тебя алиби",
                        SuccesAfterAnswer = "Комендша тебе поверила и отпустила",
                        FailAfterAnswer = "Комендша видела тебя вчера на этаже, поэтому теперь у нее есть все основания думать, что это был ты.",
                        CheckSucces = () => player.CharismaLevel >= 1,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.CharismaXP += 1;
                                player.Mood += 10;
                                player.Energy -= 5;
                                player.Hunger -= 5;
                                dateTimeInfo.Hour += 1;
                            }
                            else
                            {
                                player.CharismaXP += 1;
                                player.Mood -= 15;
                                player.Energy -= 15;
                                player.Hunger -= 10;
                                dateTimeInfo.Hour += 2;
                            }
                        }
                    }
                },
                // проснулся с болью в голове
                new ChoiceBranch()
                {
                    Message = "Ты проснулся с болью в горле.",
                    FirstChoice = new Choice()
                    {
                        Answer = "Не обращать внимание на боль и пойти на пары",
                        SuccesAfterAnswer = "Ты выздоровел и отучился на всех парах",
                        FailAfterAnswer = "Твое самочувствие ухудшилось",
                        CheckSucces = () => player.Health >= 75,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Health -= 15;
                                player.Mood += 15;
                                player.Energy -= 15;
                                player.PhysicalXP += 2;
                            }
                            else
                            {
                                player.Health -= 25;
                                player.Mood -= 10;
                                player.Energy -= 20;
                                player.PhysicalXP -= 2;
                            }
                        }

                    },
                    SecondChoice = new Choice()
                    {
                        Answer = "Сходить в аптеку за лекарством",
                        SuccesAfterAnswer = "Ты купил лекарство и вылечился.",
                        FailAfterAnswer = "У тебя не хватает денег на лекарство, clown?",
                        CheckSucces = () => player.Money >= 1000,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Money -= 1000;
                                player.Health += 10;
                                player.Mood += 10;
                                player.Energy -= 10;
                                player.PhysicalXP += 1;
                            }
                            else
                            {
                                player.Health -= 25;
                                player.Mood -= 10;
                                player.Energy -= 10;
                                player.PhysicalXP -= 2;
                            }
                            dateTimeInfo.Hour += 1;
                        }
                    },
                    ThirdChoice = new Choice()
                    {
                        Answer = "Остаться дома и попробовать перебороть болезнь самому",
                        SuccesAfterAnswer = "Твой организм справился с напастью и ты стал чувствовать себя лучше",
                        FailAfterAnswer = "Твоего имуннитета не хватило для борьбы с болезнью, тебе стало хуже",
                        CheckSucces = () => player.Health >= 50 && player.Mood >= 50,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Health += 10;
                                player.Mood += 10;
                                player.Energy -= 10;
                                player.PhysicalXP += 1;
                                player.Hunger -= 10;
                            }
                            else
                            {
                                player.Health -= 10;
                                player.Mood -= 10;
                                player.Energy -= 10;
                                player.PhysicalXP += 1;
                                player.Hunger -= 15;
                            }
                            dateTimeInfo.Hour += 1;
                        }
                    }
                },
                // гопота у обшаги
                new ChoiceBranch()
                {
                    Message = "У твоей общаги тебя останавливает группа странных людей и просят денег",
                    FirstChoice = new Choice()
                    {
                        Answer = "Сказать, что ты студент и у тебя их нет",
                        SuccesAfterAnswer = "Ты смог их убедить и тебе поверили на слово и отпустили",
                        FailAfterAnswer = "Ты не смог их убедить, тебе не поверили и забрали их силой",
                        CheckSucces = () => player.CharismaLevel >= 4,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Mood -= 5;
                                player.CharismaXP += 3;
                                player.PhysicalXP -= 1;
                            }
                            else
                            {
                                player.Mood -= 20;
                                if (player.Money > 500) player.Money = 500;
                                else player.Money = 500;
                                player.CharismaXP += 1;
                            }

                            dateTimeInfo.Hour += 1;
                        }
                    },
                    SecondChoice = new Choice()
                    {
                        Answer = "Вызвать главаря 1vs1(zxc)",
                        SuccesAfterAnswer = "Ты доказал, что не пальцем деланый и он сказал им тебя не трогать.",
                        FailAfterAnswer = "Тебя побили и забрали деньги",
                        CheckSucces = () => player.PhysicalLevel >= 4,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Mood += 20;
                                player.Energy -= 20;
                                player.Health -= 10;
                                player.Hunger -= 10;
                                player.PhysicalXP += 5;
                                dateTimeInfo.Hour += 2;
                            }
                            else
                            {
                                player.Mood -= 15;
                                player.Energy -= 20;
                                player.Health -= 30;
                                player.Hunger -= 10;
                                player.PhysicalXP += 5;
                                if (player.Money > 500) player.Money = 500;
                                else player.Money = 500;
                                dateTimeInfo.Hour += 1;
                            }
                        }
                    },
                    ThirdChoice = new Choice()
                    {
                        Answer = "Попросить помощи у прохожих",
                        SuccesAfterAnswer = "Подошло несколько парней с твоей общаги, которые тебя узнали и заступились.",
                        FailAfterAnswer = "Никто не услышал просьб о помощи либо не хотели слышать. Тебя побили",
                        CheckSucces = () => player.CharismaLevel >= 3 && player.StudWaveLevel >= 3,
                        PlayerInteract = (checkSucces) =>
                        {
                            if (checkSucces)
                            {
                                player.Mood += 10;
                                player.StudWaveXP += 3;
                                player.Hunger -= 10;
                                player.Energy -= 10;
                                dateTimeInfo.Hour += 1;
                            }
                            else
                            {
                                player.Mood -= 15;
                                player.Energy -= 20;
                                player.Health -= 30;
                                player.Hunger -= 10;
                                player.PhysicalXP += 5;
                                if (player.Money > 500) player.Money = 500;
                                else player.Money = 500;
                                dateTimeInfo.Hour += 1;
                            }
                        }
                    }
                }

            };

            branches = new Dictionary<string, List<ChoiceBranch>>();
            branches.Add("RTF", RTFlist);
            branches.Add("HOME", HOMElist);
            return branches;
        }
    }
}
