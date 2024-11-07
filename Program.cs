namespace CompositePattern
{
    public interface IDocumentComponent
    {
        void Add(IDocumentComponent component);
        void Remove(IDocumentComponent component);
        void Display(int indentLevel = 0);
    }

 
    public class Paragraph : IDocumentComponent
    {
        private readonly string text;

        public Paragraph(string text)
        {
            this.text = text;
        }

        public void Add(IDocumentComponent component)
        {
            throw new NotSupportedException("Нельзя добавить к параграфу!");
        }

        public void Remove(IDocumentComponent component)
        {
            throw new NotSupportedException("Нельзя удалить из параграфа!");
        }

        public void Display(int indentLevel = 0)
        {
            Console.WriteLine($"{new string(' ', indentLevel * 2)}Параграф: {text}");
        }
    }

    public class Section : IDocumentComponent
    {
        private string title;
        private readonly List<IDocumentComponent> components = [];

        public Section(string title)
        {
            this.title = title;
        }

        public void Add(IDocumentComponent component)
        {
            components.Add(component);
        }

        public void Remove(IDocumentComponent component)
        {
            components.Remove(component);
        }

        public void Display(int indentLevel = 0)
        {
            Console.WriteLine($"{new string(' ', indentLevel * 2)}Раздел: {title}");
            foreach (var component in components)
            {
                component.Display(indentLevel + 1);
            }
        }
    }

    public class Document : IDocumentComponent
    {
        private readonly List<IDocumentComponent> sections = new List<IDocumentComponent>();

        public void Add(IDocumentComponent component)
        {
            sections.Add(component);
        }

        public void Remove(IDocumentComponent component)
        {
            sections.Remove(component);
        }

        public void Display(int indentLevel = 0)
        {
            Console.WriteLine("Структура документа:");
            foreach (var section in sections)
            {
                section.Display(indentLevel + 1);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Document document = new Document();

            Section section1 = new Section("Введение");
            section1.Add(new Paragraph("Это параграф введения."));

            Section section2 = new Section("Основное содержание");
            section2.Add(new Paragraph("Это параграф основного содержания."));

            Section section = new Section("Раздел");
            section.Add(new Paragraph("Это параграф в разделе."));
            section2.Add(section);

            document.Add(section1);
            document.Add(section2);

            document.Display();
        }
    }


}