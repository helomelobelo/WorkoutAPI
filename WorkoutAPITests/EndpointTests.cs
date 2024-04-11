using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WorkoutAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace WorkoutAPITests
{
    // TODO Fix the voodoo magic with WebApplicationFactory not finding files
    // Didn't have time to sort this out
    public class EndpointTests // : IClassFixture<WebApplicationFactory<Program>>
    {
        //private readonly HttpClient _client;

        //public EndpointTests(WebApplicationFactory<Program> factory)
        //{
        //    _client = factory.CreateClient();
        //}

        //[Fact]
        //public async Task GetWorkout_ReturnsNotFoundForInvalidId()
        //{

        //    var response = await _client.GetAsync("/workouts/nonexistentid");
        //    Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        //}

        //[Fact]
        //public async Task CreateWorkout_ReturnsCreatedAtRoute()
        //{
        //    // Arrange
        //    var newWorkout = new Workout
        //    {
        //        Title = "Test Workout",
        //        Description = "A sample workout for testing.",
        //        Exercises = new List<Exercise>
        //    {
        //        new Exercise { Name = "Push-up", Sets = 3, Reps = 10, Duration = "00:00:30" }
        //    }
        //    };
        //    var content = JsonContent.Create(newWorkout);

        //    var response = await _client.PostAsync("/workouts", content);

        //    response.EnsureSuccessStatusCode(); // Expected 201
        //    Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        //    var location = response.Headers.Location?.ToString();
        //    Assert.NotNull(location);
        //}
    }
}