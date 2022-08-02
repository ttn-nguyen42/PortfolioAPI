using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Contexts;
using Portfolio.Models;
using Xunit.Abstractions;

namespace Portfolio.IntegrationTests.Tests
{
    public class ResumeControllerTest : IntegrationBase
    {

        public ResumeControllerTest(ITestOutputHelper logger) : base(logger)
        {
        }

        [Fact]
        public async Task GetResume_NonExistentId_ReturnsNotFound()
        {

            // Arrange
            int resumeId = 2;

            // Act
            HttpResponseMessage response = await Client.GetAsync($"/api/v1/resumes/{resumeId}");


            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Content.Should().NotBeNull();

            ExceptionMessage? body = await Deserialize<ExceptionMessage>(response.Content);
            body.Should().NotBeNull();
            body?.Message.Should().BeEquivalentTo("Resume not found");
        }

        [Fact]
        public async Task AddResume_CorrectModel_ReturnsCorrectDto()
        {
            // Arrange
            ResumeCreationDto creation = new ResumeCreationDto("Test Resume", "This is a short biography", "This is a longer biography", "Ho Chi Minh City, Vietnam", "ttn.nguyen42@gmail.com");

            // Act 
            StringContent payload = Serialize(creation);
            HttpResponseMessage response = await Client.PostAsync("/api/v1/resumes", payload);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Content.Should().NotBeNull();

            ResumeWithInfoAndAboutDto? result = await Deserialize<ResumeWithInfoAndAboutDto>(response.Content);
            result.Should().NotBeNull();
        }
    }
}
