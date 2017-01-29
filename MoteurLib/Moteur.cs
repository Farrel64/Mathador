using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoteurLib
{
    public class Moteur
    {
        public List<int> getRandomNumbers()
        {
            List<int> randList = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (i >= 0 && i < 3)
                    randList.Add(rand.Next(1, 13));
                else if (i >= 3 && i < 5)
                    randList.Add(rand.Next(1, 21));
            }
            return randList;
        }

        public int getTargetNumber()
        {
            List<int> random = this.getRandomNumbers();
            List<int> newList = new List<int>(random);
            Random rand = new Random();
            int randCalcul = rand.Next(2, 5);
            List<string> history = new List<string>();

            for (int i = 0; i < randCalcul; i++)
            {
                int rand1 = rand.Next(0, newList.Count);
                int rand2 = rand.Next(0, newList.Count);
                int randOperator = rand.Next(1, 5);

                while (rand1 == rand2)
                {
                    rand2 = rand.Next(0, newList.Count);
                }

                switch (randOperator)
                {
                    case 1:
                        history.Add(newList[rand1] + " + " + newList[rand2] + " = " + (newList[rand1] + newList[rand2]));
                        newList.Add(newList[rand1] + newList[rand2]);
                        newList.RemoveAt(rand1);
                        newList.RemoveAt(rand2);
                        break;

                    case 2:
                        history.Add(newList[rand1].ToString() + " * " + newList[rand2].ToString() + " = " + (newList[rand1] * newList[rand2]));
                        newList.Add(newList[rand1] * newList[rand2]);
                        newList.RemoveAt(rand1);
                        newList.RemoveAt(rand2);
                        break;

                    case 3:
                        if (newList[rand1] > newList[rand2])
                        {
                            history.Add(newList[rand1] + " - " + newList[rand2] + " = " + (newList[rand1] - newList[rand2]));
                            newList.Add(newList[rand1] - newList[rand2]);
                            newList.RemoveAt(rand1);
                            newList.RemoveAt(rand2);
                            break;
                        }
                        else
                        {
                            history.Add(newList[rand2].ToString() + " - " + newList[rand1].ToString() + " = " + (newList[rand2] - newList[rand1]));
                            newList.Add(newList[rand2] - newList[rand1]);
                            newList.RemoveAt(rand1);
                            newList.RemoveAt(rand2);
                            break;
                        }

                    case 4:
                        if (newList[rand1] > newList[rand2] && newList[rand2] != 0)
                        {
                            if ((newList[rand1] / newList[rand2] % 1) == 0)
                            {
                                history.Add(newList[rand1].ToString() + " / " + newList[rand2].ToString() + " = " + (newList[rand1] / newList[rand2]));
                                newList.Add(newList[rand1] / newList[rand2]);
                                newList.RemoveAt(rand1);
                                newList.RemoveAt(rand2);
                            }
                            break;
                        }
                        else
                        {
                            if ((newList[rand1] / newList[rand2] % 1) == 0)
                            {
                                history.Add(newList[rand2].ToString() + " / " + newList[rand1].ToString() + " = " + (newList[rand2] / newList[rand1]));
                                newList.Add(newList[rand2] / newList[rand1]);
                                newList.RemoveAt(rand1);
                                newList.RemoveAt(rand2);
                            }
                            break;
                        }
                }
            }
            return newList[newList.Count - 1];
        }
    }
}
