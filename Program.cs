// See https://aka.ms/new-console-template for more information
using System.Reflection;
using static FanLaptop;

public class Program
{
    public static void Main()
    {
        /*
        kodeProduk kp = new kodeProduk();
        Console.WriteLine("Kode Produk untuk Laptop : " + kp.getKodeProduk(kodeProduk.Produk.Laptop));
        Console.WriteLine("Kode Produk untuk Smartphone : " + kp.getKodeProduk(kodeProduk.Produk.Smartphone));
        Console.WriteLine("Kode Produk untuk Tablet : " + kp.getKodeProduk(kodeProduk.Produk.Tablet));
        */

        
        FanLaptop fanLaptop = new FanLaptop();
        State state = State.Quiet;
        
        state = State.Balance;
        Console.WriteLine("“Fan Quiet berubah menjadi Balance");

        state = State.Performance;
        Console.WriteLine("“Fan Balance berubah menjadi Performance");

        state = State.Turbo;
        Console.WriteLine("“Fan Performance berubah menjadi Turbo");
        
    }
    
}


class kodeProduk {
    public enum Produk
    {
        Laptop,
        Smartphone,
        Tablet,
        Headset,
        Keyboard,
        Mouse,
        Printer,
        Monitor,
        Smartwatch,
        Kamera
    }

    public string[] kP = { 
        "E100",
        "E101",
        "E102",
        "E103",
        "E104",
        "E105",
        "E106",
        "E107",
        "E108",
        "E109"
    };

    public String getKodeProduk(Produk x) {
        return this.kP[(int)x];
    }
}


internal class FanLaptop
{
    public enum State
    {
        Quiet,
        Balance,
        Performance,
        Turbo
    }

    public enum Trigger
    {
        modeDown,
        modeUp,
        turboShortcut
    }

    class transition
    {
        public State prevState;
        public State nextState;
        public Trigger trigger;
        public State currentState = State.Quiet;
        public transition(State prevState, State nextState, Trigger trigger)
        {
            this.prevState = prevState;
            this.nextState = nextState;
            this.trigger = trigger;
        }

        transition[] transitions =
            {
            new transition(State.Quiet, State.Balance, Trigger.modeUp),
            new transition(State.Balance, State.Performance, Trigger.modeUp),
            new transition(State.Performance, State.Turbo, Trigger.modeUp),
            new transition(State.Turbo, State.Performance, Trigger.modeDown),
            new transition(State.Performance, State.Balance, Trigger.modeDown),
            new transition(State.Balance, State.Quiet, Trigger.modeDown),
            new transition(State.Quiet, State.Turbo, Trigger.turboShortcut),
            new transition(State.Turbo, State.Quiet, Trigger.turboShortcut)
        };

        public State getNextState(State prevState, Trigger trigger)
        {
            foreach (var wow in transitions)
            {
                if (prevState == wow.nextState && trigger == wow.trigger)
                {
                    return wow.nextState;
                }
            }
            return prevState;
        }
        public void activateTrigger(Trigger trigger)
        {
            State prevState = currentState;
            State nextState = getNextState(currentState, trigger);
            currentState = nextState;
        }

    }   
}