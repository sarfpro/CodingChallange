using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallengeService.Service;
using CodingChallengeService.Models;
using System.Collections.Generic;

namespace CodingChallengeTest
{
    [TestClass]
    public class RequestResponseTest
    {
        [TestMethod]
        public void NotNullResponse()
        {
            //Arrange
            Request request = null;
            IFilterService _service = new FilterService();

            //Act
            var response = _service.GetFilteredResponse(request);

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void ZeroCountWithNullRequest()
        {
            //Arrange
            Request request = null;
            IFilterService _service = new FilterService();

            //Act
            var response = _service.GetFilteredResponse(request);

            //Assert
            Assert.IsTrue(response.response.Count == 0);
        }

        [TestMethod]
        public void OneCountResponse()
        {
            //Arrange
            List<Payload> payloads = new List<Payload>();
            payloads.Add(new Payload { Drm = true, EpisodeCount = 1 });
            Request request = new Request { Payload = payloads };
            IFilterService _service = new FilterService();

            //Act
            var response = _service.GetFilteredResponse(request);

            //Assert
            Assert.IsTrue(response.response.Count == 0);
        }

        [TestMethod]
        public void ZeroCountWithNoEpisodeCount()
        {
            //Arrange
            List<Payload> payloads = new List<Payload>();
            payloads.Add(new Payload { Drm = true, EpisodeCount = 0 });
            Request request = new Request { Payload = payloads };
            IFilterService _service = new FilterService();

            //Act
            var response = _service.GetFilteredResponse(request);

            //Assert
            Assert.IsTrue(response.response.Count == 0);
        }

        [TestMethod]
        public void ZeroCountWithNoDRM()
        {
            //Arrange
            List<Payload> payloads = new List<Payload>();
            payloads.Add(new Payload { Drm = false, EpisodeCount = 0 });
            Request request = new Request { Payload = payloads };
            IFilterService _service = new FilterService();

            //Act
            var response = _service.GetFilteredResponse(request);

            //Assert
            Assert.IsTrue(response.response.Count == 0);
        }
    }


}
