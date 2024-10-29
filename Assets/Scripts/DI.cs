

public class DI
{
    public static readonly DI di = new DI();

    public EconomyManager economy = new EconomyManager();

    private DI() { }
}
