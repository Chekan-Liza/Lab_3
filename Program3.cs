using System;
/* Создать класс Product. Поля – id, наименование, UPC, производитель, цена, срок хранения, количество.
 * Добавить метод вывода общей суммы продукта.
 * Проверка корректности. 
 * Создать массив объектов. Вывести:
 * a) список товаров для заданного наименования; 
 * b) список товаров для заданного наименования, цена которых не превосходит заданную;*/
namespace OAP_Laba_3
{   class Product
    {   public static uint Count { get; private set; } //количество + ограничение по set
        private readonly int Id; //id; поле только для чтения
        private string Name; //наименование 
        private int UPC; //UPC
        private string Producer; //производитель
        private float Price; //цена 
        private int Term; //срок хранения 
        public float price
        {   get
            { return Price;}
            set
            {   if (value.GetType() == price.GetType())
                { if (Price > 0)
                    { Price = value; }}
                else
                {   Console.WriteLine("Error");
                    Price = -1; }
            }
        }
        public int term
        {   get { return Term; }
            set
            {   if (value.GetType() == term.GetType())
                {   if (Term > 0)
                    { Term = value; } }
                else
                {   Console.WriteLine("Error");
                    Term = -1; }
            }
        }
        public string name
        {   get
            { return Name;}
            set
            {   if (value.GetType() == name.GetType()) 
                {   if (!(Name == ""))
                    { Name = value;}}
                else
                {   Console.WriteLine("Error: no name!");
                    Name = "Nothing"; }
            }
        }
        public string producer
        {   get
            { return Producer; }
            set
            {   if (value.GetType() == producer.GetType())
                {   if (!(Producer == ""))
                    { Producer = value; } }
                else
                {   Console.WriteLine("Error: no name!");
                    Producer = "Nothing"; }
            }
        }
        public int upc
        {   get { return UPC; }
            set
            {   if (value.GetType() == upc.GetType())
                {   UPC = value; }
                else
                {   Console.WriteLine("Error");
                    UPC = 0; }
            }
        }
// Конструкторы
        private Product() //закрытый конструктор
        {   Id = GetHashCode(); //хэш-код объекта
            Count++; //увеличение количества
        }
        public Product(float price = 23.15f) : this() // ПЕРВЫЙ
        {   Name = "Масляные краски";
            Producer = "Невская палитра";
            UPC = 31065498;
            Term = 2;
            this.Price = price;
        }
        public Product(int upc, string name, int term, string producer, float price) : this()
        {   this.UPC = upc;
            this.Name = name;
            this.Term = term;
            this.Price = price;
            this.Producer = producer;
        }
/* Статич. конструктор исп. для инициализации любых статич. данных или для выполн. определ. действия, кот. треб. выполнить только один раз.
 * Он вызывается автом-ки перед созд. первого экземпляра или ссылкой на какие-либо статич. члены.*/
        static Product()
        {   Console.WriteLine("Статический конструктор (cоздание первого объекта)\n");
            Count = 0; }
        public void TotalSum(ref float price, out float sum)
        { sum = price; }
/* Создайте в классе статич. поле, хранящее кол-во созд. объектов (инкрементируется в конструкторе) и стат. метод вывода инф-ии о классе.*/
        static public void ShowInfo()
        { Console.WriteLine($"Количество созданных объектов: {Count}");}
/* Модификатор override требуется для расшир. или изм. абстрактн./вирт. реализ/ унасл. метода, свойства, индексатора или события.*/
        public override int GetHashCode()
        {return base.GetHashCode(); }//Служит в качестве хэш-функции по умолчанию.
        public override bool Equals(object obj)
        {return base.Equals(obj); }//Определяет, равен ли указанный объект текущему объекту.
        public override string ToString() //Возвращает строку, представляющую текущий объект.
        {   string str;
            str = "ID = " + Id + ";\nНаименование продукта: " + Name + ";\nПроизводитель: " + Producer + ";\nЦена = " + Price + " б.р."
                + ";\nUPC: " + UPC + ";\nСрок хранения: " + Term + " г.\n";
            return str;
        }
// Класс partial
        public partial class Part
        { int a; }
        public partial class Part
        {   public Part(int a)
            { this.a = a = 2027;}
            public void Method()
            { Console.WriteLine($"Class partial. a = {a}");}
        }
    }
    class Program
    {   static void Main(string[] args)
        {   float price, sum;
            float[] ArrSum = new float[10];
            Product[] ArrProduct = new Product[10];
//-----------------------------------------------------------ПЕРВЫЙ
            ArrProduct[0] = new Product();
            Console.WriteLine(ArrProduct[0]);

            price = ArrProduct[0].price;
            ArrProduct[0].TotalSum(ref price, out sum);
            Console.WriteLine($"\nОбщая сумма = {sum}\n");
            ArrSum[0] = sum;
//-----------------------------------------------------------ВТОРОЙ
            ArrProduct[1] = new Product(20.0f);
            Console.WriteLine(ArrProduct[1]);

            ArrProduct[1].name = "Гуашь";
            ArrProduct[1].producer = "Невская палитра";
            ArrProduct[1].term = 1;
            ArrProduct[1].upc = 10141710;

            price = ArrProduct[1].price;
            ArrProduct[1].TotalSum(ref price, out sum);
            Console.WriteLine($"Общая сумма = {sum+ ArrSum[0]}\n");
            ArrSum[1] = sum + ArrProduct[0].price;
//-----------------------------------------------------------ТРЕТИЙ
            ArrProduct[2] = new Product(28.31f);
            Console.WriteLine(ArrProduct[2]);

            ArrProduct[2].name = "Масляные краски";
            ArrProduct[2].producer = "Гамма";
            ArrProduct[2].term = 2;
            ArrProduct[2].upc = 25143612;

            price = ArrProduct[2].price;
            ArrProduct[2].TotalSum(ref price, out sum);
            Console.WriteLine($"Общая сумма = {sum+ ArrSum[1]}\n");
            ArrSum[2] = ArrSum[1] + ArrProduct[2].price;
//-----------------------------------------------------------ЧЕТВЕРТЫЙ
            ArrProduct[3] = new Product();
            ArrProduct[3].price = 24.61f;
            ArrProduct[3].term = 1;
            ArrProduct[3].name = "Гуашь";
            ArrProduct[3].producer = "Невская палитра";
            ArrProduct[3].upc = 35610249;

            Console.WriteLine(ArrProduct[3]);
            price = ArrProduct[3].price;
            ArrProduct[3].TotalSum(ref price, out sum);
            Console.WriteLine($"Общая сумма = {sum+ ArrSum[2]}\n");
            ArrSum[3] = ArrSum[2] + ArrProduct[3].price;
//-----------------------------------------------------------ПЯТЫЙ
            ArrProduct[4] = new Product();
            ArrProduct[4].price = 73.72f;
            ArrProduct[4].term = 3;
            ArrProduct[4].name = "Масляные краски";
            ArrProduct[4].producer = "Derwent House";
            ArrProduct[4].upc = 43129756;

            Console.WriteLine(ArrProduct[4]);

            price = ArrProduct[4].price;
            ArrProduct[4].TotalSum(ref price, out sum);
            Console.WriteLine($"Общая сумма = {sum+ ArrSum[3]}\n");
//Анонимный тип
            var AnonymType = new 
            {   price = 20.0f,
                term = 1  };
            Console.WriteLine("\n" + AnonymType.GetType() + AnonymType + "\n");

            ProductList(ArrProduct);
            ProductList_Price(ArrProduct, ArrSum);
        }
//a) Список товаров для заданного наименования
        static void ProductList(Product[] arr)
        {   Console.WriteLine("\nСписок товаров - ГУАШЬ:\n");
            for (int i = 0; i < Product.Count; i++)
            {   if (arr[i].name == "Гуашь")
                { Console.WriteLine(arr[i] + "\n");}
            }
        }
//b) Список товаров для заданного наименования, цена которых не превосходит заданную
        static void ProductList_Price(Product[] arr, float[] arrF)////////////////////////////?????????? второй параметр
        {   Console.WriteLine("Список товаров - МАСЛЯНЫЕ КРАСКИ (До 50.0 б.р.):\n");
            for (int i = 0; i < Product.Count; i++)
            {   if (arr[i].name == "Масляные краски")
                {   if (arr[i].price < 50.0)
                    {Console.WriteLine(arr[i] + "\n");}
                }
            }
        }
    }
}