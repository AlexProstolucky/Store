public delegate void BI();
class Book 
{
    string name;
    string author;
    public int price;
    public Book(string name, string author, int price)
    {
        this.name = name;
        this.author = author;
        this.price = price;
    }

    public void info() 
    {
        Console.WriteLine($"  Назва книги: {name}\n  Автор: {author}\n  Ціна: {price}");
    }
}
class Offer 
{
    BI bi;
    int number;
    int total_price;
    int amount;
    List<Book> offer = new List<Book>();
    public void create() 
    {
        Console.WriteLine("Введіть кількість книжок для створення замовлення та його заповнення: ");
        number = Int32.Parse(Console.ReadLine());
        if (number > 0) 
        {
            string name;
            string author;
            int price;
            for (int i = 0; i < number; i++)
            {
                Console.Write("Введіть назву книги: ");
                name = Console.ReadLine();
                Console.Write("Введіть автора книги: ");
                author = Console.ReadLine();
                Console.Write("Введіть ціну книги: ");
                price = Int32.Parse(Console.ReadLine());
                offer.Add(new Book(name, author, price));
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Замовлення успішно створено!");
        }
        else Console.WriteLine("Хибний ввід!");
    }

    public void create(int number, params Book[] b)
    {
        if (number > 0)
        {
            foreach (var book in b) 
            {
                offer.Add(book);
            }
            Console.WriteLine("Замовлення успішно створено!");
        }
    }


    public int get_price() 
    {
        if (offer.Count() != 0)
        {
            foreach (var item in offer)
            {
                total_price += item.price;
            }
        }
        else Console.WriteLine("Корзина пуста!");

        return total_price;
    }

    public void info() 
    {
        if (offer.Count() != 0)
        {
            Console.WriteLine("Замовлення:");
            foreach (var item in offer)
            {
                Console.WriteLine(" Книга:");
                bi = item.info;
                bi();
            }
        }
        else Console.WriteLine("Корзина пуста!");
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Book b1 = new Book("1", "A", 100);
        Book b2 = new Book("2", "B", 200);
        Book b3 = new Book("3", "C", 300);

        Offer f = new Offer();
        f.create(3,b1, b2, b3);
        f.info();
    }
}