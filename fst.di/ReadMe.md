# fst.di Instructions

1. Create and implement two implementations of the IBoxFactory interface called RealBoxFactory and FakeBoxFactory. 
    * The boxes created can be of any size you wish as long as they are different
2. Add the configuration in Startup.cs to register your implementations of IBoxFactory
    * Register these services as a Singleton
    * Use FakeBoxFactory when in the Development environment
    * Use RealBoxFactory when in the Production environment

Note: You can switch between Development and Production environments by clicking the drop down arrow next to the "Play" / Debug button in Visual studio
