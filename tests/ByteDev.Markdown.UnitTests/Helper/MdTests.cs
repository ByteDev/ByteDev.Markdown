using System;
using System.Collections.Generic;
using ByteDev.Markdown.Helper;
using NUnit.Framework;

namespace ByteDev.Markdown.UnitTests.Helper
{
    [TestFixture]
    public class MdTests
    {
        [TestFixture]
        public class Header6
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header6(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header6("My Header");

                Assert.That(result, Is.EqualTo("###### My Header"));
            }
        }

        [TestFixture]
        public class Link
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenUriIsNullOrEmpty_ThenReturnEmpty(string uri)
            {
                var result = Md.Link(uri);

                Assert.That(result, Is.Empty);
            }

            [TestCase(null)]
            [TestCase("")]
            public void WhenTextIsNullOrEmpty_ThenReturnLink(string text)
            {
                var result = Md.Link("/path/somewhere.md", text);

                Assert.That(result, Is.EqualTo("[/path/somewhere.md](/path/somewhere.md)"));
            }

            [Test]
            public void WhenTextNotNullOrEmpty_ThenReturnLink()
            {
                var result = Md.Link("/path/somewhere.md", "Somewhere");

                Assert.That(result, Is.EqualTo("[Somewhere](/path/somewhere.md)"));
            }
        }

        [TestFixture]
        public class Image
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenUriIsNullOrEmpty_ThenReturnEmpty(string uri)
            {
                var result = Md.Image(uri);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenAltTextProvided_ThenReturnImage()
            {
                var result = Md.Image("/images/icon.png", "Icon");

                Assert.That(result, Is.EqualTo("![Icon](/images/icon.png)"));
            }

            [Test]
            public void WhenAltTextNotProvided_ThenReturnImage()
            {
                var result = Md.Image("/images/icon.png");

                Assert.That(result, Is.EqualTo("![Image](/images/icon.png)"));
            }
        }

        [TestFixture]
        public class CodeBlock
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenTextIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.CodeBlock(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenCodeIsNotNullOrEmpty_ThenReturnCodeBlock()
            {
                var code = "int x = 1;" + Environment.NewLine +
                           "int y = 2;" + Environment.NewLine;

                var expected = 
                    "```csharp" + Environment.NewLine +
                    "int x = 1;" + Environment.NewLine +
                    "int y = 2;" + Environment.NewLine +
                    "```";

                var result = Md.CodeBlock(code, "csharp");

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class TableHeader
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = Md.TableHeader(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = Md.TableHeader();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnHeader()
            {
                var expected =
                    "| Name |" + Environment.NewLine +
                    "| --- |" + Environment.NewLine;

                var result = Md.TableHeader("Name");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnHeader()
            {
                var expected =
                    "| Name | Age |" + Environment.NewLine +
                    "| --- | --- |" + Environment.NewLine;

                var result = Md.TableHeader("Name", "Age");

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class TableRow
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = Md.TableRow(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenIsEmpty_ThenReturnEmpty()
            {
                var result = Md.TableRow();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnRow()
            {
                var expected = "| Name |" + Environment.NewLine;

                var result = Md.TableRow("Name");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnRow()
            {
                var expected = "| Name | Age |" + Environment.NewLine;

                var result = Md.TableRow("Name", "Age");

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class TaskList
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = Md.ListTask(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnList()
            {
                const string expected = "- [ ] Wrote unit tests\r\n";

                var result = Md.ListTask(new TaskListItem("Wrote unit tests"));

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnList()
            {
                string expected = 
                    "- [x] Wrote code" + Environment.NewLine +
                    "- [ ] Wrote unit tests" + Environment.NewLine;

                var result = Md.ListTask(new TaskListItem("Wrote code", true), new TaskListItem("Wrote unit tests"));

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEnumerable_ThenReturnList()
            {
                string expected = 
                    "- [x] Wrote code" + Environment.NewLine +
                    "- [ ] Wrote unit tests" + Environment.NewLine;

                IEnumerable<TaskListItem> items = new List<TaskListItem>
                {
                    new TaskListItem("Wrote code", true),
                    new TaskListItem("Wrote unit tests")
                };

                var result = Md.ListTask(items);

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}