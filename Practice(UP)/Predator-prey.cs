using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalModeling.Practice_UP_
{
    internal class Predator_prey
    {
        double firstCountPrey; //численность жертв
        double firstCountPredator; // численность хищников
        double naturalIncreasePrey; //естественный прирост жертв
        double mortalityPreyOfPrey; //смертность жертв от конкурентов
        double mortalityPreyOfPredator; //смертность жертв от хищников
        double mortalityPredator; //смертность хищников
        double naturalIncreasePredator; //прирост хищников

        public Predator_prey(int firstCountPrey, int firstCountPredator, double naturalIncreasePrey, double mortalityPreyOfPrey, double mortalityPreyOfPredator, double mortalityPredator, double naturalIncreasePredator)
        {
            this.firstCountPrey = firstCountPrey;
            this.firstCountPredator = firstCountPredator;
            this.naturalIncreasePrey = naturalIncreasePrey;
            this.mortalityPreyOfPrey = mortalityPreyOfPrey;
            this.mortalityPreyOfPredator = mortalityPreyOfPredator;
            this.mortalityPredator = mortalityPredator;
            this.naturalIncreasePredator = naturalIncreasePredator;
        }

        public void DoTask() 
        {
            double prevCountPrey = firstCountPrey;
            double prevCountPredator = firstCountPredator;
            double nextCountPrey, nextCountPredator;
            Console.WriteLine($"0 {prevCountPrey} {prevCountPredator}");
            for (int i = 1; i < 20; i++)
            {

                nextCountPrey = prevCountPrey + (naturalIncreasePrey - mortalityPreyOfPrey * prevCountPrey) * prevCountPrey - mortalityPreyOfPredator * prevCountPrey * prevCountPredator;
                nextCountPredator = prevCountPredator - mortalityPredator * prevCountPredator + naturalIncreasePredator * prevCountPrey * prevCountPredator;
                Console.WriteLine($"{i} {Math.Round(nextCountPrey)} {Math.Round(nextCountPredator)}");
                prevCountPrey = nextCountPrey;
                prevCountPredator = nextCountPredator;
            }
        }
    }
}
