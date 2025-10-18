# 🚗 Coin Collector Car Game

A simple 3D driving game built with Unity where the player controls a car to collect coins and avoid obstacles. This project focuses on core Unity systems including Rigidbody physics, UI management, audio controls via the Mixer, and particle effects.

## ✨ Features

* **Physics-Based Movement:** Car movement controlled via Rigidbody functions (`MovePosition`, `MoveRotation`) for stable, reliable physics and collision detection.
* **Collectibles & Win Condition:** Collect coins to increase the score. Game ends upon collecting a set number of coins.
* **Obstacles & Collision:** Player must avoid obstacles. Collisions trigger sound effects and visual feedback.
* **Scene Management:** Ability to restart the current level by pressing the **'R' key**.
* **Comprehensive Settings Panel:**
    * **Volume Control:** UI Slider connected to the Audio Mixer to dynamically adjust music volume.
    * *Note: While a music toggle was requested, the provided code only handles the volume slider.*
* **Dynamic Audio & SFX:**
    * **Engine Sound:** Looping engine rumble with dynamic pitch adjustment based on acceleration.
    * **Brake Screech:** Plays a realistic screech sound when the player sharply reverses direction.
    * **Coin/Collision Sounds:** Dedicated sound effects for picking up coins and hitting obstacles.
* **Particle Systems:**
    * **Dust Burst:** A particle effect (dust) is instantiated at the contact point when the car collides with a solid object.
    * **Coin Shimmer:** A sparkle/shimmer particle effect plays when a coin is collected.

## 🛠️ Key Technologies & Scripts

### PlayerController.cs

The core script handling player input, movement, game state, and triggering effects.

* **Input:** Uses standard Unity Input (`GetAxis("Horizontal")`, `GetAxis("Vertical")`) for smooth control.
* **Physics:** Movement is handled in `FixedUpdate()` using `rb.MovePosition` and `rb.MoveRotation`.
* **Collision Detection:** Uses `OnCollisionEnter` for physical hits (dust particle spawn) and `OnTriggerEnter` for pickups (coins, obstacles).
* **Sound Logic:** Includes custom methods like `ControlEngineSound()` and `ControlBrakeSound()` for dynamic audio feedback.

### CoinPickup.cs

A simple script attached to the Coin Prefab, responsible for its localized behavior.

* **`CollectCoin()`:** Called by the `PlayerController` upon trigger. This method manages the instantiation of the **shimmer particle prefab** and deactivates the coin object.

### Particle System Integration

The project uses a standard pattern for instantiating particle effects:

1.  **Dust:** Spawned via `Instantiate()` in `PlayerController.OnCollisionEnter` at the collision point (`collision.contacts[0].point`).
2.  **Shimmer:** Spawned via `Instantiate()` in `CoinPickup.CollectCoin()` at the coin's position (`transform.position`).

## ⚙️ Setup and Dependencies

To run this project correctly, ensure the following are configured in Unity:

1.  **Audio Mixer:** A dedicated "Music" **Audio Mixer Group** must be created, and its volume parameter must be **exposed to script** and named **`MusicVolume`**.
2.  **Scene in Build:** The main game scene must be added to the **Build Settings** for the restart functionality (`SceneManager.LoadScene`) to work.
3.  **Tags:**
    * Collectibles must be tagged **`CoinPickUp`**.
    * Obstacle triggers must be tagged **`Obstacle`**.
4.  **Inspector Links:** All public variables must be linked:
    * **Player Car:** All `AudioSource` slots, the `dustParticlePrefab`, `countText`, and `winTextObject`.
    * **Coin Prefab:** The `shimmerParticlePrefab` must be linked to the `CoinPickup.cs` script.

## 🕹️ Controls

| Action | Key/Axis |
| :--- | :--- |
| **Accelerate/Brake** | W/S or Vertical Axis |
| **Steering** | A/D or Horizontal Axis |
| **Honk Horn** | **Spacebar** |
| **Restart Scene** | **R Key** |