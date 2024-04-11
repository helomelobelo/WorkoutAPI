# How to use
1. Open the project with Visual Studio 2022 and launch WorkoutAPI project in https mode.
2. Application will host the REST API at localhost:5000
3. Test using SwaggerUI or any other REST client


## Some test lines
Creating a workout
``` POST /workouts```
```
{
  "title": "Morning Workout",
  "description": "Workout in the woods in the morning...",
  "exercises": [
    {
      "name": "Push Ups",
      "sets": 3,
      "reps": 15,
      "duration": "00:15:00"
    },
    {
      "name": "Jumps",
      "sets": 1,
      "reps": 30,
      "duration": "00:10:30"
    }
  ]
}
```

Getting a workout
``` GET /workouts/{id}```

Deleting a workout
``` DELETE /workouts/{id}```

Getting a summary for a workout
``` GET /workouts/{id}/summary```

Linking a date to a workout
``` POST /calendar{date}/workouts  + (string workoutId as query parameter)```

Get workouts linked to a date
``` GET /calendar{date}/workouts```