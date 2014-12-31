using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class PressureMeasurementTests
	{
		[Test]
		public void pressure_bar_psi()
		{
			var fromBar = PressureMeasurement.FromBar(100);
			Assert.AreEqual(100, fromBar.Bar);
			Assert.AreEqual(1450.37738, fromBar.Psi);

			var fromPsi = PressureMeasurement.FromPsi(1450.37738);
			Assert.AreEqual(100, fromPsi.Bar);
			Assert.AreEqual(1450.37738, fromPsi.Psi);
		}

		[Test]
		public void pressure_kgcm2_bar()
		{
			var fromBar = PressureMeasurement.FromBar(1);
			Assert.AreEqual(1, fromBar.Bar);
			Assert.AreEqual(1.01971621298, fromBar.KgCm2);

			var fromKgCm2 = PressureMeasurement.FromKgCm2(1.01971621298);
			Assert.AreEqual(1, fromKgCm2.Bar);
			Assert.AreEqual(1.01971621298, fromKgCm2.KgCm2);
		}

		[Test]
		public void pressure_bar_kpa_mpa_atm()
		{
			var fromBar = PressureMeasurement.FromBar(1.01325);
			Assert.AreEqual(1.01325, fromBar.Bar);
			Assert.AreEqual(101.325, fromBar.Kpa);
			Assert.AreEqual(0.101325, fromBar.Mpa);
			Assert.AreEqual(1, fromBar.Atm);

			var fromKpa = PressureMeasurement.FromKpa(101.325);
			Assert.AreEqual(1.01325, fromKpa.Bar);
			Assert.AreEqual(101.325, fromKpa.Kpa);
			Assert.AreEqual(0.101325, fromBar.Mpa);
			Assert.AreEqual(1, fromKpa.Atm);

			var fromMpa = PressureMeasurement.FromMpa(0.101325);
			Assert.AreEqual(1.01325, fromKpa.Bar);
			Assert.AreEqual(101.325, fromKpa.Kpa);
			Assert.AreEqual(0.101325, fromBar.Mpa);
			Assert.AreEqual(1, fromKpa.Atm);

			var fromAtm = PressureMeasurement.FromAtm(1);
			Assert.AreEqual(1.01325, fromAtm.Bar);
			Assert.AreEqual(101.325, fromAtm.Kpa);
			Assert.AreEqual(0.101325, fromBar.Mpa);
			Assert.AreEqual(1, fromAtm.Atm);
		}

		[Test]
		public void pressure_pa_kpa_mpa()
		{
			var fromMpa = PressureMeasurement.FromMpa(1);
			Assert.AreEqual(1, fromMpa.Mpa);
			Assert.AreEqual(1000, fromMpa.Kpa);
			Assert.AreEqual(1000000, fromMpa.Pa);

			var fromKpa = PressureMeasurement.FromKpa(1000);
			Assert.AreEqual(1, fromKpa.Mpa);
			Assert.AreEqual(1000, fromKpa.Kpa);
			Assert.AreEqual(1000000, fromKpa.Pa);

			var fromPa = PressureMeasurement.FromPa(1000000);
			Assert.AreEqual(1, fromPa.Mpa);
			Assert.AreEqual(1000, fromPa.Kpa);
			Assert.AreEqual(1000000, fromPa.Pa);
		}

		[Test]
		public void pressure_atm_mmhg()
		{
			var fromAtm = PressureMeasurement.FromAtm(1);
			Assert.AreEqual(1, fromAtm.Atm);
			Assert.AreEqual(760, fromAtm.Mmhg);

			var fromMmhg = PressureMeasurement.FromMmhg(760);
			Assert.AreEqual(1, fromMmhg.Atm);
			Assert.AreEqual(760, fromMmhg.Mmhg);
		}

		[Test]
		public void pressure_static_members()
		{
			Assert.AreEqual(0, PressureMeasurement.Zero.Bar);
			Assert.AreEqual(0, PressureMeasurement.Zero.Bar * 10);
			Assert.AreEqual(0, PressureMeasurement.Zero.Bar / 10);

			Assert.AreEqual(double.NaN, PressureMeasurement.None.Bar);
			Assert.AreEqual(double.NaN, PressureMeasurement.None.Bar * 10);
			Assert.AreEqual(double.NaN, PressureMeasurement.None.Bar / 10);

			Assert.AreEqual(double.PositiveInfinity, PressureMeasurement.Max.Bar);
			Assert.AreEqual(double.PositiveInfinity, PressureMeasurement.Max.Bar * 10);
			Assert.AreEqual(double.PositiveInfinity, PressureMeasurement.Max.Bar / 10);

			Assert.AreEqual(double.NegativeInfinity, PressureMeasurement.Min.Bar);
			Assert.AreEqual(double.NegativeInfinity, PressureMeasurement.Min.Bar * 10);
			Assert.AreEqual(double.NegativeInfinity, PressureMeasurement.Min.Bar / 10);
		}

		[Test]
		public void pressure_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = PressureMeasurement.FromBar(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Bar, PressureMeasurement.Parse(testString).Bar);

			Assert.IsNull(PressureMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, PressureMeasurement.Parse("hello").Bar);
		}

		[Test]
		public void pressure_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(PressureMeasurement.FromBar(2) == PressureMeasurement.FromBar(1));
			Assert.IsFalse(PressureMeasurement.FromBar(1) == PressureMeasurement.FromBar(2));
			Assert.IsTrue(PressureMeasurement.FromBar(1) == PressureMeasurement.FromBar(1));

			Assert.IsTrue(PressureMeasurement.FromBar(2) != PressureMeasurement.FromBar(1));
			Assert.IsTrue(PressureMeasurement.FromBar(1) != PressureMeasurement.FromBar(2));
			Assert.IsFalse(PressureMeasurement.FromBar(1) != PressureMeasurement.FromBar(1));

			Assert.IsTrue(PressureMeasurement.FromBar(2) > PressureMeasurement.FromBar(1));
			Assert.IsFalse(PressureMeasurement.FromBar(1) > PressureMeasurement.FromBar(2));
			Assert.IsFalse(PressureMeasurement.FromBar(1) > PressureMeasurement.FromBar(1));

			Assert.IsTrue(PressureMeasurement.FromBar(2) >= PressureMeasurement.FromBar(1));
			Assert.IsFalse(PressureMeasurement.FromBar(1) >= PressureMeasurement.FromBar(2));
			Assert.IsTrue(PressureMeasurement.FromBar(1) >= PressureMeasurement.FromBar(1));

			Assert.IsFalse(PressureMeasurement.FromBar(2) < PressureMeasurement.FromBar(1));
			Assert.IsTrue(PressureMeasurement.FromBar(1) < PressureMeasurement.FromBar(2));
			Assert.IsFalse(PressureMeasurement.FromBar(1) < PressureMeasurement.FromBar(1));

			Assert.IsFalse(PressureMeasurement.FromBar(2) <= PressureMeasurement.FromBar(1));
			Assert.IsTrue(PressureMeasurement.FromBar(1) <= PressureMeasurement.FromBar(2));
			Assert.IsTrue(PressureMeasurement.FromBar(1) <= PressureMeasurement.FromBar(1));
		}

		[Test]
		public void pressure_multiply_divide_add_subtract()
		{
			Assert.AreEqual(PressureMeasurement.FromBar(100),
				PressureMeasurement.FromBar(50).Add(PressureMeasurement.FromBar(50)));

			Assert.AreEqual(PressureMeasurement.FromBar(50),
				PressureMeasurement.FromBar(100).Subtract(PressureMeasurement.FromBar(50)));

			Assert.AreEqual(PressureMeasurement.FromBar(200),
				PressureMeasurement.FromBar(100).MultiplyBy(2));

			Assert.AreEqual(PressureMeasurement.FromBar(50),
				PressureMeasurement.FromBar(100).DivideBy(2));
		}

		[Test]
		public void pressure_implicit_double_conversion()
		{
			Assert.AreEqual((double)PressureMeasurement.FromBar(100), 100d);
			Assert.AreEqual(PressureMeasurement.FromBar(100), (PressureMeasurement)100d);
		}
	}
}
