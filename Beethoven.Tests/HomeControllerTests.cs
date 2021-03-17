using Beethoven.Controllers;
using Beethoven.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Beethoven.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexCheckFirstValueCorrect()
        {
            PianoModel piano = new PianoModel();
            piano.Number = 3;
            piano.Divider = 4;
            piano.Stave = "4 4 8 8 | 4 4 2";

            piano.Check(piano);
            Assert.True(piano.Success);
        }

        [Fact]
        public void IndexCheckSecondValueCorrect()
        {
            PianoModel piano = new PianoModel();
            piano.Number = 3;
            piano.Divider = 4;
            piano.Stave = "4 4 8 8 | 4 4 8 8";
            piano.Check(piano);

            Assert.True(piano.Success);
        }

        [Fact]
        public void IndexCheckThirdValueFalse()
        {
            PianoModel piano = new PianoModel();
            piano.Number = 3;
            piano.Divider = 4;
            piano.Stave = "4 4 8 8 | 4 4 8 8 8";
            piano.Check(piano);
            
            Assert.False(piano.Success);
        }
    }
}
