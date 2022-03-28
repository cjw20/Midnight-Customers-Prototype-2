# **Midnight Customers**
- Link to the [CHANGELOG](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/CHANGELOG.md).
- Link to the [Modifed Semantic Versioning](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/MSV.md) reference document.
(Eventually will be full documentation, for now this is just for reference)


## __General Scripts__

### [ClickDrag](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/ClickDrag.cs)
#### Description
Handles input from mousePosition and OnMouseDown
#### Properties
| Name | Description |
|------|-------------|
| isHeld | Whether the item is being dragged currently. |
| startPosX | The starting position of the item being dragged. |
| startPosY | The starting position of the item being dragged. |
| startPosZ | The starting position of the item being dragged. |
* No Dependencies
* Referenced by:
	* [StockingItem](#stockingitem)

### [CustomerInfo](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/CustomerInfo.cs)
#### Description
Handles information about customer (Dialogue, Money, ID, Relationship)
#### Properties
| Name | Description |
|------|-------------|
| customerName | Name of the customer. |
| relationshipScore | The current relationship score the player has with this character. |
| hasValidID | Whether the character has a valid ID or not. |
| essential | Set to `true` if the character should NOT leave when the timer runs out. |
| conversationProgress | How far the player is into the conversations with this character. |
| moodMilestones[] | Determines how to segment the mood timer. |
#### References
| Name | Description |
|------|-------------|
| dialogueFont | Font to use for this customer. |
| portrait | Sprite to use for this customer. |
| checkoutItems[] | Objects this character will bring to the checkout counter. |
| carriedMoney[] | The amount of money carried by this character. |
| nextConversation | Next conversation that this character will have next. |
| conversations[] | All conversations this character will progress through. |
#### Public Methods
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
	
### CustomerManager
* Handles customer spawning
* Dependencies
	* CustomerMovement (customersInStore assumes CustomerMovement component)
* Referenced by:
	* TimeManager
	* CustomerMovement
	* Itself?

### CustomerMovement
* Handles customer movement*
* Dependencies
    * CustomerManager
    * SoundManager

### Fade
* Handles fade to black at day transition
* Dependencies
* Referenced by
	* TimeManager

### GameControl
* Loads scenes

### Hatch
* Handles hatch triggers 
* Dependencies
	* HatchStoryBeat

### Interactable
* Kind of confused, but it seems to handles interactable triggers and dialogue windows

### LightFlicker
* Handles lighting and turns it off/on (Is this inert?)
* Referenced by
	* LightSanityEffect

### LightSanityEffect
* Generates spooky effects (is this inert?)
* Referenced by
	* LightSanityEffect

### Pause
* Pauses the game by setting Time.timeScale to 1 or 0
* Brings up in game pause screen

### PerformanceReview
* Handles which message to send based on the performance score
* Dependencies
	* phoneNotification (assumes its a phone)
	* PhoneMessage
	* dayPenaltyPoints
		* CheckoutManager
		* PerformanceReview
* Referenced by
	* CheckoutManager
	* TimeManager

### Phone
* ClosePhone (inert?)

### PhoneMessage
* Opens messages 
* Dependencies
	* PerformanceReview

### PlayerMovement
* Handles Player Movement (duh)
* Referenced by
	* CheckoutTrigger
	* MiniGameTrigger
	* TimeManager
	* moveable bool is also referenced by the scripts above

### SanityEventManager
* Handles Sanity Events and Light Effects (inert?)
* Dependencies
	* SanityEventManager
	* LightSanityEffect

### SanityManager
* Manages Sanity Values (inert?)

### SoundManager
* Manages BGM (inert?)
* Manages all sound effects
* Referenced by
	* LightSanityEffect
    	* CheckoutManager
	* PlayerMovement

### TaskSpawner
* Handles randomly spawning new tasks (also happens to murder unity in the process)
* Referenced By
	*TaskManager (commented, cuz it breaks the game)

### TimeManager
* Manages the display and passage of time 
* Dependencies:
	* Player
	* PlayerMovement
	* PerformanceReview
	* StoryEventHandler
	* TaskSpawner
	* CustomerManager

## **Checkout**

### CheckoutItem
* Handles triggers of checkoutManager 
* Dependencies
	* CheckoutManager
* Referenced by:
	* CheckoutManager

### CheckoutManager
* Manages Checkout Process
* Dependencies
	* CheckoutTrigger
	* EmoteController
	* Checkout Item
    * SoundManager
* Referenced by
	* DialoguePlayer
	* CheckoutItem
	* CheckoutTrigger
	* Money
	* CheckoutItem

### CheckoutTrigger
* Handles the triggers for starting Checkout 
* Dependencies
	* CheckoutManager
	* CustomerInfo
	* playerMovement
Referenced by
	* CheckoutManager

### CountdownSlider
* Manages Slider (?)
* Dependencies
* Referenced by
	* DialoguePlayer

### EmoteController
* Controls emote sprites
* Dependencies
* Referenced by
	* CheckoutManager

### Money
* Handles Money colliders
* Dependencies
	* CheckoutManager

### Rulebook
* Opens Rulebook

## **MG Scripts**

### CleanableObject
* Handles triggers for mop tasks
* Dependencies
	* CleaningTool
	* CleanableObject
	* MopGame

### CleaningTool
* Handles position and rigidbody of CleaningTool
* Referenced by
	* CleaningObject

### ItemBox
* Handles item box
* Referenced by
	* StockingItem

### MiniGameControl
* Loads and Ends Minigames
* Dependencies
	* MiniGameTrigger
* Referenced by
	* MiniGameTrigger
	* MopGame

### MiniGameTrigger
* Handles triggers for minigames
* Dependencies
	* MinigameControl
	* PlayerMovement
* Referenced by
	* MinigameControl

### MopGame
* Handles cleanableObjects
* Dependencies
	* CleanableObjects
	* MiniGame Control
* Referenced By
	* CleanableObjects

### Shelf
* I assume WIP
* Referenced by
	* StockingItem

### StockingGame
* I assume WIP
* Referenced by
	* StockingItem

### StockingItem
* I assume WIP
* Dependencies
	* StockingGame
	* ItemBox

## **Story**

### HatchStoryBeat
* Handles Hatch Event
* Dependencies
	* CustomerInfo
* Referenced by
	* Hatch
	* StoryEventHandler

### StoryEventHandler
* Handles Story Events
* Dependencies
	* HatchStoryBeat
* Referenced by
	* TimeManager
