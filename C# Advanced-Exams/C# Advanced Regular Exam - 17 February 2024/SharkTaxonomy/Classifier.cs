namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }
        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if (GetCount < Capacity && !Species.Exists(s => s.Kind == shark.Kind))
            {
                Species.Add(shark);
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark shark = Species.Find(s => s.Kind == kind);
            if (shark != null)
            {
                Species.Remove(shark);
                return true;
            }
            return false;
        }

        public string GetLargestShark()
        {
            return Species.OrderByDescending(s => s.Length).FirstOrDefault().ToString();
        }

        public double GetAverageLength()
        {
            return Species.Average(s => s.Length);
        }

        public string Report()
        {
            return $"{GetCount} sharks classified:" +
                   Environment.NewLine +
                   $"{String.Join(Environment.NewLine, Species)}";
        }
    }
}
