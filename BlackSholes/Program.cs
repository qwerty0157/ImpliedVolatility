using System;

namespace BlackSholes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double stock = 20790;
            double strike = 20500;
            double maturity = 0.08767;
            double start = 0.0;
            double sigma = 0.1655;
            double rate = 0.00075;
            double initialIV = 0.15;
            double price = 0.1;
            //var Bs = new BlackSholes(110.0, 105, 1, 0, 0.05, 0.001);

            var Bs = new BlackSholes(stock, strike, maturity, start, sigma, rate);
            price = Bs.BlackSholesFunction();

            var IV = new ImpliedVolatility(price, stock, strike, maturity, start, rate, initialIV);
            double result = IV.calcIV();
            Console.WriteLine(result);
        }
    }
}
