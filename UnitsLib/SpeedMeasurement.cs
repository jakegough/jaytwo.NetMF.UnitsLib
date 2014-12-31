using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class SpeedMeasurement : OverloadedMeasurementBase
	{
		public static SpeedMeasurement FromKilometersPerHour(double kilometersPerHour)
		{
			return new SpeedMeasurement(kilometersPerHour);
		}

		public static SpeedMeasurement FromMilesPerHour(double milesPerHour)
		{
			var kilometersPerHour = milesPerHour * LengthMeasurement.KILOMETERS_PER_MILE;
			return new SpeedMeasurement(kilometersPerHour);
		}

		public SpeedMeasurement(double kilometersPerHour)
			: base(kilometersPerHour)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private SpeedMeasurement()
			: base()
		{
		}
#endif

		public double KilometersPerHour { get { return BasicUnits; } }

		public double MilesPerHour { get { return (KilometersPerHour / LengthMeasurement.KILOMETERS_PER_MILE); } }

#if MF_FRAMEWORK_VERSION_V4_2
		public static SpeedMeasurement None = new SpeedMeasurement(double.NaN);
#else
		public static SpeedMeasurement None = new SpeedMeasurement();
#endif
		public static SpeedMeasurement Zero = new SpeedMeasurement(0);
		public static SpeedMeasurement Min = new SpeedMeasurement(double.NegativeInfinity);
		public static SpeedMeasurement Max = new SpeedMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public SpeedMeasurement MultiplyBy(double value)
		{
			return new SpeedMeasurement(BasicUnits * value);
		}

		public SpeedMeasurement DivideBy(double value)
		{
			return new SpeedMeasurement(BasicUnits / value);
		}

		public SpeedMeasurement Add(SpeedMeasurement value)
		{
			return new SpeedMeasurement(BasicUnits + value.BasicUnits);
		}

		public SpeedMeasurement Subtract(SpeedMeasurement value)
		{
			return new SpeedMeasurement(BasicUnits - value.BasicUnits);
		}

#if MF_FRAMEWORK_VERSION_V4_2
		public static SpeedMeasurement Parse(string value)
		{
			return TryParse(value) ?? SpeedMeasurement.None;
		}

		public static SpeedMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new SpeedMeasurement(units);
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

			SpeedMeasurement other = obj as SpeedMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(SpeedMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(SpeedMeasurement a, SpeedMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(SpeedMeasurement a, SpeedMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(SpeedMeasurement a, SpeedMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(SpeedMeasurement a, SpeedMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(SpeedMeasurement a, SpeedMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(SpeedMeasurement a, SpeedMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator SpeedMeasurement(double value)
		{
			return new SpeedMeasurement(value);
		}

		public static implicit operator double(SpeedMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
