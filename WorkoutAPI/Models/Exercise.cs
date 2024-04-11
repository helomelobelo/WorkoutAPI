namespace WorkoutAPI.Models
{
    public class Exercise
    {
        public string Name { get; set; }
        private int sets;
        private int reps;
        private TimeSpan duration;

        public int Sets
        {
            get => sets;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sets must => 0");
                sets = value;
            }
        }

        public int Reps
        {
            get => reps;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Reps must be => 0");
                reps = value;
            }
        }

        public string Duration
        {
            get => duration.ToString(@"hh\:mm\:ss");
            set
            {
                if (!TimeSpan.TryParseExact(value, @"hh\:mm\:ss", null, out duration))
                    throw new ArgumentException("Duration must be in the format of 'hh:mm:ss'.");
            }
        }
    }
}
