using System.ComponentModel;

namespace Trophylibrary
{
    public class Trophy
    {
        private int id;
        private string competition;
        private int year;

        public int Id { get; set; }

        public string? Competition
        {
            get => competition;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name is null");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Competition name must be at least 3 characters");
                }
                competition = value;
            }
        }

        public int Year
        {
            get => year;
            set
            {
                if (value < 1970 || value > 2025)
                {
                    throw new ArgumentOutOfRangeException(nameof(Year), "Year must be between 1970 and 2025");
                }
                year = value;
            }
        }

        public Trophy(int id, string competition, int year)
        {
            this.id = id;
            this.competition = competition;
            this.year = year;
        }

        public Trophy() : this(0, "blank", 0) { }

        public override string ToString()
        {
            return $"Trophy: Id = {Id} Competition = {competition}, Year = {year}";
        }

    }
}
