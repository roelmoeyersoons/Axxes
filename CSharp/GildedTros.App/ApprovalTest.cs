﻿using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace GildedTros.App
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            //https://github.com/approvals/ApprovalTests.Net very interesting, never heard of this way of testing
            //i will just compare the .received. files.

            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }
    }
}
