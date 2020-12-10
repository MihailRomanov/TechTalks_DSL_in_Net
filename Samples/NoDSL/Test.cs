using NUnit.Framework;
using System.Threading;

namespace NoDSL
{
    [TestFixture]
    [RequiresThread(ApartmentState.STA)]
    public class Test
    {
        [Test]
        public void TestXAML()
        {
            var dialog = new DialogWindow(new DialogModel { Field1 = "111" });
            dialog.ShowDialog();
        }

        [Test]
        public void TestCode()
        {
            var dialog = new DialogWindowInCode(new DialogModel { Field1 = "111" });
            dialog.ShowDialog();
        }
    }
}
