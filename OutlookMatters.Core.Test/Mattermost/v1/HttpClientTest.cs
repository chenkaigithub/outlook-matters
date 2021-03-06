﻿using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using OutlookMatters.Core.Chat;
using OutlookMatters.Core.Mattermost.v1;
using OutlookMatters.Core.Mattermost.v1.Interface;

namespace Test.OutlookMatters.Core.Mattermost.v1
{
    [TestFixture]
    public class HttpClientTest
    {
        [Test]
        public void LoginByUsername_UsesDataFromRestServiceToCreateSession()
        {
            const string url = "http://localhost";
            const string userId = "userId";
            const string teamId = "teamId";
            const string username = "username";
            const string password = "password";
            var token = "token";
            var login = new Login {Name = teamId, Email = username, Password = password};
            var user = new User {Id = userId};
            var restService = new Mock<IRestService>();
            restService.Setup(x => x.Login(new Uri(url), login, out token)).Returns(user);
            var session = new Mock<ISession>();
            var sessionFactory = new Mock<ISessionFactory>();
            sessionFactory.Setup(x => x.NewInstance(new Uri(url), token, userId)).Returns(session.Object);
            var sut = new HttpClient(sessionFactory.Object, restService.Object);

            var result = sut.LoginByUsername(url, teamId, username, password);

            result.ShouldBeEquivalentTo(session.Object, "because the correct session should be returned");
        }
    }
}