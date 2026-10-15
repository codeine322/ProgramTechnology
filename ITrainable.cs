namespace SpaceCrew
{
    /// <summary>
    /// Defines a contract for crew members who can undergo training.
    /// </summary>
    public interface ITrainable
    {
        void Train(string program);
    }
}