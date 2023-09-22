namespace ActorLib
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }

        public void ValidateName()
        {
            if(Name == null || Name.Length < 4)
            {
                throw new ArgumentException($"Name can't be null, or less than 4: {Name}");
            }
        }

        public void ValidateBirthYear()
        {
            if(BirthYear < 1820)
            {
                throw new ArgumentOutOfRangeException($"Birthyear needs to be from 1820 or later");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateBirthYear();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(BirthYear)}={BirthYear.ToString()}}}";
        }
    }
}