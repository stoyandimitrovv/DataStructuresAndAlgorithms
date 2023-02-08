using System;

namespace MovieCharacters
{
    public class Character : IComparable<Character>
    {
        public Character(string name, string role, bool isMainCharacter)
        {
            this.Name = name;
            this.Role = role;
            this.IsMainCharacter = isMainCharacter;
        }

        public string Name { get; set; }

        public string Role { get; set; }

        public bool IsMainCharacter { get; set; }

        public int CompareTo(Character other)
        {
            int compareRoleMain = other.IsMainCharacter.CompareTo(this.IsMainCharacter);
            if (compareRoleMain != 0)
            {
                return compareRoleMain;
            }

            int compareRole = this.Role.CompareTo(other.Role);
            return compareRole == 0
                ? this.Name.CompareTo(other.Name)
                : compareRole;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Role}";
        }
    }
}
