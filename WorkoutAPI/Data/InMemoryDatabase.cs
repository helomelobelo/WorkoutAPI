using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutAPI.Models;

namespace WorkoutAPI.Data
{
    public class InMemoryDatabase
    {
        // Map for the fake data map id->value
        private readonly Dictionary<string, Workout> _workouts = new Dictionary<string, Workout>();
        private readonly Dictionary<DateTime, List<string>> _calendar = new Dictionary<DateTime, List<string>>();

        public Workout CreateWorkout(Workout workout)
        {
            workout.Id = Guid.NewGuid().ToString();
            _workouts[workout.Id] = workout;
            return workout;
        }

        public Workout GetWorkout(string id)
        {
            _workouts.TryGetValue(id, out var workout);
            return workout;
        }

        public bool DeleteWorkout(string id)
        {
            return _workouts.Remove(id);
        }

        public WorkoutSummary GetWorkoutSummary(string id)
        {
            // Place null in output var if cannot get value
            if (!_workouts.TryGetValue(id, out var workout))
                return null;

            var summary = new WorkoutSummary
            {
                WorkoutId = workout.Id,
                TotalSets = workout.Exercises.Sum(e => e.Sets),
                TotalReps = workout.Exercises.Sum(e => e.Reps),
                TotalDuration = CalculateTotalDuration(workout.Exercises)
            };

            return summary;
        }

        public void LinkWorkoutToCalendar(DateTime date, string workoutId)
        {
            // Only actual date, not time
            DateTime dateOnly = date.Date;

            if (!_workouts.ContainsKey(workoutId))
                throw new KeyNotFoundException($"Workout with ID '{workoutId}' does not exist.");

            if (!_calendar.ContainsKey(dateOnly))
                _calendar[dateOnly] = new List<string>();

            _calendar[dateOnly].Add(workoutId);
        }


        public List<Workout> GetWorkoutsForDate(DateTime date)
        {
            // Only actual date, not time
            DateTime dateOnly = date.Date;

            if (!_calendar.TryGetValue(dateOnly, out var workoutIds))
                return new List<Workout>();

            return workoutIds.Select(id => GetWorkout(id)).ToList();
        }

        private string CalculateTotalDuration(List<Exercise> exercises)
        {
            // Sum up all TimeSpan objects and then return the total duration as a formatted string.
            TimeSpan totalDuration = exercises.Select(e => TimeSpan.ParseExact(e.Duration, @"hh\:mm\:ss", null)).Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            return totalDuration.ToString(@"hh\:mm\:ss");
        }
    }
}
