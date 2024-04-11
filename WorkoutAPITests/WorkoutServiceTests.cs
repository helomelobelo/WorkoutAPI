using Moq;
using WorkoutAPI.Data;
using WorkoutAPI.Models;
using WorkoutAPI.Services;

namespace WorkoutAPITests
{
    public class WorkoutServiceTests
    {
        [Fact]
        public void CreateWorkout_AddsWorkoutSuccessfully()
        {
            var mockDb = new Mock<InMemoryDatabase>();
            var service = new WorkoutService(mockDb.Object);
            var workout = new Workout
            {
                Title = "Morning Routine",
                Description = "Quick morning workout to start the day",
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Push-ups", Sets = 3, Reps = 10, Duration = "00:00:30" }
                }
            };

            var result = service.CreateWorkout(workout);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void GetWorkoutById_ReturnsCorrectWorkout()
        {
            var mockDb = new Mock<InMemoryDatabase>();
            var workout = new Workout { Title = "Test Workout" };
            var service = new WorkoutService(mockDb.Object);

            var id = service.CreateWorkout(workout).Id;
            var result = service.GetWorkoutById(id);

            Assert.Equal(workout, result);
        }

        [Fact]
        public void GetWorkoutById_ReturnsNullWhenNotFound()
        {
            var mockDb = new Mock<InMemoryDatabase>();
            var service = new WorkoutService(mockDb.Object);

            var result = service.GetWorkoutById("nonexistent id");

            Assert.Null(result);
        }
    
        // TODO MORE TESTS
    }
}
