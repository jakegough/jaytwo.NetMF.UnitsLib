using System;

namespace jaytwo.NetMF.UnitsLib
{
	public interface IOverloadedMeasurement
	{
#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		bool HasValue { get; }
#endif

		double BasicUnits { get; }
	}
}
