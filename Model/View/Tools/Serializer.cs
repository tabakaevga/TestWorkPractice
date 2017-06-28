using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace View.Tools
{
    internal class Serializer
    {
        /// <summary>
        ///     Сериализатор данных
        /// </summary>
        /// <typeparam name="T"> Тип данных, поступающий на сериализацию </typeparam>
        /// <param name="fileName"> Название файла, куда записывается серия </param>
        /// <param name="container"> Контейнер данных </param>
        public static void SerializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(serializeFileStream, container);
            serializeFileStream.Close();
        }

        /// <summary>
        ///     Десериализатор данных
        /// </summary>
        /// <typeparam name="T"> Тип данных, поступающий на десериализацию </typeparam>
        /// <param name="fileName"> Название файла, откуда происходит десериализация </param>
        /// <param name="container"> Контейнер данных </param>
        public static void DeserializeBinary<T>(string fileName, ref T container)
        {
            var formatter = new BinaryFormatter();
            var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate);
            if (deserializeFile.Length > 0)
                container = (T) formatter.Deserialize(deserializeFile);
            deserializeFile.Close();
        }
    }
}