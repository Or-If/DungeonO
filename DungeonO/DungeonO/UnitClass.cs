﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonO
{
    internal class Unit
    {
        protected string _name;
        protected int _health;
        protected int _maxHealth;
        protected int _damage;

        public Unit(string name)
        {
            _name = name;
        }

        //
        public void AttackOther(Unit other)
        {
            other.Hurt(Damage);
            AttackMessage(other);
        }

        public void Hurt(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                DeathMessage();
            }
        }

        //
        protected virtual void DeathMessage()
        {
            Console.WriteLine("Some kind of death");
        }

        protected virtual void AttackMessage(Unit other)
        {
            Console.WriteLine("Some kind of Metal clanging noise");
        }

        // 
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; } 
        }

        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
    }

    class Slime : Unit
    {

        public Slime(string name) : base(name)
        {
            _damage = 1;
            _maxHealth = 3;
            _health = _maxHealth;
        }

        protected override void DeathMessage() {
            Console.WriteLine(_name + " the Slime, has erupted into soooo many pieces... gross?");
        }

        protected override void AttackMessage(Unit other)
        {
            Console.WriteLine(_name + " the Slime, glorps all over you, it stings... grosss");
        }
    }

    class Player : Unit
    {

        public Player(string name) : base(name)
        {
            _damage = 3;
            _maxHealth = 6;
            _health = _maxHealth;
        }

        protected override void DeathMessage()
        {
            Console.WriteLine("You have been killed, how unfortunate...");
        }

        protected override void AttackMessage(Unit other)
        {
            Console.WriteLine("You strike the " + other.Name + " with great force dealing " + Damage);
        }
    }

}
