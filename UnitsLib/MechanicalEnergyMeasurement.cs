using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class MechanicalEnergyMeasurement : OverloadedMeasurementBase
	{
		public static MechanicalEnergyMeasurement FromNewtonMeters(double newtonMeters)
		{
			return new MechanicalEnergyMeasurement(newtonMeters);
		}

        public static MechanicalEnergyMeasurement FromForce(WeightMeasurement force, LengthMeasurement radius)
        {
            var newtonMeters = force.Newtons * radius.Meters;
            return MechanicalEnergyMeasurement.FromNewtonMeters(newtonMeters);
        }

		public static MechanicalEnergyMeasurement FromFootPounds(double footPounds)
		{
			var newtonMeters = footPounds * WeightMeasurement.NEWTONS_PER_POUND * LengthMeasurement.METERS_PER_FOOT;
			return MechanicalEnergyMeasurement.FromNewtonMeters(newtonMeters);
		}

		public static MechanicalEnergyMeasurement FromInchPounds(double inchPounds)
		{
			var footPounds = inchPounds / LengthMeasurement.INCHES_PER_FOOT;
			return FromFootPounds(footPounds);
		}

		public static MechanicalEnergyMeasurement FromBasicUnits(double basicUnits)
		{
			return new MechanicalEnergyMeasurement(basicUnits);
		}

		private MechanicalEnergyMeasurement(double newtonMeters)
			: base(newtonMeters)
		{
		}

#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		private MechanicalEnergyMeasurement()
			: base()
		{
		}
#endif

		public double NewtonMeters { get { return BasicUnits; } }

		public double KilogramMeters { get { return (NewtonMeters / WeightMeasurement.NEWTONS_PER_KILOGRAM); } }
		public double FootPounds { get { return (NewtonMeters / WeightMeasurement.NEWTONS_PER_POUND / LengthMeasurement.METERS_PER_FOOT); } }
		public double InchPounds { get { return (FootPounds * LengthMeasurement.INCHES_PER_FOOT); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static MechanicalEnergyMeasurement None = new MechanicalEnergyMeasurement(double.NaN);
#else
		public static MechanicalEnergyMeasurement None = new MechanicalEnergyMeasurement();
#endif
		public static MechanicalEnergyMeasurement Zero = new MechanicalEnergyMeasurement(0);
		public static MechanicalEnergyMeasurement Min = new MechanicalEnergyMeasurement(double.NegativeInfinity);
		public static MechanicalEnergyMeasurement Max = new MechanicalEnergyMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public MechanicalEnergyMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new MechanicalEnergyMeasurement(result);
		}

		public MechanicalEnergyMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new MechanicalEnergyMeasurement(result);
		}

		public MechanicalEnergyMeasurement Add(MechanicalEnergyMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new MechanicalEnergyMeasurement(result);
		}

		public MechanicalEnergyMeasurement Subtract(MechanicalEnergyMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new MechanicalEnergyMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static MechanicalEnergyMeasurement Parse(string value)
		{
			return TryParse(value) ?? MechanicalEnergyMeasurement.None;
		}

		public static MechanicalEnergyMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new MechanicalEnergyMeasurement(units);
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

			MechanicalEnergyMeasurement other = obj as MechanicalEnergyMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(MechanicalEnergyMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(MechanicalEnergyMeasurement a, MechanicalEnergyMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator MechanicalEnergyMeasurement(double value)
		{
			return new MechanicalEnergyMeasurement(value);
		}

		public static implicit operator double(MechanicalEnergyMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
