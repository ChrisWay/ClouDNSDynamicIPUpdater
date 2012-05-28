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
            Assert.IsTrue(ResponseParser.CheckResponse(ResponseParser.ValidResponce));
        }

        [Test]
        public void CheckReponse_InvalidResponse_ReturnsFalse()
        {
            Assert.IsFalse(ResponseParser.CheckResponse(ResponseParser.InvalidResponse));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckReponse_UnknownResponse_ThrowsArgumentOutOfRangeException()
        {
            ResponseParser.CheckResponse("kjahkajhd");
        }
    }
}
