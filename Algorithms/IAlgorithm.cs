namespace Algorithms
{
    public interface IAlgorithm
    {
        public string Title { get; }

        public void Test(int variant, int[] inputArray);
    }
}