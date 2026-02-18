namespace InterfaceDI_Practice
{
    internal class Program
    {
        public interface IToolInterface
        {
            public void SetHammer(Hammer hammer);
            public void SetDrill(Drill drill);

        }

        public class Hammer
        {
            public void UseHammer()
            {
                Console.WriteLine("Using hammer");
            }
        }

        public class Drill
        {
            public void UseDrill()
            {
                Console.WriteLine("Using drill");
            }
        }

        public class Builder : IToolInterface
        {
            Hammer _hammer;
            Drill _drill;

            

            public void SetHammer(Hammer hammer)
            {
                _hammer = hammer;
            }

            public void SetDrill(Drill drill)
            {
                _drill = drill;
            }

            public void Execute()
            {
                _hammer.UseHammer();
                _drill.UseDrill();
            }
        }

        static void Main(string[] args)
        {
            Hammer hammer = new();
            Drill drill = new();
            Builder builder = new();

            builder.SetDrill(drill);
            builder.SetHammer(hammer);

            builder.Execute();

            Console.ReadKey();
        }
    }
}
