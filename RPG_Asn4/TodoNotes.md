//Todo: make some weather for the environment, tell it how many turns it takes to change the time of day
//have the characters comment on changes in the weather on the turn that makes sense or the current weather.
//night time characters could be different than daytime characters along with animals.

//Todo: Refactor social commands using the new `IReactable` interface.
// - Create `IReactable` interface with methods like `OnSlapped()`, `OnLaughedAt()`, `OnFlirtedWith()`, and `OnFartedAt()`.
// - Implement `IReactable` on `Npc.cs` and `Animal.cs` and give them their specific reactions.
// - Update `Command.cs` to check `if (c.CurrentTarget is IReactable reactable)` to trigger the reactions polymorphically without if/else chains.

The design pattern we were using to replace those giant if/else chains is called Polymorphism, and it perfectly demonstrates one of the most famous rules in software engineering: the Open/Closed Principle.

Here is a quick refresher on what those mean:

Polymorphism: This is a fancy Greek word that means "many forms." In C#, it means we can treat different objects (like an Animal and an Npc) as the exact same type (an IReactable) when we interact with them. We don't care what they are, we just care that they know how to react.
The Open/Closed Principle: This is the "O" in the famous S.O.L.I.D. principles of object-oriented programming. It states that a class (like your Command class) should be Open for extension, but Closed for modification.
Closed: You shouldn't have to constantly open Command.cs and modify it with a new else if every time you add a new monster or character type to your game.
Open: You can easily extend your game with Goblins, Ghosts, or Dragons, and as long as you put IReactable on them, the Command class will magically know how to slap, laugh, or flirt with them without changing a single line of code in Command.cs!
Using interfaces this way is also heavily related to the Strategy Pattern, where you delegate the specific behavior (the "strategy" of how to react) to the objects themselves.

Whenever you are ready to shake off the rust from the break, we can tackle adding OnFartedAt() to your IReactable interface and cleaning up that last command!