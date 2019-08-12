using Shouldly;
using Xunit;

namespace CheapPark.Tests
{
    public class ParkingMachineTests
    {
        readonly ParkingMachine machine = new ParkingMachine();

        [Fact]
        public void InitializedWithNoBalance()
        {
            machine.GetBalance().ShouldBeEmpty();
        }

        [Fact]
        public void CheckoutCosts200()
        {
            machine.Checkout("AB 12 456");

            var item = machine.GetBalance().ShouldHaveSingleItem();
            item.Key.ShouldBe("AB 12 456");
            item.Value.ShouldBe(200);
        }

        [Fact]
        public void CheckoutTwiceCosts400()
        {
            machine.Checkout("AB 12 456");
            machine.Checkout("AB 12 456");

            var item = machine.GetBalance().ShouldHaveSingleItem();
            item.Key.ShouldBe("AB 12 456");
            item.Value.ShouldBe(400);
        }

        [Fact]
        public void TwoDifferentCheckouts()
        {
            machine.Checkout("AB 12 456");
            machine.Checkout("DE 13 337");

            machine.GetBalance().Count.ShouldBe(2);
            machine.GetBalance()["AB 12 456"].ShouldBe(200);
            machine.GetBalance()["DE 13 337"].ShouldBe(200);
        }
    }
}
