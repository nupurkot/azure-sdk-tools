﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    using Microsoft.Azure.Commands.Automation.Cmdlet;
    using Microsoft.Azure.Commands.Automation.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using System;

    [TestClass]
    public class RemoveAzureAutomationScheduleTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private RemoveAzureAutomationSchedule cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new RemoveAzureAutomationSchedule
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void RemoveAzureAutomationScheduleByIdSuccessfull()
        {
            // Setup
            string accountName = "automation";
            var scheduleId = new Guid();

            this.mockAutomationClient.Setup(f => f.DeleteSchedule(accountName, scheduleId));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = scheduleId;
            this.cmdlet.Force = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.DeleteSchedule(accountName, scheduleId), Times.Once());
        }

        [TestMethod]
        public void RemoveAzureAutomationScheduleByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string scheduleName = "schedule";

            this.mockAutomationClient.Setup(f => f.DeleteSchedule(accountName, scheduleName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = scheduleName;
            this.cmdlet.Force = true;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.DeleteSchedule(accountName, scheduleName), Times.Once());
        }
    }
}
