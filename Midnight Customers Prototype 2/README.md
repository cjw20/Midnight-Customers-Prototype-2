# Midnight Customers Codebase Documentation
- Link to the [CHANGELOG](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/CHANGELOG.md).
- Link to the [Modifed Semantic Versioning](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/MSV.md) reference document.
- Link to the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) document.

## [AnimControl]()
### Description
### Properties
### References
### Public Methods

## [CheckoutItem]()
### Description
### Properties
### References
### Public Methods
* Handles triggers of checkoutManager 
* Dependencies
	* [CheckoutManager](#checkoutmanager)
* Referenced by:
	* [CheckoutManager](#checkoutmanager)

## [CheckoutManager]()
### Description
### Properties
### References
### Public Methods
* Manages Checkout Process
* Dependencies
	* [CheckoutTrigger](#checkouttrigger)
	* [EmoteController](#emotecontroller)
	* [CheckoutItem](#checkoutitem)
    * SoundManager
* Referenced by
	* [DialoguePlayer](#dialogueplayer)
	* [CheckoutItem](#checkoutitem)
	* [CheckoutTrigger](#checkouttrigger)
	* [Money](#money)
	* [CheckoutItem](#checkoutitem)

## [CheckoutTimer]()
### Description
### Properties
### References
### Public Methods

## [CheckoutTrigger]()
### Description
### Properties
### References
### Public Methods
* Handles the triggers for starting Checkout 
* Dependencies
	* [CheckoutManager](#checkoutmanager)
	* [CustomerInfo](#customerinfo)
	* [PlayerMovement](#playermovement)
* Referenced by
	* [CheckoutManager](#checkoutmanager)

## [CleanableObject]()
### Description
### Properties
### References
### Public Methods
* Handles triggers for mop tasks
* Dependencies
	* [CleaningTool](#cleaningtool)
	* [CleanableObject](#cleanableobject)
	* [MopGame](#mopgame)

## [CleaningTool]()
### Description
### Properties
### References
### Public Methods
* Handles position and rigidbody of CleaningTool
* Referenced by
	* [CleaningObject](#cleaningobject)

## [ClickDrag](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/ClickDrag.cs)
### Description
Handles input from mousePosition and OnMouseDown
### Properties
| Name | Description |
|------|-------------|
| isHeld | Whether the item is being dragged currently. |
| startPosX | The starting position of the item being dragged. |
| startPosY | The starting position of the item being dragged. |
| startPosZ | The starting position of the item being dragged. |
* No Dependencies
* Referenced by:
	* [StockingItem](#stockingitem)
    
## [CountdownSlider]()
### Description
### Properties
### References
### Public Methods
* Manages Slider (?)
* Dependencies
* Referenced by
	* [DialoguePlayer](#dialogueplayer)

## [CustomerInfo](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/CustomerInfo.cs)
### Description
Handles information about customer (Dialogue, Money, ID, Relationship)
### Properties
| Name | Description |
|------|-------------|
| customerName | Name of the customer. |
| relationshipScore | The current relationship score the player has with this character. |
| hasValidID | Whether the character has a valid ID or not. |
| essential | Set to `true` if the character should NOT leave when the timer runs out. |
| conversationProgress | How far the player is into the conversations with this character. |
| moodMilestones[] | Determines how to segment the mood timer. |
### References
| Name | Description |
|------|-------------|
| dialogueFont | Font to use for this customer. |
| portrait | Sprite to use for this customer. |
| checkoutItems[] | Objects this character will bring to the checkout counter. |
| carriedMoney[] | The amount of money carried by this character. |
| nextConversation | Next conversation that this character will have next. |
| conversations[] | All conversations this character will progress through. |
### Public Methods
| Name | Description |
|------|-------------|
| LoadNextConvo | Loads the next conversation. |
| UpdateRelationship | Adds or subtracts from the relationship score for this customer. |
| SetStoryConvo | Moves the story conversation progress. |
* Dependencies
* Referenced by: 
	* [CheckoutManager](#checkoutmanager)
	* [CheckoutTrigger](#checkouttrigger)
	* [HatchStoryBeat](#hatchstorybeat)
	
## [CustomerManager]()
### Properties
| Name | Description |
|------|-------------|
| spawning | Whether the customer is spawning or not. |
| arrayPos | The position index in the array. |
### References
| Name | Description |
|------|-------------|
| lastCoroutine | The last Coroutine ran. |
| customerManager | Reference to an instance of the CustomerManager class. |
| customers[] | The list of customers. |
| customerList[] | Each customer in array for save and loading purposes. |
| exit | A Transform for the exit point of the customers. |
| customersInStore[] | List of customers currently in the store. |
| endingManager | Reference to an instance of the EndingManager class. |
### Public Methods
| Name | Description |
|------|-------------|
| OnLoadGame | Starts spawning customers when the game starts. |
| LoadCustomer | Spawns a customer into the store and gets them moving and sets their mood. |
| CustomerExit | Despawns customers. |
| StopSpawns | Stops customers spawning. |
| StartSpawns | Resumes customer spawning. |
| PauseSpawns | Pauses customer spawning. |
* Dependencies
	* [CustomerMovement](#customermovement) (customersInStore assumes CustomerMovement component)
* Referenced by:
	* [TimeManager](#timemanager)
	* [CustomerMovement](#customermovement)
	* Itself?

## [CustomerMovement]()
### Properties
### References
### Public Methods
* Handles customer movement*
* Dependencies
    * [CustomerManager](#customermanager)
    * [SoundManager](#soundmanager)

## [DialogButtonClick]()
### Description
### Properties
### References
### Public Methods

## [DragBulb]()
### Description
### Properties
### References
### Public Methods

## [DrawerTrigger]()
### Description
### Properties
### References
### Public Methods

## [DynamicLayering]()
### Description
### Properties
### References
### Public Methods

## [EmoteController]()
### Description
### Properties
### References
### Public Methods
* Controls emote sprites
* Dependencies
* Referenced by
	* [CheckoutManager](#checkoutmanager)

## [EndingManager]()
### Description
### Properties
### References
### Public Methods

## [EndingText]()
### Description
### Properties
### References
### Public Methods

## [Fade]()
### Properties
### References
### Public Methods
* Handles fade to black at day transition
* Dependencies
* Referenced by
	* [TimeManager](#timemanager)

## [FlashLight]()
### Description
### Properties
### References
### Public Methods

## [GameControl]()
### Properties
### References
### Public Methods
* Loads scenes

## [GlobalSave]()
### Description
### Properties
### References
### Public Methods

## [Hatch]()
### Properties
### References
### Public Methods
* Handles hatch triggers 
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)

## [HatchStoryBeat]()
### Description
### Properties
### References
### Public Methods
* Handles Hatch Event
* Dependencies
	* [CustomerInfo](#customerinfo)
* Referenced by
	* [Hatch](#hatch)
	* [StoryEventHandler](#storyeventhandler)

## [IceGame]()
### Description
### Properties
### References
### Public Methods

## [Interactable]()
### Properties
### References
### Public Methods
* Kind of confused, but it seems to handles interactable triggers and dialogue windows

## [InteractableManager]()
### Description
### Properties
### References
### Public Methods

## [ItemBox]()
### Description
### Properties
### References
### Public Methods
* Handles item box
* Referenced by
	* [StockingItem](#stockingitem)

## [JournalDisplay]()
### Description
### Properties
### References
### Public Methods

## [LightChangeGame]()
### Description
### Properties
### References
### Public Methods

## [LightFlicker]()
### Properties
### References
### Public Methods
* Handles lighting and turns it off/on (Is this inert?)
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [LightManager]()
### Description
### Properties
### References
### Public Methods

## [LightSanityEffect]()
### Properties
### References
### Public Methods
* Generates spooky effects (is this inert?)
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [MainMenuManager]()
### Description
### Properties
### References
### Public Methods

## [MainMenuSound]()
### Description
### Properties
### References
### Public Methods

## [MiniGameControl]()
### Description
### Properties
### References
### Public Methods
* Loads and Ends Minigames
* Dependencies
	* [MiniGameTrigger](#minigametrigger)
* Referenced by
	* [MiniGameTrigger](#minigametrigger)
	* [MopGame](#mopgame)

## [MiniGameTrigger]()
### Description
### Properties
### References
### Public Methods
* Handles triggers for minigames
* Dependencies
	* [MinigameControl](#minigamecontrol)
	* [PlayerMovement](#playermovement)
* Referenced by
	* [MinigameControl](#minigamecontrol)

## [Money]()
### Description
### Properties
### References
### Public Methods
* Handles Money colliders
* Dependencies
	* [CheckoutManager](#checkoutmanager)

## [MoodIndicator]()
### Description
### Properties
### References
### Public Methods

## [MopGame]()
### Description
### Properties
### References
### Public Methods
* Handles cleanableObjects
* Dependencies
	* [CleanableObjects](#cleanableobjects)
	* [MiniGameControl](#minigamecontrol)
* Referenced By
	* [CleanableObjects](#cleanableobjects)

## [Pause]()
### Properties
### References
### Public Methods
* Pauses the game by setting Time.timeScale to 1 or 0
* Brings up in game pause screen

## [PauseMenu]()
### Description
### Properties
### References
### Public Methods

## [PerformanceReview]()
### Properties
### References
### Public Methods
* Handles which message to send based on the performance score
* Dependencies
	* [phoneNotification](#phonenotification) (assumes its a phone)
	* [PhoneMessage](#phonemessage)
	* [DayPenaltyPoints](#daypenaltypoints)
		* [CheckoutManager](#checkoutmanager)
		* [PerformanceReview](#performancereview)
* Referenced by
	* [CheckoutManager](#checkoutmanager)
	* [TimeManager](#timemanger)

## [Phone]()
### Properties
### References
### Public Methods
* ClosePhone (inert?)

## [PhoneMessage]()
### Properties
### References
### Public Methods
* Opens messages 
* Dependencies
	* [PerformanceReview](#performancereview)

## [PlayerMovement]()
### Properties
### References
### Public Methods
* Handles Player Movement (duh)
* Referenced by
	* [CheckoutTrigger](#checkouttrigger)
	* [MiniGameTrigger](#minigametrigger)
	* [TimeManager](#timemanager)
	* moveable bool is also referenced by the scripts above

## [PlayerTrigger]()
### Description
### Properties
### References
### Public Methods

## [PowerButton]()
### Description
### Properties
### References
### Public Methods

## [PowerGame]()
### Description
### Properties
### References
### Public Methods

## [PPManager]()
### Description
### Properties
### References
### Public Methods

## [RandomEventManager]()
### Description
### Properties
### References
### Public Methods

## [Rule]()
### Description
### Properties
### References
### Public Methods

## [RuleBook]()
### Description
### Properties
### References
### Public Methods

## [SanityEventManager]()
### Properties
### References
### Public Methods
* Handles Sanity Events and Light Effects (inert?)
* Dependencies
	* [SanityEventManager](#sanityeventmanager)
	* [LightSanityEffect](#lightsanityeffect)

## [SanityManager]()
### Properties
### References
### Public Methods
* Manages Sanity Values (inert?)

## [SaveData]()
### Description
### Properties
### References
### Public Methods

## [SaveUtility]()
### Description
### Properties
### References
### Public Methods

## [ScrewBulb]()
### Description
### Properties
### References
### Public Methods

## [ScrollEffect]()
### Description
### Properties
### References
### Public Methods

## [SettingsScreen]()
### Description
### Properties
### References
### Public Methods

## [Shelf]()
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [SoundManager]()
### Properties
### References
### Public Methods
* Manages BGM (inert?)
* Manages all sound effects
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)
    	* [CheckoutManager](#checkoutmanager)
	* [PlayerMovement](#playermovement)

## [SpriteFade]()
### Description
### Properties
### References
### Public Methods

## [StockingGame]()
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [StockingItem]()
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Dependencies
	* [StockingGame](#stockinggame)
	* [ItemBox](#itembox)

## [StoryEventHandler]()
### Description
### Properties
### References
### Public Methods
* Handles Story Events
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)
* Referenced by
	* [TimeManager](#timemanager)

## [TaskSpawner]()
### Properties
### References
### Public Methods
* Handles randomly spawning new tasks (also happens to murder unity in the process)
* Referenced By
	* [TaskManager](#taskmanager)

## [TimeManager]()
### Properties
### References
### Public Methods
* Manages the display and passage of time 
* Dependencies:
	* [Player](#player)
	* [PlayerMovement](#playermovement)
	* [PerformanceReview](#performancereview)
	* [StoryEventHandler](#storyeventhandler)
	* [TaskSpawner](#taskspawner)
	* [CustomerManager](#customermanager)

## [Wiggle]()
### Description
### Properties
### References
### Public Methods