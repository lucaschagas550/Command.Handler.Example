namespace CommandHandler.Test.Model
{
    public class MeuEvento
    {
        public static event EventHandler Send;

        public static void DispararEvento()
        {
            // Lógica para disparar o evento
            Send?.Invoke(null, EventArgs.Empty);
        }
    }
}
