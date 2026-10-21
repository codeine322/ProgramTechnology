namespace SpaceCrew
{
    /// <summary>
    /// Договор для членов экипажа, которые могут пройти обучение.
    /// </summary>
    public interface ITrainable
    {
        /// <summary>
        /// Проходит обучение по указанной программе.
        /// </summary>
        /// <param name="program">Название программы обучения.</param>
        void Train(string program);
    }
}