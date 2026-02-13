using Core.Interface;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Core.Algorithms
{
    public class PowerHandler : IPowerHandler
    {
        public Complex GetFullPowerVector(double activePower, double cos_fi)
        {

            if (Math.Abs(cos_fi) < 1e-10)
            {
                throw new ArgumentException("cos_fi не должен быть близок к нулю");
            }

            if (cos_fi < 0)
            {
                throw new ArgumentException("cos_fi должен быть положительным");
            }

            var tan_fi = Math.Sqrt(1 - Math.Pow(cos_fi, 2)) / cos_fi;
            return new Complex(activePower, tan_fi * activePower);
        }
        public double GetFullPowerAbs(double activePower, double cos_fi)
        {
            if (Math.Abs(cos_fi) < 1e-10)
            {
                throw new ArgumentException("cos_fi не должен быть близок к нулю");
            }

            if (cos_fi < 0)
            {
                throw new ArgumentException("cos_fi должен быть положительным");
            }

            return activePower / cos_fi;
        }

        public List<Complex> GetAllFullPowerVector(List<double> activePowers, List<double> cos_fi)
        {
            if (activePowers.Count == 0 || cos_fi.Count == 0)
            {
                throw new ArgumentException("Указан пустой список в аргументе");
            }

            if (activePowers.Count != cos_fi.Count)
            {
                throw new ArgumentException("Длина списка значений активных мощностей не равна длине списка коэффициентов мощности");
            }

            var result = new List<Complex>();
            for (int i = 0; i < cos_fi.Count; i++)
            {
                if (Math.Abs(cos_fi[i]) < 1e-10)
                {
                    throw new ArgumentException("cos_fi не должен быть близок к нулю");
                }

                if (cos_fi[i] < 0)
                {
                    throw new ArgumentException("cos_fi должен быть положительным");
                }

                var tan_fi = Math.Sqrt(1 - Math.Pow(cos_fi[i], 2)) / cos_fi[i];
                result.Add(new Complex(activePowers[i], activePowers[i] * tan_fi));
            }
            return result;
        }

        public List<Complex> GetAllFullPowerVector(List<double> activePowers, double cos_fi)
        {
            if (activePowers.Count == 0)
            {
                throw new ArgumentException("Указан пустой список в аргументе");
            }

            if (Math.Abs(cos_fi) < 1e-10)
            {
                throw new ArgumentException("cos_fi не должен быть близок к нулю");
            }

            if (cos_fi < 0)
            {
                throw new ArgumentException("cos_fi должен быть положительным");
            }

            var result = new List<Complex>();
            var tan_fi = Math.Sqrt(1 - Math.Pow(cos_fi, 2)) / cos_fi;
            for (int i = 0; i < activePowers.Count; i++)
            {
                result.Add(new Complex(activePowers[i], activePowers[i] * tan_fi));
            }
            return result;
        }

        public List<double> GetAllFullPowerAbs(List<double> activePowers, List<double> cos_fi)
        {
            if (activePowers.Count == 0 || cos_fi.Count == 0)
            {
                throw new ArgumentException("Указан пустой список в аргументе");
            }

            if (activePowers.Count != cos_fi.Count)
            {
                throw new ArgumentException("Длина списка значений активных мощностей не равна длине списка коэффициентов мощности");
            }

            var result = new List<double>();
            for (int i = 0; i < cos_fi.Count; i++)
            {
                if (Math.Abs(cos_fi[i]) < 1e-10)
                {
                    throw new ArgumentException("cos_fi не должен быть близок к нулю");
                }

                if (cos_fi[i] < 0)
                {
                    throw new ArgumentException("cos_fi должен быть положительным");
                }

                result.Add(activePowers[i] / cos_fi[i]);
            }
            return result;
        }
        public List<double> GetAllFullPowerAbs(List<double> activePowers, double cos_fi)
        {
            if (activePowers.Count == 0)
            {
                throw new ArgumentException("Указан пустой список в аргументе");
            }

            if (Math.Abs(cos_fi) < 1e-10)
            {
                throw new ArgumentException("cos_fi не должен быть близок к нулю");
            }

            if (cos_fi < 0)
            {
                throw new ArgumentException("cos_fi должен быть положительным");
            }


            var result = new List<double>();
            for (int i = 0; i < activePowers.Count; i++)
            {
                result.Add(activePowers[i] / cos_fi);
            }
            return result;
        }

        public double GetReactivePower(double activePower, double cos_fi)
        {
            var tan_fi = Math.Sqrt(1 - Math.Pow(cos_fi, 2)) / cos_fi;
            return tan_fi * activePower;
        }
    }
}
