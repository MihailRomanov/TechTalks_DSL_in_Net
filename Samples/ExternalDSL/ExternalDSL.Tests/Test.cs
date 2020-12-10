using NUnit.Framework;
using System.Threading;

namespace ExternalDSL.Tests
{
    [TestFixture]
    [RequiresThread(ApartmentState.STA)]
    public class Tests
    {
        [Test]
        public void TestXml()
        {
            var dialog = new XmlBasedDialog
            {
                Field1 = 100.1
            };
            dialog.ShowDialog();
        }

        [Test]
        public void TestJson()
        {
            var dialog = new JsonDialog
            {
                Field1 = "Json string"
            };
            dialog.ShowDialog();
        }

        [Test]
        public void TestGrammar()
        {
            var dialog = new MyGrammarDialog
            {
                F1 = "My grammar",
                F2 = 34
            };
            dialog.ShowDialog();
        }
    }
}