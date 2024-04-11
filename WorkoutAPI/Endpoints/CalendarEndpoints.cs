using WorkoutAPI.Services;

namespace WorkoutAPI.Endpoints
{
    public static class CalendarEndpoints
    {
        public static void MapCalendarEndpoints(this WebApplication app)
        {
            app.MapPost("/calendar/{date}/workouts", (IWorkoutService workoutService, DateTime date, string workoutId) =>
            {
                try
                {
                    workoutService.LinkWorkoutToCalendar(date, workoutId);
                    return Results.Ok();
                }
                catch (KeyNotFoundException knfex)
                {
                    return Results.BadRequest(knfex.Message);
                }
                catch (Exception ex)
                {
                    var errorMsg = $"An unexpected error occurred: {ex.Message}";
                    Console.WriteLine(errorMsg);

                    return Results.Problem(detail: errorMsg, statusCode: 500);
                }
            });

            app.MapGet("/calendar/{date}/workouts", (IWorkoutService workoutService, DateTime date) =>
            {
                var workouts = workoutService.GetWorkoutsForDate(date);
                return workouts != null ? Results.Ok(workouts) : Results.NotFound("No workouts found for the requested date.");
            });
        }
    }
}
