using Xunit;

namespace GalaxyQuest.Test
{
    public class ArabicToRomanTest
    {
        [Fact]
        public void Roman_1_I()
        {
            Assert.Equal("I", Roman.To(1));
        }

        [Fact]
        public void Roman_2_II()
        {
            Assert.Equal("II", Roman.To(2));
        }

        [Fact]
        public void Roman_3_III()
        {
            Assert.Equal("III", Roman.To(3));
        }

        [Fact]
        public void Roman_4_IV()
        {
            Assert.Equal("IV", Roman.To(4));
        }

        [Fact]
        public void Roman_5_V()
        {
            Assert.Equal("V", Roman.To(5));
        }

        [Fact]
        public void Roman_9_IX()
        {
            Assert.Equal("IX", Roman.To(9));
        }

        [Fact]
        public void Roman_10_X()
        {
            Assert.Equal("X", Roman.To(10));
        }

        [Fact]
        public void Roman_49_XLIX()
        {
            Assert.Equal("XLIX", Roman.To(49));
        }

        [Fact]
        public void Roman_50_L()
        {
            Assert.Equal("L", Roman.To(50));
        }

        [Fact]
        public void Roman_100_C()
        {
            Assert.Equal("C", Roman.To(100));
        }

        [Fact]
        public void Roman_400_CD()
        {
            Assert.Equal("CD", Roman.To(400));
        }

        [Fact]
        public void Roman_500_D()
        {
            Assert.Equal("D", Roman.To(500));
        }

        [Fact]
        public void Roman_900_CM()
        {
            Assert.Equal("CM", Roman.To(900));
        }

        [Fact]
        public void Roman_1000_M()
        {
            Assert.Equal("M", Roman.To(1000));
        }

        [Fact]
        public void Roman_11984_MMMMMMMMMMMCMLXXXIV()
        {
            Assert.Equal("MMMMMMMMMMMCMLXXXIV", Roman.To(11984));
        }
    }
}
