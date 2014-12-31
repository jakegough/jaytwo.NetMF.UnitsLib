using System;

namespace jaytwo.NetMF.UnitsLib
{
	public interface IOverloadedMeasurement
	{
#if !MF_FRAMEWORK_VERSION_V4_2
		bool HasValue { get; }
#endif

		double BasicUnits { get; }
	}
}
