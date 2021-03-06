﻿using System.Windows.Input;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OutlookMatters.Core.Settings;

namespace Test.OutlookMatters.Core.Settings
{
    [TestFixture]
    public class SettingsViewModelTest
    {
        [Test]
        public void MattermostUrl_ReturnsUrlFromSettingsProvider()
        {
            var settings = new AddInSettings("http://localhost", "teamId", "username", "channels", It.IsAny<MattermostVersion>());
            var classUnderTest = new SettingsViewModel(settings, Mock.Of<ICommand>(), Mock.Of<ICommand>());

            var result = classUnderTest.MattermostUrl;

            result.Should()
                .Be(settings.MattermostUrl, "because the returned url should come from the settings provider");
        }

        [Test]
        public void TeamId_ReturnsTeamIdFromSettingsProvider()
        {
            var settings = new AddInSettings("http://localhost", "teamId", "username", "channels", It.IsAny<MattermostVersion>());
            var classUnderTest = new SettingsViewModel(settings, Mock.Of<ICommand>(), Mock.Of<ICommand>());

            var result = classUnderTest.TeamId;

            result.Should()
                .Be(settings.TeamId, "because the returned team id should come from the settings provider");
        }

        [Test]
        public void Username_ReturnsUsernameFromSettingsProvider()
        {
            var settings = new AddInSettings("http://localhost", "teamId", "username", "channels", It.IsAny<MattermostVersion>());
            var classUnderTest = new SettingsViewModel(settings, Mock.Of<ICommand>(), Mock.Of<ICommand>());

            var result = classUnderTest.Username;

            result.Should()
                .Be(settings.Username, "because the returned user name should come from the settings provider");
        }

        [Test]
        public void Save_ReturnsSaveCommand()
        {
            var settings = new AddInSettings("http://localhost", "teamId", "username", "channels", It.IsAny<MattermostVersion>());
            var saveCommand = new Mock<ICommand>();
            var classUnderTest = new SettingsViewModel(settings, saveCommand.Object, Mock.Of<ICommand>());

            var result = classUnderTest.Save;

            result.Should().Be(saveCommand.Object, "because the view model should return the save command for binding");
        }

        [Test]
        public void Cancel_ReturnsCancelCommand()
        {
            var settings = new AddInSettings("http://localhost", "teamId", "username", "channels", It.IsAny<MattermostVersion>());
            var cancelCommand = new Mock<ICommand>();
            var classUnderTest = new SettingsViewModel(settings, Mock.Of<ICommand>(), cancelCommand.Object);

            var result = classUnderTest.Cancel;

            result.Should()
                .Be(cancelCommand.Object, "because the view model should return the cancel command for binding");
        }
    }
}