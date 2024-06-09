

namespace Task1
{
    public class FamalyMember
    {
        private Marriage[]? _marriages = null;

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? BirthPlace { get; set; }
        public string? ResidencePlace { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public enum Gender { Male, Female }
        public Gender MemberGender { get; set; }
        public FamalyMember? Mother { get; private set; } = null;
        public FamalyMember? Father { get; private set; } = null;
        public FamalyMember? Wife { get; private set; } = null;
        public FamalyMember? Husband { get; private set; } = null;
        public FamalyMember[]? Children { get; private set; } = null;
        public FamalyMember[]? Sons { get; private set; } = null;
        public FamalyMember[]? Daughters { get; private set; } = null;

        public FamalyMember(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public FamalyMember(string name, string surname, string birthday)
        {
            this.Name = name;
            this.Surname = surname;

            if (birthday != null)
            {
                this.Birthday = DateTime.Parse(birthday);
                this.Age = DateTime.Now.Year - this.Birthday.Value.Year;

                if (DateTime.Now.Month - this.Birthday.Value.Month < 0 ||
                   (DateTime.Now.Month - this.Birthday.Value.Month == 0 &&
                    DateTime.Now.Day - this.Birthday.Value.Day < 0)) this.Age -= 1;
            }
            else
            {
                this.Birthday = DateTime.Now;
                this.Age = 0;
            }
        }

        public void AddMother(FamalyMember mother)
        {
            this.Mother = mother;
            this.Mother.MemberGender = Gender.Female;

            if (this.MemberGender == Gender.Male)
            {
                if (this.Mother.Sons is null)
                {
                    this.Mother.Sons = [this];
                }
                else
                {
                    AddMemeberToArray(this, this.Mother.Sons);
                }
            }
            else if (this.MemberGender == Gender.Female)
            {
                if (this.Mother.Name is null)
                {
                    this.Mother.Daughters = [this];
                }
                else
                {
                    AddMemeberToArray(this, this.Mother.Daughters!);
                }
            }

            if (this.Mother.Children is null)
            {
                this.Mother.Children = [this];
            }
            else
            {
                AddMemeberToArray(this, this.Mother.Children);
            }
        }

        public void AddFather(FamalyMember father)
        {
            this.Father = father;
            this.Father.MemberGender = Gender.Male;

            if (this.MemberGender == Gender.Male)
            {
                if (this.Father.Sons is null)
                {
                    this.Father.Sons = [this];
                }
                else
                {
                    AddMemeberToArray(this, this.Father.Sons);
                }
            }
            else if (this.MemberGender == Gender.Female)
            {
                if (this.Father.Name is null)
                {
                    this.Father.Daughters = [this];
                }
                else
                {
                    AddMemeberToArray(this, this.Father.Daughters!);
                }
            }

            if (this.Father.Children is null)
            {
                this.Father.Children = [this];
            }
            else
            {
                AddMemeberToArray(this, this.Father.Children);
            }
        }

        public void AddSon(FamalyMember son)
        {
            son.MemberGender = Gender.Male;

            if (this.Sons is null)
            {
                this.Sons = [son];
            }
            else
            {
                AddMemeberToArray(son, this.Sons);
            }

            if (this.Children is null)
            {
                this.Children = [son];
            }
            else
            {
                AddMemeberToArray(son, this.Sons);
            }

            if (this.MemberGender == Gender.Male)
            {
                if (this.Wife!.Children is null)
                {
                    this.Wife.Children = [son];
                }
                else
                {
                    AddMemeberToArray(son, this.Wife.Children);
                }

                if (this.Wife!.Sons is null)
                {
                    this.Wife.Sons = [son];
                }
                else
                {
                    AddMemeberToArray(son, this.Wife.Sons);
                }
            }
            else if (this.MemberGender == Gender.Female)
            {
                if (this.Husband!.Children is null)
                {
                    this.Husband.Children = [son];
                }
                else
                {
                    AddMemeberToArray(son, this.Husband.Children);
                }

                if (this.Husband!.Sons is null)
                {
                    this.Husband.Sons = [son];
                }
                else
                {
                    AddMemeberToArray(son, this.Husband.Sons);
                }
            }
        }

        public void AddDaughter(FamalyMember daughter)
        {
            daughter.MemberGender = Gender.Female;

            if (this.Daughters is null)
            {
                this.Daughters = [daughter];
            }
            else
            {
                AddMemeberToArray(daughter, this.Daughters);
            }

            if (this.Children is null)
            {
                this.Children = [daughter];
            }
            else
            {
                AddMemeberToArray(daughter, this.Children);
            }

            if (this.MemberGender == Gender.Male)
            {
                if (this.Wife!.Children is null)
                {
                    this.Wife.Children = [daughter];
                }
                else
                {
                    AddMemeberToArray(daughter, this.Wife.Children);
                }

                if (this.Wife!.Daughters is null)
                {
                    this.Wife.Daughters = [daughter];
                }
                else
                {
                    AddMemeberToArray(daughter, this.Wife.Daughters);
                }
            }
            else if (this.MemberGender == Gender.Female)
            {
                if (this.Husband!.Children is null)
                {
                    this.Husband.Children = [daughter];
                }
                else
                {
                    AddMemeberToArray(daughter, this.Husband.Children);
                }

                if (this.Husband!.Daughters is null)
                {
                    this.Husband.Daughters = [daughter];
                }
                else
                {
                    AddMemeberToArray(daughter, this.Husband.Daughters);
                }
            }
        }

        private void AddMemeberToArray(FamalyMember member, FamalyMember[] memberArray)
        {
            var newArray = new FamalyMember[memberArray.Length + 1];
            memberArray.CopyTo(newArray, 0);
            newArray[memberArray.Length] = member;
            memberArray = newArray;
        }

        public void AddWife(FamalyMember wife, string dateOfMarriage)
        {
            if (this.Wife is not null)
            {
                Console.WriteLine($"Челен семьи уже женат, что бы добавить новую жену, сначала челен семьи должен развестись!");
                return;
            }

            this.Wife = wife;
            this.Wife.MemberGender = Gender.Female;
            var currentMarriage = new Marriage { Wife = this.Wife, Husband = this, DateOfMarriage = DateTime.Parse(dateOfMarriage) };

            if (this._marriages is null)
            {
                this._marriages = [currentMarriage];
            }
            else
            {
                var newMarriageArray = new Marriage[this._marriages!.Length + 1];
                this._marriages.CopyTo(newMarriageArray, 0);
                newMarriageArray[this._marriages!.Length] = currentMarriage;
                this._marriages = newMarriageArray;
            }
            
            if (this.Wife._marriages is not null)
            {
                bool isInMarriageObject = false;
                foreach (Marriage marriage in this.Wife._marriages)
                {
                    if (marriage.Husband.Equals(this))
                    {
                        isInMarriageObject = true;
                        break;
                    }
                }
                if (!isInMarriageObject) this.Wife.AddHusband(this, dateOfMarriage);
            }
            else
            {
                this.Wife.AddHusband(this, dateOfMarriage);
            }
        }

        public void AddHusband(FamalyMember husband, string dateOfMarriage)
        {
            if (this.Husband is not null)
            {
                Console.WriteLine($"Челен семьи уже замужем, что бы добавить нового мужв, сначала челен семьи должен развестись!");
                return;
            }

            this.Husband = husband;
            this.Husband.MemberGender = Gender.Male;
            var currentMarriage = new Marriage { Wife = this, Husband = this.Husband, DateOfMarriage = DateTime.Parse(dateOfMarriage) };

            if (this._marriages is null)
            {
                this._marriages = [currentMarriage];
            }
            else
            {
                var newMarriageArray = new Marriage[this._marriages!.Length + 1];
                this._marriages.CopyTo(newMarriageArray, 0);
                newMarriageArray[this._marriages!.Length] = currentMarriage;
                this._marriages = newMarriageArray;
            }

            if (this.Husband._marriages is not null)
            {
                bool isInMarriageObject = false;
                foreach (Marriage marriage in this.Husband._marriages)
                {
                    if (marriage.Wife.Equals(this))
                    {
                        isInMarriageObject = true;
                        break;
                    }
                }
                if (!isInMarriageObject) this.Husband.AddWife(this, dateOfMarriage);
            }
            else
            {
                this.Husband.AddWife(this, dateOfMarriage);
            }
        }

        private void SortMarriage(Marriage[] mariages)
        {
            if (mariages.Length == 1) return;

            var newMarriageArray = new Marriage[mariages.Length];
            newMarriageArray = mariages.OrderBy(m => m.DateOfMarriage).ToArray();
            mariages = newMarriageArray;
        }

        public FamalyMember[] GetNearRelatives()
        {
            if (this.MemberGender == Gender.Male && (this._marriages is not null))
            {
                if (this._marriages!.Length > 1)
                {
                    var result = new FamalyMember[this._marriages.Length];
                    for (int i = 0; i < this._marriages.Length; i++)
                    {
                        result[i] = this._marriages[i].Wife;
                    }

                    return result;
                }
                else
                {
                    return [this.Wife!];
                }
            }
            else
            {
                if (this._marriages!.Length > 1)
                {
                    var result = new FamalyMember[this._marriages.Length];
                    for (int i = 0; i < this._marriages.Length; i++)
                    {
                        result[i] = this._marriages[i].Husband;
                    }

                    return result;
                }
                else
                {
                    return [this.Husband!];
                }
            }

        }
        public void PrintMemberInfo()
        {
            Console.WriteLine($"{this.Name} {this.Surname} {this.Birthday}");
        }
    }

}
