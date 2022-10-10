using System;

namespace VCproj.DataBase
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