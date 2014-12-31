using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using jaytwo.NetMF.UnitsLib;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class FrequencyMeasurementTests
	{
		[Test]
		public void frequency_hz_wavelength()
		{
			var millisecond = TimeSpan.FromMilliseconds(10);

			var fromWavelength = FrequencyMeasurement.FromWavelength(millisecond);
			Assert.AreEqual(100, fromWavelength.Hz);
		}

		[Test]
		public void frequency_hz_rpm()
		{
			var fromHz = FrequencyMeasurement.FromHz(10);
			Assert.AreEqual(600, fromHz.RPM);
			Assert.AreEqual(10, fromHz.Hz);

			var fromRpm = FrequencyMeasurement.FromRpm(600);
			Assert.AreEqual(600, fromRpm.RPM);
			Assert.AreEqual(10, fromRpm.Hz);
		}

		[Test]
		public void frequency_hz_khz_mhz_ghz()
		{
			var fromHz = FrequencyMeasurement.FromHz(1000);
			Assert.AreEqual(1000, fromHz.Hz);
			Assert.AreEqual(1, fromHz.Khz);
			Assert.AreEqual(.001, fromHz.Mhz);
			Assert.AreEqual(.000001, fromHz.Ghz);

			var fromKhz = FrequencyMeasurement.FromKhz(1);
			Assert.AreEqual(1000, fromKhz.Hz);
			Assert.AreEqual(1, fromKhz.Khz);
			Assert.AreEqual(.001, fromKhz.Mhz);
			Assert.AreEqual(.000001, fromKhz.Ghz);

			var fromMhz = FrequencyMeasurement.FromMhz(.001);
			Assert.AreEqual(1000, fromMhz.Hz);
			Assert.AreEqual(1, fromMhz.Khz);
			Assert.AreEqual(.001, fromMhz.Mhz);
			Assert.AreEqual(.000001, fromMhz.Ghz);

			var fromGhz = FrequencyMeasurement.FromGhz(.000001);
			Assert.AreEqual(1000, fromGhz.Hz);
			Assert.AreEqual(1, fromGhz.Khz);
			Assert.AreEqual(.001, fromGhz.Mhz);
			Assert.AreEqual(.000001, fromGhz.Ghz);

		}

		[Test]
		public void frequency_static_members()
		{
			Assert.AreEqual(0, FrequencyMeasurement.Zero.Hz);
			Assert.AreEqual(0, FrequencyMeasurement.Zero.Hz * 10);
			Assert.AreEqual(0, FrequencyMeasurement.Zero.Hz / 10);

			Assert.AreEqual(double.NaN, FrequencyMeasurement.None.Hz);
			Assert.AreEqual(double.NaN, FrequencyMeasurement.None.Hz * 10);
			Assert.AreEqual(double.NaN, FrequencyMeasurement.None.Hz / 10);

			Assert.AreEqual(double.PositiveInfinity, FrequencyMeasurement.Max.Hz);
			Assert.AreEqual(double.PositiveInfinity, FrequencyMeasurement.Max.Hz * 10);
			Assert.AreEqual(double.PositiveInfinity, FrequencyMeasurement.Max.Hz / 10);

			Assert.AreEqual(double.NegativeInfinity, FrequencyMeasurement.Min.Hz);
			Assert.AreEqual(double.NegativeInfinity, FrequencyMeasurement.Min.Hz * 10);
			Assert.AreEqual(double.NegativeInfinity, FrequencyMeasurement.Min.Hz / 10);
		}

		[Test]
		public void frequency_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = FrequencyMeasurement.FromHz(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Hz, FrequencyMeasurement.Parse(testString).Hz);

			Assert.IsNull(FrequencyMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, FrequencyMeasurement.Parse("hello").Hz);
		}

		[Test]
		public void frequency_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(FrequencyMeasurement.FromHz(2) == FrequencyMeasurement.FromHz(1));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) == FrequencyMeasurement.FromHz(2));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) == FrequencyMeasurement.FromHz(1));

			Assert.IsTrue(FrequencyMeasurement.FromHz(2) != FrequencyMeasurement.FromHz(1));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) != FrequencyMeasurement.FromHz(2));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) != FrequencyMeasurement.FromHz(1));

			Assert.IsTrue(FrequencyMeasurement.FromHz(2) > FrequencyMeasurement.FromHz(1));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) > FrequencyMeasurement.FromHz(2));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) > FrequencyMeasurement.FromHz(1));

			Assert.IsTrue(FrequencyMeasurement.FromHz(2) >= FrequencyMeasurement.FromHz(1));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) >= FrequencyMeasurement.FromHz(2));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) >= FrequencyMeasurement.FromHz(1));

			Assert.IsFalse(FrequencyMeasurement.FromHz(2) < FrequencyMeasurement.FromHz(1));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) < FrequencyMeasurement.FromHz(2));
			Assert.IsFalse(FrequencyMeasurement.FromHz(1) < FrequencyMeasurement.FromHz(1));

			Assert.IsFalse(FrequencyMeasurement.FromHz(2) <= FrequencyMeasurement.FromHz(1));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) <= FrequencyMeasurement.FromHz(2));
			Assert.IsTrue(FrequencyMeasurement.FromHz(1) <= FrequencyMeasurement.FromHz(1));
		}

		[Test]
		public void frequency_multiply_divide_add_subtract()
		{
			Assert.AreEqual(FrequencyMeasurement.FromHz(100), 
				FrequencyMeasurement.FromHz(50).Add(FrequencyMeasurement.FromHz(50)));

			Assert.AreEqual(FrequencyMeasurement.FromHz(50),
				FrequencyMeasurement.FromHz(100).Subtract(FrequencyMeasurement.FromHz(50)));

			Assert.AreEqual(FrequencyMeasurement.FromHz(200),
				FrequencyMeasurement.FromHz(100).MultiplyBy(2));

			Assert.AreEqual(FrequencyMeasurement.FromHz(50),
				FrequencyMeasurement.FromHz(100).DivideBy(2));
		}

		[Test]
		public void frequency_implicit_double_conversion()
		{
			Assert.AreEqual((double)FrequencyMeasurement.FromHz(100), 100d);
			Assert.AreEqual(FrequencyMeasurement.FromHz(100), (FrequencyMeasurement)100d);
		}
	}
}
