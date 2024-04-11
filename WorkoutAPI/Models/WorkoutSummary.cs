namespace WorkoutAPI.Models
{
    public class WorkoutSummary
    {
        public string WorkoutId { get; set; }
        public int TotalSets { get; set; }
        public int TotalReps { get; set; }
        private TimeSpan totalDuration;

        public string TotalDuration
        {
            get => totalDuration.ToString(@"hh\:mm\:ss");
            set => totalDuration = TimeSpan.ParseExact(value, @"hh\:mm\:ss", null);
        }
    }
}
