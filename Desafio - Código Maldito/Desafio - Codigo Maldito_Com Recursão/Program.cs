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

            EvaluateKidsAndToys(0, 0);
            PrintResults();
        }

        private static void EvaluateKidsAndToys(int kidIndex, int toyIndex)
        {
            if (toyIndex >= _toys.Count)
            {
                return; // Todas as crianças já receberam brinquedos.
            }

            Kid currentKid = _kids[kidIndex];
            Toy currentToy = _toys[(EToyType)toyIndex];

            Console.WriteLine($"Brinquedo atual da caixa: {currentToy.Name}");

            if (currentKid.IsTheCorrectToy(currentToy))
            {
                Console.WriteLine($"{currentKid.Name} gosta de {currentToy.Name} e pegou para si.");

                // Avalia o próximo brinquedo
                EvaluateKidsAndToys(0, toyIndex + 1);
            }
            else
            {
                Console.WriteLine($"{currentKid.Name} não gosta de {currentToy.Name} e vai repassar este brinquedo.");
                EvaluateKidsAndToys(kidIndex + 1, toyIndex); // Avança para a próxima criança. 
            }
        }

        private static void PrintResults()
        {
            Console.WriteLine(string.Empty);
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