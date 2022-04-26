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
Handles triggering the checkout minigame.
### Properties
| Name | Description |
|------|-------------|
| playerReady | Whether the player is standing behind the register or not. |
| customerReady | Whether the customer is in front of the register and ready to checkout or not. |
| inCheckout | Whether the checkout minigame is running or not. |
### References
| Name | Description |
|------|-------------|
| playerMove | Reference to an instance of the [PlayerMovement](#playermovement) class. |
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| checkoutManager | Reference to an instance of the [CheckoutManager](#checkoutmanager) class. |
| checkoutTimer | Reference to an instance of the [CheckoutTimer](#checkouttimer) class. |
| checkoutGame | Reference to the checkout game object prefab. |
| customer | Reference to the customer that's ready to checkout. |
| customerInfo | Reference to an instance of the [CustomerInfo](#customerinfo) class. |
### Methods
| Name | Description |
|------|-------------|
| TriggerCheckout | Starts the checkout minigame. |
| EndCheckout | Ends the checkout minigame. |
* Handles the triggers for starting Checkout 
* Dependencies
	* [CheckoutManager](#checkoutmanager)
	* [CustomerInfo](#customerinfo)
	* [PlayerMovement](#playermovement)
* Referenced by
	* [CheckoutManager](#checkoutmanager)

## [CleanableObject](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/CleanableObject.cs)
### Description
Used on all objects that the player can clean.
### Properties
| Name | Description |
|------|-------------|
| isBeingCleaned | Whether the object is currently being cleaned or not. |
| passedTime | Time passed since cleaning started. |
| startingColor | The color before the object is cleaned. |
| hitpoints | The health of the object that needs cleaned. |
| cleanTime | The cleaning time. |
| currentAlpha | The current alpha value for transparency. |
| newColor | The new color to use after cleaning is finished. |
### References
| Name | Description |
|------|-------------|
| tool | Reference to an instance of the [CleaningTool](#cleaningtool) class. |
| mess | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
| mopGame | Reference to an instance of the [MopGame](#mopgame) class. |
### Methods
| Name | Description |
|------|-------------|
| setAlpha | Used to change the alpha value. |
* Handles triggers for mop tasks
* Dependencies
	* [CleaningTool](#cleaningtool)
	* [CleanableObject](#cleanableobject)
	* [MopGame](#mopgame)

## [CleaningTool](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/CleaningTool.cs)
### Description
Used on objects that the player can use to clean things.
### Properties
| Name | Description |
|------|-------------|
| oldPosition| A [Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html) representing the previous position of the cleaning tool. |
| newPosition| A [Vector3](https://docs.unity3d.com/ScriptReference/Vector3.html) representing the new position of the cleaning tool. |
| isCleaning | Whether the tool is currently cleaning or not. |
| toolName | The name of the tool. |
| cleaningThreshold | The cleaning threshold for the tool. |
### References
| Name | Description |
|------|-------------|
| rb | Reference to a [Rigidbody2D](https://docs.unity3d.com/ScriptReference/Rigidbody2D.html) component. |
| soundmanager | Reference to an instance of the [SoundManager](#soundmanager) class. |
* Handles position and rigidbody of CleaningTool
* Referenced by
	* [CleaningObject](#cleaningobject)

## [ClickDrag](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/ClickDrag.cs)
### Description
Handles input from mousePosition and OnMouseDown and allows the dragging of objects.
### Properties
| Name | Description |
|------|-------------|
| isHeld | Whether the item is being dragged currently. |
| startPosX | The starting position of the item being dragged. |
| startPosY | The starting position of the item being dragged. |
| startPosZ | The starting position of the item being dragged. |
### References
| Name | Description |
|------|-------------|
| sprite | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
* No Dependencies
* Referenced by:
	* [StockingItem](#stockingitem)
    
## [CountdownSlider](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/CountdownSlider.cs)
### Description
Controls the countdown slider during checkout minigame.
### Properties
| Name | Description |
|------|-------------|
| isCountingDown | Whether the timer is counting currently or not. |
| timePassed | How much time has passed on the timer. |
### References
| Name | Description |
|------|-------------|
| slider | Reference to an instance of the [Slider](#slider) class. |
### Methods
| Name | Description |
|------|-------------|
| SetValue | Sets the `value` of the `slider`. |
| SetMinMax | Sets the minimum, current, and maximum values for the slider. |
| StartCount | Starts the countdown of the timer. |
| Reset | Resets the timer back to its max value. |
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
| moodMilestones | Determines how to segment the mood timer. |
### References
| Name | Description |
|------|-------------|
| dialogueFont | [Font](https://docs.unity3d.com/Manual/class-Font.html) to use for this customer. |
| portrait | [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) to use for this customer. |
| checkoutItems | Objects this character will bring to the checkout counter. |
| carriedMoney | The amount of money carried by this character. |
| nextConversation | Reference to an instance of the [DialogueContainer](#dialoguecontainer) class that represents the conversation that this character will have next. |
| conversations | Reference to an array of [DialogueContainer](#dialoguecontainer) representing all conversations this character will progress through. |
### Methods
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
### Description
Handles spawning and despawning of customers in the store.
### Properties
| Name | Description |
|------|-------------|
| spawning | Whether the customer is spawning or not. |
| arrayPos | The position index in the array. |
### References
| Name | Description |
|------|-------------|
| lastCoroutine | The last [Coroutine](https://docs.unity3d.com/ScriptReference/Coroutine.html) ran. |
| customerManager | Reference to an instance of the [CustomerManager](#customermanager) class. |
| customers | The list of customers. |
| customerList | Each customer in array for save and loading purposes. |
| exit | A [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) for the exit point of the customers. |
| customersInStore | List of customers currently in the store. |
| endingManager | Reference to an instance of the [EndingManager](#endingmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| OnLoadGame | Starts spawning customers when the game starts. |
| LoadCustomer | Spawns a customer into the store and gets them moving and sets their mood. |
| CustomerExit | Despawns customers. |
| NextCustomer | IEnumerator handles delay between spawning next customer. |
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
### Description
Handles movement of NPC customers.
### Properties
| Name | Description |
|------|-------------|
| speed | Movement speed of the customer. |
| isWaiting | Whether the customer is waiting or not. |
| velocity | The velocity of the customer. |
| lastPosition | The last position of the customer. |
| minDistance | Margin of error to determine if customer has reached a waypoint. |
| destination | The destination of the customer. |
| timeToWait | How long the customer will wait at a waypoint before moving to the next one. |
| hasCheckedOut | Whether the customer has completed checking out or not. |
| readyForCheckout | Whether the customer is ready for checkout or not. |
### References
| Name | Description |
|------|-------------|
| customerManager | Reference to an instance of the [CustomerManager](#customermanager) class. |
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
| agent | Reference to a [NavMeshAgent2D](https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.html). |
| spriteRenderer | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
| animator | Reference to an [Animator](https://docs.unity3d.com/ScriptReference/Animator.html). |
| plannedPath | Array of [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) representing the waypoints the customer will travel along. |
| checkout | A [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) representing the location of the checkout zone. |
| exit | A [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) representing the location of the exit area. |
### Methods
| Name | Description |
|------|-------------|
| EnterStore | Called when customer spawns. Plays door sounds and activates the `agent`. |
| GoToNextPoint | Sends the customer to their next waypoint. |
| Wait | IEnumerator handling when customer is waiting either near exit or checkout zone. |
| FinishedCheckout | Finishes checkout minigame and sends customer to next waypoint. |
| ExitStore | Despawns the customer and triggers door sound. |
* Dependencies
    * [CustomerManager](#customermanager)
    * [SoundManager](#soundmanager)

## [DialogButtonClick](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/DialogButtonClick.cs)
### Description
Used to play a sound when a button is clicked.
### References
| Name | Description |
|------|-------------|
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| TriggerSound | Plays button click sound. |

## [DragBulb](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/DragBulb.cs)
### Description
Handles dragging of the lightbulb for the lightbulb changing minigame.
### References
| Name | Description |
|------|-------------|
| newBulb | The prefab for the new lightbulb. |

## [DrawerTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/DrawerTrigger.cs)
### Description
Handles dropping items into the drawer behind the counter and hides or shows the drawer.
### References
| Name | Description |
|------|-------------|
| sr | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |

## [DynamicLayering](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/DynamicLayering.cs)
### Description
Handles making sure the customers and player are always on the correct layer.
### Properties
| Name | Description |
|------|-------------|
| targetLayer | The target layer for the player and customers. |

## [EmoteController](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/EmoteController.cs)
### Description
Handles the display of the mood sprites for the NPC customers.
### References
| Name | Description |
|------|-------------|
| lastCoroutine | Reference to the last [Coroutine](https://docs.unity3d.com/ScriptReference/Coroutine.html) ran. |
| spriteRenderer | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
| happyEmote | Reference to the happy emote [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html). |
| sadEmote | Reference to the sad emote [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html). |
| angryEmote | Reference to the angry emote [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html). |
### Methods
| Name | Description |
|------|-------------|
| React | Changes the emotion sprites. |
| HideReaction | IEnumerator handling a dely between changing sprites. |
* Controls emote sprites
* Dependencies
* Referenced by
	* [CheckoutManager](#checkoutmanager)

## [EndingManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/EndingManager.cs)
### Description
Handles the various endings that exist in the game.
### References
| Name | Description |
|------|-------------|
| timeManager | Reference to an instance of the [TimeManager](#timemanager) class. |
| cultEnd | Reference to the cult ending prefab. |
| deepEnd | Reference to the deep one ending prefab. |
| investigatorEnd | Reference to the investigator ending prefab. |
| endingPhone | Reference to the ending phone prefab. |
| activeEnding | Reference to an instance of the [EndingText](#endingtext) class. |
### Methods
| Name | Description |
|------|-------------|
| StartEnding | Triggers the end of the game. |
| CultEnding | Triggers the cult ending. |
| DeepOneEnding | Triggers the deep one ending. |
| InvestigatorEnding | Triggers the investigator ending. |
| OnContinueButton | Makes it so the button method does not have to be set separately for each ending. |

## [EndingText](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/EndingText.cs)
### Description
Handles the text shown at the end of the game.
### Properties
| Name | Description |
|------|-------------|
| endingContents | The text to be shown at the end. |
| showArtTiming | How far into the array to switch from black screen to full art. |
| waitingForConfirm | Whether the game is waiting for confirmation or not? |
### References
| Name | Description |
|------|-------------|
| endingWindow | The prefab for the ending window. |
| endingTextDisplay | The [Text](https://docs.unity3d.com/2017.3/Documentation/ScriptReference/UI.Text.html) to display. |
| timeManager | Reference to an instance of the [TimeManager](#timemanager) class. |
| spriteRenderer | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
### Methods
| Name | Description |
|------|-------------|
| PlayText | Shows ending text and starts the `DisplayEnd()` IEnumerator. |
| DisplayEnd | IEnumerator handles showing text for the end letter by letter and fading screen. |

## [Fade](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Fade.cs)
### Description
Handles fading in and out of the screen.
### Properties
| Name | Description |
|------|-------------|
| fadeIN | Whether the screen is fading in currently or not. |
| fadeOUT | Whether the screen is fading out currently or not. |
| currentAlpha | The current alpha value of the screen. |
| duration | The duration of the fade. |
| passedTime | The time passed during fading. |
### References
| Name | Description |
|------|-------------|
| thisSprite | The [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) object that is being faded. |
| startingColor | The starting [Color](https://docs.unity3d.com/ScriptReference/Color.html) of `thisSprite`. |
| newColor | The new [Color](https://docs.unity3d.com/ScriptReference/Color.html) of `thisSprite` updated as fading is happening. |
### Methods
| Name | Description |
|------|-------------|
| FadeIn | Triggers screen fade in. |
| FadeOut | Triggers screen fade out. |
* Dependencies
* Referenced by
	* [TimeManager](#timemanager)
    
## [FinalJournalDisplay](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/FinalJournalDisplay.cs)
### Description
Handles displaying the journal.
### Properties
| Name | Description |
|------|-------------|
| journalText | Array of strings for journal text. |
| journalProgress | Amount of progress in the journal. |
| inJournal | Whether the journal is currently open or not. |
### References
| Name | Description |
|------|-------------|
| journal | Reference to the journal [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| displayText | Reference to the [Text](https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.Text.html) to display. |
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| OpenJournal | Opens up the `journal` for viewing. |
| IncrementPage | Turns the page. |
| DecrementPage | Goes to the previous page. |
| CloseJournal | Closes the `journal`. |

## [FlashLight](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/FlashLight.cs)
### Description
Handles behavior for the player-held flashlight.
### Properties
| Name | Description |
|------|-------------|
| on | Whether the flashlight is turned on or not. |
| rotateSpeed | How quickly the beam of the flashlight rotates. |
### References
| Name | Description |
|------|-------------|
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| fLight | Reference to a [Light2D](https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.0/api/UnityEngine.Experimental.Rendering.Universal.Light2D.html). |
### Methods
| Name | Description |
|------|-------------|
| ToggleFlashLight | Toggles the flashlight on and off. |

## [GameControl](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/GameControl.cs)
### Description
Handles loading scenes from normal day progression, or from saved games.
### Properties
| Name | Description |
|------|-------------|
| dayProg | The day progression. |
| customerProg | The customer progression. |
| individualProg | Individual progression. |
| loadingGame | Whether the game has been loaded from a previous save or not. |
| gameComplete | Whether the game has been completed or not. |
### References
| Name | Description |
|------|-------------|
| control | Reference to an instance of the [GameControl](#gamecontrol) class. |
| saveUtility | Reference to an instance of the [SaveUtility](#saveutility) class. |
| dataToLoad | Rerence to an instance of the [SaveData](#savedata) class. |
### Methods
| Name | Description |
|------|-------------|
| SaveGame | Saves the current game. |
| SetComplete | Sets `gameComplete` to true and updates the global save. |
| LoadSave | Loads a previous save. |
| ContinueGame | Continues the game (moves to next day?) |
| LoadScene | Loads the given scene. |

## [GlobalSave](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/GlobalSave.cs)
### Description
Manages saves.
### Properties
| Name | Description |
|------|-------------|
| saveFileNames | List of existing saves. |
| gameComplete | Whether the game has been completed or not. |
### Methods
| Name | Description |
|------|-------------|
| AddSave | Adds a new save to `saveFileNames`. |
| SetComplete | Sets `gameComplete` to true so complete journal is unlocked in the main menu. |

## [Hatch](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Hatch.cs)
### Description
Manages the secret hatch to the basement.
### Properties
| Name | Description |
|------|-------------|
| found | Whether the hatch has been found by the player or not. |
| inRange | Whether the player is close enough to interact with the hatch or not. |
### References
| Name | Description |
|------|-------------|
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| story | Reference to an instance of the [HatchStoryBeat](#hatchstorybeat) class. |
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)

## [HatchStoryBeat](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Story/HatchStoryBeat.cs)
### Description
Handles the story surrounding the secret hatch.
### References
| Name | Description |
|------|-------------|
| hatchFound | Reference to an instance of the [DialogueContainer](#dialoguecontainer) class. |
| hatchHint | Reference to an instance of the [DialogueContainer](#dialogcontainer) class. |
| investigator | Reference to the investigator [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| hintCustomer | Reference to the customer [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that gives hints about the hatch. |
| hatch | Reference to the hatch [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
### Methods
| Name | Description |
|------|-------------|
| StartStory | Makes the hatch discoverable. |
| FoundHatch | Lets the rest of the game know the player has found the hatch for story and dialogue purposes. |
* Dependencies
	* [CustomerInfo](#customerinfo)
* Referenced by
	* [Hatch](#hatch)
	* [StoryEventHandler](#storyeventhandler)

## [IDRule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rules/IDRule.cs)
### Description
Handles checking of customer ID for purchases that require an ID.
### Methods
| Name | Description |
|------|-------------|
| CheckRule | Checks to see if the customer passed the ID check or not. |

## [IceGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/IceGame.cs)
### Description
Manages the ice minigame.
### References
| Name | Description |
|------|-------------|
| mgControl | Reference to an instance of the [MiniGameControl](#minigamecontrol) class. |

## [IceTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/IceTrigger.cs)
### Description
Handles filling the ice machine with ice.
### Properties
| Name | Description |
|------|-------------|
| halfway | Whether the machine is half full or not. |
| done | Whether the machine is finished being filled or not. |
### References
| Name | Description |
|------|-------------|
| mgControl | Reference to an instance of the [MiniGameControl](#minigamecontrol) class. |
| first | Reference to the first ice [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)? |
| second | Reference to the second ice [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html)? |

## [Interactable](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Interactable.cs)
### Description
Handles things the player can interact with and their associated dialog boxes and interactable indicators.
### Properties
| Name | Description |
|------|-------------|
| inRange | Whether the object is close enough to the player to enable interaction or not. |
| interacting | Whether the player is currently interacting with the object or not. |
| messages | Array of messages. |
| progress | The amount of progress. |
### References
| Name | Description |
|------|-------------|
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| thoughtText | Reference to the thought text [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| thoughtWindow | Reference to the thought window [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
### Methods
| Name | Description |
|------|-------------|
| SetMessage | Sets the content of the message to be displayed. |
| TriggerInteractable | Starts and stops the interaction. |
| EndInteract | Stops the interaction. |
| DisplayMessage | Displays the message. |

## [InteractableManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/InteractableManager.cs)
### Description
Handles all interactable messages, objects, etc.
### Properties
| Name | Description |
|------|-------------|
| freezer_m | Message to be shown when interacting with the freezer. |
| freezer_1 | Another message to be shown when interacting with the freezer. |
| soda_m | Message to be shown when interacting with the soda machine. |
| soda_1 | Another message to be shown when interacting with the soda machine. |
| window_m | Message to be shown when interacting with the window. |
| window_1 | Another message for the window. |
| shelves_m | Message for the shelves. |
| shelves_1 | Another message for the shelves. |
| food_m | Message for the food. |
| food_1 | Another message for the food. |
### References
| Name | Description |
|------|-------------|
| freezer_reference | Reference to an instance of the [Interactable](#interactable) class. |
| soda_reference | Reference to an instance of the [Interactable](#interactable) class. |
| shelves_reference | Reference to an instance of the [Interactable](#interactable) class. |
| window_reference | Reference to an instance of the [Interactable](#interactable) class. |
| food_reference | Reference to an instance of the [Interactable](#interactable) class. |
### Methods
| Name | Description |
|------|-------------|
| UpdateInteractables | Updates the messages for all the interactables from the original messages to the second alternative ones. |

## [ItemBox](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/ItemBox.cs)
### Description
Handles the items that will be spawned and then placed on shelves during the stocking minigame.
### Properties
| Name | Description |
|------|-------------|
| boxOpen | Whether the box is open or not. |
### References
| Name | Description |
|------|-------------|
| openedBox | The opened box [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| itemsInBox | Array of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) inside the box. |
| boxSpawns | Array of [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) representing the locations that the items in the box will be spawned at. |
| spawnedItems | List of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) items that have already been spawned. |
| sprite | The [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html) representing the item box itself. |
### Methods
| Name | Description |
|------|-------------|
| UpdateItems | Updates the items in the item box and displays their images. |
| SelectItem | Removes item from the box. |
| OpenBox | Opens the box and displays the items inside. |
| CloseBox | Closes the box and destroys the items inside. |
| SpawnItems | Spawns the items in the box when it's opened. |
* Referenced by
	* [StockingItem](#stockingitem)

## [JournalDisplay](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/JournalDisplay.cs)
### Description
Handles displaying information in the journal.
### Properties
| Name | Description |
|------|-------------|
| journalText | List of text for the journal. |
| journalProgress | Amount of progress made in the journal. |
| inJournal | Whether the journal is currently open or not. |
### References
| Name | Description |
|------|-------------|
| journal | The journal [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| displayText | The [Text](https://docs.unity3d.com/2017.3/Documentation/ScriptReference/UI.Text.html) to be displayed. |
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| OpenJournal | Opens up the journal for viewing. |
| CloseJournal | Closes the journal. |

## [LightChangeGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/LightChangeGame.cs)
### Description
Handles the light bulb changing minigame.
### References
| Name | Description |
|------|-------------|
| mgControl | Reference to an instance of the [MiniGameControl](#minigamecontrol) class. |
| lightManager | Reference to an instance of the [LightManager](#lightmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| Finish | Ends the minigame. |
| EndGame | IEnumerator that gives a slight delay before ending the minigame. |

## [LightFlicker](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightFlicker.cs)
### Description
Handles the flickering of lights on and off.
### Properties
| Name | Description |
|------|-------------|
| timePassed | The time passed since the light was toggled. |
| lightOn | Whether the light is on or not. |
| frequency | How frequently the light will flicker. |
| offDuration | How long the light stays off during flickering. |
| offIntensity | How bright the light is when flickering off. |
| onIntensity | How bright the light is when flickering on. |
### References
| Name | Description |
|------|-------------|
| thisLight | Reference to the [Light](https://docs.unity3d.com/ScriptReference/Light.html). |
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [LightManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightManager.cs)
### Description
Manages all the lights.
### Properties
| Name | Description |
|------|-------------|
| normalGlobalIntensity | The default intensity for the lights. |
| normalColor | The default [Color](https://docs.unity3d.com/ScriptReference/Color.html) for the lights. |
### References
| Name | Description |
|------|-------------|
| randomEventManager | Reference to an instance of the [RandomEventManager](#randomeventmanager) class. |
| brokenLight | Reference to a broken [Light](https://docs.unity3d.com/ScriptReference/Light.html) that needs replaced in the light minigame. |
| ceilingLights | Array of [Light](https://docs.unity3d.com/ScriptReference/Light.html) on the ceiling. |
| miscLights | Array of various [Light](https://docs.unity3d.com/ScriptReference/Light.html) such as the fridge, register, etc. |
| windowLights | Array of [Light](https://docs.unity3d.com/ScriptReference/Light.html) for the windows. |
| globalLight | The global [Light](https://docs.unity3d.com/ScriptReference/Light.html). |
| flashLight | The [Light](https://docs.unity3d.com/ScriptReference/Light.html) for the player's flashlight. |
| lightingColor | Reference to a [Color](https://docs.unity3d.com/ScriptReference/Color.html) for the lights. |
| lightningSound | Reference to an [AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html) for the sound of lightning. |
| powerGameTrigger | The [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that triggers the start of the power minigame. |
| lightBulbTrigger | The [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that triggers the light bulb minigame. |
### Methods
| Name | Description |
|------|-------------|
| ChangeColor | Changes a given lights color and returns the old one for turning it back. |
| Strobe | Starts a strobe effect on a given light. |
| PowerOutage | Turns off all the lights and allows the power minigame to be started. |
| RestorePower | Turns all the lights back on. |
| CallLightning | Triggers a lightning strike. |
| LightningEffect | IEnumerator that creates a lightning strike with sounds and flashing. |
| ResetLight | Resets a light to the default color. |
| BreakBulb | Burns out a bulb. |
| FixBulb | Fixes a bulb so it can turn on again. |

## [LightSanityEffect](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/LightSanityEffect.cs)
### Description
Handles the light sanity effect. DEPRECATED
### Properties
| Name | Description |
|------|-------------|
| normalGlobalIntensity | The default normal intensity for global lights. |
| normalColor | The default light color. |
| effectDuration | The duration of the effect. |
### References
| Name | Description |
|------|-------------|
| targetLights | Array of [Light](https://docs.unity3d.com/ScriptReference/Light.html) that the sanity effect will be played on. |
| globalLight | The [Light](https://docs.unity3d.com/ScriptReference/Light.html) to be used for global lighting. |
### Methods
| Name | Description |
|------|-------------|
| RedLightScare | IEnumerator that makes certain lights flash red rapidly. |
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)

## [MainMenuManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MainMenuManager.cs)
### Description
Manages the buttons and features of the main menu.
### Properties
| Name | Description |
|------|-------------|
| loadButton | The [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) for the load button. |
| deleteSaveButton | The [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) for the delete save button. |
### Methods
| Name | Description |
|------|-------------|
| QuitGame | Exit the game to the desktop. |

## [MainMenuSound](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Sound/MainMenuSound.cs)
### Description
Handles sound effects for the main menu.
### References
| Name | Description |
|------|-------------|
| onOffButton | Reference to an [AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html) for the button click sound. |
### Methods
| Name | Description |
|------|-------------|
| PlayOnOffClick | Plays the `onOffButton` sound effect. |

## [MiniGameControl](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MiniGameControl.cs)
### Description
Manages loading and ending the various minigames.
### References
| Name | Description |
|------|-------------|
| camerPosition | Reference to the [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) of the camera. |
| currentTrigger | Reference to an instance of the [MiniGameTrigger](#minigametrigger) class. |
| currentGame | Reference to the [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that represents the current minigame. |
| taskSpawner | Reference to an instance of the [TaskSpawner](#taskspawner) class. |
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| LoadMiniGame | Instantiates and starts a minigame. |
| EndMiniGame | Stops the current minigame. |
* Dependencies
	* [MiniGameTrigger](#minigametrigger)
* Referenced by
	* [MiniGameTrigger](#minigametrigger)
	* [MopGame](#mopgame)

## [MiniGameTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MiniGameTrigger.cs)
### Description
Handles triggering the start and end of minigames.
### References
| Name | Description |
|------|-------------|
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| mgControl | Reference to an instance of the [MiniGameControl](#minigamecontrol) class. |
| playerMove | Reference to an instance of the [PlayerMovement](#playermovement) class. |
| minigame | The minigame [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) to be loaded. |
### Methods
| Name | Description |
|------|-------------|
| TriggerMiniGame | Freezes player movement and starts the minigame. |
| EndMiniGame | Allows player movement and ends the minigame. |
* Dependencies
	* [MinigameControl](#minigamecontrol)
	* [PlayerMovement](#playermovement)
* Referenced by
	* [MinigameControl](#minigamecontrol)

## [Money](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Money.cs)
### Description
Handles money transactions.
### Properties
| Name | Description |
|------|-------------|
| value | The value in dollars of the money. |
### References
| Name | Description |
|------|-------------|
| checkoutManager | Reference to an instance of the [CheckoutManager](#checkoutmanager) class. |
### Methods
* Dependencies
	* [CheckoutManager](#checkoutmanager)

## [MoodIndicator](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MoodIndicator.cs)
### Description
Handles displaying the moods of the customers.
### References
| Name | Description |
|------|-------------|
| spriteRenderer | Reference to a [SpriteRenderer](https://docs.unity3d.com/ScriptReference/SpriteRenderer.html). |
| happySprite | The [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) to be used for a happy customer. |
| sadSprite | The [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) to be used for a sad customer. |
| angrySprite | The [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) to be used for an angry customer. |
| pissedSprite | The [Sprite](https://docs.unity3d.com/ScriptReference/Sprite.html) to be used for a pissed off customer. |
### Methods
| Name | Description |
|------|-------------|
| SetMood | Sets and displays the correct sprite for the given mood. |
| HideEmote | Hides the mood sprite. |
| Hide | IEnumerator that introduces a delay before hiding the sprite. |

## [MopGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/MopGame.cs)
### Description
Handles the cleaning of dirt spots minigame.
### Properties
| Name | Description |
|------|-------------|
| remainingObjects | Number of objects remaining to be cleaned. |
### References
| Name | Description |
|------|-------------|
| cleanableObjects | Array of [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) that can be cleaned. |
| mgControl | Reference to an instance of the [MiniGameControl](#minigamecontrol) class. |
| dirt1 | Reference to a [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) representing a cleanable spot of dirt. |
| dirt2 | Reference to another [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) representing another cleanable spot of dirt. |
### Methods
| Name | Description |
|------|-------------|
| CleanedObject | Decreases the number of `remainingObjects` and ends the cleaning minigame when the objects are less than 1. |
* Dependencies
	* [CleanableObjects](#cleanableobjects)
	* [MiniGameControl](#minigamecontrol)
* Referenced By
	* [CleanableObjects](#cleanableobjects)

## [PaperRule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rules/PaperRule.cs)
### Description
Handles bagging rules for paper items.
### Methods
| Name | Description |
|------|-------------|
| CheckRule | Makes customer angry if a food item is put on top of a paper item. |

## [Pause](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Pause.cs)
### Description
Handles pausing and resuming of the game.
### Properties
| Name | Description |
|------|-------------|
| paused | Whether the game is paused or not. |
### References
| Name | Description |
|------|-------------|
| playerInput | Reference to an instance of the [PlayerInput](#playerinput) class. |
| pauseScreen | Reference to the [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) prefab representing the pause screen UI. |
| ppManager | Reference to an instance of the [PPManager](#ppmanager) class. |
| journalButton | Reference to the journal button [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) on the pause menu UI. |
| journalScreen | Reference to the journal screen [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
| settingsScreen | Reference to the settings screen [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html). |
### Methods
| Name | Description |
|------|-------------|
| TogglePause | Toggles pausing and resuming of the game. |
| LoadScene | Loads the given scene. |
| SaveAndQuit | Saves the game and quits to the main menu. |

## [PerformanceReview](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PerformanceReview.cs)
### Description
Handles which messages to send based on the performance score.
### Properties
| Name | Description |
|------|-------------|
| lastPenalty | The last penalty received |
| thisScore | Score on how well the player did from 0-3 with 0 being worse and 3 being best. |
| lastScore | Score of the last thing the player did. |
| totalPenaltyPoints | Total penalty points the player has accumulated. |
| dayPenaltyPoints | Total penalty points accumulated during the current day. |
| idErrors | The number of ID errors made. |
| baggingErrors | The number of bagging errors made. |
| goodMessage | The message displayed when performance is good. |
| badMessage | The message displayed when performance is bad. |
| neutralMessage | The message displayed when performance is average. |
| improvedMessage | The message displayed when performance has improved. |
### References
| Name | Description |
|------|-------------|
| phoneMessage | Reference to an instance of the [PhoneMessage](#phonemessage) class. |
| phoneNotification | Reference to the phone notification [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) prefab. |
| soundManager | Reference to an instance of the [SoundManager](#soundmanager) class. |
### Methods
| Name | Description |
|------|-------------|
| NewMessage | Triggers the phone to pop up with the provided string. |
| NewDay | Adds the `dayPenaltyPoints` to the `totalPenaltyPoints`, sets `lastPenalty` to what `dayPenaltyPoints` is, then resets `dayPenaltyPoints` to 0. |
| ReviewMessage | Sends the review text message to the phone. |
| MessageSelect | Chooses which message needs to be displayed. |
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
### Description
Handles the player phone object.
### Properties
### References
### Methods
* ClosePhone (inert?)

## [PhoneMessage](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PhoneMessage.cs)
### Description
Opens and displays messages on the phone.
### Properties
### References
### Methods
* Dependencies
	* [PerformanceReview](#performancereview)

## [PlayerMovement](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PlayerMovement.cs)
### Description
Handles player movement.
### Properties
### References
### Methods
* Referenced by
	* [CheckoutTrigger](#checkouttrigger)
	* [MiniGameTrigger](#minigametrigger)
	* [TimeManager](#timemanager)
	* moveable bool is also referenced by the scripts above

## [PlayerTrigger](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PlayerTrigger.cs)
### Description
### Properties
### References
### Methods

## [PowerButton](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/PowerButton.cs)
### Description
### Properties
### References
### Methods

## [PowerGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/PowerGame.cs)
### Description
### Properties
### References
### Methods

## [PPManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/PPManager.cs)
### Description
### Properties
### References
### Methods

## [RandomEventManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/RandomEventManager.cs)
### Description
### Properties
### References
### Methods

## [Rule](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rule.cs)
### Description
### Properties
### References
### Methods

## [RuleBook](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Checkout/Rulebook.cs)
### Description
### Properties
### References
### Methods

## [SanityEventManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SanityEventManager.cs)
### Description
Handles sanity events and light effects.
### Properties
### References
### Methods
* Dependencies
	* [SanityEventManager](#sanityeventmanager)
	* [LightSanityEffect](#lightsanityeffect)

## [SanityManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SanityManager.cs)
### Description
Manages sanity values.
### Properties
### References
### Methods

## [SaveData](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SaveData.cs)
### Description
### Properties
### References
### Methods

## [SaveUtility](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SaveUtility.cs)
### Description
### Properties
### References
### Methods

## [ScrewBulb](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/ScrewBulb.cs)
### Description
### Properties
### References
### Methods

## [ScrollEffect](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/ScrollEffect.cs)
### Description
### Properties
### References
### Methods

## [SettingsScreen](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SettingsScreen.cs)
### Description
### Properties
### References
### Methods

## [Shelf](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/Shelf.cs)
### Description
### Properties
### References
### Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [SoundManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Sound/SoundManager.cs)
### Description
Manages sounds and music.
### Properties
### References
### Methods
* Referenced by
	* [LightSanityEffect](#lightsanityeffect)
    	* [CheckoutManager](#checkoutmanager)
	* [PlayerMovement](#playermovement)

## [SpriteFade](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/SpriteFade.cs)
### Description
### Properties
### References
### Methods

## [StockingGame](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/StockingGame.cs)
### Description
### Properties
### References
### Methods
* I assume WIP
* Referenced by
	* [StockingItem](#stockingitem)

## [StockingItem](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/MG%20Scripts/StockingItem.cs)
### Description
### Properties
### References
### Methods
* I assume WIP
* Dependencies
	* [StockingGame](#stockinggame)
	* [ItemBox](#itembox)

## [StoryEventHandler](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Story/StoryEventHandler.cs)
### Description
Handles story events.
### Properties
### References
### Methods
* Dependencies
	* [HatchStoryBeat](#hatchstorybeat)
* Referenced by
	* [TimeManager](#timemanager)

## [TaskSpawner](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/TaskSpawner.cs)
### Description
Handles spawning new tasks.
### Properties
### References
### Methods
* Referenced By
	* [TaskManager](#taskmanager)

## [TimeManager](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/TimeManager.cs)
### Description
Manages the passage of time and days.
### Properties
### References
### Methods
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
### Methods

## [Wiggle](https://github.com/cjw20/Midnight-Customers-Prototype-2/blob/main/Midnight%20Customers%20Prototype%202/Assets/Scripts/Wiggle.cs)
### Description
### Properties
### References
### Methods