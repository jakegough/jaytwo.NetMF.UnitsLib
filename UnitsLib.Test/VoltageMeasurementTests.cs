using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class VoltageMeasurementTests
	{
		[Test]
		public void voltage_volts_millivolts()
		{
			var fromVolts = VoltageMeasurement.FromVolts(1);
			Assert.AreEqual(1, fromVolts.Volts);
			Assert.AreEqual(1000, fromVolts.Millivolts);

			var fromMillivolts = VoltageMeasurement.FromMillivolts(1000);
			Assert.AreEqual(1, fromMillivolts.Volts);
			Assert.AreEqual(1000, fromMillivolts.Millivolts);
		}

		[Test]
		public void voltage_static_members()
		{
			Assert.AreEqual(0, VoltageMeasurement.Zero.Volts);
			Assert.AreEqual(0, VoltageMeasurement.Zero.Volts * 10);
			Assert.AreEqual(0, VoltageMeasurement.Zero.Volts / 10);

			Assert.AreEqual(double.NaN, VoltageMeasurement.None.Volts);
			Assert.AreEqual(double.NaN, VoltageMeasurement.None.Volts * 10);
			Assert.AreEqual(double.NaN, VoltageMeasurement.None.Volts / 10);

			Assert.AreEqual(double.PositiveInfinity, VoltageMeasurement.Max.Volts);
			Assert.AreEqual(double.PositiveInfinity, VoltageMeasurement.Max.Volts * 10);
			Assert.AreEqual(double.PositiveInfinity, VoltageMeasurement.Max.Volts / 10);

			Assert.AreEqual(double.NegativeInfinity, VoltageMeasurement.Min.Volts);
			Assert.AreEqual(double.NegativeInfinity, VoltageMeasurement.Min.Volts * 10);
			Assert.AreEqual(double.NegativeInfinity, VoltageMeasurement.Min.Volts / 10);
		}

		[Test]
		public void voltage_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = VoltageMeasurement.FromVolts(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Volts, VoltageMeasurement.Parse(testString).Volts);

			Assert.IsNull(VoltageMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, VoltageMeasurement.Parse("hello").Volts);
		}

		[Test]
		public void voltage_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(VoltageMeasurement.FromVolts(2) == VoltageMeasurement.FromVolts(1));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) == VoltageMeasurement.FromVolts(2));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) == VoltageMeasurement.FromVolts(1));

			Assert.IsTrue(VoltageMeasurement.FromVolts(2) != VoltageMeasurement.FromVolts(1));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) != VoltageMeasurement.FromVolts(2));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) != VoltageMeasurement.FromVolts(1));

			Assert.IsTrue(VoltageMeasurement.FromVolts(2) > VoltageMeasurement.FromVolts(1));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) > VoltageMeasurement.FromVolts(2));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) > VoltageMeasurement.FromVolts(1));

			Assert.IsTrue(VoltageMeasurement.FromVolts(2) >= VoltageMeasurement.FromVolts(1));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) >= VoltageMeasurement.FromVolts(2));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) >= VoltageMeasurement.FromVolts(1));

			Assert.IsFalse(VoltageMeasurement.FromVolts(2) < VoltageMeasurement.FromVolts(1));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) < VoltageMeasurement.FromVolts(2));
			Assert.IsFalse(VoltageMeasurement.FromVolts(1) < VoltageMeasurement.FromVolts(1));

			Assert.IsFalse(VoltageMeasurement.FromVolts(2) <= VoltageMeasurement.FromVolts(1));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) <= VoltageMeasurement.FromVolts(2));
			Assert.IsTrue(VoltageMeasurement.FromVolts(1) <= VoltageMeasurement.FromVolts(1));
		}

		[Test]
		public void voltage_multiply_divide_add_subtract()
		{
			Assert.AreEqual(VoltageMeasurement.FromVolts(100),
				VoltageMeasurement.FromVolts(50).Add(VoltageMeasurement.FromVolts(50)));

			Assert.AreEqual(VoltageMeasurement.FromVolts(50),
				VoltageMeasurement.FromVolts(100).Subtract(VoltageMeasurement.FromVolts(50)));

			Assert.AreEqual(VoltageMeasurement.FromVolts(200),
				VoltageMeasurement.FromVolts(100).MultiplyBy(2));

			Assert.AreEqual(VoltageMeasurement.FromVolts(50),
				VoltageMeasurement.FromVolts(100).DivideBy(2));
		}

		[Test]
		public void voltage_implicit_double_conversion()
		{
			Assert.AreEqual((double)VoltageMeasurement.FromVolts(100), 100d);
			Assert.AreEqual(VoltageMeasurement.FromVolts(100), (VoltageMeasurement)100d);
		}
	}
}
