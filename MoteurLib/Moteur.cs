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

        public void Solveur(List<String> results, List<int> generatedNumbers, int solution, string calcul)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int result = 0;
            List<char> operands = new List<char> { '+', '-', '/', '*' };
            List<int> solverValues = new List<int>();

            for (i = 0; i < generatedNumbers.Count; i++)
            {
                for (j = generatedNumbers.Count - 1; j >= i + 1; j--)
                {
                    for (k = 0; k < operands.Count; k++)
                    {
                        solverValues = new List<int>(generatedNumbers);
                        string lastCalcul = generatedNumbers[i] + " " + operands[k] + " " + generatedNumbers[j] + " ; ";
                        result = calcResult(generatedNumbers[i], generatedNumbers[j], operands[k]);
                        if (result != -1)
                        {
                            solverValues[i] = result;
                            solverValues.RemoveAt(j);
                            if (solverValues.Count > 1)
                            {
                                //results.Add(generatedNumbers[i] + " " + operands[k] + " " + generatedNumbers[j]);
                                Solveur(results, solverValues, solution, calcul + lastCalcul);
                                if (result == solution)
                                {
                                    results.Add(calcul + lastCalcul + "" + result);
                                }
                            }
                            else
                            {
                                if (result == solution)
                                {
                                    //string math = calcul + lastCalcul;
                                    //math = math.TrimEnd('+');
                                    //string value = new DataTable().Compute(math, null).ToString();
                                    results.Add(calcul + lastCalcul + "" + result);
                                }
                            }
                        }
                    }
                }
            }
        }

        public int calcResult(int numberOne, int numberTwo, Char operand)
        {
            int result = 0;
            switch (operand)
            {
                case '+':
                    result = numberOne + numberTwo;
                    break;
                case '-':
                    result = numberOne - numberTwo;
                    if (result < 0)
                    {
                        result = numberTwo - numberOne;
                    }
                    break;
                case '/':
                    if (numberOne > numberTwo && (numberOne % numberTwo == 0))
                    {
                        result = numberOne / numberTwo;
                    }
                    else if (numberTwo > numberOne && (numberTwo % numberOne == 0))
                    {
                        result = numberTwo / numberOne;
                    }
                    break;
                case '*':
                    result = numberOne * numberTwo;
                    break;
            }

            //If an operation goes wrong
            if (result <= 0)
            {
                result = -1;
            }
            return result;
        }
    }
}
