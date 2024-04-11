using System;
using System.Collections.Generic;
using WorkoutAPI.Models;


namespace WorkoutAPI.Services
{
    public interface IWorkoutService
    {
        Workout CreateWorkout(Workout workout);
        Workout GetWorkoutById(string id);
        bool DeleteWorkout(string id);
        WorkoutSummary GetWorkoutSummary(string id);
        void LinkWorkoutToCalendar(DateTime date, string workoutId);
        List<Workout> GetWorkoutsForDate(DateTime date);
    }
}
