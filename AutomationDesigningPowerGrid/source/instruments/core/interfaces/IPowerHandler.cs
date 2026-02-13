using System.Collections.Generic;
using System.Numerics;

namespace Core.Interface
{
    public interface IPowerHandler
    {
        List<double> GetAllFullPowerAbs(List<double> activePowers, double cos_fi);
        List<double> GetAllFullPowerAbs(List<double> activePowers, List<double> cos_fi);
        List<Complex> GetAllFullPowerVector(List<double> activePowers, double cos_fi);
        List<Complex> GetAllFullPowerVector(List<double> activePowers, List<double> cos_fi);
        double GetFullPowerAbs(double activePower, double cos_fi);
        Complex GetFullPowerVector(double activePower, double cos_fi);
        double GetReactivePower(double activePower, double cos_fi);
    }
}