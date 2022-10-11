using System;

namespace DataBase.Tables
{
    internal class ForeignKeyAttribute : Attribute
    {
        public ForeignKeyAttribute(string v)
        {
            V = v;
        }

        public string V { get; }
    }
}