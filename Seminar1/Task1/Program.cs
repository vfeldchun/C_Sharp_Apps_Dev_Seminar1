// Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран
// близких родственников (жену/мужа). Продумайте способ более красивого вывода с использованием
// горизонтальных и вертикальных черточек.

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new FamalyMember("Иван", "Петров", "12.07.2003");
            person.MemberGender = FamalyMember.Gender.Male;

            var personFather = new FamalyMember("Петр", "Петров", "08.12.1980");
            var personMother = new FamalyMember("Ирина", "Савина", "12.06.1982");
            var personWife = new FamalyMember("Евгения", "Суворова", "02.03.2003");
            var personSon = new FamalyMember("Михаил", "Петров", "01.09.2022");
            var personDaughter = new FamalyMember("Екатерина", "Петрова", "19.07.2021");
            var personGrandFatherByMale = new FamalyMember("Николай", "Петров", "05.03.1958");
            var personGrandMatherByMale = new FamalyMember("Елизавета", "Забельская", "10.08.1959");
            var personGrandFatherByFemale = new FamalyMember("Альберт", "Савин", "15.11.1959");
            var personGrandMatherByFemale = new FamalyMember("Мария", "Заединова", "09.10.1960");

            var wifeFather = new FamalyMember("Алексей", "Суворов", "12.04.1979");
            var wifeMother = new FamalyMember("Пелагея", "Козлова", "15.06.1980");
            var wifeGrandFatherByMale = new FamalyMember("Роман", "Суворов", "21.06.1955");
            var wifeGrandMatherByMale = new FamalyMember("Дарья", "Синицина", "05.01.1957");
            var wifeGrandFatherByFemale = new FamalyMember("Лев", "Козлов", "17.05.1957");
            var wifeGrandMatherByFemale = new FamalyMember("Ольга", "Фролова", "23.06.1958");

            // Добавляем бабушек, дедушек, папу и маму для основной персоны
            personFather.AddMother(personGrandMatherByMale);
            personFather.AddFather(personGrandFatherByMale);
            personMother.AddMother(personGrandMatherByFemale);
            personMother.AddFather(personGrandFatherByFemale);
            personGrandFatherByMale.AddWife(personGrandMatherByMale, "12.05.1979");
            personGrandFatherByFemale.AddWife(personGrandMatherByFemale, "23.08.1978");
            person.AddMother(personMother);
            person.AddFather(personFather);

            // Добавляем бабушек, дедушек, папу и маму для жены персоны
            wifeFather.AddMother(wifeGrandMatherByMale);
            wifeFather.AddFather(wifeGrandFatherByMale);
            wifeMother.AddMother(wifeGrandMatherByFemale);
            wifeMother.AddFather(wifeGrandFatherByFemale);
            wifeGrandFatherByMale.AddWife(wifeGrandMatherByMale, "01.09.1976");
            wifeGrandFatherByFemale.AddWife(wifeGrandMatherByFemale, "25.05.1977");
            personWife.AddMother(wifeMother);
            personWife.AddFather(wifeFather);

            // Добавляем брак между персоной и женой
            person.AddWife(personWife, "10.10.2020");

            // Добавляем детей персоны
            person.AddSon(personSon);
            person.AddDaughter(personDaughter);


            // Получаем ближайших родственников муж/жен включая бывших
            var nearRelativesArray = person.GetNearRelatives();

            // Выводим на экран
            Console.WriteLine("Ближайшие родственники");
            person.PrintMemberInfo();

            foreach (FamalyMember member in nearRelativesArray)
            {
                Console.WriteLine("\nЖена:");
                member.PrintMemberInfo();
            }

            // Получаем ближайших родственников муж/жен включая бывших
            nearRelativesArray = personWife.GetNearRelatives();

            Console.WriteLine();

            // Выводим на экран
            Console.WriteLine("Ближайшие родственники");
            personWife.PrintMemberInfo();

            foreach (FamalyMember member in nearRelativesArray)
            {
                Console.WriteLine("\nМуж:");
                member.PrintMemberInfo();
            }
        }
    }
}
