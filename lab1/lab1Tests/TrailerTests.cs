using CarsLibrary;
using Xunit;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирование трейлера
    /// </summary>
    public class TrailerTests
    {
        /// <summary>
        /// Тестирование конструкторов
        /// </summary>
        [Fact]
        public void TrailerConstructorTest()
        {
            Trailer t = new Trailer();
            Assert.NotNull(t);
            BigTrailer bt = new BigTrailer();
            Assert.NotNull(bt);
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 }
}
