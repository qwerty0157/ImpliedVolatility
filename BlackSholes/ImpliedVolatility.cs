using System;
namespace BlackSholes
{
    public class ImpliedVolatility
    {
        double price;
        double stock;
        double strike;
        double maturity;
        double t;
        double r;
        double init;

        public ImpliedVolatility(double Price, double Stock, double Strike, double Maturity, double T, double R, double Init)
        {
            this.stock = Stock;
            this.strike = Strike;
            this.maturity = Maturity;
            this.t = T;
            this.price = Price;
            this.r = R;
            this.init = Init;
        }

        public double calcIV()
        {
            int i = 0;
            double xn1 = 0.0;
            double xn2 = 0.0;
            double tol = 0.0001;
            xn1 = Newton(init);

            while(i < 100)
            {
                i++;
                xn2 = Newton(xn1);
                if (Math.Abs(xn2 - xn1) < tol) break;
                xn1 = xn2;
            }
            return xn2;
        }


        private double Newton(double x)
        {
            double result = x - impliedVolatilityFunction(x) / difference(x);
            return result;
        }

        private double difference(double x)
        {
            double h = 0.001;
            var funcEnd = impliedVolatilityFunction(x);
            var funcStart = impliedVolatilityFunction(x - h);

            double result = (funcEnd - funcStart) / h;
            return result;
        }

        private double impliedVolatilityFunction(double x)
        {
            var BS = new BlackSholes(stock, strike, maturity, t, x, r);
            double f = BS.BlackSholesFunction() - price;
            return f;
        }
    }
}
