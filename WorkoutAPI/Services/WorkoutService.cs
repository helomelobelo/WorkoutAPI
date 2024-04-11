using WorkoutAPI.Data;
using WorkoutAPI.Models;

namespace WorkoutAPI.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly InMemoryDatabase _database;

        public WorkoutService(InMemoryDatabase database)
        {
            _database = database;
        }

        public Workout CreateWorkout(Workout workout)
        {
            return _database.CreateWorkout(workout);
        }

        public Workout GetWorkoutById(string id)
        {
            return _database.GetWorkout(id);
        }

        public bool DeleteWorkout(string id)
        {
            return _database.DeleteWorkout(id);
        }

        public WorkoutSummary GetWorkoutSummary(string id)
        {
            return _database.GetWorkoutSummary(id);
        }

        public void LinkWorkoutToCalendar(DateTime date, string workoutId)
        {
            _database.LinkWorkoutToCalendar(date, workoutId);
        }

        public List<Workout> GetWorkoutsForDate(DateTime date)
        {
            return _database.GetWorkoutsForDate(date);
        }
    }
}
