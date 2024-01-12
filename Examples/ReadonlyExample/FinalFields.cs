using System;
namespace ReadonlyExample
{
	public class FinalFields
	{
        public readonly int intValue = 42;
        public readonly double doubleValue;
        private readonly FortyTwo objectValue = new FortyTwo();

        public FinalFields()
		{
		}

        public FortyTwo ObjectValue => objectValue;
    }
}

