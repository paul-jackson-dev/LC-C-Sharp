

using Technology;

Laptop newLaptop = new(50, 100, true, 11);
Console.WriteLine(newLaptop.ToString());

newLaptop.AddGPU(250);
Console.WriteLine(newLaptop.ToString());

Computer a = (Computer)newLaptop;
Console.WriteLine(a.ToString());