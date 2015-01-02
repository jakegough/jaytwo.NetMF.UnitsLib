using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class ElectricalPowerMeasurement : OverloadedMeasurementBase
	{
		public static ElectricalPowerMeasurement FromWatts(double watts)
		{
			return new ElectricalPowerMeasurement(watts);
		}

		public static ElectricalPowerMeasurement FromMilliwatts(double milliwatts)
		{
			var watts = DoubleMetricPrefixUtility.FromMilli(milliwatts);
			return ElectricalPowerMeasurement.FromWatts(watts);
		}

		public static ElectricalPowerMeasurement FromVoltsCurrent(VoltageMeasurement voltage, CurrentMeasurement current)
		{
			var watts = voltage.Volts * current.Amps;
			return ElectricalPowerMeasurement.FromWatts(watts);
		}

		public static ElectricalPowerMeasurement FromBasicUnits(double basicUnits)
		{
			return new ElectricalPowerMeasurement(basicUnits);
		}

		private ElectricalPowerMeasurement(double watts)
			: base(watts)
		{
		}

#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		private ElectricalPowerMeasurement()
			: base()
		{
		}
#endif

		public double Watts { get { return BasicUnits; } }

		public double Milliwatts { get { return DoubleMetricPrefixUtility.ToMilli(Watts); } }

		public CurrentMeasurement GetCurrent(VoltageMeasurement voltage)
		{
			var amps = Watts / voltage.Volts;
			return CurrentMeasurement.FromAmps(amps);
		}

		public VoltageMeasurement GetVoltage(CurrentMeasurement current)
		{
			var volts = Watts / current.Amps;
			return VoltageMeasurement.FromVolts(volts);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static ElectricalPowerMeasurement None = new ElectricalPowerMeasurement(double.NaN);
#else
		public static ElectricalPowerMeasurement None = new ElectricalPowerMeasurement();
#endif
		public static ElectricalPowerMeasurement Zero = new ElectricalPowerMeasurement(0);
		public static ElectricalPowerMeasurement Min = new ElectricalPowerMeasurement(double.NegativeInfinity);
		public static ElectricalPowerMeasurement Max = new ElectricalPowerMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public ElectricalPowerMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new ElectricalPowerMeasurement(result);
		}

		public ElectricalPowerMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new ElectricalPowerMeasurement(result);
		}

		public ElectricalPowerMeasurement Add(ElectricalPowerMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new ElectricalPowerMeasurement(result);
		}

		public ElectricalPowerMeasurement Subtract(ElectricalPowerMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new ElectricalPowerMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static ElectricalPowerMeasurement Parse(string value)
		{
			return TryParse(value) ?? ElectricalPowerMeasurement.None;
		}

		public static ElectricalPowerMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new ElectricalPowerMeasurement(units);
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

			ElectricalPowerMeasurement other = obj as ElectricalPowerMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(ElectricalPowerMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(ElectricalPowerMeasurement a, ElectricalPowerMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator ElectricalPowerMeasurement(double value)
		{
			return new ElectricalPowerMeasurement(value);
		}

		public static implicit operator double(ElectricalPowerMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
