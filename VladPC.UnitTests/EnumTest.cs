using VladPC.Common;

namespace VladPC.UnitTests
{
    public class EnumTest
    {
        /// <summary>
        /// Проверка на то, что количество элементов в enum соответствует количеству элементов в словаре для это enum
        /// </summary>
        [Fact]
        public void CorrectnessLists()
        {
            Assert.Equal(Enum.GetValues(typeof(Company)).Length, DictionaryLists.CompanyMap.Count);
            Assert.Equal(Enum.GetValues(typeof(Socket)).Length, DictionaryLists.SocketMap.Count);
            Assert.Equal(Enum.GetValues(typeof(MemoryType)).Length, DictionaryLists.MemoryTypeMap.Count);
            Assert.Equal(Enum.GetValues(typeof(Chipset)).Length, DictionaryLists.ChipsetMap.Count);
            Assert.Equal(Enum.GetValues(typeof(Status80plus)).Length, DictionaryLists.Status80plusMap.Count);
            Assert.Equal(Enum.GetValues(typeof(FormFactor)).Length, DictionaryLists.FormFactorMap.Count);
        }
    }
}