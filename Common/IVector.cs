namespace BotFactory.Common.Interface
{
    public interface IVector
    {
        double X { set; get; }
        double Y { set; get; }
        double Length();
    }
}
