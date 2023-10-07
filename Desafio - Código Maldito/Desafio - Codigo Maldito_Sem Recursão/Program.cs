using System;
using System.Collections.Generic;

namespace Main
{
    public class MainProgram
    {
        private static Dictionary<EToyType, Toy>? _toys;
        private static List<Kid>? _kids;

        public static void Main(string[] args)
        {
            _toys = new(5);
            _toys.Add(EToyType.ARANHA, new Toy("Aranhas de plástico​"));
            _toys.Add(EToyType.SAPO, new Toy("Sapo de borracha​"));
            _toys.Add(EToyType.DENTADURA, new Toy("Dentaduras​"));
            _toys.Add(EToyType.FANTASMA, new Toy("Fantasminhas que brilham no escuro​"));
            _toys.Add(EToyType.BRUXA, new Toy("Bruxinhas​"));

            _kids = new(5);
            _kids.Add(new Kid("Samuel", _toys[EToyType.SAPO]));
            _kids.Add(new Kid("Franklin", _toys[EToyType.ARANHA]));
            _kids.Add(new Kid("Hellen", _toys[EToyType.FANTASMA]));
            _kids.Add(new Kid("JC", _toys[EToyType.BRUXA]));
            _kids.Add(new Kid("Daniel", _toys[EToyType.DENTADURA]));

            EvaluteKidsAndToys();
        }

        private static void EvaluteKidsAndToys()
        {
            if (_kids == null || _toys == null)
            {
                return;
            }

            int kidsWithToysCount = 0;

            while (kidsWithToysCount < _kids.Count)
            {
                foreach (var toy in _toys.Values)
                {
                    Toy currentToy = toy;

                    Console.WriteLine($"Brinquendo atual da caixa: {currentToy.Name}");

                    foreach (Kid kid in _kids)
                    {
                        Kid currentKid = kid;

                        if (kid.IsTheCorrectToy(currentToy))
                        {
                            Console.WriteLine($"{currentKid.Name} gosta de {currentToy.Name} e pegou para si.");
                            kidsWithToysCount++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{currentKid.Name} não gosta de {currentToy.Name} e vai repassar este brinquedo.");
                        }
                    }
                }
            }

            Console.WriteLine("\n");
            foreach (var kid in _kids)
            {
                Console.WriteLine($"{kid.Name} está com {kid.ToyInBag.Name} na mochila");
            }
            Console.WriteLine($"Fim do algoritmo");
            Console.ReadKey();
        }
    }

    public class Kid
    {
        public readonly string Name;
        public readonly Toy Toy;
        public Toy ToyInBag { get; private set; }

        public Kid(string name, Toy toy)
        {
            Name = name;
            Toy = toy;
        }

        public bool IsTheCorrectToy(Toy toyToEvaluate)
        {
            if (ToyInBag != null)
            {
                return false;
            }

            bool isTheCorrectToy = toyToEvaluate.Name == Toy.Name;

            if (isTheCorrectToy)
            {
                ToyInBag = toyToEvaluate;
            }

            return isTheCorrectToy;
        }
    }

    public class Toy
    {
        public readonly string Name;

        public Toy(string name)
        {
            Name = name;
        }
    }

    public enum EToyType
    {
        ARANHA,
        SAPO,
        DENTADURA,
        FANTASMA,
        BRUXA
    };
}