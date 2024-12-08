namespace Lecture4._3_Factory_Method
{
    using System;

    namespace AbstractFactoryPattern
    {
        // Абстрактный продукт A
        public interface IChair
        {
            void SitOn();
        }

        // Конкретный продукт A1
        public class VictorianChair : IChair
        {
            public void SitOn()
            {
                Console.WriteLine("Сидим на викторианском стуле.");
            }
        }

        // Конкретный продукт A2
        public class ModernChair : IChair
        {
            public void SitOn()
            {
                Console.WriteLine("Сидим на современном стуле.");
            }
        }

        // Абстрактный продукт B
        public interface ISofa
        {
            void LieOn();
        }

        // Конкретный продукт B1
        public class VictorianSofa : ISofa
        {
            public void LieOn()
            {
                Console.WriteLine("Лежим на викторианском диване.");
            }
        }

        // Конкретный продукт B2
        public class ModernSofa : ISofa
        {
            public void LieOn()
            {
                Console.WriteLine("Лежим на современном диване.");
            }
        }

        // Абстрактная фабрика
        public interface IFurnitureFactory
        {
            IChair CreateChair();
            ISofa CreateSofa();
        }

        // Конкретная фабрика 1
        public class VictorianFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair()
            {
                return new VictorianChair();
            }

            public ISofa CreateSofa()
            {
                return new VictorianSofa();
            }
        }

        // Конкретная фабрика 2
        public class ModernFurnitureFactory : IFurnitureFactory
        {
            public IChair CreateChair()
            {
                return new ModernChair();
            }

            public ISofa CreateSofa()
            {
                return new ModernSofa();
            }
        }

        // Клиентский код
        class Program
        {
            static void Main(string[] args)
            {
                // Викторианская фабрика
                IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
                IChair victorianChair = victorianFactory.CreateChair();
                ISofa victorianSofa = victorianFactory.CreateSofa();
                victorianChair.SitOn();
                victorianSofa.LieOn();

                // Современная фабрика
                IFurnitureFactory modernFactory = new ModernFurnitureFactory();
                IChair modernChair = modernFactory.CreateChair();
                ISofa modernSofa = modernFactory.CreateSofa();
                modernChair.SitOn();
                modernSofa.LieOn();
            }
        }
    }
   
}
