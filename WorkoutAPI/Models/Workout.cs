namespace WorkoutAPI.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
