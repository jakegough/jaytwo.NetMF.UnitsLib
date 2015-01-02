using System;

namespace jaytwo.NetMF.UnitsLib
{	
	public class AreaMeasurement : OverloadedMeasurementBase
	{
		// as defined in the NSIT Handbook 44
		// http://www.nist.gov/pml/wmd/pubs/upload/2012-hb44-final.pdf

		internal const double SQ_METERS_PER_SQ_FOOT = (LengthMeasurement.METERS_PER_FOOT * LengthMeasurement.METERS_PER_FOOT);
		internal const double SQ_INCHES_PER_SQ_FOOT = 144;
		internal const double SQ_FEET_PER_SQ_YARD = 9;
		internal const double SQ_FEET_PER_ACRE = 43560;
		internal const double SQ_FEET_PER_SQ_MILE = 27878400;
		
		public static AreaMeasurement FromSquareMeters(double squareMeters)
		{
			return new AreaMeasurement(squareMeters);
		}

		public static AreaMeasurement FromSquareInches(double squareInches)
		{
			var squareFeet = (squareInches / SQ_INCHES_PER_SQ_FOOT);
			return FromSquareFeet(squareFeet);
		}

		public static AreaMeasurement FromSquareFeet(double squareFeet)
		{
			var squareMeters = (squareFeet * SQ_METERS_PER_SQ_FOOT);
			return AreaMeasurement.FromSquareMeters(squareMeters);
		}

		public static AreaMeasurement FromCircleRadius(LengthMeasurement radius)
		{
			return FromCircleRadiusMeters(radius.Meters);
		}

		public static AreaMeasurement FromCircleDiameter(LengthMeasurement diameter)
		{
			var radius = diameter.DivideBy(2);
			return FromCircleRadius(radius);
		}

		public static AreaMeasurement FromCircleRadiusMeters(double radiusMeters)
		{
			var squareMeters = (System.Math.PI * System.Math.Pow(radiusMeters, 2));
			return FromSquareMeters(squareMeters);
		}

		public static AreaMeasurement FromBasicUnits(double basicUnits)
		{
			return new AreaMeasurement(basicUnits);
		}

		private AreaMeasurement(double squareMeters)
			: base(squareMeters)
		{
		}

#if MF_FRAMEWORK_VERSION_V3_0 || MF_FRAMEWORK_VERSION_V4_0 || MF_FRAMEWORK_VERSION_V4_1
		private AreaMeasurement()
			: base()
		{
		}
#endif

		public double SquareMeters { get { return BasicUnits; } }

		public double SquareMillimeters { get { return (SquareMeters * (1000 * 1000)); } }
		public double SquareCentimeters { get { return (SquareMeters * (100 * 100)); } }
		public double SquareKilometers { get { return (SquareMeters / (1000 * 1000)); } }
		public double SquareInches { get { return (SquareFeet * SQ_INCHES_PER_SQ_FOOT); } }
		public double SquareFeet { get { return (SquareMeters / SQ_METERS_PER_SQ_FOOT); } }
		public double SquareYards { get { return (SquareFeet / SQ_FEET_PER_SQ_YARD); } }
		public double SquareMiles { get { return (SquareFeet / SQ_FEET_PER_SQ_MILE); } }
		public double Acres { get { return (SquareFeet / SQ_FEET_PER_ACRE); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static AreaMeasurement None = new AreaMeasurement(double.NaN);
#else
		public static AreaMeasurement None = new AreaMeasurement();
#endif
		public static AreaMeasurement Zero = new AreaMeasurement(0);
		public static AreaMeasurement Min = new AreaMeasurement(double.NegativeInfinity);
		public static AreaMeasurement Max = new AreaMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public AreaMeasurement MultiplyBy(double value)
		{
			return new AreaMeasurement(BasicUnits * value);
		}

		public AreaMeasurement DivideBy(double value)
		{
			return new AreaMeasurement(BasicUnits / value);
		}

		public AreaMeasurement Add(AreaMeasurement value)
		{
			return new AreaMeasurement(BasicUnits + value.BasicUnits);
		}

		public AreaMeasurement Subtract(AreaMeasurement value)
		{
			return new AreaMeasurement(BasicUnits - value.BasicUnits);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static AreaMeasurement Parse(string value)
		{
			return TryParse(value) ?? AreaMeasurement.None;
		}

		public static AreaMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new AreaMeasurement(units);
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

			AreaMeasurement other = obj as AreaMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(AreaMeasurement other)
		{
			return !OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(AreaMeasurement a, AreaMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(AreaMeasurement a, AreaMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(AreaMeasurement a, AreaMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(AreaMeasurement a, AreaMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(AreaMeasurement a, AreaMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(AreaMeasurement a, AreaMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator AreaMeasurement(double value)
		{
			return new AreaMeasurement(value); 
		}

		public static implicit operator double(AreaMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return BasicUnits.GetHashCode();
		}
	}
}
