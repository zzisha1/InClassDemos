<Query Kind="Program" />

void Main()
{
	//"hello" + "don" + "world"
	
	//5+7
	//string name = "don";
	//string message = "hello" + name;
	//message.Dump();
	Sayhello("Don ");
}

// Define other methods and classes here
public void Sayhello(string name)
{
	string message = "hello " + name + "world";
	message.Dump();
}