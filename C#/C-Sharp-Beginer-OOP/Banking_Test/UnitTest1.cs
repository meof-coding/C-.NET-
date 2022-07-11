using System;
using Xunit;
using MyBank_OOP_Project;

namespace Banking_Test
{
    public class UnitTest1
    {
        [Fact]
        public void TrueIsTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void CanTakeMoreThanYouHave() {
            var acount = new BankAccount("Kendra", 23000);

            //Test for the negative balances 


            Assert.Throws<InvalidOperationException>(
                () => acount.MakeWithDraw(89000, DateTime.Now,"Xbox game")

                );
        }

        [Fact]
        public void PositiveBalance () {
            Assert.Throws<ArgumentOutOfRangeException>(
               () => new BankAccount("invalid", -55)

               );

           
        }
    }
}
