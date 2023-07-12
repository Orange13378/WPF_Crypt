using Kursach;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KursachTests1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Encode_message_привет_мир_key_скорпион_returned_бычтфы_ыцв()
        {
            char[] message = "привет мир".ToCharArray();
            char[] key = "скорпион".ToCharArray();
            char[] expected = "бычтфы ыцв".ToCharArray();

            MainWindow mainWindow = new MainWindow();
            char[] actual = mainWindow.Encode(message, key);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void Decode_message_бычтфы_ыцв_key_скорпион_returned_привет_мир()
        {
            char[] message = "бычтфы ыцв".ToCharArray();
            char[] key = "скорпион".ToCharArray();
            char[] expected = "привет мир".ToCharArray();

            MainWindow mainWindow = new MainWindow();
            char[] actual = mainWindow.Decode(message, key);

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void ReadPathTest()
        {
            MainWindow mainWindow = new MainWindow();
            string path = "";
            string actual = mainWindow.ReadPath(path);
            string expected = mainWindow.Path;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SaveFileTest()
        {
            MainWindow mainWindow = new MainWindow();
            string path = "";
            path = mainWindow.ReadPath(path); // запоминает путь
            bool actual = mainWindow.SaveFile("", path);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
