using System;

namespace CurrencyConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задаем курсы обмена валюты
            double usdToRubRate = 73.11;
            double eurToRubRate = 90.76;
            double usdToEurRate = 0.82;

            // Создаем объекты валюты с помощью явного или неявного преобразования
            CurrencyUSD usd = 100; // 100 USD
            CurrencyEUR eur = (CurrencyEUR)usd; // Преобразуем 100 USD в EUR
            CurrencyRUB rub = (CurrencyRUB)eur; // Преобразуем полученные EUR в RUB

            Console.WriteLine("100 USD в EUR: " + eur.Value);
            Console.WriteLine("100 USD в RUB: " + rub.Value);
            Console.WriteLine("100 EUR в RUB: " + ((CurrencyRUB)eur).Value);

            // Изменяем курс обмена валюты
            Console.WriteLine("Укажите новый курс обмена USD в RUB:");
            usdToRubRate = Convert.ToDouble(Console.ReadLine());

            // Преобразуем 100 USD в RUB с использованием нового курса
            CurrencyRUB newRub = (CurrencyRUB)usd;

            Console.WriteLine("100 USD в новых RUB: " + newRub.Value);
        }
    }

    class Currency
    {
        public double Value { get; set; }

        public Currency(double value)
        {
            Value = value;
        }
    }

    class CurrencyUSD : Currency
    {
        private static double usdToEurRate;
        private static double usdToRubRate;

        public CurrencyUSD(double value) : base(value) { }

        public static implicit operator CurrencyUSD(int v)
        {
            throw new NotImplementedException();
        }

        public static explicit operator CurrencyEUR(CurrencyUSD usd)
        {
            double eurValue = usd.Value * usdToEurRate;
            return new CurrencyEUR(eurValue);
        }

        public static explicit operator CurrencyRUB(CurrencyUSD usd)
        {

            double rubValue = usd.Value * usdToRubRate;
            return new CurrencyRUB(rubValue);
        }
    }

    class CurrencyEUR : Currency
    {
        private static double eurToRubRate;

        public CurrencyEUR(double value) : base(value) { }

        public static explicit operator CurrencyRUB(CurrencyEUR eur)
        {
            double rubValue = eur.Value * eurToRubRate;
            return new CurrencyRUB(rubValue);
        }
    }

    class CurrencyRUB : Currency
    {
        private static double usdToRubRate;
        private static double eurToRubRate;

        public CurrencyRUB(double value) : base(value) { }

        public static explicit operator CurrencyUSD(CurrencyRUB rub)
        {
            double usdValue = rub.Value / usdToRubRate;
            return new CurrencyUSD(usdValue);
        }

        public static explicit operator CurrencyEUR(CurrencyRUB rub)
        {
            double eurValue = rub.Value / eurToRubRate;
            return new CurrencyEUR(eurValue);
        }
    }
}
