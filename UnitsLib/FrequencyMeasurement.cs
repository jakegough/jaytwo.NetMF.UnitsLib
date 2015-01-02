using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class FrequencyMeasurement : OverloadedMeasurementBase
	{
		public static FrequencyMeasurement FromWavelength(TimeSpan wavelength)
		{
			return FromHz(TimeSpan.TicksPerSecond / wavelength.Ticks);
		}

		public static FrequencyMeasurement FromHz(double hz)
		{
			return new FrequencyMeasurement(hz);
		}

		public static FrequencyMeasurement FromKhz(double khz)
		{
			return FromHz(DoubleMetricPrefixUtility.FromKilo(khz));
		}

		public static FrequencyMeasurement FromMhz(double mhz)
		{
			return FromHz(DoubleMetricPrefixUtility.FromMega(mhz));
		}

		public static FrequencyMeasurement FromGhz(double ghz)
		{
			return FromHz(DoubleMetricPrefixUtility.FromGiga(ghz));
		}

		public static FrequencyMeasurement FromRpm(double rpm)
		{
			return FromHz(rpm / 60);
		}

		public static FrequencyMeasurement FromBasicUnits(double basicUnits)
		{
			return new FrequencyMeasurement(basicUnits);
		}

		private FrequencyMeasurement(double hz)
			: base(hz)
		{
		}

#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		private FrequencyMeasurement()
			: base()
		{
		}
#endif

		public double Hz { get { return BasicUnits; } }
		public double Khz { get { return DoubleMetricPrefixUtility.ToKilo(Hz); } }
		public double Mhz { get { return DoubleMetricPrefixUtility.ToMega(Hz); } }
		public double Ghz { get { return DoubleMetricPrefixUtility.ToGiga(Hz); } }
		public double RPM { get { return Hz * 60; } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static FrequencyMeasurement None = new FrequencyMeasurement(double.NaN);
#else
		public static FrequencyMeasurement None = new FrequencyMeasurement();
#endif
		public static FrequencyMeasurement Zero = new FrequencyMeasurement(0);
		public static FrequencyMeasurement Min = new FrequencyMeasurement(double.NegativeInfinity);
		public static FrequencyMeasurement Max = new FrequencyMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public FrequencyMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new FrequencyMeasurement(result);
		}

		public FrequencyMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new FrequencyMeasurement(result);
		}

		public FrequencyMeasurement Add(FrequencyMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new FrequencyMeasurement(result);
		}

		public FrequencyMeasurement Subtract(FrequencyMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new FrequencyMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static FrequencyMeasurement Parse(string value)
		{
			return TryParse(value) ?? FrequencyMeasurement.None;
		}

		public static FrequencyMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new FrequencyMeasurement(units);
			}
			else
			{
				return null;
			}
		}
#endif

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			FrequencyMeasurement other = obj as FrequencyMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(FrequencyMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(FrequencyMeasurement a, FrequencyMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator FrequencyMeasurement(double value)
		{
			return new FrequencyMeasurement(value);
		}

		public static implicit operator double(FrequencyMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
