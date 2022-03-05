using Xunit;

namespace GalaxyQuest.Test
{
    public class RomanToArabicTest
    {
        [Fact]
        public void Roman_I_1()
        {
            Assert.Equal(1, Roman.From("I"));
        }

        [Fact]
        public void Roman_II_2()
        {
            Assert.Equal(2, Roman.From("II"));
        }

        [Fact]
        public void Roman_III_3()
        {
            Assert.Equal(3, Roman.From("III"));
        }

        [Fact]
        public void Roman_IV_4()
        {
            Assert.Equal(4, Roman.From("IV"));
        }

        [Fact]
        public void Roman_V_5()
        {
            Assert.Equal(5, Roman.From("V"));
        }

        [Fact]
        public void Roman_IX_9()
        {
            Assert.Equal(9, Roman.From("IX"));
        }

        [Fact]
        public void Roman_X_10()
        {
            Assert.Equal(10, Roman.From("X"));
        }

        [Fact]
        public void Roman_XLIX_49()
        {
            Assert.Equal(49, Roman.From("XLIX"));
        }

        [Fact]
        public void Roman_L_50()
        {
            Assert.Equal(50, Roman.From("L"));
        }

        [Fact]
        public void Roman_C_100()
        {
            Assert.Equal(100, Roman.From("C"));
        }

        [Fact]
        public void Roman_CD_400()
        {
            Assert.Equal(400, Roman.From("CD"));
        }

        [Fact]
        public void Roman_D_500()
        {
            Assert.Equal(500, Roman.From("D"));
        }

        [Fact]
        public void Roman_CM_900()
        {
            Assert.Equal(900, Roman.From("CM"));
        }

        [Fact]
        public void Roman_M_1000()
        {
            Assert.Equal(1000, Roman.From("M"));
        }

        [Fact]
        public void Roman_MMMMMMMMMMMCMLXXXIV_11984()
        {
            Assert.Equal(11984, Roman.From("MMMMMMMMMMMCMLXXXIV"));
        }
    }
}
