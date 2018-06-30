using System;
namespace BlackSholes
{
    public class BlackSholes
    {
        double stock;
        double strike;
        double maturity;
        double t;
        double sigma;
        double r;

        public BlackSholes(double Stock, double Strike, double Maturity, double T, double Sigma, double R)
        {
            this.stock = Stock;
            this.strike = Strike;
            this.maturity = Maturity;
            this.t = T;
            this.sigma = Sigma;
            this.r = R;
        }

        public double BlackSholesFunction()
        {
            var result = 0.0;
            result = stock * gauss(dplus()) - strike * Math.Exp(-r * (maturity - t)) * gauss(dminus());
            return result;
        }

        public double gauss(double x)
        {
            double sum = 0;
            double a = -10;
            double b = x;
            double h = 10000000;
            double width = (b - a) / h;
            for (double i = a; i < b; i += width)
            {
                sum += gaussFunction(i) * width;
            }
            return sum / Math.Sqrt(2 * Math.PI);
        }

        private double gaussFunction(double x)
        {
            return Math.Exp(-(Math.Pow(x, 2.0) / 2));
        }

        private double dplus()
        {
            double d =
                (Math.Log(stock / strike) + (r + Math.Pow(sigma, 2.0) / 2.0) * (maturity - t))
                / (sigma * Math.Sqrt(maturity - t)); 
            return d;
        }

        private double dminus()
        {
            double d =
                (Math.Log(stock / strike) + (r - Math.Pow(sigma, 2.0) / 2.0) * (maturity - t))
                / (sigma * Math.Sqrt(maturity - t));
            return d;
        }
    }
}
