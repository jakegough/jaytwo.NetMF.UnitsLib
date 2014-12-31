using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class CurrentMeasurementTests
	{
		[Test]
		public void current_amps_milliamps()
		{
			var fromAmps = CurrentMeasurement.FromAmps(1);
			Assert.AreEqual(1, fromAmps.Amps);
			Assert.AreEqual(1000, fromAmps.Milliamps);

			var fromMilliamps = CurrentMeasurement.FromMilliamps(1000);
			Assert.AreEqual(1, fromMilliamps.Amps);
			Assert.AreEqual(1000, fromMilliamps.Milliamps);
		}

		[Test]
		public void current_static_members()
		{
			Assert.AreEqual(0, CurrentMeasurement.Zero.Amps);
			Assert.AreEqual(0, CurrentMeasurement.Zero.Amps * 10);
			Assert.AreEqual(0, CurrentMeasurement.Zero.Amps / 10);

			Assert.AreEqual(double.NaN, CurrentMeasurement.None.Amps);
			Assert.AreEqual(double.NaN, CurrentMeasurement.None.Amps * 10);
			Assert.AreEqual(double.NaN, CurrentMeasurement.None.Amps / 10);

			Assert.AreEqual(double.PositiveInfinity, CurrentMeasurement.Max.Amps);
			Assert.AreEqual(double.PositiveInfinity, CurrentMeasurement.Max.Amps * 10);
			Assert.AreEqual(double.PositiveInfinity, CurrentMeasurement.Max.Amps / 10);

			Assert.AreEqual(double.NegativeInfinity, CurrentMeasurement.Min.Amps);
			Assert.AreEqual(double.NegativeInfinity, CurrentMeasurement.Min.Amps * 10);
			Assert.AreEqual(double.NegativeInfinity, CurrentMeasurement.Min.Amps / 10);
		}

		[Test]
		public void current_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = CurrentMeasurement.FromAmps(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Amps, CurrentMeasurement.Parse(testString).Amps);

			Assert.IsNull(CurrentMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, CurrentMeasurement.Parse("hello").Amps);
		}

		[Test]
		public void current_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(CurrentMeasurement.FromAmps(2) == CurrentMeasurement.FromAmps(1));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) == CurrentMeasurement.FromAmps(2));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) == CurrentMeasurement.FromAmps(1));

			Assert.IsTrue(CurrentMeasurement.FromAmps(2) != CurrentMeasurement.FromAmps(1));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) != CurrentMeasurement.FromAmps(2));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) != CurrentMeasurement.FromAmps(1));

			Assert.IsTrue(CurrentMeasurement.FromAmps(2) > CurrentMeasurement.FromAmps(1));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) > CurrentMeasurement.FromAmps(2));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) > CurrentMeasurement.FromAmps(1));

			Assert.IsTrue(CurrentMeasurement.FromAmps(2) >= CurrentMeasurement.FromAmps(1));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) >= CurrentMeasurement.FromAmps(2));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) >= CurrentMeasurement.FromAmps(1));

			Assert.IsFalse(CurrentMeasurement.FromAmps(2) < CurrentMeasurement.FromAmps(1));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) < CurrentMeasurement.FromAmps(2));
			Assert.IsFalse(CurrentMeasurement.FromAmps(1) < CurrentMeasurement.FromAmps(1));

			Assert.IsFalse(CurrentMeasurement.FromAmps(2) <= CurrentMeasurement.FromAmps(1));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) <= CurrentMeasurement.FromAmps(2));
			Assert.IsTrue(CurrentMeasurement.FromAmps(1) <= CurrentMeasurement.FromAmps(1));
		}

		[Test]
		public void current_multiply_divide_add_subtract()
		{
			Assert.AreEqual(CurrentMeasurement.FromAmps(100),
				CurrentMeasurement.FromAmps(50).Add(CurrentMeasurement.FromAmps(50)));

			Assert.AreEqual(CurrentMeasurement.FromAmps(50),
				CurrentMeasurement.FromAmps(100).Subtract(CurrentMeasurement.FromAmps(50)));

			Assert.AreEqual(CurrentMeasurement.FromAmps(200),
				CurrentMeasurement.FromAmps(100).MultiplyBy(2));

			Assert.AreEqual(CurrentMeasurement.FromAmps(50),
				CurrentMeasurement.FromAmps(100).DivideBy(2));
		}

		[Test]
		public void current_implicit_double_conversion()
		{
			Assert.AreEqual((double)CurrentMeasurement.FromAmps(100), 100d);
			Assert.AreEqual(CurrentMeasurement.FromAmps(100), (CurrentMeasurement)100d);
		}
	}
}
