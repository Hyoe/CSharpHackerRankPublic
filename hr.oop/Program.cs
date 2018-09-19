using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
///   Complete the implementation below however you see fit. (Hint: Use Object Oriented Programming techniques)
///
///   Requirements
///     -Create a Dog class
///        -with the following properties
///           -Id : int
///           -Name : string
///           -Age : int
///           -SortOrder : int
///           -Bread : string
///        -with the following methods
///           -Print()
///              -Displays 3 lines using Console.WriteLine()
///                 -Id - (dog's Id here)
///                 -Name - (dog's Name here)
///                 -Bread - (dog's bread here)
///     -Create a Cat class 
///        -with the following properties
///           -Id : int
///           -Name : string
///           -Age : int
///           -SortOrder : int
///           -Lives : int
///        -with the following methods
///           -Print()
///              -Displays 3 lines using Console.WriteLine()
///                 -Id - (cat's Id here)
///                 -Name - (cat's Name here)
///                 -Lives - (cat's lives here)
/// </summary>
class Solution
{
    private interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        int SortOrder { get; set; }

        void Print();
    }

    /**********************************************************************/
    /***                 Implement Classes Here                         ***/
    /**********************************************************************/


    //todo


    private static void printDashes()
    {
        Console.WriteLine("--------------------");
    }

    private static List<Dog> dogs;
    private static List<Cat> cats;


    static void Main(String[] args)
    {

        dogs = new List<Dog>()
        {
            new Dog() {Id = 1, Name = "Fido", Age = 10, SortOrder = 2, Bread = "Akita"},
            new Dog() {Id = 2, Name = "Spot", Age = 1, SortOrder = 0, Bread = "German Shepherd"},
            new Dog() {Id = 3, Name = "Sam", Age = 4, SortOrder = 0, Bread = "Labrador Retriever"},
            new Dog() {Id = 4, Name = "Jim", Age = 12, SortOrder = 5, Bread = "Akita"},
            new Dog() {Id = 5, Name = "Spotty", Age = 2, SortOrder = 4, Bread = "German Shepherd"},
            new Dog() {Id = 6, Name = "Alfred", Age = 4, SortOrder = 1, Bread = "Labrador Retriever"}
        };


        cats = new List<Cat>()
        {
            new Cat() {Id = 1, Name = "Fido", Age = 10, SortOrder = 2, Lives = 4},
            new Cat() {Id = 2, Name = "Spot", Age = 1, SortOrder = 0, Lives = 9},
            new Cat() {Id = 3, Name = "Sam", Age = 4, SortOrder = 0, Lives = 1},
            new Cat() {Id = 4, Name = "Jim", Age = 12, SortOrder = 5, Lives = 2},
            new Cat() {Id = 5, Name = "Spotty", Age = 2, SortOrder = 4, Lives = 5},
            new Cat() {Id = 6, Name = "Alfred", Age = 4, SortOrder = 1, Lives = 6}
        };

        foreach (var dog in dogs)
        {
            dog.Print();
        }

        foreach (var cat in cats)
        {
            cat.Print();
        }

        Console.Read();
    }
}