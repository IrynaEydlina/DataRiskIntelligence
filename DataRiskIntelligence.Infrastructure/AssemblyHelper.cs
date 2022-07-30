using System.Reflection;

namespace DataRiskIntelligence.Infrastructure;

public class InfrustructureAssemblyHelper
{
    public static Assembly GetLogicAssembly() => typeof(InfrustructureAssemblyHelper).Assembly;
}

