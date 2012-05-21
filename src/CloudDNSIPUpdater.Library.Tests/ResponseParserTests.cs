using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClouDNSIPUpdater.Library;
using NUnit.Framework;

namespace CloudDNSIPUpdater.Library.Tests
{
    [TestFixture]
    public class ResponseParserTests
    {
        [Test]
        public void CheckReponse_ValidResponse_ReturnsTrue()
        {
            ResponseParser parser = new ResponseParser();
            Assert.IsTrue(parser.CheckResponse(ResponseParser.ValidResponce));
        }

        [Test]
        public void CheckReponse_InvalidResponse_ReturnsFalse()
        {
            ResponseParser parser = new ResponseParser();
            Assert.IsFalse(parser.CheckResponse(ResponseParser.InvalidResponse));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckReponse_UnknownResponse_ThrowsArgumentOutOfRangeException()
        {
            ResponseParser parser = new ResponseParser();
            parser.CheckResponse("kjahkajhd");
        }
    }
}
