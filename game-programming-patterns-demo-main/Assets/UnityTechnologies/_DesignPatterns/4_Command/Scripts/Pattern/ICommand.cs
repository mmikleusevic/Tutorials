namespace DesignPatterns.Command
{
    // interface to wrap your actions in a "command object"
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}