# Midnight Customers Codebase Documentation
- Link to the [CHANGELOG](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/CHANGELOG.md).
- Link to the [Modifed Semantic Versioning](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/MSV.md) reference document.
- Link to the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) document.

## [AnimControl](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/AnimControl.cs)
### Description
DEPRECATED.
### Properties
| Name | Description |
|------|-------------|
| velocity | The [Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) velocity of this object. |
### References
| Name | Description |
|------|-------------|
| body | Reference to a [RigidBody2D](https://docs.unity3d.com/ScriptReference/Rigidbody2D.html) component. |
| animator | Reference to an [Animator](https://docs.unity3d.com/ScriptReference/Animator.html). |

## [CheckoutItem](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CheckoutItem.cs)
### Description
Putting this script on a prefab allows it to be purchased by customers at the register.
### Properties
| Name | Description |
|------|-------------|
| price | The price of the item that shows up on the register screen. |
| itemName | The name of the item. |
| weight | 1 for light, 2 for medium, and 3 for heavy. |
| requiresID | Whether the item requires an ID to purchase or not. |
| isScanned | Whether the item has been scanned or not. |
| foodItem | Whether the item is a food item or not. |
| paperItem | Whether the item is made of paper or not. |
### References
| Name | Description |
|------|-------------|
| checkoutManager | Reference to an instance of the [CheckoutManager](#checkoutmanager) class. |

## [CheckoutManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CheckoutManager.cs)
### Description
Manages all aspects of the checkout minigame.
### Properties
| Name | Description |
|------|-------------|
| itemNumber | The number of items the customer has brought to the checkout counter. |
| remainingItems | The number of items that still have to be bagged. |
| customerPayed | Whether the customer has paid yet or not. |
| passedIDCheck | NOT IN USE |
| finishedBag | Whether all the items have been scanned or not. |
| totalPrice | The total price of all scanned items. |
| dialogueFinished | Whether the dialogue has finished completely or not. |
| needsIDCheck | Whether an ID check is needed or not. |
| failedIDCheck | Whether an ID check was failed or not. |
| penaltyPoints | Sum of errors in current checkout interaction. |
| activePhase | The current active phase. |
### References
| Name | Description |
|------|-------------|
| checkoutTrigger | Reference to an instance of the [CheckoutTrigger](#checkouttrigger) class. |
| checkoutTimer | Reference to an instance of the [CheckoutTimer](#checkouttimer) class. |
| items | Array of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that are items brought to checkout. |
| spawnedItems | List of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) spawned. |
| customerInfo | Reference to an instance of the [CustomerInfo](#customerinfo) class. |
| activeRules | List of [Rule](#rule). |
| currentItem | Reference to an instance of the [CheckoutItem](#checkoutitem) class that represents the current item being checked out. |
| lastItem | Reference to an instance of the [CheckoutItem](#checkoutitem) class that represents the last item checked out. |
| firstCheckout | Whether this is the first checkout of the game or not. |
| soundManger | Reference to an instance of the [SoundManager](#soundmanager) class. |
| review | Reference to an instance of the [PerformanceReview](#performancereview) class. |
| emoter | Reference to an instance of the [EmoteController](#emotecontroller) class. |
| dialoguePlayer | Reference to an instance of the [DialoguePlayer](#dialogueplayer) class. |
| itemSpawns | An array of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) to spawn. |
| portraitLocation | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html) for the portrait location. |
| phase0Rules | Array of [Rule](#rule) for phase 0. |
| phase1Rules | Array of [Rule](#rule) for phase 1. |
| moneySpawn | Reference to a [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) where the money will be placed when spawned. |
| misbagMessage | Reference to the "Misbag" UI [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| idButton | Reference to the "ID Button" UI [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| hasIDMessage | Reference to the "Has ID" UI [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| noIDMessage | Reference to the "No ID" UI [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| priceText | Reference to the "price text" UI [Text](https://docs.unity3d.com/2017.3/Documentation/ScriptReference/UI.Text.html). |
| weightText | Reference to the "weight text" UI [Text](https://docs.unity3d.com/2017.3/Documentation/ScriptReference/UI.Text.html). |
### Methods
| Name | Description |
|------|-------------|
| LoadPhase1 | Adds all [Rule](#rules) from `phase1Rules` to the `activeRules`. |
| StartCheckout | Triggers a new checkout minigame. |
| EndDialogue | Ends the current dialogue, updates relationship, loads the next conversation, and ends checkout once dialogue is finished. |
| UpdateItem | Updates `lastItem` and the `currentItem`. |
| Bagged | Handles bagging of items. |
| GiveMoney | Makes customer put their money on the counter. |
| TakeMoney | Handles putting money into the cash register and ending checkout. |
| ScanItem | Adds item cost to running total, displays info on register. |
| PutAwayItem | Handles putting an item into the drawer and refunding the cost if scanned. |
| EndCheckout | Ends current checkout interaction. |
| GiveUp | Handles customer leaving early because player didn't attend to them. |
| DisplayWeight | Displays the weight of the item being scanned. |
| DisplayMessage | Displays a message for a set duration. |
| CheckID | Randomly determines if a customer has their ID or not. |

## [CheckoutTimer](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CheckoutTimer.cs)
### Description
Manages the countdown timer displayed during checkout that influences customer mood levels as well as if they leave before being checked out.
### Properties
| Name | Description |
|------|-------------|
| segments | How many segments make up the timer countdown bar. |
| maxValue | The value that the timer starts at. |
| isRunning | Whether the timer is running or not. |
| inCheckout | Whether the checkout UI is open or not. |
| timePassed | How much time has passed since timer started. |
| scale | How quickly the timer counts down. |
| currentMilestone | Index of the array for the most recently passed milestone. |
### References
| Name | Description |
|------|-------------|
| currentCustomer | Reference to an instance of the [CustomerInfo](#customerinfo) class. |
| slider | Reference to a [Slider](https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.Slider.html). |
| slideImage | Reference to an [Image](https://docs.unity3d.com/ScriptReference/UIElements.Image.html). |
| checkoutManager | Reference to an instance of the [CheckoutManager](#checkoutmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| SetMood | Manages changing moods of a customer. |
| StartTimer | Starts the checkout timer. |
| SetValues | Sets values for the time slider. |
| UpdateValue | Used to change value up or down if an action makes customer happy/unhappy. |
| ResetTimer | Resets the countdown timer. |

## [CheckoutTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CheckoutTrigger.cs)
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

## [CleanableObject](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/CleanableObject.cs)
### Description
### Properties
### References
### Public Methods
* Handles triggers for mop tasks
* Dependencies
	* [CleaningTool](#cleaningtool)
	* [CleanableObject](#cleanableobject)
	* [MopGame](#mopgame)

## [CleaningTool](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/CleaningTool.cs)
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
    
## [CountdownSlider](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CountdownSlider.cs)
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
	
## [CustomerManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/CustomerManager.cs)
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

## [CustomerMovement](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/CustomerMovement.cs)
### Properties
### References
### Public Methods
* Handles customer movement*
* Dependencies
    * [CustomerManager](#customermanager)
    * [SoundManager](#soundmanager)

## [DialogButtonClick](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/DialogButtonClick.cs)
### Description
### Properties
### References
### Public Methods

## [DragBulb](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/DragBulb.cs)
### Description
### Properties
### References
### Public Methods

## [DrawerTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/DrawerTrigger.cs)
### Description
### Properties
### References
### Public Methods

## [DynamicLayering](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/DynamicLayering.cs)
### Description
### Properties
### References
### Public Methods

## [EmoteController](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/EmoteController.cs)
### Description
### Properties
### References
### Public Methods
* Controls emote sprites
* Dependencies
* Referenced by
	* [CheckoutManager](#checkoutmanager)

## [EndingManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/EndingManager.cs)
### Description
### Properties
### References
### Public Methods

## [EndingText](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/EndingText.cs)
### Description
### Properties
### References
### Public Methods

## [Fade](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Fade.cs)
### Properties
### References
### Public Methods
* Handles fade to black at day transition
* Dependencies
* Referenced by
	* [TimeManager](#timemanager)

## [FlashLight](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/FlashLight.cs)
### Description
### Properties
### References
### Public Methods

## [GameControl](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/GameControl.cs)
### Properties
### References
### Public Methods
* Loads scenes

## [GlobalSave](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/GlobalSave.cs)
### Description
### Properties
### References
### Public Methods

## [Hatch](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Hatch.cs)
### Properties
### References
### Public Methods
* Handles hatch triggers 
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)

## [HatchStoryBeat](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Story/HatchStoryBeat.cs)
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

## [IDRule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rules/IDRule.cs)
### Description
### Properties
### References
### Public Methods

## [IceGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/IceGame.cs)
### Description
### Properties
### References
### Public Methods

## [IceTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/IceTrigger.cs)
### Description
### Properties
### References
### Public Methods

## [Interactable](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Interactable.cs)
### Properties
### References
### Public Methods
* Kind of confused, but it seems to handles interactable triggers and dialogue windows

## [InteractableManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/InteractableManager.cs)
### Description
### Properties
### References
### Public Methods

## [ItemBox](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/ItemBox.cs)
### Description
### Properties
### References
### Public Methods
* Handles item box
* Referenced by
	* [StockingItem](#stockingitem)

## [JournalDisplay](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/JournalDisplay.cs)
### Description
### Properties
### References
### Public Methods

## [LightChangeGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/LightChangeGame.cs)
### Description
### Properties
### References
### Public Methods

## [LightFlicker](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightFlicker.cs)
### Properties
### References
### Public Methods
* Handles lighting and turns it off/on (Is this inert?)
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [LightManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightManager.cs)
### Description
### Properties
### References
### Public Methods

## [LightSanityEffect](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightSanityEffect.cs)
### Properties
### References
### Public Methods
* Generates spooky effects (is this inert?)
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [MainMenuManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MainMenuManager.cs)
### Description
### Properties
### References
### Public Methods

## [MainMenuSound](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Sound/MainMenuSound.cs)
### Description
### Properties
### References
### Public Methods

## [MiniGameControl](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MiniGameControl.cs)
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

## [MiniGameTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MiniGameTrigger.cs)
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

## [Money](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Money.cs)
### Description
### Properties
### References
### Public Methods
* Handles Money colliders
* Dependencies
	* [CheckoutManager](#checkoutmanager)

## [MoodIndicator](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MoodIndicator.cs)
### Description
### Properties
### References
### Public Methods

## [MopGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MopGame.cs)
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

## [PaperRule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rules/PaperRule.cs)
### Description
### Properties
### References
### Public Methods

## [Pause](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Pause.cs)
### Properties
### References
### Public Methods
* Pauses the game by setting Time.timeScale to 1 or 0
* Brings up in game pause screen

## [PauseMenu](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PauseMenu.cs)
### Description
### Properties
### References
### Public Methods

## [PerformanceReview](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PerformanceReview.cs)
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

## [Phone](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Phone.cs)
### Properties
### References
### Public Methods
* ClosePhone (inert?)

## [PhoneMessage](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PhoneMessage.cs)
### Properties
### References
### Public Methods
* Opens messages 
* Dependencies
	* [PerformanceReview](#performancereview)

## [PlayerMovement](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PlayerMovement.cs)
### Properties
### References
### Public Methods
* Handles Player Movement (duh)
* Referenced by
	* [CheckoutTrigger](#checkouttrigger)
	* [MiniGameTrigger](#minigametrigger)
	* [TimeManager](#timemanager)
	* moveable bool is also referenced by the scripts above

## [PlayerTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PlayerTrigger.cs)
### Description
### Properties
### References
### Public Methods

## [PowerButton](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/PowerButton.cs)
### Description
### Properties
### References
### Public Methods

## [PowerGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/PowerGame.cs)
### Description
### Properties
### References
### Public Methods

## [PPManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PPManager.cs)
### Description
### Properties
### References
### Public Methods

## [RandomEventManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/RandomEventManager.cs)
### Description
### Properties
### References
### Public Methods

## [Rule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rule.cs)
### Description
### Properties
### References
### Public Methods

## [RuleBook](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rulebook.cs)
### Description
### Properties
### References
### Public Methods

## [SanityEventManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SanityEventManager.cs)
### Properties
### References
### Public Methods
* Handles Sanity Events and Light Effects (inert?)
* Dependencies
	* [SanityEventManager](#sanityeventmanager)
	* [LightSanityEffect](#lightsanityeffect)

## [SanityManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SanityManager.cs)
### Properties
### References
### Public Methods
* Manages Sanity Values (inert?)

## [SaveData](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SaveData.cs)
### Description
### Properties
### References
### Public Methods

## [SaveUtility](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SaveUtility.cs)
### Description
### Properties
### References
### Public Methods

## [ScrewBulb](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/ScrewBulb.cs)
### Description
### Properties
### References
### Public Methods

## [ScrollEffect](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/ScrollEffect.cs)
### Description
### Properties
### References
### Public Methods

## [SettingsScreen](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SettingsScreen.cs)
### Description
### Properties
### References
### Public Methods

## [Shelf](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/Shelf.cs)
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [SoundManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Sound/SoundManager.cs)
### Properties
### References
### Public Methods
* Manages BGM (inert?)
* Manages all sound effects
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)
    	* [CheckoutManager](#checkoutmanager)
	* [PlayerMovement](#playermovement)

## [SpriteFade](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SpriteFade.cs)
### Description
### Properties
### References
### Public Methods

## [StockingGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/StockingGame.cs)
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [StockingItem](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/StockingItem.cs)
### Description
### Properties
### References
### Public Methods
* I assume WIP
* Dependencies
	* [StockingGame](#stockinggame)
	* [ItemBox](#itembox)

## [StoryEventHandler](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Story/StoryEventHandler.cs)
### Description
### Properties
### References
### Public Methods
* Handles Story Events
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)
* Referenced by
	* [TimeManager](#timemanager)

## [TaskSpawner](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/TaskSpawner.cs)
### Properties
### References
### Public Methods
* Handles randomly spawning new tasks (also happens to murder unity in the process)
* Referenced By
	* [TaskManager](#taskmanager)

## [TimeManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/TimeManager.cs)
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

## [WeightRule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rules/WeightRule.cs)
### Description
### Properties
### References
### Public Methods

## [Wiggle](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Wiggle.cs)
### Description
### Properties
### References
### Public Methods