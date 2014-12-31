using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using jaytwo.NetMF.UnitsLib;
using NUnit.Framework;

namespace jaytwo.NetMF.UnitsLib.Test.MeasurementUnits
{
	[TestFixture]
	public class WeightMeasurementTests
	{
		[Test]
		public void weight_kilograms_newtons()
		{
			var fromKilograms = WeightMeasurement.FromKilograms(1);
			Assert.AreEqual(1, fromKilograms.Kilograms);
			Assert.AreEqual(9.80665, fromKilograms.Newtons);

			var fromNewtons = WeightMeasurement.FromNewtons(9.80665);
			Assert.AreEqual(1, fromNewtons.Kilograms);
			Assert.AreEqual(9.80665, fromNewtons.Newtons);
		}

        [Test]
        public void weight_from_torque()
        {
            Assert.AreEqual(10d, WeightMeasurement.FromTorque(
                MechanicalEnergyMeasurement.FromNewtonMeters(10),
                LengthMeasurement.FromMeters(1))
                    .Newtons);

            Assert.AreEqual(10d, WeightMeasurement.FromTorque(
                MechanicalEnergyMeasurement.FromNewtonMeters(20),
                LengthMeasurement.FromMeters(2))
                    .Newtons);

            Assert.AreEqual(10d, WeightMeasurement.FromTorque(
                MechanicalEnergyMeasurement.FromNewtonMeters(5),
                LengthMeasurement.FromMeters(.5))
                    .Newtons);
        }

		[Test]
		public void weight_FromTorque_ftlbs()
		{
			var torque = MechanicalEnergyMeasurement.FromFootPounds(1);
			var radius = LengthMeasurement.FromFeet(1);
			var result = WeightMeasurement.FromTorque(torque, radius);
			Assert.AreEqual(1d, result.Pounds, 0.00001);
		}

		[Test]
		public void weight_FromPressure_psi()
		{
			var pressure = PressureMeasurement.FromPsi(1);
			var area = AreaMeasurement.FromSquareInches(1);
			var result = WeightMeasurement.FromPressure(pressure, area);
			Assert.AreEqual(1d, result.Pounds, 0.00001);
		}

		[Test]
		public void weight_FromPressure()
		{
			var pressure = PressureMeasurement.FromPa(1);
			var area = AreaMeasurement.FromSquareMeters(1);
			var result = WeightMeasurement.FromPressure(pressure, area);
			Assert.AreEqual(1d, result.Newtons);
		}

		[Test]
		public void weight_pounds_kolograms()
		{
			var fromPounds = WeightMeasurement.FromPounds(1);
			Assert.AreEqual(1, fromPounds.Pounds);
			Assert.AreEqual(0.45359237, fromPounds.Kilograms);

			var fromKilograms = WeightMeasurement.FromKilograms(0.45359237);
			Assert.AreEqual(1, fromKilograms.Pounds);
			Assert.AreEqual(0.45359237, fromKilograms.Kilograms);
		}

		[Test]
		public void weight_pounds_grains()
		{
			var fromPounds = WeightMeasurement.FromPounds(1);
			Assert.AreEqual(1, fromPounds.Pounds);
			Assert.AreEqual(7000, fromPounds.Grains);
		}

		[Test]
		public void weight_ounces_pounds_tons()
		{
			var fromPounds = WeightMeasurement.FromPounds(2000);
			Assert.AreEqual(32000, fromPounds.Ounces);
			Assert.AreEqual(2000, fromPounds.Pounds);
			Assert.AreEqual(1, fromPounds.Tons);
		}

		[Test]
		public void weight_grams_kilograms_metrictons()
		{
			var fromKilograms = WeightMeasurement.FromKilograms(1000);
			Assert.AreEqual(1000000, fromKilograms.Grams);
			Assert.AreEqual(1000, fromKilograms.Kilograms);
			Assert.AreEqual(1, fromKilograms.MetricTons);
		}

		[Test]
		public void weight_static_members()
		{
			Assert.AreEqual(0, WeightMeasurement.Zero.Kilograms);
			Assert.AreEqual(0, WeightMeasurement.Zero.Kilograms * 10);
			Assert.AreEqual(0, WeightMeasurement.Zero.Kilograms / 10);

			Assert.AreEqual(double.NaN, WeightMeasurement.None.Kilograms);
			Assert.AreEqual(double.NaN, WeightMeasurement.None.Kilograms * 10);
			Assert.AreEqual(double.NaN, WeightMeasurement.None.Kilograms / 10);

			Assert.AreEqual(double.PositiveInfinity, WeightMeasurement.Max.Kilograms);
			Assert.AreEqual(double.PositiveInfinity, WeightMeasurement.Max.Kilograms * 10);
			Assert.AreEqual(double.PositiveInfinity, WeightMeasurement.Max.Kilograms / 10);

			Assert.AreEqual(double.NegativeInfinity, WeightMeasurement.Min.Kilograms);
			Assert.AreEqual(double.NegativeInfinity, WeightMeasurement.Min.Kilograms * 10);
			Assert.AreEqual(double.NegativeInfinity, WeightMeasurement.Min.Kilograms / 10);
		}

		[Test]
		public void weight_tostring_parse()
		{
			var testDouble = 1234.5678d;
			var testString = testDouble.ToString();
			var testUnits = WeightMeasurement.FromKilograms(testDouble);

			Assert.AreEqual(testString, testUnits.ToString());
			Assert.AreEqual(testUnits.Kilograms, WeightMeasurement.Parse(testString).Kilograms);

			Assert.IsNull(WeightMeasurement.TryParse("hello"));
			Assert.AreEqual(double.NaN, WeightMeasurement.Parse("hello").Kilograms);
		}

		[Test]
		public void weight_eq_ne_gt_gte_lt_lte()
		{
			Assert.IsFalse(WeightMeasurement.FromKilograms(2) == WeightMeasurement.FromKilograms(1));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) == WeightMeasurement.FromKilograms(2));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) == WeightMeasurement.FromKilograms(1));

			Assert.IsTrue(WeightMeasurement.FromKilograms(2) != WeightMeasurement.FromKilograms(1));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) != WeightMeasurement.FromKilograms(2));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) != WeightMeasurement.FromKilograms(1));

			Assert.IsTrue(WeightMeasurement.FromKilograms(2) > WeightMeasurement.FromKilograms(1));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) > WeightMeasurement.FromKilograms(2));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) > WeightMeasurement.FromKilograms(1));

			Assert.IsTrue(WeightMeasurement.FromKilograms(2) >= WeightMeasurement.FromKilograms(1));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) >= WeightMeasurement.FromKilograms(2));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) >= WeightMeasurement.FromKilograms(1));

			Assert.IsFalse(WeightMeasurement.FromKilograms(2) < WeightMeasurement.FromKilograms(1));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) < WeightMeasurement.FromKilograms(2));
			Assert.IsFalse(WeightMeasurement.FromKilograms(1) < WeightMeasurement.FromKilograms(1));

			Assert.IsFalse(WeightMeasurement.FromKilograms(2) <= WeightMeasurement.FromKilograms(1));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) <= WeightMeasurement.FromKilograms(2));
			Assert.IsTrue(WeightMeasurement.FromKilograms(1) <= WeightMeasurement.FromKilograms(1));
		}

		[Test]
		public void weight_multiply_divide_add_subtract()
		{
			Assert.AreEqual(WeightMeasurement.FromKilograms(100),
				WeightMeasurement.FromKilograms(50).Add(WeightMeasurement.FromKilograms(50)));

			Assert.AreEqual(WeightMeasurement.FromKilograms(50),
				WeightMeasurement.FromKilograms(100).Subtract(WeightMeasurement.FromKilograms(50)));

			Assert.AreEqual(WeightMeasurement.FromKilograms(200),
				WeightMeasurement.FromKilograms(100).MultiplyBy(2));

			Assert.AreEqual(WeightMeasurement.FromKilograms(50),
				WeightMeasurement.FromKilograms(100).DivideBy(2));
		}

		[Test]
		public void weight_implicit_double_conversion()
		{
			Assert.AreEqual((double)WeightMeasurement.FromKilograms(100), 100d);
			Assert.AreEqual(WeightMeasurement.FromKilograms(100), (WeightMeasurement)100d);
		}
	}
}
