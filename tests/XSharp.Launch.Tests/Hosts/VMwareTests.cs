﻿using System.Diagnostics;
using System.IO;

using NUnit.Framework;

using XSharp.Launch.Hosts.VMware;

namespace XSharp.Launch.Tests.Hosts
{
    [TestFixture(TestOf = typeof(VMware))]
    public class VMwareTests
    {
        private string TestDir = TestUtilities.NewTestDir();

        [Test]
        public void LaunchVMware()
        {
            var xLaunchSettings = new VMwareLaunchSettings()
            {
                ConfigurationFile = Path.Combine(TestDir, "VMware.vmx"),
                VMwareExecutable = null
            };

            var xVMware = new VMware(xLaunchSettings);

            xVMware.Start();

            var xProcessCount = Process.GetProcessesByName("vmplayer").Length;
            Assert.That(xProcessCount, Is.Not.Zero);

            xVMware.Stop();
            Assert.That(Process.GetProcessesByName("vmplayer").Length, Is.EqualTo(xProcessCount - 1));
        }
    }
}
