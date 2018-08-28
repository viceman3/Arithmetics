﻿using NUnit.Framework;
using Shouldly;
using System.Diagnostics;
using System.Globalization;

namespace Lombiq.Arithmetics.Tests
{
	[TestFixture]
	class Posit8_1Tests
	{
		[Test]
		public void Posit8_1_IntConversionIsCorrect()
		{
			Assert.AreEqual(new Posit8_1(0).PositBits, 0);
			Assert.AreEqual((int)new Posit8_1(1), 1);
			Assert.AreEqual((int)new Posit8_1(-1), -1);
			Assert.AreEqual((int)new Posit8_1(3), 3);
			Assert.AreEqual((int)new Posit8_1(-3), -3);
			Assert.AreEqual((int)new Posit8_1(8), 8);
			Assert.AreEqual((int)new Posit8_1(-16), -16);
			Assert.AreEqual((int)new Posit8_1(1024), 1024);
			Assert.AreEqual((int)new Posit8_1(-1024), -1024);

									
		}

		[Test]
		public void Posit8_1_FloatConversionIsCorrect()
		{
			Assert.AreEqual(new Posit8_1((float)0.0).PositBits, 0);
			
			Assert.AreEqual((float)new Posit8_1((float)1.0), 1);
			Assert.AreEqual((float)new Posit8_1((float)2.0), 2);
			Assert.AreEqual((float)new Posit8_1((float)0.5), 0.5);
			Assert.AreEqual((float)new Posit8_1((float)0.0625), 0.0625);

			Assert.AreEqual((float)new Posit8_1((float)0.09375), 0.09375);
			Assert.AreEqual((float)new Posit8_1((float)1.5), 1.5);
			Assert.AreEqual((float)new Posit8_1((float)-0.09375),- 0.09375);
			Assert.AreEqual((float)new Posit8_1((float)-1.5), -1.5);
			Assert.AreEqual((float)new Posit8_1((float)6), 6);
			Assert.AreEqual((float)new Posit8_1((float)-6), -6);
			Assert.AreEqual((float)new Posit8_1((float) 4096),(float)4096);
			Assert.AreEqual((float)new Posit8_1((float) -4096),(float)-4096);			
			}

		[Test]
		public void Posit8_1_DoubleConversionIsCorrect()
		{
			Assert.AreEqual((double)new Posit8_1(0.0).PositBits, 0);
			
			Assert.AreEqual((double)new Posit8_1(1.0), 1.0);
			Assert.AreEqual((double)new Posit8_1(2.0), 2);
			Assert.AreEqual((double)new Posit8_1(0.5), 0.5);
			Assert.AreEqual((double)new Posit8_1(0.0625), 0.0625);

			Assert.AreEqual((double)new Posit8_1(0.09375), 0.09375);
			Assert.AreEqual((double)new Posit8_1(1.5), 1.5);
			Assert.AreEqual((double)new Posit8_1(-0.09375),-0.09375);
			Assert.AreEqual((double)new Posit8_1(-1.5), -1.5);
			Assert.AreEqual((double)new Posit8_1(6), 6);
			Assert.AreEqual((double)new Posit8_1(-6), -6);
			Assert.AreEqual((float)(double)new Posit8_1( 4096),(float)4096);
			Assert.AreEqual((float)(double)new Posit8_1( -4096),(float)-4096);			
		}
		
		[Test]
		public void Posit8_1_AdditionIsCorrectForPositives()
		{
			var posit1 = new Posit8_1(1);

			for (var i = 1; i < 8; i++)
			{
				posit1 += 1;
			}
			((uint)posit1).ShouldBe((uint)new Posit8_1(8));
		}

		[Test]
		public void Posit8_1_AdditionIsCorrectForNegatives()
		{
			var posit1 = new Posit8_1(-4);

			for (var i = 1; i < 8; i++)
			{
				posit1 += 1;
			}
			((uint)posit1).ShouldBe((uint)new Posit8_1(3));
		}

		[Test]
		public void Posit8_1_AdditionIsCorrectForReals()
		{
			var posit1 = new Posit8_1(0.015625);
			var posit2 = posit1 + posit1;
			posit2.ShouldBe(new Posit8_1(0.03125));
			(posit1-posit2).ShouldBe(new Posit8_1(-0.015625));
			(new Posit8_1(1) - new Posit8_1(0.1)).ShouldBe(new Posit8_1(0.9));
			
			  					
		}	

		[Test]
		public void Posit8_1_MultiplicationIsCorrect()
		{
			 var posit1 = new Posit8_1(1);
			 (posit1 * new Posit8_1(0.015625)).ShouldBe(new Posit8_1(0.015625));
			 (posit1 * new Posit8_1(256)).ShouldBe(new Posit8_1(256));
			 (-posit1 * new Posit8_1(3)).ShouldBe(new Posit8_1(-3));
			 (new Posit8_1(2) * new Posit8_1(0.015625)).ShouldBe(new Posit8_1(0.03125));
			 (new Posit8_1(4) * new Posit8_1(16)).ShouldBe(new Posit8_1(64));
			 (new Posit8_1(-3) * new Posit8_1(-4)).ShouldBe(new Posit8_1(12));
			
				  					
		}	

		[Test]
		public void Posit8_1_DivisionIsCorrect()
		{
			 var posit1 = new Posit8_1(1);
			 (posit1 / new Posit8_1(0)).ShouldBe(new Posit8_1(Posit8_1.NaNBitMask, true));
			 (new Posit8_1(0.015625) / posit1).ShouldBe(new Posit8_1(0.015625));
			 (new Posit8_1(256) / posit1).ShouldBe(new Posit8_1(256));
			 (new Posit8_1(3) / -posit1).ShouldBe(new Posit8_1(-3));
			 (new Posit8_1(0.03125) / new Posit8_1(2)).ShouldBe(new Posit8_1(0.015625));
			 (new Posit8_1(64) / new Posit8_1(16)).ShouldBe(new Posit8_1(4));
			 (new Posit8_1(12) / new Posit8_1(-4)).ShouldBe(new Posit8_1(-3));
			
			    
		 }										
	}
}