using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Weather
    {
        private double currTemp;
        private double vlazZraka;
        private double jacVjetra;

        public Weather()
        {
            currTemp = 0;
            vlazZraka = 0;
            jacVjetra = 0;
        }
        public Weather(double temp, double vlaznost, double brzina)
        {
            currTemp = temp;
            vlazZraka = vlaznost;
            jacVjetra = brzina;
        }


        public double GetTemperature()
        {
            return currTemp;
        }
        public void SetTemperature(double currTemp)
        {
            this.currTemp = currTemp;
        }

        public double GetHumidity()
        {
            return vlazZraka;
        }
        public void SetHumidity(double vlazZraka)
        {
            this.vlazZraka = vlazZraka;
        }

        public double GetWindSpeed()
        {
            return jacVjetra;
        }
        public void SetWindSpeed(double jacVjetra)
        {
            this.jacVjetra = jacVjetra;
        }

        public double CalculateWindChill()
        {
            double WindCh = 13.12 + 0.6215 * currTemp - 11.37 * Math.Pow(jacVjetra, 0.16) + 0.3965 * currTemp * Math.Pow(jacVjetra, 0.16);
            if (WindCh > GetTemperature())
            {
                return 0;
            }
            return WindCh;
        }
        public double CalculateFeelsLikeTemperature()
        {
            return (-8.78469475556 + 1.61139411 * currTemp + 2.33854883889 * vlazZraka - 0.14611605 * currTemp * vlazZraka + (-0.012308094 * Math.Pow(currTemp, 2)) + (-0.0164248277778 * Math.Pow(vlazZraka, 2)) + (0.002211732 * Math.Pow(currTemp, 2) * vlazZraka) + (0.00072546*currTemp * Math.Pow(vlazZraka, 2)) + (-0.000003582 * Math.Pow(currTemp, 2) * Math.Pow(vlazZraka, 2)));
        }
        public Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather najveci = new Weather(0, 0, 0);
            for (int i = 0; i < weathers.Length - 1; i++)
            {
                if (weathers[i].CalculateWindChill() > weathers[i + 1].CalculateWindChill())
                {
                    najveci = weathers[i];
                }
            }
            return najveci;
        }
    }
}

