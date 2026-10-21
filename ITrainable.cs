namespace SpaceCrew
{
    /// <summary>
    /// Договор для членов экипажа, которые могут пройти обучение.
    /// </summary>
    public interface ITrainable
    {
        void Train(string program);
    }
}