using System.Collections;
using System.Collections.Generic;

public interface ICharacter
{
    void Attack();
    void UseAbility();
}

public class Character : ICharacter
{
    public string Name { get; set; }

    public void Attack()
    {
        Console.WriteLine($"{Name} атакует!");
    }

    public void UseAbility()
    {
        Console.WriteLine($"{Name} использует способность.");
    }
}

public interface IParty
{
    void Atack(ICharacter character);
    void UseAbility();
}

public class Party : IParty, IEnumerable<ICharacter>
{
    private readonly List<ICharacter> _members = new List<ICharacter>();

    public IEnumerator<ICharacter> GetEnumerator()
    {
        return _members.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddMember(ICharacter character)
    {
        if (!_members.Contains(character))
            _members.Add(character);
    }

    public void Atack(ICharacter target)
    {
        foreach (var member in _members)
        {
            member.Attack();
        }
    }

    public void UseAbility()
    {
        foreach (var member in _members)
        {
            member.UseAbility();
        }
    }

    public IReadOnlyCollection<ICharacter> Members
    {
        get { return _members.AsReadOnly(); }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var party = new Party();
        var hero1 = new Character { Name = "Герой 1" };
        var hero2 = new Character { Name = "Герой 2" };
        party.AddMember(hero1);
        party.AddMember(hero2);
        var enemy = new Character { Name = "Противник" };
        party.Atack(enemy);
        party.UseAbility();
    }
}