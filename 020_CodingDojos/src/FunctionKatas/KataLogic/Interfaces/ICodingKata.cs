namespace KataLogic.Interfaces
{
    public interface ICodingKata
    {
        object Result
        {
            get;
        }

        void SetContent(object content);

        void Execute();
    }
}
