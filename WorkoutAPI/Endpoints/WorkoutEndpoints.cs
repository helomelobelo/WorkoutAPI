using Microsoft.AspNetCore.Mvc;
using WorkoutAPI.Models;
using WorkoutAPI.Services;

namespace WorkoutAPI.Endpoints
{
    public static class WorkoutEndpoints
    {
        public static void MapWorkoutEndpoints(this WebApplication app)
        {
            app.MapPost("/workouts", async (IWorkoutService workoutService, Workout workout) =>
            {
                try
                {
                    return Results.Created($"/workouts/{workout.Id}", workoutService.CreateWorkout(workout));
                }
                catch(ArgumentException aex)
                {
                    return Results.BadRequest(aex.Message);
                }
                catch (Exception ex)
                {
                    var errorMsg = $"An unexpected error occurred: {ex.Message}";
                    Console.WriteLine(errorMsg);

                    return Results.Problem(detail: errorMsg, statusCode: 500);
                }
            });

            // TODO additional endpoints for updating workouts if needed

            app.MapGet("/workouts/{id}", (IWorkoutService workoutService, string id) =>
            {
                var workout = workoutService.GetWorkoutById(id);
                return workout != null ? Results.Ok(workout) : Results.NotFound();
            });

            app.MapDelete("/workouts/{id}", (IWorkoutService workoutService, string id) =>
            {
                return workoutService.DeleteWorkout(id) ? Results.Ok() : Results.NotFound();
            });

            app.MapGet("/workouts/{id}/summary", (IWorkoutService workoutService, string id) =>
            {
                var summary = workoutService.GetWorkoutSummary(id);
                return summary != null ? Results.Ok(summary) : Results.NotFound();
            });
        }
    }
}
