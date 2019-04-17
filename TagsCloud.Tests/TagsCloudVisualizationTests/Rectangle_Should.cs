using NUnit.Framework;
using System.Collections;
using System.Drawing;
using TagsCloud.Core.Extensions;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class Rectangle_Should
    {
        [TestCaseSource(nameof(GetCenterPointTestCases))]
        public Point GetCenterPoint_ShouldBeCorrect(Rectangle rect)
        {
            return rect.GetCenterPoint();
        }

        private static IEnumerable GetCenterPointTestCases
        {
            get
            {
                yield return new TestCaseData(new Rectangle(-64, -64, 128, 128)).Returns(new Point(0, 0));

                yield return new TestCaseData(new Rectangle(0, 0, 3, 3)).Returns(new Point(3 / 2, 3 / 2));
                yield return new TestCaseData(new Rectangle(0, 0, -3, 3)).Returns(new Point(-3 / 2, 3 / 2));
                yield return new TestCaseData(new Rectangle(0, 0, 3, -3)).Returns(new Point(3 / 2, -3 / 2));
                yield return new TestCaseData(new Rectangle(0, 0, -3, -3)).Returns(new Point(-3 / 2, -3 / 2));

                yield return new TestCaseData(new Rectangle(0, 0, 128, 128)).Returns(new Point(64, 64));
                yield return new TestCaseData(new Rectangle(0, 0, -128, 128)).Returns(new Point(-64, 64));
                yield return new TestCaseData(new Rectangle(0, 0, 128, -128)).Returns(new Point(64, -64));
                yield return new TestCaseData(new Rectangle(0, 0, -128, -128)).Returns(new Point(-64, -64));
            }
        }
    }
}