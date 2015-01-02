using System;

namespace jaytwo.NetMF.UnitsLib
{
	public class PressureMeasurement : OverloadedMeasurementBase
	{
		// 1 pascal = 1 newton per sq meter
		// 1 bar = 100,000 newtons per sq meter
		const double PSI_PER_BAR = 14.5037738;
		const double BAR_PER_ATM = 1.01325;
		const double KGCM2_PER_BAR = 1.01971621298; // http://www.convertunits.com/info/kilograms+per+square+centimeter
		const double MMHG_PER_ATM = 760;

		public static PressureMeasurement FromPsi(double psi)
		{
			var bar = (psi / PSI_PER_BAR);
			return FromBar(bar);
		}

		public static PressureMeasurement FromBar(double bar)
		{
			return new PressureMeasurement(bar);
		}

		public static PressureMeasurement FromKpa(double kpa)
		{
			var bar = kpa / 100;
			return PressureMeasurement.FromBar(bar);
		}

		public static PressureMeasurement FromMpa(double mpa)
		{
			var bar = mpa * 10;
			return FromBar(bar);
		}

		public static PressureMeasurement FromPa(double pa)
		{
			var bar = pa / 100000;
			return FromBar(bar);
		}

		public static PressureMeasurement FromKgCm2(double kgPerCc)
		{
			var bar = kgPerCc / KGCM2_PER_BAR;
			return FromBar(bar);
		}

		public static PressureMeasurement FromMmhg(double mmhg)
		{
			var atm = mmhg / MMHG_PER_ATM;
			return FromAtm(atm);
		}

		public static PressureMeasurement FromAtm(double atm)
		{
			var bar = atm * BAR_PER_ATM;
			return FromBar(bar);
		}

		public static PressureMeasurement FromBasicUnits(double basicUnits)
		{
			return new PressureMeasurement(basicUnits);
		}

		private PressureMeasurement(double bar)
			: base(bar)
		{
		}

#if !MF_FRAMEWORK_VERSION_V4_2
		private PressureMeasurement()
			: base()
		{
		}
#endif

		public double Bar { get { return BasicUnits; } }
		public double Psi { get { return (Bar * PSI_PER_BAR); } }
		public double Pa { get { return (Bar * 100000); } }
		public double Kpa { get { return (Bar * 100); } }
		public double Mpa { get { return (Bar / 10); } }
		public double Mmhg { get { return (Atm * MMHG_PER_ATM); } }
		public double Atm { get { return (Bar / BAR_PER_ATM); } }
		public double KgCm2 { get { return (Bar * KGCM2_PER_BAR); } }

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static PressureMeasurement None = new PressureMeasurement(double.NaN);
#else
		public static PressureMeasurement None = new PressureMeasurement();
#endif
		public static PressureMeasurement Zero = new PressureMeasurement(0);
		public static PressureMeasurement Min = new PressureMeasurement(double.NegativeInfinity);
		public static PressureMeasurement Max = new PressureMeasurement(double.PositiveInfinity);

		public override string ToString()
		{
			return BasicUnits.ToString();
		}

		public PressureMeasurement MultiplyBy(double value)
		{
			var result = (BasicUnits * value);
			return new PressureMeasurement(result);
		}

		public PressureMeasurement DivideBy(double value)
		{
			var result = (BasicUnits / value);
			return new PressureMeasurement(result);
		}

		public PressureMeasurement Add(PressureMeasurement value)
		{
			var result = (BasicUnits + value.BasicUnits);
			return new PressureMeasurement(result);
		}

		public PressureMeasurement Subtract(PressureMeasurement value)
		{
			var result = (BasicUnits - value.BasicUnits);
			return new PressureMeasurement(result);
		}

#if !MF_FRAMEWORK_VERSION_V3_0 && !MF_FRAMEWORK_VERSION_V4_0 && !MF_FRAMEWORK_VERSION_V4_1
		public static PressureMeasurement Parse(string value)
		{
			return TryParse(value) ?? PressureMeasurement.None;
		}

		public static PressureMeasurement TryParse(string value)
		{
			double units;
			if (double.TryParse(value, out units))
			{
				return new PressureMeasurement(units);
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

			PressureMeasurement other = obj as PressureMeasurement;
			if ((object)other == null)
			{
				return false;
			}

			return MeasurementHelpers.AreDoublesEqual(BasicUnits, other.BasicUnits);
		}

		public bool Equals(PressureMeasurement other)
		{
			return OverloadedMeasurementBase.IsEqualTo(this, other);
		}

		public static bool operator ==(PressureMeasurement a, PressureMeasurement b)
		{
			return OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator !=(PressureMeasurement a, PressureMeasurement b)
		{
			return !OverloadedMeasurementBase.IsEqualTo(a, b);
		}

		public static bool operator >(PressureMeasurement a, PressureMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThan(a, b);
		}

		public static bool operator >=(PressureMeasurement a, PressureMeasurement b)
		{
			return OverloadedMeasurementBase.IsGreaterThanOrEqual(a, b);
		}

		public static bool operator <(PressureMeasurement a, PressureMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThan(a, b);
		}

		public static bool operator <=(PressureMeasurement a, PressureMeasurement b)
		{
			return OverloadedMeasurementBase.IsLessThanOrEqual(a, b);
		}

		public static implicit operator PressureMeasurement(double value)
		{
			return new PressureMeasurement(value);
		}

		public static implicit operator double(PressureMeasurement value)
		{
			return value.BasicUnits;
		}

		public override int GetHashCode()
		{
			return OverloadedMeasurementBase.GetHashCode(this);
		}
	}
}
