using System;
using System.Collections.Generic;
using System.Linq;
using ByteDev.Markdown.Helper;
using NUnit.Framework;

namespace ByteDev.Markdown.UnitTests.Helper
{
    [TestFixture]
    public class MdTests
    {
        [TestFixture]
        public class Italic
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Italic(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Italic("make this italic");

                Assert.That(result, Is.EqualTo("*make this italic*"));
            }
        }

        [TestFixture]
        public class Bold
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Bold(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Bold("make this bold");

                Assert.That(result, Is.EqualTo("**make this bold**"));
            }
        }

        [TestFixture]
        public class Strike
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Strike(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Strike("ignore this");

                Assert.That(result, Is.EqualTo("~~ignore this~~"));
            }
        }

        [TestFixture]
        public class Blockquote
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Blockquote(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Blockquote("Something somewhere");

                Assert.That(result, Is.EqualTo("> Something somewhere"));
            }
        }

        [TestFixture]
        public class HorizontalRule
        {
            [Test]
            public void WhenCalled_ThenReturnsRule()
            {
                var result = Md.HorizontalRule();

                Assert.That(result, Is.EqualTo("---"));
            }
        }

        [TestFixture]
        public class Header1
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header1(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header1("My Header");

                Assert.That(result, Is.EqualTo("# My Header"));
            }
        }

        [TestFixture]
        public class Header2
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header2(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header2("My Header");

                Assert.That(result, Is.EqualTo("## My Header"));
            }
        }

        [TestFixture]
        public class Header3
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header3(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header3("My Header");

                Assert.That(result, Is.EqualTo("### My Header"));
            }
        }

        [TestFixture]
        public class Header4
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header4(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header4("My Header");

                Assert.That(result, Is.EqualTo("#### My Header"));
            }
        }

        [TestFixture]
        public class Header5
        {
            [TestCase(null)]
            [TestCase("")]
            public void WhenIsNullOrEmpty_ThenReturnEmpty(string text)
            {
                var result = Md.Header5(text);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTextIsValid_ThenReturnHeader()
            {
                var result = Md.Header5("My Header");

                Assert.That(result, Is.EqualTo("##### My Header"));
            }
        }

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
                var result = Md.TaskList(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnList()
            {
                string expected = "- [ ] Wrote unit tests" + Environment.NewLine;

                var result = Md.TaskList(new TaskListItem("Wrote unit tests"));

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnList()
            {
                string expected = 
                    "- [x] Wrote code" + Environment.NewLine +
                    "- [ ] Wrote unit tests" + Environment.NewLine;

                var result = Md.TaskList(new TaskListItem("Wrote code", true), new TaskListItem("Wrote unit tests"));

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

                var result = Md.TaskList(items);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEmptyEnumerable_ThenReturnEmpty()
            {
                var result = Md.TaskList(Enumerable.Empty<TaskListItem>());

                Assert.That(result, Is.Empty);
            }
        }

        [TestFixture]
        public class UnorderedList
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = Md.UnorderedList(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnList()
            {
                string expected = "* Wrote unit tests" + Environment.NewLine;

                var result = Md.UnorderedList("Wrote unit tests");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnList()
            {
                string expected = 
                    "* Wrote code" + Environment.NewLine +
                    "* Wrote unit tests" + Environment.NewLine;

                var result = Md.UnorderedList("Wrote code", "Wrote unit tests");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEnumerable_ThenReturnList()
            {
                string expected = 
                    "* Wrote code" + Environment.NewLine +
                    "* Wrote unit tests" + Environment.NewLine;

                IEnumerable<string> items = new List<string> { "Wrote code", "Wrote unit tests" };

                var result = Md.UnorderedList(items);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEmptyEnumerable_ThenReturnEmpty()
            {
                var result = Md.UnorderedList(Enumerable.Empty<object>());

                Assert.That(result, Is.Empty);
            }
        }

        [TestFixture]
        public class OrderedList
        {
            [Test]
            public void WhenIsNull_ThenReturnEmpty()
            {
                var result = Md.OrderedList(null);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenSingle_ThenReturnList()
            {
                string expected = "1. Wrote unit tests" + Environment.NewLine;

                var result = Md.OrderedList("Wrote unit tests");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenTwo_ThenReturnList()
            {
                string expected = 
                    "1. Wrote code" + Environment.NewLine +
                    "2. Wrote unit tests" + Environment.NewLine;

                var result = Md.OrderedList("Wrote code", "Wrote unit tests");

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEnumerable_ThenReturnList()
            {
                string expected = 
                    "1. Wrote code" + Environment.NewLine +
                    "2. Wrote unit tests" + Environment.NewLine;

                IEnumerable<string> items = new List<string> { "Wrote code", "Wrote unit tests" };

                var result = Md.OrderedList(items);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenEmptyEnumerable_ThenReturnEmpty()
            {
                var result = Md.OrderedList(Enumerable.Empty<object>());

                Assert.That(result, Is.Empty);
            }
        }
    }
}