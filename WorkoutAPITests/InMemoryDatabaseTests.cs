using WorkoutAPI.Models;
using WorkoutAPI.Data;

namespace WorkoutAPITests
{
    public class InMemoryDatabaseTests
    {
        [Fact]
        public void CreateWorkout_AddsWorkoutSuccessfully()
        {
            var workoutName = "Morning Routine";
            var workoutDescription = "Quick morning workout to start the day";

            var db = new InMemoryDatabase();
            var workout = new Workout
            {
                Title = workoutName,
                Description = workoutDescription,
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Push-ups", Sets = 3, Reps = 10, Duration = "00:00:30" }
                }
            };

            var createdWorkout = db.CreateWorkout(workout);

            Assert.NotNull(createdWorkout.Id);
        }

        [Fact]
        public void GetWorkout_ReturnsCorrectWorkout()
        {
            var workoutName = "Evening Stretch";
            var workoutDescription = "Relaxing stretches for the evening";

            var db = new InMemoryDatabase();
            var workout = new Workout
            {
                Title = workoutName,
                Description = workoutDescription,
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Hamstring Stretch", Sets = 1, Reps = 1, Duration = "00:05:00" }
                }
            };
            var createdWorkout = db.CreateWorkout(workout);

            var retrievedWorkout = db.GetWorkout(createdWorkout.Id);
            Assert.Equal(workoutName, retrievedWorkout.Title);
            Assert.Equal(workoutDescription, retrievedWorkout.Description);
            Assert.Single(retrievedWorkout.Exercises);
        }

        [Fact]
        public void GetWorkoutSummary_ReturnsCorrectSummary()
        {
            var db = new InMemoryDatabase();
            var workout = new Workout
            {
                Exercises = new List<Exercise>
                {
                    new Exercise { Name = "Sit ups", Sets = 3, Reps = 20, Duration = "00:01:00" },
                    new Exercise { Name = "Jumping Jacks", Sets = 2, Reps = 30, Duration = "00:02:00" }
                }
            };
            var createdWorkout = db.CreateWorkout(workout);

            var summary = db.GetWorkoutSummary(createdWorkout.Id);
            Assert.Equal(5, summary.TotalSets); // 3 sets of Sit ups + 2 sets of Jumping Jacks
            Assert.Equal(50, summary.TotalReps); // 20 reps of Sit ups + 30 reps of Jumping Jacks
            Assert.Equal("00:03:00", summary.TotalDuration); // Total duration
        }

        // TODO more tests
    }
}