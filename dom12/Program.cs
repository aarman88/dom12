using System;

// Абстрактный класс "Автомобиль"
abstract class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public Car(string model, int speed)
    {
        Model = model;
        Speed = speed;
    }

    public abstract void Move();

    // Событие для уведомления о финише
    public event EventHandler Finished;

    protected virtual void OnFinished()
    {
        Finished?.Invoke(this, EventArgs.Empty);
    }
}

// Класс "Спортивный автомобиль"
class SportsCar : Car
{
    public SportsCar(string model, int speed) : base(model, speed) { }

    public override void Move()
    {
        Console.WriteLine($"{Model} двигается со скоростью {Speed} км/ч.");
        if (Speed >= 100)
        {
            Console.WriteLine($"{Model} пришел к финишу!");
            OnFinished();
        }
    }
}

// Класс "Легковой автомобиль"
class SedanCar : Car
{
    public SedanCar(string model, int speed) : base(model, speed) { }

    public override void Move()
    {
        Console.WriteLine($"{Model} двигается со скоростью {Speed} км/ч.");
        if (Speed >= 100)
        {
            Console.WriteLine($"{Model} пришел к финишу!");
            OnFinished();
        }
    }
}

// Класс "Грузовик"
class Truck : Car
{
    public Truck(string model, int speed) : base(model, speed) { }

    public override void Move()
    {
        Console.WriteLine($"{Model} двигается со скоростью {Speed} км/ч.");
        if (Speed >= 100)
        {
            Console.WriteLine($"{Model} пришел к финишу!");
            OnFinished();
        }
    }
}

// Класс "Автобус"
class Bus : Car
{
    public Bus(string model, int speed) : base(model, speed) { }

    public override void Move()
    {
        Console.WriteLine($"{Model} двигается со скоростью {Speed} км/ч.");
        if (Speed >= 100)
        {
            Console.WriteLine($"{Model} пришел к финишу!");
            OnFinished();
        }
    }
}

// Класс игры "Гонки"
class RaceGame
{
    // Делегат для вызова методов из классов автомобилей
    public delegate void RaceHandler();

    // Событие для начала гонки
    public event RaceHandler RaceStarted;

    public void StartRace()
    {
        Console.WriteLine("Гонка началась!");
        RaceStarted?.Invoke();
    }

    // Событие для вывода сообщения о текущем положении автомобилей
    public event EventHandler<string> PositionChanged;

    public void UpdatePosition(string message)
    {
        PositionChanged?.Invoke(this, message);
    }

    // Событие для вывода сообщения о победителе
    public event EventHandler<string> WinnerDeclared;

    public void DeclareWinner(string winner)
    {
        WinnerDeclared?.Invoke(this, winner);
    }
}

class Program
{
    static void Main()
    {
        RaceGame raceGame = new RaceGame();

        // Создание автомобилей
        SportsCar sportsCar = new SportsCar("Спортивный автомобиль", 0);
        SedanCar sedanCar = new SedanCar("Легковой автомобиль", 0);
        Truck truck = new Truck("Грузовик", 0);
        Bus bus = new Bus("Автобус", 0);

        // Подписка на событие начала гонки
        raceGame.RaceStarted += sportsCar.Move;
        raceGame.RaceStarted += sedanCar.Move;
        raceGame.RaceStarted += truck.Move;
        raceGame.RaceStarted += bus.Move;

        // Подписка на событие изменения положения
        raceGame.PositionChanged += (sender, message) => Console.WriteLine(message);

        // Подписка на событие объявления победителя
        raceGame.WinnerDeclared += (sender, winner) => Console.WriteLine($"Победитель: {winner}");

        // Запуск гонок
        raceGame.StartRace();

        // Эмуляция движения автомобилей (обычно это происходит в цикле с использованием таймеров)
        sportsCar.Speed = 90;
        sedanCar.Speed = 95;
        truck.Speed = 80;
        bus.Speed = 100;

        // Уведомление о финише (обычно это происходит, когда какой-то автомобиль достигнет финиша)
        raceGame.DeclareWinner("Спортивный автомобиль");
    }
}
